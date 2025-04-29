empty = 0
SOLUTION = ivs_calc_proj/ivs_calc_proj.sln
SOLUTION_RUN = ivs_calc_proj/ivs_calc_proj.csproj
TEST_PROJECT = math_tests/math_tests.csproj
STDDEV_PROJECT = stddev/stddev.csproj
DOC_CONFIG = Doxyfile
PACKAGE_DIR = ivs-projekt2-kalkulacka

# Improved OS detection
ifeq ($(OS),Windows_NT)
    RM = if exist "$(1)" ( del /s /q "$(1)" )
    RMDIR = if exist "$(1)" ( rmdir /s /q "$(1)" )
    MKDIR = if not exist "$(1)" ( mkdir "$(1)" )
    CP = xcopy /e /i /q /y "$(1)" "$(2)"
    CPFILE = copy /y "$(1)" "$(2)"
    ZIP = powershell -noprofile -executionpolicy bypass -command "Compress-Archive -Force -Path '..$(SEP)..$(SEP)ivs-projekt2-kalkulacka' -DestinationPath '$(PACKAGE_DIR).zip'"
    SEP = \\
    CLEAN_BIN_OBJ = powershell -noprofile -executionpolicy bypass -command "if ((Test-Path 'bin') -Or (Test-Path 'obj')) { Get-ChildItem -Recurse -Directory -Include bin,obj | Remove-Item -Recurse -Force }"
    IS_WINDOWS = 1
else
    RM = test ! -e "$(1)" || rm -rf "$(1)"
    RMDIR = test ! -e "$(1)" || rm -rf "$(1)"
    MKDIR = mkdir -p "$(1)"
    CP = cp -r "$(1)" "$(2)"
    CPFILE = cp "$(1)" "$(2)"
    ZIP = zip -r "$(PACKAGE_DIR).zip" "..$(SEP)..$(SEP)ivs-projekt2-kalkulacka"
    SEP = /
    CLEAN_BIN_OBJ = test ! -e bin && test ! -e obj || find . -type d \( -name bin -o -name obj \) -exec rm -rf {} +
    IS_WINDOWS = 0
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
pack: clean
	$(ZIP)

# Clean build artifacts
clean: check-dotnet
	dotnet clean $(SOLUTION)
	dotnet clean $(STDDEV_PROJECT)
	$(CLEAN_BIN_OBJ)
	$(call RM,$(PACKAGE_DIR).zip)
	$(call RMDIR,docs)

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

# Zjistí jestli je nainstalován .NET 9.0
DOTNET_9_INSTALLED := $(shell dotnet --list-sdks | grep -q '9\.0' && echo yes || echo no)

check-dotnet:
ifeq ($(DOTNET_9_INSTALLED),no)
	@echo ".NET 9.0 not installed. Installing..."
	@$(MAKE) install-dotnet
endif

# Instalace .NET 9.0 podle OS
install-dotnet:
ifeq ($(IS_WINDOWS),1)
	@echo "Instalace .NET 9.0 via PowerShell..."
	@powershell -NoProfile -ExecutionPolicy Bypass -Command "[Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12; $$ProgressPreference = 'SilentlyContinue'; Invoke-WebRequest -Uri 'https://dotnet.microsoft.com/download/dotnet/scripts/v1/dotnet-install.ps1' -OutFile \"$$env:TEMP\dotnet-install.ps1\""
	@powershell -NoProfile -ExecutionPolicy Bypass -Command "& \"$$env:TEMP\dotnet-install.ps1\" -Channel 9.0 -Runtime dotnet -InstallDir \"$$env:USERPROFILE\.dotnet\""
	@powershell -NoProfile -ExecutionPolicy Bypass -Command "[System.Environment]::SetEnvironmentVariable('Path', \"$$($$env:Path);$$($$env:USERPROFILE)\.dotnet\", 'User')"
	@echo "Instalace dokončena. Aktuální PATH:"
	@powershell -NoProfile -Command "$$env:Path"
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