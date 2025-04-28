#!/bin/bash

# Clean-up
rm -rf ./out/
rm -rf ./staging_folder/

# .NET publish
# self-contained is recommended, so final users won't need to install .NET
dotnet publish ".\src\ivs_calc_proj\ivs_calc_proj.csproj" \
  --verbosity quiet \
  --nologo \
  --configuration Release \
  --self-contained true \
  --runtime linux-x64 \
  --output "./out/linux-x64" \
  /p:PublishSingleFile=true

# Staging directory
mkdir staging_folder

# Debian control file
mkdir ./staging_folder/DEBIAN
cp ./src/ivs_calc_proj/ivs_calc_proj.Desktop.Debian/control ./staging_folder/DEBIAN

# Starter script
mkdir ./staging_folder/usr
mkdir ./staging_folder/usr/bin
cp ./src/ivs_calc_proj/ivs_calc_proj.Desktop.Debian/ivs_calc_proj.sh ./staging_folder/usr/bin/ivs_calc_proj
chmod +x ./staging_folder/usr/bin/ivs_calc_proj # set executable permissions to starter script

# Other files
mkdir ./staging_folder/usr/lib
mkdir ./staging_folder/usr/lib/ivs_calc_proj
cp -f -a ./out/linux-x64/. ./staging_folder/usr/lib/ivs_calc_proj/ # copies all files from publish dir
mv ./staging_folder/usr/lib/ivs_calc_proj/ivs_calc_proj ./staging_folder/usr/lib/ivs_calc_proj/ivs_calc_proj_executable
chmod -R a+rX ./staging_folder/usr/lib/ivs_calc_proj/ # set read permissions to all files
chmod +x ./staging_folder/usr/lib/ivs_calc_proj/ivs_calc_proj_executable # set executable permissions to main executable

# Desktop shortcut
mkdir ./staging_folder/usr/share
mkdir ./staging_folder/usr/share/applications
cp ./src/ivs_calc_proj/ivs_calc_proj.Desktop.Debian/ivs_calc_proj.desktop ./staging_folder/usr/share/applications/ivs_calc_proj.desktop

# Desktop icon
mkdir ./staging_folder/usr/share/pixmaps
cp --preserve=all ./src/ivs_calc_proj/Assets/math.png ./staging_folder/usr/share/pixmaps/ivs_calc_proj.png

# Hicolor icons
mkdir ./staging_folder/usr/share/icons
mkdir ./staging_folder/usr/share/icons/hicolor
mkdir ./staging_folder/usr/share/icons/hicolor/scalable
mkdir ./staging_folder/usr/share/icons/hicolor/scalable/apps
cp --preserve=all ./src/ivs_calc_proj/Assets/math.svg ./staging_folder/usr/share/icons/hicolor/scalable/apps/ivs_calc_proj.svg

find ./staging_folder -type f -exec chmod 644 {} \;

# Set all directories to 755 (rwxr-xr-x)
find ./staging_folder -type d -exec chmod 755 {} \;

# Set executables correctly
chmod 755 ./staging_folder/usr/bin/ivs_calc_proj
chmod 755 ./staging_folder/usr/lib/ivs_calc_proj/ivs_calc_proj_executable
# Make .deb file
dpkg-deb --root-owner-group --build ./staging_folder/ ./ivs_calc_proj_1.0.0_amd64.deb

# Clean-up
rm -rf ./out/
rm -rf ./staging_folder/