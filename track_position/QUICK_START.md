# Quick Start Guide

## 🚀 For Users

### Running the Pre-built App
```bash
open TrackPosition.app
```

That's it! The app will show your mouse position in real-time.

### First Time Setup
If you see a security warning:
1. Right-click `TrackPosition.app`
2. Click "Open"
3. Click "Open" again in the dialog

---

## 👨‍💻 For Developers

### Build the App
```bash
# One command to build everything:
./build-macos-universal.sh

# Then run it:
open TrackPosition.app
```

### Development Mode
```bash
cd TrackPosition
dotnet run
```

### Distribution
```bash
# Create a ZIP file:
zip -r TrackPosition.zip TrackPosition.app

# Or create a DMG:
hdiutil create -volname "TrackPosition" -srcfolder TrackPosition.app -ov -format UDZO TrackPosition.dmg
```

---

## 📋 Command Reference

| Task | Command |
|------|---------|
| Run app | `open TrackPosition.app` |
| Build app | `./build-macos-universal.sh` |
| Dev mode | `cd TrackPosition && dotnet run` |
| Clean build | `dotnet clean && dotnet build` |
| Create ZIP | `zip -r TrackPosition.zip TrackPosition.app` |
| Remove quarantine | `xattr -cr TrackPosition.app` |

---

## 🎯 What You Get

- ✅ Native macOS `.app` bundle
- ✅ Self-contained (no .NET runtime needed)
- ✅ ~85MB app size
- ✅ Works on Apple Silicon & Intel
- ✅ Real-time global mouse tracking

---

## 📁 Files Overview

```
track_position/
├── TrackPosition.app              ← The macOS app (double-click to run)
├── build-macos-universal.sh       ← Build script (recommended)
├── build-macos-app.sh             ← Quick rebuild script
├── BUILD_INSTRUCTIONS.md          ← Detailed build guide
├── README.md                      ← Full documentation
└── TrackPosition/                 ← Source code
    ├── Program.cs
    └── TrackPosition.csproj
```

---

## ❓ Common Issues

**"App can't be opened"**  
→ Right-click → Open

**Mouse position shows 0,0**  
→ Grant accessibility permissions in System Settings

**App won't launch**  
→ Run: `chmod +x TrackPosition.app/Contents/MacOS/TrackPosition`

---

Need more help? See [BUILD_INSTRUCTIONS.md](BUILD_INSTRUCTIONS.md) or [README.md](README.md)
