using math_lib;
using Xunit;

namespace math_tests;

public class MathLibUnitTestTdd
{
    private readonly Calculator _calculator = new Calculator();

    [Fact]
    public void Add_basic()
    {
        var result = _calculator.Add(2, 9);
        Assert.Equal(11, result);
    }

    [Fact]
    public void Subtract_basic()
    {
        var result = _calculator.Subtract(2, 9);
        Assert.Equal(-7, result);
    }

    [Fact]
    public void Multiply_basic()
    {
        var result = _calculator.Multiply(2, 9);
        Assert.Equal(18, result);
    }

    [Fact]
    public void Divide_basic()
    {
        var result = _calculator.Divide(2, 9);
        Assert.Equal(0.22222, result);
    }

    [Fact]
    public void Factorial_basic()
    {
        var result = _calculator.Factorial(2);
        Assert.Equal(2, result);
        result = _calculator.Factorial(9);
        Assert.Equal(362880, result);
    }

    [Fact]
    public void Power_basic()
    {
        var result = _calculator.Power(9, 2);
        Assert.Equal(81, result);
    }

    [Fact]
    public void Root_basic()
    {
        var result = _calculator.Root(16, 2);
        Assert.Equal(4, result);
    }

    [Fact]
    public void Log_basic()
    {
        var result = _calculator.Log(100, 10);
        Assert.Equal(2, result);
    }

    [Fact]
    public void Sin_basic()
    {
        var result = _calculator.Sin(90);
        Assert.Equal(1, result);
    }

    [Fact]
    public void Cos_basic()
    {
        var result = _calculator.Cos(90);
        Assert.Equal(0, result);
    }

    [Fact]
    public void Tan_basic()
    {
        var result = _calculator.Tan(0);
        Assert.Equal(0, result);
    }
}