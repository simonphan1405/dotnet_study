# Building TrackPosition for macOS

This guide explains how to build the TrackPosition application as a native macOS `.app` bundle.

## Prerequisites

- macOS (Apple Silicon or Intel)
- .NET 9.0 SDK installed
- Terminal access

## Quick Build

Run the included build script:

```bash
./build-macos-app.sh
```

This will create `TrackPosition.app` in the current directory.

## Running the Application

### Option 1: Double-click the app
Simply double-click `TrackPosition.app` in Finder.

### Option 2: Use the `open` command
```bash
open TrackPosition.app
```

### Option 3: Run directly from Terminal
```bash
./TrackPosition.app/Contents/MacOS/TrackPosition
```

## Manual Build Steps

If you prefer to build manually:

### 1. Publish for macOS (Apple Silicon)
```bash
cd TrackPosition
dotnet publish -c Release -r osx-arm64 --self-contained true \
  -p:PublishSingleFile=true \
  -p:IncludeNativeLibrariesForSelfExtract=true
```

### 2. For Intel Macs, use:
```bash
cd TrackPosition
dotnet publish -c Release -r osx-x64 --self-contained true \
  -p:PublishSingleFile=true \
  -p:IncludeNativeLibrariesForSelfExtract=true
```

### 3. Create the .app bundle structure
```bash
mkdir -p TrackPosition.app/Contents/MacOS
mkdir -p TrackPosition.app/Contents/Resources
cp -r bin/Release/net9.0/osx-arm64/publish/* TrackPosition.app/Contents/MacOS/
chmod +x TrackPosition.app/Contents/MacOS/TrackPosition
```

### 4. Create Info.plist
Create `TrackPosition.app/Contents/Info.plist` with the application metadata (see the build script for the template).

## Distribution

### To distribute the app:

1. **Compress the app bundle:**
   ```bash
   zip -r TrackPosition.zip TrackPosition.app
   ```

2. **Create a DMG (optional):**
   ```bash
   hdiutil create -volname "TrackPosition" -srcfolder TrackPosition.app -ov -format UDZO TrackPosition.dmg
   ```

### Important Notes:

- **Code Signing**: For distribution outside your machine, you'll need to sign the app with an Apple Developer certificate:
  ```bash
  codesign --deep --force --verify --verbose --sign "Developer ID Application: Your Name" TrackPosition.app
  ```

- **Notarization**: For distribution to other users, Apple requires notarization. This requires an Apple Developer account.

- **Gatekeeper**: If users get a "cannot be opened because it is from an unidentified developer" message, they can:
  - Right-click the app → Open → Open
  - Or run: `xattr -cr TrackPosition.app`

## Build Output Locations

- **Published files**: `TrackPosition/bin/Release/net9.0/osx-arm64/publish/`
- **App bundle**: `TrackPosition.app`
- **Executable size**: ~84 MB (self-contained with .NET runtime)

## What the App Does

The TrackPosition app tracks your mouse cursor position globally across your entire screen in real-time. The position updates are displayed in a small window showing the X and Y coordinates relative to the top-left corner of your primary display.

## Troubleshooting

### App won't open
- Check if the executable has execute permissions:
  ```bash
  chmod +x TrackPosition.app/Contents/MacOS/TrackPosition
  ```

### "Damaged app" message
- Remove quarantine attribute:
  ```bash
  xattr -cr TrackPosition.app
  ```

### Mouse tracking not working
- Ensure the app has accessibility permissions in System Settings → Privacy & Security → Accessibility

## Architecture Support

- **osx-arm64**: Apple Silicon (M1, M2, M3, M4 chips)
- **osx-x64**: Intel Macs

The build script defaults to Apple Silicon. Edit the script to change the architecture if needed.
