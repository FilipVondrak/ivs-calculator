using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace ivs_calc_proj.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void CloseApp(object? sender, RoutedEventArgs e) => Close();
    
    private void MinimizeApp(object? sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;

    private void MaximizeApp(object? sender, RoutedEventArgs e) => WindowState = WindowState.Maximized;
    
}