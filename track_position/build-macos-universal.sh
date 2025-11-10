#!/bin/bash

# Build universal macOS .app bundle for TrackPosition (Intel + Apple Silicon)

APP_NAME="TrackPosition"
APP_BUNDLE="${APP_NAME}.app"

echo "🔨 Building TrackPosition for macOS..."
echo ""

# Detect current architecture
ARCH=$(uname -m)
if [ "$ARCH" = "arm64" ]; then
    DEFAULT_ARCH="osx-arm64"
    echo "Detected: Apple Silicon (ARM64)"
else
    DEFAULT_ARCH="osx-x64"
    echo "Detected: Intel (x64)"
fi

# Allow override via command line argument
BUILD_ARCH="${1:-$DEFAULT_ARCH}"

echo "Building for: $BUILD_ARCH"
echo ""

# Clean up any existing bundle
rm -rf "${APP_BUNDLE}"

# Build the application
echo "📦 Publishing application..."
cd TrackPosition
dotnet publish -c Release -r "$BUILD_ARCH" --self-contained true \
  -p:PublishSingleFile=true \
  -p:IncludeNativeLibrariesForSelfExtract=true \
  -p:PublishTrimmed=false

if [ $? -ne 0 ]; then
    echo "❌ Build failed!"
    exit 1
fi

cd ..

# Create app bundle structure
echo "🏗️  Creating app bundle structure..."
CONTENTS="${APP_BUNDLE}/Contents"
MACOS="${CONTENTS}/MacOS"
RESOURCES="${CONTENTS}/Resources"

mkdir -p "${MACOS}"
mkdir -p "${RESOURCES}"

# Copy the published files
echo "📁 Copying application files..."
cp -r "TrackPosition/bin/Release/net9.0/$BUILD_ARCH/publish/"* "${MACOS}/"

# Make the executable runnable
chmod +x "${MACOS}/${APP_NAME}"

# Create Info.plist
echo "📝 Creating Info.plist..."
cat > "${CONTENTS}/Info.plist" << EOF
<?xml version="1.0" encoding="UTF-8"?>
<!DOCTYPE plist PUBLIC "-//Apple//DTD PLIST 1.0//EN" "http://www.apple.com/DTDs/PropertyList-1.0.dtd">
<plist version="1.0">
<dict>
    <key>CFBundleDevelopmentRegion</key>
    <string>en</string>
    <key>CFBundleExecutable</key>
    <string>${APP_NAME}</string>
    <key>CFBundleIdentifier</key>
    <string>com.example.trackposition</string>
    <key>CFBundleInfoDictionaryVersion</key>
    <string>6.0</string>
    <key>CFBundleName</key>
    <string>${APP_NAME}</string>
    <key>CFBundlePackageType</key>
    <string>APPL</string>
    <key>CFBundleShortVersionString</key>
    <string>1.0.0</string>
    <key>CFBundleVersion</key>
    <string>1</string>
    <key>LSMinimumSystemVersion</key>
    <string>10.15</string>
    <key>NSHighResolutionCapable</key>
    <true/>
    <key>NSPrincipalClass</key>
    <string>NSApplication</string>
    <key>LSUIElement</key>
    <false/>
</dict>
</plist>
EOF

# Get app size
APP_SIZE=$(du -sh "${APP_BUNDLE}" | cut -f1)

echo ""
echo "✅ macOS app bundle created successfully!"
echo ""
echo "📦 App Name: ${APP_BUNDLE}"
echo "💾 Size: ${APP_SIZE}"
echo "🏗️  Architecture: ${BUILD_ARCH}"
echo ""
echo "🚀 To run the app:"
echo "   open ${APP_BUNDLE}"
echo ""
echo "📦 To create a distributable ZIP:"
echo "   zip -r ${APP_NAME}.zip ${APP_BUNDLE}"
echo ""
echo "💿 To create a DMG:"
echo "   hdiutil create -volname \"${APP_NAME}\" -srcfolder ${APP_BUNDLE} -ov -format UDZO ${APP_NAME}.dmg"
echo ""
