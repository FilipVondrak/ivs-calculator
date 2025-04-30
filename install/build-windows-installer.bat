@echo off
setlocal

:: Set project paths and names
set PROJECT_NAME=ivs_calc_proj
set PROJECT_PATH=..\src\ivs_calc_proj\%PROJECT_NAME%.csproj
set OUTPUT_DIR=..\out\win-x64
set EXE_NAME=ivs_calc_proj_starymedved.exe
set ISS_SCRIPT=windows-inno-script.iss

:: Clean old output
echo Cleaning output directory...
if exist "%OUTPUT_DIR%" rmdir /s /q "%OUTPUT_DIR%"

:: Build and publish with .NET
echo Publishing .NET project...
dotnet publish "%PROJECT_PATH%" ^
  -c Release ^
  -r win-x64 ^
  --self-contained true ^
  -o "%OUTPUT_DIR%" ^
  /p:PublishSingleFile=true ^
  /nologo /v:quiet

if errorlevel 1 (
  echo [ERROR] Build failed.
  exit /b 1
)

:: Run Inno Setup to build the installer
echo Building installer using Inno Setup...
set INNO_COMPILER="C:\Program Files (x86)\Inno Setup 6\ISCC.exe"
if not exist %INNO_COMPILER% (
  echo [ERROR] Inno Setup Compiler not found at: %INNO_COMPILER%
  exit /b 1
)
%INNO_COMPILER% %ISS_SCRIPT%

if errorlevel 1 (
  echo [ERROR] Inno Setup failed.
  exit /b 1
)

echo Installer build completed successfully.
pause
