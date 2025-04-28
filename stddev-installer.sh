dotnet publish "./src/stddev/stddev.csproj" --self-contained true --runtime linux-x64 --output "./out/linux-x64-stddev" /p:PublishSingleFile=true

mkdir -p staging_folder_stddev/DEBIAN
mkdir -p staging_folder_stddev/usr/bin
mkdir -p staging_folder_stddev/usr/lib/stddev
mkdir -p staging_folder_stddev/usr/share/applications

cp ./src/stddev/stddev.Desktop.Debian/stddev.sh ./staging_folder_stddev/usr/bin/stddev
chmod +x ./staging_folder_stddev/usr/bin/stddev

cp -a ./out/linux-x64-stddev/. ./staging_folder_stddev/usr/lib/stddev/
mv ./staging_folder_stddev/usr/lib/stddev/stddev ./staging_folder_stddev/usr/lib/stddev/stddev_executable
chmod +x ./staging_folder_stddev/usr/lib/stddev/stddev_executable

cp ./src/stddev/stddev.Desktop.Debian/stddev.desktop ./staging_folder_stddev/usr/share/applications/stddev.desktop
chmod 644 ./staging_folder_stddev/usr/share/applications/stddev.desktop

find ./staging_folder_stddev -type f -exec chmod 644 {} \;
find ./staging_folder_stddev -type d -exec chmod 755 {} \;
chmod 755 ./staging_folder_stddev/usr/bin/stddev
chmod 755 ./staging_folder_stddev/usr/lib/stddev/stddev_executable

dpkg-deb --root-owner-group --build ./staging_folder_stddev/ ./stddev_1.0.0_amd64.deb
