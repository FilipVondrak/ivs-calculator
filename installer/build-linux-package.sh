#!/bin/bash

# Clean-up
rm -rf ../out/
rm -rf ./staging_folder/

# .NET publish
echo "Publishing .NET project..."
dotnet publish "../src/ivs_calc_proj/ivs_calc_proj.csproj" \
  --verbosity quiet \
  --nologo \
  --configuration Release \
  --self-contained true \
  --runtime linux-x64 \
  --output "../out/linux-x64" \
  /p:PublishSingleFile=true

# Staging directory
echo "Setting up staging directory..."
mkdir -p staging_folder/DEBIAN

# Debian control file
cp ../src/ivs_calc_proj/ivs_calc_proj.Desktop.Debian/control ./staging_folder/DEBIAN

# Starter script
mkdir -p ./staging_folder/usr/bin
cp ../src/ivs_calc_proj/ivs_calc_proj.Desktop.Debian/ivs_calc_proj.sh ./staging_folder/usr/bin/ivs_calc_starymedved
chmod +x ./staging_folder/usr/bin/ivs_calc_starymedved

# Application binaries
mkdir -p ./staging_folder/usr/lib/ivs_calc_starymedved
cp -a ../out/linux-x64/. ./staging_folder/usr/lib/ivs_calc_starymedved/

# Rename executable properly
mv ./staging_folder/usr/lib/ivs_calc_starymedved/ivs_calc_starymedved ./staging_folder/usr/lib/ivs_calc_starymedved/ivs_calc_starymedved_executable
chmod -R a+rX ./staging_folder/usr/lib/ivs_calc_starymedved/
chmod +x ./staging_folder/usr/lib/ivs_calc_starymedved/ivs_calc_starymedved_executable

# Desktop shortcut
mkdir -p ./staging_folder/usr/share/applications
cp ../src/ivs_calc_proj/ivs_calc_proj.Desktop.Debian/ivs_calc_proj.desktop ./staging_folder/usr/share/applications/ivs_calc_starymedved.desktop

# Desktop icons
mkdir -p ./staging_folder/usr/share/pixmaps
cp ../src/ivs_calc_proj/Assets/math.png ./staging_folder/usr/share/pixmaps/ivs_calc_starymedved.png

mkdir -p ./staging_folder/usr/share/icons/hicolor/scalable/apps
cp ../src/ivs_calc_proj/Assets/math.svg ./staging_folder/usr/share/icons/hicolor/scalable/apps/ivs_calc_starymedved.svg

# Set permissions
find ./staging_folder -type f -exec chmod 644 {} \;
find ./staging_folder -type d -exec chmod 755 {} \;

# Specific executable permissions
chmod 755 ./staging_folder/usr/bin/ivs_calc_starymedved
chmod 755 ./staging_folder/usr/lib/ivs_calc_starymedved/ivs_calc_starymedved_executable

# Build .deb package
echo "Building .deb package..."
dpkg-deb --root-owner-group --build ./staging_folder/ ./ivs_calc_starymedved_1.0.0_amd64.deb

# Clean-up
rm -rf ../out/
rm -rf ./staging_folder/

echo "Linux .deb package built successfully."
