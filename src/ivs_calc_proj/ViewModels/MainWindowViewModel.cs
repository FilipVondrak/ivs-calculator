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
        Expression += $"{newCharacter}";
    }

    [RelayCommand]
    private void AddBinaryOperation(string newOperation)
    {
        if (Expression[^1] == ' ')
            RemoveCharacter();
        Expression += $" {newOperation} ";
    }

    [RelayCommand]
    private void AddUnaryOperation(string newOperation)
    {
        Expression += $"{newOperation}";
    }

    [RelayCommand]
    private void RemoveExpression()
    {
        Expression = string.Empty;
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
    }

    private void ExpressionChanged()
    {

    }

    [RelayCommand]
    private void Equals()
    {
        Expression = Output;
        Output = string.Empty;
    }
}