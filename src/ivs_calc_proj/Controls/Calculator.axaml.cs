using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using ivs_calc_proj.ViewModels;

namespace ivs_calc_proj.Controls;

/// <summary>
/// Represents a user control for the calculator interface.
/// </summary>
/// <remarks>
/// This class initializes and manages the data context for the calculator,
/// leveraging the <see cref="CalculatorViewModel"/> class for its operations.
/// It also integrates with the history menu functionality if provided.
/// </remarks>
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

    /// <summary>
    /// Handles the KeyDown event and simulates button presses on a calculator UI.
    /// Maps specific keyboard keys to corresponding calculator button actions.
    /// </summary>
    /// <param name="sender">The source of the event, typically the control that received focus.</param>
    /// <param name="e">The event arguments containing information about the key pressed.</param>
    private void Input_OnKeyDown(object? sender, KeyEventArgs e)
    {
        if ((e.KeyModifiers & KeyModifiers.Shift) != 0 || (e.KeyModifiers & KeyModifiers.Alt) != 0)
            return;
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

    private void Intput_OnTextInput(object? sender, TextInputEventArgs e)
    {
        switch (e.Text)
        {
            case "^":
                PowerOfButton.SimulatePress();
                break;
            case "!":
                FactorialButton.SimulatePress();
                break;
            case "%":
                ModuloButton.SimulatePress();
                break;
            case "√":
                RootOfButton.SimulatePress();
                break;
            case ".":
            case ",":
                DecimalPointButton.SimulatePress();
                break;
            case "=":
                EqualButton.SimulatePress();
                break;
            case "(":
                LeftBracketButton.SimulatePress();
                break;
            case ")":
                RightBracketButton.SimulatePress();
                break;
        }
    }
}