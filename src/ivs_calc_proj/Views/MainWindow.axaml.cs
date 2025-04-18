using System;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Platform;
using Avalonia.Styling;
using Avalonia.Themes.Fluent;

namespace ivs_calc_proj.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void ToggleButton_OnIsCheckedChanged(object? sender, RoutedEventArgs e)
    {
        var app = Application.Current;

        if(app==null) return;

        if(app.ActualThemeVariant==ThemeVariant.Dark)
            app.RequestedThemeVariant=ThemeVariant.Light;
        else
            app.RequestedThemeVariant=ThemeVariant.Dark;
    }


    private void Control_OnLoaded(object? sender, RoutedEventArgs e)
    {
        Calc.Focus();
    }
}