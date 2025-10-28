# AI Agent Instructions for .NET Solution

## Project Structure
This is a .NET solution consisting of two projects:
- `HelloWorld`: A console application (.NET 9.0)
- `HelloWorldLib`: A class library (.NET 9.0)

## Key Files and Components
- `HelloWorld/Program.cs`: Main entry point for the console application
- `HelloWorldLib/Class1.cs`: Core library code
- `HelloWorld.sln`: Solution file containing project references and build configurations

## Development Setup
The solution uses:
- .NET 9.0 SDK
- Implicit using directives (enabled in .csproj)
- Nullable reference types (enabled in .csproj)

## Build and Run Commands
```bash
# Build the solution
dotnet build

# Run the HelloWorld console app
dotnet run --project HelloWorld

# Run with arguments
dotnet run --project HelloWorld -- arg1 arg2
```

## Project Conventions
1. Code Organization:
   - Console app logic in `HelloWorld/Program.cs`
   - Reusable components in `HelloWorldLib`

2. Build Configuration:
   - Supports multiple platforms (x86, x64, AnyCPU)
   - Debug and Release configurations available

## Dependencies
- No external NuGet packages currently referenced
- Project references:
  - `HelloWorld` can reference `HelloWorldLib`

## Additional Notes
- The solution uses the modern top-level statements feature in `Program.cs`
- Project is configured with latest C# language features enabled