using System;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ivs_calc_proj.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
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

        if (Expression[^1] == ' ')
        {
            Expression=Expression.Substring(0, Expression.Length - 3);
        }
        else if (Expression[^1] == '(')
        {
            if(Expression.Length==1)
                Expression=Expression.Substring(0, Expression.Length - 1);
            else if(Expression[^2] == ' ')
                Expression=Expression.Substring(0, Expression.Length - 4);
        }
        else if (Expression[^1] == '√' && Expression[^2] == '2')
        {
            if (Expression.Length>2 && Expression[^3] == ' ')
                Expression=Expression.Substring(0, Expression.Length - 2);
            else if (Expression.Length==2)
                Expression=Expression.Substring(0, Expression.Length - 2);
            else
                Expression=Expression.Substring(0, Expression.Length - 1);
        }
        else
        {
            Expression=Expression.Substring(0, Expression.Length - 1);
        }
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
        Expression = Output;
        Output = string.Empty;
    }
}