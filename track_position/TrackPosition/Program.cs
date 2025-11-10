using System;
using System.Runtime.InteropServices;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using Avalonia.Themes.Fluent;

class Program
{
    static void Main(string[] args)
    {
        AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .StartWithClassicDesktopLifetime(args);
    }
}

class App : Application
{
    public override void Initialize()
    {
        Styles.Add(new FluentTheme());
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is Avalonia.Controls.ApplicationLifetimes.IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MouseTrackerWindow();
        }
        base.OnFrameworkInitializationCompleted();
    }
}

// Platform-specific mouse position tracker
static class GlobalMouseTracker
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CGPoint
    {
        public double X;
        public double Y;
    }

    [DllImport("/System/Library/Frameworks/CoreGraphics.framework/CoreGraphics")]
    private static extern CGPoint CGEventGetLocation(IntPtr eventRef);

    [DllImport("/System/Library/Frameworks/CoreGraphics.framework/CoreGraphics")]
    private static extern IntPtr CGEventCreate(IntPtr source);

    public static (double X, double Y) GetMousePosition()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            IntPtr eventRef = CGEventCreate(IntPtr.Zero);
            if (eventRef != IntPtr.Zero)
            {
                CGPoint point = CGEventGetLocation(eventRef);
                return (point.X, point.Y);
            }
        }
        return (0, 0);
    }
}

class MouseTrackerWindow : Window
{
    private TextBlock lblPosition;
    private System.Threading.Timer? timer;

    public MouseTrackerWindow()
    {
        Width = 400;
        Height = 200;
        Title = "Mouse Tracker - Global Screen Position";

        lblPosition = new TextBlock
        {
            Margin = new Thickness(20),
            FontSize = 20,
            Text = "Tracking mouse position on screen...",
            Foreground = Brushes.DarkBlue,
            HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
            VerticalAlignment = Avalonia.Layout.VerticalAlignment.Center,
            TextAlignment = Avalonia.Media.TextAlignment.Center
        };

        Content = lblPosition;
        Background = Brushes.LightGray;
        
        // Start timer to poll global mouse position
        timer = new System.Threading.Timer(UpdateMousePosition, null, 0, 50); // Update every 50ms
        
        Closed += (s, e) => timer?.Dispose();
    }

    private void UpdateMousePosition(object? state)
    {
        Avalonia.Threading.Dispatcher.UIThread.Post(() =>
        {
            try
            {
                var (x, y) = GlobalMouseTracker.GetMousePosition();
                if (lblPosition != null)
                {
                    lblPosition.Text = $"Global Screen Position:\nX: {x:F0}  Y: {y:F0}";
                }
            }
            catch (Exception ex)
            {
                if (lblPosition != null)
                {
                    lblPosition.Text = $"Error: {ex.Message}";
                }
            }
        });
    }
}
