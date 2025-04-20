using System.Linq.Expressions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ivs_calc_proj.ViewModels;

public partial class CalculatorViewModel : ViewModelBase
{

    [ObservableProperty]
    private string _expression = string.Empty;

    [ObservableProperty]
    private string _output = "= 0";
    public bool OutputVisible { get; set; } = true;

    [RelayCommand]
    private void AddNumber(string newCharacter)
    {
        if (Expression.Length > 0 && Expression[^1] == ')')
        {
            AddBinaryOperation("*");
        }

        Expression += $"{newCharacter}";
        ExpressionChanged();
    }

    [RelayCommand]
    private void AddBracket(string newBracket)
    {
        // if previus character is a number, add a multiply operation
        if (newBracket=="(" && Expression.Length > 0 && char.IsNumber(Expression[^1]))
        {
            AddBinaryOperation("*");
        }

        Expression += $"{newBracket}";


        ExpressionChanged();
    }

    [RelayCommand]
    private void AddBinaryOperation(string newOperation)
    {
        if(Expression.Length==0) return;

        if (Expression[^1] == ' ')
            RemoveCharacter();
        Expression += $" {newOperation} ";
        ExpressionChanged();
    }

    [RelayCommand]
    private void AddRootOfOperation(string newOperation)
    {
        if (Expression.Length>0 && !(char.IsNumber(Expression[^1]) || Expression[^1]==' '))
        {
            return;
        }

        if ((Expression.Length > 0 && !char.IsNumber(Expression[^1]))||Expression.Length==0)
        {
            AddNumber("2");
        }

        Expression += $"{newOperation}";
        ExpressionChanged();
    }

    [RelayCommand]
    private void AddUnaryOperation(string newOperation)
    {
        // correctly formats the string
        // example: expression is "55" and newOperation is "sin", then ensures there is multiplication between these
        if (Expression.Length>0 && Expression[^1] != ' ' && newOperation!="^")
            AddBinaryOperation("*");

        // ensures that there is a number before adding the ^ operation
        if (newOperation=="^" && (Expression.Length>0 && !char.IsNumber(Expression[^1]) || Expression.Length==0))
            return;

        Expression += $"{newOperation}";
        ExpressionChanged();
    }

    [RelayCommand]
    private void RemoveExpression()
    {
        Expression = string.Empty;
        ExpressionChanged();
    }

    [RelayCommand]
    private void RemoveCharacter()
    {
        if(Expression.Length==0) return;
        // if the last character is a space, then it removes the last operation
        if (Expression[^1] == ' ')
        {
            Expression=Expression.Substring(0, Expression.Length - 3);
            ExpressionChanged();
            return;
        }
        // removes the last character if it is a number
        if (char.IsNumber(Expression[^1]))
        {
            Expression=Expression.Substring(0, Expression.Length - 1);
            ExpressionChanged();
            return;
        }

        // checks if the character to be removed is the "root of" operation
        // also removes the "2" from the expression because it is the default value
        if (Expression[^1] == '√' && Expression[^2] == '2')
        {
            if ((Expression.Length > 2 && Expression[^3] == ' ') || Expression.Length == 2)
            {
                Expression=Expression.Substring(0, Expression.Length - 2);
                ExpressionChanged();
                return;
            }

            Expression=Expression.Substring(0, Expression.Length - 1);
            ExpressionChanged();
            return;
        }

        // checks if the character to be removed is "ln(" operation
        if (Expression.Length>=3 && Expression.Substring(Expression.Length-3, 3)=="ln(")
        {
            Expression=Expression.Substring(0, Expression.Length - 3);
            ExpressionChanged();
            return;
        }

        // checks if the character to be removed is "sin(" operation
        if (Expression.Length>=4)
        {
            string last4 = Expression.Substring(Expression.Length - 4, 4);
            if (last4 == "sin(" || last4 == "cos(" || last4 == "tan(")
            {
                Expression=Expression.Substring(0, Expression.Length - 4);
                ExpressionChanged();
                return;
            }
        }
        if (Expression[^1] == '(')
        {
            if (Expression.Length == 1)
            {
                Expression=Expression.Substring(0, Expression.Length - 1);
                ExpressionChanged();
                return;
            }

            if (Expression[^2] == ' ')
            {
                Expression=Expression.Substring(0, Expression.Length - 4);
                ExpressionChanged();
                return;
            }
        }

        Expression=Expression.Substring(0, Expression.Length - 1);
        ExpressionChanged();
    }

    private void ExpressionChanged()
    {
        if (Expression == string.Empty)
            Output = "= 0";
        else
            Output = $"= {Expression}";
    }

    [RelayCommand]
    private void Equals()
    {
        Expression = Output.Substring(2);
        Output = string.Empty;
    }
}