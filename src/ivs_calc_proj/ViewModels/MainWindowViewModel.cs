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
    private void AddUnaryOperation(string newOperation)
    {
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