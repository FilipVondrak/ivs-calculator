using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using ivs_calc_proj.ViewModels;

namespace ivs_calc_proj.Controls;

public partial class Calculator : UserControl
{
    public Calculator()
    {
        InitializeComponent();
        this.DataContext = new CalculatorViewModel();
        this.Focus();
    }

    public Calculator(HistoryMenu historyMenu)
    {
        InitializeComponent();
        this.DataContext = new CalculatorViewModel(historyMenu);
        this.Focus();
    }

    private void Input_OnKeyDown(object? sender, KeyEventArgs e)
    {
        switch (e.Key)
        {
            case Key.D0:
            case Key.NumPad0:
                ZeroButton.SimulatePress();
                break;
            case Key.D1:
            case Key.NumPad1:
                OneButton.SimulatePress();
                break;
            case Key.D2:
            case Key.NumPad2:
                TwoButton.SimulatePress();
                break;
            case Key.D3:
            case Key.NumPad3:
                ThreeButton.SimulatePress();
                break;
            case Key.D4:
            case Key.NumPad4:
                FourButton.SimulatePress();
                break;
            case Key.D5:
            case Key.NumPad5:
                FiveButton.SimulatePress();
                break;
            case Key.D6:
            case Key.NumPad6:
                SixButton.SimulatePress();
                break;
            case Key.D7:
            case Key.NumPad7:
                SevenButton.SimulatePress();
                break;
            case Key.D8:
            case Key.NumPad8:
                EightButton.SimulatePress();
                break;
            case Key.D9:
            case Key.NumPad9:
                NineButton.SimulatePress();
                break;
            case Key.Add:
                PlusButton.SimulatePress();
                break;
            case Key.Subtract:
                MinusButton.SimulatePress();
                break;
            case Key.Multiply:
                MultiplicationButton.SimulatePress();
                break;
            case Key.Divide:
                DivisionButton.SimulatePress();
                break;
            case Key.Back:
                DeleteButton.SimulatePress();
                break;
            case Key.Enter:
                EqualButton.SimulatePress();
                break;
        }
    }
}