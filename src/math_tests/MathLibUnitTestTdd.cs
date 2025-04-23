using math_lib;
using Xunit;

namespace math_tests;

public class MathLibUnitTestTdd
{
    private readonly ICalculator _calculator = new Calculator();

    [Fact]
    public void Add_1()
    {
        var result = _calculator.Add(2, 9);
        Assert.Equal(11, result);
    }

    [Fact]
    public void Add_2()
    {
        var result = _calculator.Add(2, -9);
        Assert.Equal(-7, result);
    }

    [Fact]
    public void Add_3()
    {
        var result = _calculator.Add(-2, 9);
        Assert.Equal(7, result);
    }

    [Fact]
    public void Add_4()
    {
        var result = _calculator.Add(-2, -9);
        Assert.Equal(-11, result);
    }

    [Fact]
    public void Add_5()
    {
        var result = _calculator.Add((decimal)0.0000, 0);
        Assert.Equal(0, result);
    }

    [Fact]
    public void Subtract_1()
    {
        var result = _calculator.Subtract(2, 9);
        Assert.Equal(-7, result);
    }

    [Fact]
    public void Subtract_2()
    {
        var result = _calculator.Subtract(2, -9);
        Assert.Equal(11, result);
    }

    [Fact]
    public void Subtract_3()
    {
        var result = _calculator.Subtract(-2, 9);
        Assert.Equal(-11, result);
    }

    [Fact]
    public void Subtract_4()
    {
        var result = _calculator.Subtract(-2, -9);
        Assert.Equal(7, result);
    }

    [Fact]
    public void Subtract_5()
    {
        var result = _calculator.Subtract((decimal)0.0000, 0);
        Assert.Equal(0, result);
    }

    [Fact]
    public void Multiply_1()
    {
        var result = _calculator.Multiply(2, 9);
        Assert.Equal(18, result);
    }

    [Fact]
    public void Multiply_2()
    {
        var result = _calculator.Multiply(2, -9);
        Assert.Equal(-18, result);
    }

    [Fact]
    public void Multiply_3()
    {
        var result = _calculator.Multiply(-2, 9);
        Assert.Equal(-18, result);
    }

    [Fact]
    public void Multiply_4()
    {
        var result = _calculator.Multiply(-2, -9);
        Assert.Equal(18, result);
    }

    [Fact]
    public void Multiply_5()
    {
        var result = _calculator.Multiply((decimal)0.0000, 0);
        Assert.Equal(0, result);
    }

    [Fact]
    public void Divide_1()
    {
        var result = _calculator.Divide(2, 9);
        Assert.Equal((decimal)0.22222, result);
    }

    [Fact]
    public void Divide_2()
    {
        var result = _calculator.Divide(2, -9);
        Assert.Equal((decimal)-0.22222, result);
    }

    [Fact]
    public void Divide_3()
    {
        var result = _calculator.Divide(-2, 9);
        Assert.Equal((decimal)-0.22222, result);
    }

    [Fact]
    public void Divide_4()
    {
        var result = _calculator.Divide(-2, -9);
        Assert.Equal((decimal)0.22222, result);
    }

    [Fact]
    public void Divide_5()
    {
        Assert.Throws<DivideByZeroException>(() => _calculator.Divide((decimal)0.0000, 0));
    }

    [Fact]
    public void Factorial_1()
    {
        var result = _calculator.Factorial(2);
        Assert.Equal(2, result);
    }

    [Fact]
    public void Factorial_2()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.Factorial(-2));
    }

    [Fact]
    public void Factorial_3()
    {
        var result = _calculator.Factorial(9);
        Assert.Equal(362880, result);
    }

    [Fact]
    public void Power_1()
    {
        var result = _calculator.Power(2, 9);
        Assert.Equal(512, result);
    }

    [Fact]
    public void Root()
    {
        var result = _calculator.Root(16, 2);
        Assert.Equal(4, result);
    }

    [Fact]
    public void Log()
    {
        var result = _calculator.Log(100, 10);
        Assert.Equal(0, result.CompareTo(2));
    }

    [Fact]
    public void Sin()
    {
        var result = _calculator.Sin(90);
        Assert.Equal(1, result);
    }

    [Fact]
    public void Cos()
    {
        var result = _calculator.Cos(90);
        Assert.Equal(0, result);
    }

    [Fact]
    public void Tan()
    {
        var result = _calculator.Tan(0);
        Assert.Equal(0, result);
    }
}