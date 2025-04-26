using System;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Platform;
using Avalonia.Styling;
using Avalonia.Themes.Fluent;

namespace ivs_calc_proj.Views;

/// <summary>
/// Represents the main window of the application.
/// Provides the primary user interface and handles initial loading configurations
/// for the application, including its styles, layout, and default view model binding.
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Handles the `IsCheckedChanged` event for the `ToggleButton`. Toggles the application's current theme
    /// between Dark and Light modes and focuses on the content of the main window.
    /// </summary>
    /// <param name="sender">The source of the event, typically the `ToggleButton` that triggered the change.</param>
    /// <param name="e">Event data associated with the `IsCheckedChanged` event.</param>
    private void ToggleButton_OnIsCheckedChanged(object? sender, RoutedEventArgs e)
    {
        var app = Application.Current;

        if(app==null) return;

        if(app.ActualThemeVariant==ThemeVariant.Dark)
            app.RequestedThemeVariant=ThemeVariant.Light;
        else
            app.RequestedThemeVariant=ThemeVariant.Dark;

        FocusOnContent();
    }


    private void Control_OnLoaded(object? sender, RoutedEventArgs e)
    {
        FocusOnContent();
    }

    private void ContentControl_OnTransitionCompleted(object? sender, TransitionCompletedEventArgs e)
    {
        FocusOnContent();
    }

    private void FocusOnContent()
    {
        if(ContentControl.Content==null) return;

        ((UserControl)ContentControl.Content).Focus();
    }
}