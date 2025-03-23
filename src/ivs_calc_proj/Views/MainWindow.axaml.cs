using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Platform;

namespace ivs_calc_proj.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        if (!OperatingSystem.IsWindows())
        {
            TitleBarTitle.IsVisible = false;
            TitleBarButtons.IsVisible = false;
            DisplayBorder.Padding = new Thickness(0);
        }
    }

    private void CloseApp(object? sender, RoutedEventArgs e) => Close();
    
    private void MinimizeApp(object? sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;

    private void MaximizeApp(object? sender, RoutedEventArgs e) => WindowState = WindowState.Maximized;

    private void TitleBarHold(object? sender, PointerPressedEventArgs e) => BeginMoveDrag(e);
}