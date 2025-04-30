dotnet publish "../src/stddev/stddev.csproj" --self-contained true --runtime linux-x64 --output "../out/linux-x64-stddev" /p:PublishSingleFile=true

# Create folders
mkdir -p staging_folder_stddev/DEBIAN
mkdir -p staging_folder_stddev/usr/bin
mkdir -p staging_folder_stddev/usr/lib/stddev
mkdir -p staging_folder_stddev/usr/share/applications

# Copy files
cp ../src/stddev/stddev.Desktop.Debian/control ./staging_folder_stddev/DEBIAN
cp ../src/stddev/stddev.Desktop.Debian/stddev.sh ./staging_folder_stddev/usr/bin/stddev
cp -a ../out/linux-x64-stddev/. ./staging_folder_stddev/usr/lib/stddev/
cp ../src/stddev/stddev.Desktop.Debian/stddev.desktop ./staging_folder_stddev/usr/share/applications/stddev.desktop

mv ./staging_folder_stddev/usr/lib/stddev/stddev ./staging_folder_stddev/usr/lib/stddev/stddev_executable

# Set file permissions
find ./staging_folder_stddev -type f -exec chmod 644 {} \;

# Set directory permissions
find ./staging_folder_stddev -type d -exec chmod 755 {} \;

# Set executable perms back
chmod 755 ./staging_folder_stddev/usr/bin/stddev
chmod 755 ./staging_folder_stddev/usr/lib/stddev/stddev_executable

# Build
dpkg-deb --root-owner-group --build ./staging_folder_stddev/ ./stddev_1.0.0_amd64.deb