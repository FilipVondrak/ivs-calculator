using System;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ivs_calc_proj.Controls;

namespace ivs_calc_proj.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private Calculator CalculatorTab;
    private HelpMenu HelpTab;

    public MainWindowViewModel()
    {
        CalculatorTab = new Calculator() { Name = "Calc"};
        HelpTab = new HelpMenu();
        CurrentContent = CalculatorTab;
    }

    [ObservableProperty]
    private object _currentContent;

    // -------- Commands for switching the main content -------- //

    [RelayCommand]
    private void SwitchToCalculator()
    {
        CurrentContent = CalculatorTab;
        IsCurrentlyHelpTab = false;
        IsCurrentlyHistoryTab = false;
        IsCurrentlyCalculatorTab = true;
    }

    [RelayCommand]
    private void SwitchToHelp()
    {
        CurrentContent = HelpTab;
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