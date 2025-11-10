# TrackPosition - Global Mouse Tracker for macOS

A simple macOS application that tracks your mouse cursor position globally across your entire screen in real-time.

![macOS](https://img.shields.io/badge/macOS-10.15+-blue.svg)
![.NET](https://img.shields.io/badge/.NET-9.0-purple.svg)
![License](https://img.shields.io/badge/license-MIT-green.svg)

## Features

- 🖱️ **Global Mouse Tracking**: Tracks mouse position anywhere on your screen, not just within the app window
- 🎯 **Real-time Updates**: Position updates ~20 times per second
- 🪶 **Lightweight**: Native macOS app with minimal resource usage
- 🎨 **Clean UI**: Simple, modern interface built with Avalonia UI

## Screenshot

The app displays a small window showing your mouse coordinates:
```
Global Screen Position:
X: 1234  Y: 567
```

## Requirements

- macOS 10.15 (Catalina) or later
- For Apple Silicon (M1/M2/M3/M4) or Intel Macs

## Installation

### Option 1: Download Pre-built App

1. Download `TrackPosition.app` or `TrackPosition.zip`
2. Extract if needed
3. Double-click `TrackPosition.app` to run

**Note**: On first launch, you may need to right-click → Open to bypass Gatekeeper.

### Option 2: Build from Source

#### Prerequisites
- [.NET 9.0 SDK](https://dotnet.microsoft.com/download)
- macOS with Xcode Command Line Tools

#### Quick Build
```bash
# Clone or download this repository
cd track_position

# Run the universal build script
./build-macos-universal.sh

# Open the app
open TrackPosition.app
```

#### Manual Build
```bash
# Navigate to project directory
cd TrackPosition

# Publish for your architecture
# For Apple Silicon:
dotnet publish -c Release -r osx-arm64 --self-contained true

# For Intel:
dotnet publish -c Release -r osx-x64 --self-contained true

# Create the app bundle
cd ..
./build-macos-app.sh
```

See [BUILD_INSTRUCTIONS.md](BUILD_INSTRUCTIONS.md) for detailed build instructions.

## Usage

1. **Launch the app**: Double-click `TrackPosition.app` or run `open TrackPosition.app`
2. **Move your mouse**: The window will display your cursor's screen coordinates in real-time
3. **Position the window**: You can move the tracker window anywhere on your screen
4. **Quit**: Close the window or press Cmd+Q

### Coordinates

- **X coordinate**: Horizontal position (0 = left edge of screen)
- **Y coordinate**: Vertical position (0 = top edge of screen)
- Coordinates are relative to the top-left corner of your primary display

## Build Scripts

| Script | Purpose |
|--------|---------|
| `build-macos-universal.sh` | Full build with dotnet publish + app bundle creation |
| `build-macos-app.sh` | Quick app bundle creation from existing build |

## Project Structure

```
track_position/
├── TrackPosition/          # Main application source
│   ├── Program.cs         # Application code
│   └── TrackPosition.csproj
├── TrackPosition.app/     # Built macOS app bundle
├── build-macos-universal.sh
├── build-macos-app.sh
├── BUILD_INSTRUCTIONS.md
└── README.md
```

## How It Works

The application uses:
- **Avalonia UI**: Cross-platform .NET UI framework
- **CoreGraphics P/Invoke**: macOS native APIs to get global cursor position
- **Timer-based polling**: Continuously queries mouse position every 50ms

## Distribution

### Create a ZIP archive
```bash
zip -r TrackPosition.zip TrackPosition.app
```

### Create a DMG disk image
```bash
hdiutil create -volname "TrackPosition" -srcfolder TrackPosition.app -ov -format UDZO TrackPosition.dmg
```

### Code Signing (Optional)
For distribution to other users:
```bash
codesign --deep --force --verify --verbose --sign "Developer ID Application: Your Name" TrackPosition.app
```

## Troubleshooting

### "Cannot be opened because it is from an unidentified developer"
**Solution**: Right-click the app → Open → Open

Or remove the quarantine attribute:
```bash
xattr -cr TrackPosition.app
```

### Mouse tracking shows (0, 0)
**Solution**: The app may need accessibility permissions:
1. Open System Settings → Privacy & Security → Accessibility
2. Add TrackPosition if not already listed
3. Restart the app

### App won't launch
**Solution**: Ensure execute permissions:
```bash
chmod +x TrackPosition.app/Contents/MacOS/TrackPosition
```

## Development

### Running in Development Mode
```bash
cd TrackPosition
dotnet run
```

### Debugging
```bash
cd TrackPosition
dotnet build
dotnet run
```

## Technologies Used

- [.NET 9.0](https://dotnet.microsoft.com/)
- [Avalonia UI 11.0.7](https://avaloniaui.net/)
- CoreGraphics Framework (macOS)

## License

MIT License - Feel free to use and modify as needed.

## Author

Created with ❤️ for macOS developers and power users

## Contributing

Contributions are welcome! Feel free to:
- Report bugs
- Suggest features
- Submit pull requests

## Roadmap

Potential future enhancements:
- [ ] Always-on-top window option
- [ ] Customizable update rate
- [ ] Multi-monitor support with display info
- [ ] Keyboard shortcut to show/hide window
- [ ] Click tracking
- [ ] Position history/logging
- [ ] Custom window themes

---

**Note**: This application uses native macOS APIs and is designed specifically for macOS. For Windows or Linux support, additional platform-specific code would be needed.
