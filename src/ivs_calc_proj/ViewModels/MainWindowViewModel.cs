using System;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ivs_calc_proj.Controls;

namespace ivs_calc_proj.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private readonly Calculator _calculatorTab;
    private readonly HelpMenu _helpTab;
    private readonly HistoryMenu _historyTab;

    public MainWindowViewModel()
    {
        _calculatorTab = new Calculator() { Name = "Calc"};
        _helpTab = new HelpMenu();
        _historyTab = new HistoryMenu();
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