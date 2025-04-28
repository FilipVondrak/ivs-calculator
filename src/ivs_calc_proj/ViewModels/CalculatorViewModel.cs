using System;
using System.Linq;
using System.Linq.Expressions;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ivs_calc_proj.Controls;
using math_lib;

namespace ivs_calc_proj.ViewModels;

/// <summary>
/// Represents the view model for the calculator.
/// </summary>
/// <remarks>
/// This view model provides the base logic for the Calculator user interface
/// and interacts with optional components such as history handling.
/// </remarks>
public partial class CalculatorViewModel : ViewModelBase
{
    public CalculatorViewModel()
    {
    }

    private StringParser _stringParser = new StringParser();

    public CalculatorViewModel(HistoryMenu historyMenu) => _historyMenu = historyMenu;

    private readonly HistoryMenu? _historyMenu;

    [ObservableProperty] private string _expression = string.Empty;

    [ObservableProperty] private string _output = "= 0";

    [ObservableProperty] private bool _outputVisible = true;

    [ObservableProperty] private int _errorVisible = 0;

    /// <summary>
    /// When called, this method shows an "Invalid input" warning for one second
    /// </summary>
    private void ShowError()
    {
        var timer = new DispatcherTimer
        {
            Interval = TimeSpan.FromMilliseconds(1000)
        };

        // Removes the pressed state after the set interval
        timer.Tick += (sender, args) =>
        {
            ErrorVisible = 0;
            timer.Stop();
        };

        ErrorVisible = 1;
        timer.Start();
    }

    /// <summary>
    /// Adds a number in the parameter "newCharacter" to the end of the expression
    /// </summary>
    /// <param name="newCharacter"></param>
    [RelayCommand]
    private void AddNumber(string newCharacter)
    {
        // ensures that there is a number before adding a floating point
        if (newCharacter == "." &&
            ((Expression.Length > 0 && !char.IsNumber(Expression[^1])) || Expression.Length == 0)) return;

        // if the previous character is a bracket or factorial, add a multiply operation
        if (Expression.Length > 0 && (Expression[^1] == ')' || Expression[^1] == '!'))
        {
            AddBinaryOperation("*");
        }

        Expression += $"{newCharacter}";
        ExpressionChanged();
    }

    /// <summary>
    /// Adds the bracket / goniometric function in the parameter "newBracket" to the end of the expression
    /// </summary>
    /// <remarks>
    /// Also validates that the input can be added
    /// </remarks>
    /// <param name="newBracket"></param>
    [RelayCommand]
    private void AddBracket(string newBracket)
    {
        // if the previous character is a number, add a multiply operation
        if ((newBracket == "(" || newBracket == "sin(" || newBracket == "cos(" || newBracket == "tan(" ||
             newBracket == "ln(")
            && Expression.Length > 0 && (char.IsNumber(Expression[^1]) || Expression[^1] == ')'))
        {
            AddBinaryOperation("*");
        }

        int countOpeningBrackets = Expression.Count(c => c == '(');
        int countClosingBrackets = Expression.Count(c => c == ')');

        // ensures that there is a matching bracket for the end bracket
        if (newBracket == ")" && countOpeningBrackets <= countClosingBrackets)
        {
            ShowError();
            return;
        }

        // ensure the bracket is not empty
        if (newBracket == ")" && (Expression.Length >= 2 && (Expression[^1] == '(' || Expression[^2] == '-')))
        {
            ShowError();
            return;
        }

        Expression += $"{newBracket}";


        ExpressionChanged();
    }

    /// <summary>
    /// Adds a binary operation to the expression
    /// </summary>
    /// <remarks>
    /// Also validates that the input can be added
    /// if the previous entry in the expression is also an operation it is removed
    /// </remarks>
    /// <param name="newOperation"></param>
    [RelayCommand]
    private void AddBinaryOperation(string newOperation)
    {
        if (newOperation != "-" && (Expression.Length == 0 || Expression[^1] == '('))
        {
            ShowError();
            return;
        }

        // ensures that there is a number/end-bracket before adding the % operation
        if ((newOperation == "%") &&
            ((Expression.Length > 0 && !char.IsNumber(Expression[^1]) && Expression[^1] != ')') ||
             Expression.Length == 0))
        {
            ShowError();
            return;
        }

        if (Expression.Length > 0 && Expression[^1] == ' ')
            RemoveCharacter();
        Expression += $" {newOperation} ";
        ExpressionChanged();
    }

    /// <summary>
    /// Adds the "root of" operation symbol
    /// </summary>
    /// <remarks>
    /// Also validates that the input can be added
    /// If there is no number before the symbol, also add the number 2 as it expects square root of a number
    /// </remarks>
    /// <param name="newOperation"></param>
    [RelayCommand]
    private void AddRootOfOperation(string newOperation)
    {
        if (Expression.Length > 0 && !(char.IsNumber(Expression[^1]) || Expression[^1] == ' '))
        {
            ShowError();
            return;
        }

        if ((Expression.Length > 0 && !char.IsNumber(Expression[^1])) || Expression.Length == 0)
        {
            AddNumber("2");
        }

        Expression += $"{newOperation}";
        ExpressionChanged();
    }

    /// <summary>
    /// Adds a unary operation to the expression
    /// </summary>
    /// <remarks>
    /// Also validates that the input can be added -> the previous character must either be a number or a bracket
    /// </remarks>
    /// <param name="newOperation"></param>
    [RelayCommand]
    private void AddUnaryOperation(string newOperation)
    {
        // correctly formats the string
        // example: expression is "55" and newOperation is "sin", then ensures there is multiplication between these
        if (Expression.Length > 0 && Expression[^1] != ' ' && !(newOperation != "^" || newOperation != "!"))
            AddBinaryOperation("*");

        // ensures that there is a number/end-bracket before adding the ^ or ! operation
        if ((newOperation == "^" || newOperation == "!") &&
            ((Expression.Length > 0 && !char.IsNumber(Expression[^1]) && Expression[^1] != ')') ||
             Expression.Length == 0))
        {
            ShowError();
            return;
        }

        Expression += $"{newOperation}";
        ExpressionChanged();
    }

    /// <summary>
    /// Removes the whole expression
    /// </summary>
    [RelayCommand]
    private void RemoveExpression()
    {
        Expression = string.Empty;
        ExpressionChanged();
    }

    /// <summary>
    /// Removes the last character the user added
    /// </summary>
    /// <remarks>
    /// if the last character is an operation also removes the spaces between
    /// if the last character is a square root operation, removes the 2 as it is added automatically
    /// </remarks>
    [RelayCommand]
    private void RemoveCharacter()
    {
        if (Expression.Length == 0)
        {
            ShowError();
            return;
        }

        // if the last character is a space, then it removes the last operation
        if (Expression[^1] == ' ')
        {
            Expression = Expression.Substring(0, Expression.Length - 3);
            ExpressionChanged();
            return;
        }

        // removes the last character if it is a number
        if (char.IsNumber(Expression[^1]))
        {
            Expression = Expression.Substring(0, Expression.Length - 1);
            ExpressionChanged();
            return;
        }

        // checks if the character to be removed is the "root of" operation
        // also removes the "2" from the expression because it is the default value
        if (Expression[^1] == '√' && Expression[^2] == '2')
        {
            if ((Expression.Length > 2 && Expression[^3] == ' ') || Expression.Length == 2)
            {
                Expression = Expression.Substring(0, Expression.Length - 2);
                ExpressionChanged();
                return;
            }

            Expression = Expression.Substring(0, Expression.Length - 1);
            ExpressionChanged();
            return;
        }

        // checks if the character to be removed is "ln(" operation
        if (Expression.Length >= 3 && Expression.Substring(Expression.Length - 3, 3) == "ln(")
        {
            Expression = Expression.Substring(0, Expression.Length - 3);
            ExpressionChanged();
            return;
        }

        // checks if the character to be removed is "sin(" operation
        if (Expression.Length >= 4)
        {
            string last4 = Expression.Substring(Expression.Length - 4, 4);
            if (last4 == "sin(" || last4 == "cos(" || last4 == "tan(")
            {
                Expression = Expression.Substring(0, Expression.Length - 4);
                ExpressionChanged();
                return;
            }
        }

        if (Expression[^1] == '(')
        {
            if (Expression.Length == 1)
            {
                Expression = Expression.Substring(0, Expression.Length - 1);
                ExpressionChanged();
                return;
            }

            if (Expression[^2] == ' ')
            {
                Expression = Expression.Substring(0, Expression.Length - 4);
                ExpressionChanged();
                return;
            }
        }

        Expression = Expression.Substring(0, Expression.Length - 1);
        ExpressionChanged();
    }

    /// <summary>
    /// This method is called whenever the expression is changed to update the output
    /// </summary>
    /// <remarks>
    /// if the current expression isn't valid, then it hides the output label
    /// </remarks>
    private int ExpressionChanged()
    {
        if (Expression == string.Empty)
        {
            OutputVisible = false;
            return 1;
        }

        // check if the expression contains equal brackets
        if (Expression.Count(c => c == '(') != Expression.Count(c => c == ')'))
        {
            OutputVisible = false;
            return 1;
        }

        // check if the expression is properly closed
        if (!(char.IsNumber(Expression[^1]) || Expression[^1] == ')' || Expression[^1] == '!'))
        {
            OutputVisible = false;
            return 1;
        }

        Expression = $"({Expression})";
        Output = $"= {_stringParser.SolveWholeExpression(Expression.Replace(".", ","))}";
        Expression = Expression.Substring(1, Expression.Length - 2);
        Output = Output.Replace(",", ".");
        OutputVisible = true;
        return 0;
    }

    /// <summary>
    /// Moves the output to the input label and sets output to empty string
    /// </summary>
    [RelayCommand]
    private void Equals()
    {
        if (ExpressionChanged() == 1)
            return;

        if (Output == string.Empty)
        {
            ShowError();
            return;
        }

        if (_historyMenu != null)
            _historyMenu.AddEntry(Expression, Output);
        Expression = Output.Substring(2);
        Output = string.Empty;
    }
}