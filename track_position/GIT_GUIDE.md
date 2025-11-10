# Git Setup Guide

## 📁 Files to Commit

The `.gitignore` has been configured to exclude build artifacts and only commit source files.

### ✅ Files that WILL be committed:
```
Source Code:
├── TrackPosition/
│   ├── Program.cs
│   └── TrackPosition.csproj
├── TrackPosition.sln

Build Scripts:
├── build-macos-universal.sh
├── build-macos-app.sh

Documentation:
├── README.md
├── BUILD_INSTRUCTIONS.md
├── QUICK_START.md
├── SUMMARY.md
├── GIT_GUIDE.md
└── .gitignore
```

### ❌ Files that will be IGNORED:
```
Build Output:
├── TrackPosition/bin/
├── TrackPosition/obj/
├── TrackPosition.app/

Distribution:
├── *.zip
├── *.dmg

IDE/Editor:
├── .vs/
├── .vscode/
├── .idea/
├── .DS_Store

Temporary:
├── tmp_rovodev_*
└── *.log
```

## 🚀 Initialize Git Repository

If this isn't a git repository yet, run:

```bash
# Initialize the repository
git init

# Add all source files
git add .

# Make initial commit
git commit -m "Initial commit: TrackPosition macOS app with global mouse tracking"

# (Optional) Add remote and push
git remote add origin <your-repo-url>
git branch -M main
git push -u origin main
```

## 📝 Suggested Commit Message

```
Initial commit: TrackPosition macOS app with global mouse tracking

Features:
- Global mouse cursor tracking using CoreGraphics P/Invoke
- Real-time position updates (20 FPS)
- Native macOS .app bundle support
- Self-contained .NET 9.0 application
- Avalonia UI with FluentTheme
- Build scripts for easy distribution
- Comprehensive documentation

Supported Platforms:
- macOS 10.15+ (Apple Silicon & Intel)
```

## 🔄 Typical Git Workflow

### After making changes:
```bash
# Check what changed
git status

# Stage your changes
git add .

# Commit with descriptive message
git commit -m "Add feature: [describe your change]"

# Push to remote
git push
```

### Common commit types:
```bash
git commit -m "feat: Add always-on-top window option"
git commit -m "fix: Resolve mouse tracking accuracy issue"
git commit -m "docs: Update build instructions for Intel Macs"
git commit -m "refactor: Improve CoreGraphics error handling"
git commit -m "style: Format code and improve UI layout"
git commit -m "chore: Update dependencies to latest versions"
```

## 🏷️ Suggested Git Tags

For versioning:
```bash
# Create a version tag
git tag -a v1.0.0 -m "Release version 1.0.0 - Initial public release"

# Push tags to remote
git push --tags
```

## 📦 Creating Releases

### For GitHub releases:
```bash
# Build the app
./build-macos-universal.sh

# Create distribution package
zip -r TrackPosition-v1.0.0-macOS.zip TrackPosition.app

# Create DMG
hdiutil create -volname "TrackPosition v1.0.0" \
  -srcfolder TrackPosition.app \
  -ov -format UDZO \
  TrackPosition-v1.0.0-macOS.dmg

# These distribution files are gitignored but can be uploaded as GitHub release assets
```

## 🌿 Branch Strategy

### Suggested branch workflow:
```bash
# Main branch for stable releases
main (or master)

# Development branch
git checkout -b develop

# Feature branches
git checkout -b feature/always-on-top
git checkout -b feature/keyboard-shortcuts

# Bug fix branches
git checkout -b fix/mouse-tracking-accuracy

# When feature is complete, merge back to develop
git checkout develop
git merge feature/always-on-top

# When ready for release, merge to main
git checkout main
git merge develop
git tag -a v1.1.0 -m "Release 1.1.0"
```

## 🔍 Useful Git Commands

```bash
# View commit history
git log --oneline -n 10

# View what changed in last commit
git show

# Undo last commit (keep changes)
git reset --soft HEAD~1

# Discard all uncommitted changes
git reset --hard HEAD

# View diff of unstaged changes
git diff

# View diff of staged changes
git diff --cached

# Remove untracked files (be careful!)
git clean -fd
```

## 📊 Repository Size

With proper `.gitignore`:
- Source code: ~50 KB
- Documentation: ~30 KB
- Total repository size: ~100 KB

Without `.gitignore` (DO NOT DO THIS):
- Would include bin/obj: ~300+ MB
- Would include .app bundle: ~81 MB
- Total: 400+ MB (unnecessarily large!)

## ✅ Verification

Check that gitignore is working:
```bash
# This should NOT show bin/, obj/, or .app files
git status

# If you see build artifacts, they weren't ignored
# Make sure .gitignore is in the root directory
```

## 🔒 What NOT to Commit

Never commit:
- ❌ Built binaries (bin/, obj/)
- ❌ .app bundles
- ❌ Distribution packages (.zip, .dmg)
- ❌ IDE-specific files (.vs/, .vscode/, .idea/)
- ❌ User-specific settings (*.user, *.suo)
- ❌ Temporary files
- ❌ API keys or secrets
- ❌ Large binary files

## 📚 Additional Resources

- [Git Basics](https://git-scm.com/book/en/v2/Getting-Started-Git-Basics)
- [Conventional Commits](https://www.conventionalcommits.org/)
- [GitHub Flow](https://guides.github.com/introduction/flow/)
- [Semantic Versioning](https://semver.org/)

---

**Ready to commit?** Run `git status` to see what will be included!
