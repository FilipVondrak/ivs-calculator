empty = 0
SOLUTION = ivs_calc_proj/ivs_calc_proj.sln
SOLUTION_RUN = ivs_calc_proj/ivs_calc_proj.csproj
TEST_PROJECT = math_tests/math_tests.csproj
STDDEV_PROJECT = stddev/stddev.csproj
DOC_CONFIG = Doxyfile
PACKAGE_DIR = xvondrf00_xbondam00_xbondao00_xkrausv00

# Improved OS detection
ifeq ($(OS),Windows_NT)
    RM = if exist "$(1)" ( del /s /q "$(1)" )
    RMDIR = if exist "$(1)" ( rmdir /s /q "$(1)" )
    ZIP = powershell -noprofile -executionpolicy bypass -command " \
          $$tempDir = Join-Path $$env:TEMP 'package_temp'; \
          $$repoDir = Join-Path $$tempDir 'repo'; \
          $$installDir = Join-Path $$tempDir 'install'; \
          $$docDir = Join-Path $$tempDir 'doc'; \
          New-Item -ItemType Directory -Path $$tempDir -Force | Out-Null; \
          New-Item -ItemType Directory -Path $$repoDir -Force | Out-Null; \
          New-Item -ItemType Directory -Path $$installDir -Force | Out-Null; \
          New-Item -ItemType Directory -Path $$docDir -Force | Out-Null; \
          Copy-Item -Path '..$(SEP)install$(SEP)*' -Destination $$installDir -Recurse -Force; \
          Copy-Item -Path 'doc$(SEP)*' -Destination $$docDir -Recurse -Force; \
          if (Test-Path 'doc') { Remove-Item -Path 'doc' -Recurse -Force; } \
          Copy-Item -Path '..$(SEP)*' -Destination $$repoDir -Recurse -Force; \
          Compress-Archive -Force -Path (Join-Path $$tempDir '*') -DestinationPath '$(PACKAGE_DIR).zip'; \
          Remove-Item -Path $$tempDir -Recurse -Force"
    SEP = \\
    CLEAN_BIN_OBJ = powershell -noprofile -executionpolicy bypass -command "if ((Test-Path 'bin') -Or (Test-Path 'obj')) { Get-ChildItem -Recurse -Directory -Include bin,obj | Remove-Item -Recurse -Force }"
    IS_WINDOWS = 1
    DOTNET_9_INSTALLED := $(shell (dotnet --list-sdks 2> nul | findstr /r "9\.0" > nul && echo yes) || echo no)
else
    RM = test ! -e "$(1)" || rm -rf "$(1)"
    RMDIR = test ! -e "$(1)" || rm -rf "$(1)"
    ZIP = mkdir -p /tmp/package_temp && \
          { [ -d "../install" ] && cp -r ../install/. /tmp/package_temp/install/ || true; } && \
          { [ -d "doc" ] && { cp -r doc/. /tmp/package_temp/doc/ && rm -rf doc; } || true; } && \
          cp -r ..$(SEP)/. /tmp/package_temp/repo/ && \
          cd /tmp/package_temp && \
          zip -r "$(CURDIR)/$(PACKAGE_DIR).zip" * && \
          cd - && \
          rm -rf /tmp/package_temp
    SEP = /
    CLEAN_BIN_OBJ = test ! -e bin && test ! -e obj || find . -type d \( -name bin -o -name obj \) -exec rm -rf {} +
    IS_WINDOWS = 0
    DOTNET_9_INSTALLED := $(shell dotnet --list-sdks | grep -q '9\.0' && echo yes || echo no)
endif

# Default target
all: run

# Build all projects including stddev
build: check-dotnet
	dotnet build $(SOLUTION)
	dotnet build $(STDDEV_PROJECT)

# Run tests
test: check-dotnet
	dotnet test $(TEST_PROJECT)

# Generate documentation
doc:
	doxygen $(DOC_CONFIG)

# Run the calculator application
run: build
	dotnet run --project $(SOLUTION_RUN)

# Run the stddev application
stddev: check-dotnet
	dotnet run --project $(STDDEV_PROJECT) -- random_1000.txt

# Create package for submission
pack: clean doc
	$(ZIP)

# Clean build artifacts
clean: check-dotnet
	dotnet clean $(SOLUTION)
	dotnet clean $(STDDEV_PROJECT)
	$(CLEAN_BIN_OBJ)
	$(call RM,$(PACKAGE_DIR).zip)
	$(call RMDIR,doc)

# Make usage
help:
	@echo "Usage: make [target]"
	@echo ""
	@echo "Available targets:"
	@echo "  all       - Default target, runs the calculator application"
	@echo "  build     - Builds all projects including stddev"
	@echo "  test      - Runs unit tests"
	@echo "  doc       - Generates documentation using Doxygen"
	@echo "  run       - Runs the calculator application"
	@echo "  stddev    - Runs the standard deviation application"
	@echo "  pack      - Creates a submission package"
	@echo "  clean     - Cleans build artifacts and temporary files"
	@echo "  help      - Displays this help message"

check-dotnet:
ifneq ($(DOTNET_9_INSTALLED),yes)
	@echo ".NET 9.0 not installed. Installing..."
	@$(MAKE) install-dotnet
endif

# Instalace .NET 9.0 podle OS
install-dotnet:
ifeq ($(IS_WINDOWS),1)
	@echo "Installing .NET 9.0 SDK via PowerShell..."
	@powershell -NoProfile -ExecutionPolicy Bypass -Command "[Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12; $$ProgressPreference = 'SilentlyContinue'; \
	Invoke-WebRequest -Uri 'https://dotnet.microsoft.com/download/dotnet/scripts/v1/dotnet-install.ps1' -OutFile \"$$env:TEMP\dotnet-install.ps1\""
	@powershell -NoProfile -ExecutionPolicy Bypass -Command "& \"$$env:TEMP\dotnet-install.ps1\" -Channel 9.0 -Version latest -InstallDir \"$$env:USERPROFILE\.dotnet\""
	@powershell -NoProfile -ExecutionPolicy Bypass -Command "[System.Environment]::SetEnvironmentVariable('DOTNET_ROOT', \"$$env:USERPROFILE\.dotnet\", 'User'); \
	[System.Environment]::SetEnvironmentVariable('Path', \"$$env:Path;$$env:USERPROFILE\.dotnet\", 'User')"
	@echo "Verifying installation..."
	@powershell -NoProfile -Command "& \"$$env:USERPROFILE\.dotnet\dotnet.exe\" --version"
else
	@echo "Detected Linux, installing .NET 9.0..."
	wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
	sudo dpkg -i packages-microsoft-prod.deb
	rm packages-microsoft-prod.deb
	sudo apt-get update
	sudo apt-get install -y dotnet-sdk-9.0
endif
	@echo "Instalace .NET 9.0 dokončena."

# Phony targets
.PHONY: all build test doc run stddev pack clean help check-dotnet install-dotnet