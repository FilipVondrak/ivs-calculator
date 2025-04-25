using System;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ivs_calc_proj.Controls;

namespace ivs_calc_proj.ViewModels;

/// <summary>
/// Represents the ViewModel for the main window of the application.
/// </summary>
/// <remarks>
/// The MainWindowViewModel serves as the central data-binding context for the main user interface.
/// It manages the primary interactive components of the application, including the calculator,
/// help menu, and history menu. This ViewModel implements the navigation between these components
/// and defines the content currently displayed within the main window.
/// </remarks>
public partial class MainWindowViewModel : ViewModelBase
{
    private readonly Calculator _calculatorTab;
    private readonly HelpMenu _helpTab;
    private readonly HistoryMenu _historyTab;

    /// <summary>
    /// Represents the ViewModel for the Main Window in the application.
    /// Manages the main content displayed in the application,
    /// including the Calculator, Help Menu, and History Menu.
    /// </summary>
    public MainWindowViewModel()
    {
        _historyTab = new HistoryMenu();
        _calculatorTab = new Calculator(_historyTab) { Name = "Calc",};
        _helpTab = new HelpMenu();
        CurrentContent = _calculatorTab;
    }

    [ObservableProperty]
    private object _currentContent;

    [RelayCommand]
    private void SwitchToCalculator()
    {
        CurrentContent = _calculatorTab;
        IsCurrentlyHelpTab = false;
        IsCurrentlyHistoryTab = false;
        IsCurrentlyCalculatorTab = true;
    }

    [RelayCommand]
    private void SwitchToHistory()
    {
        CurrentContent = _historyTab;
        IsCurrentlyHelpTab = false;
        IsCurrentlyHistoryTab = true;
        IsCurrentlyCalculatorTab = false;
    }

    [RelayCommand]
    private void SwitchToHelp()
    {
        CurrentContent = _helpTab;
        IsCurrentlyHelpTab = true;
        IsCurrentlyHistoryTab = false;
        IsCurrentlyCalculatorTab = false;
    }

    [ObservableProperty]
    private bool _isCurrentlyHelpTab = false;

    [ObservableProperty]
    private bool _isCurrentlyHistoryTab = false;

    [ObservableProperty]
    private bool _isCurrentlyCalculatorTab = true;
}