#!/bin/bash

# Quick build script - just uses the existing published files
# For a full build, use: ./build-macos-universal.sh

APP_NAME="TrackPosition"
APP_BUNDLE="${APP_NAME}.app"
CONTENTS="${APP_BUNDLE}/Contents"
MACOS="${CONTENTS}/MacOS"
RESOURCES="${CONTENTS}/Resources"

# Clean up any existing bundle
rm -rf "${APP_BUNDLE}"

# Create app bundle structure
mkdir -p "${MACOS}"
mkdir -p "${RESOURCES}"

# Copy the published files (assumes already built)
echo "Copying application files..."
if [ -d "TrackPosition/bin/Release/net9.0/osx-arm64/publish" ]; then
    cp -r TrackPosition/bin/Release/net9.0/osx-arm64/publish/* "${MACOS}/"
elif [ -d "TrackPosition/bin/Release/net9.0/osx-x64/publish" ]; then
    cp -r TrackPosition/bin/Release/net9.0/osx-x64/publish/* "${MACOS}/"
else
    echo "❌ No published files found. Run this first:"
    echo "   cd TrackPosition && dotnet publish -c Release -r osx-arm64 --self-contained"
    exit 1
fi

# Make the executable runnable
chmod +x "${MACOS}/${APP_NAME}"

# Create Info.plist
echo "Creating Info.plist..."
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
</dict>
</plist>
EOF

echo ""
echo "✅ macOS app bundle created successfully!"
echo "📦 Location: ${APP_BUNDLE}"
echo ""
echo "To run the app:"
echo "  open ${APP_BUNDLE}"
echo ""
echo "To test from command line:"
echo "  ./${APP_BUNDLE}/Contents/MacOS/${APP_NAME}"
echo ""
