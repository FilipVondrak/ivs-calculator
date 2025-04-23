using math_lib;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace math_tests;

public class MathLibUnitTestTdd
{
    private readonly ICalculator _calculator = new Calculator();

    private readonly ITestOutputHelper _output;
    
    public MathLibUnitTestTdd(ITestOutputHelper output)
    {
        _output = output;
    }
    
    [Fact]
    public void Add_Basic1()
    {
        var result = _calculator.Add(2, 9);
        Assert.Equal(11, result);
    }

    [Fact]
    public void Add_Basic2()
    {
        var result = _calculator.Add(2, -9);
        Assert.Equal(-7, result);
    }

    [Fact]
    public void Add_Basic3()
    {
        var result = _calculator.Add(-2, 9);
        Assert.Equal(7, result);
    }

    [Fact]
    public void Add_Basic4()
    {
        var result = _calculator.Add(-2, -9);
        Assert.Equal(-11, result);
    }

    [Fact]
    public void Add_Basic5()
    {
        var result = _calculator.Add(0.0000m, 0);
        Assert.Equal(0, result);
    }

    [Fact]
    public void Subtract_Basic1()
    {
        var result = _calculator.Subtract(2, 9);
        Assert.Equal(-7, result);
    }

    [Fact]
    public void Subtract_Basic2()
    {
        var result = _calculator.Subtract(2, -9);
        Assert.Equal(11, result);
    }

    [Fact]
    public void Subtract_Basic3()
    {
        var result = _calculator.Subtract(-2, 9);
        Assert.Equal(-11, result);
    }

    [Fact]
    public void Subtract_Basic4()
    {
        var result = _calculator.Subtract(-2, -9);
        Assert.Equal(7, result);
    }

    [Fact]
    public void Subtract_Basic5()
    {
        var result = _calculator.Subtract(0.0000m, 0);
        Assert.Equal(0, result);
    }

    [Fact]
    public void Multiply_Basic1()
    {
        var result = _calculator.Multiply(2, 9);
        Assert.Equal(18, result);
    }

    [Fact]
    public void Multiply_Basic2()
    {
        var result = _calculator.Multiply(2, -9);
        Assert.Equal(-18, result);
    }

    [Fact]
    public void Multiply_Basic3()
    {
        var result = _calculator.Multiply(-2, 9);
        Assert.Equal(-18, result);
    }

    [Fact]
    public void Multiply_Basic4()
    {
        var result = _calculator.Multiply(-2, -9);
        Assert.Equal(18, result);
    }

    [Fact]
    public void Multiply_Basic5()
    {
        var result = _calculator.Multiply(0.0000m, 0);
        Assert.Equal(0, result);
    }

    [Fact]
    public void Divide_Basic1()
    {
        var result = _calculator.Divide(2, 9);
        Assert.Equal(0.22222m, result);
    }

    [Fact]
    public void Divide_Basic2()
    {
        var result = _calculator.Divide(2, -9);
        Assert.Equal(-0.22222m, result);
    }

    [Fact]
    public void Divide_Basic3()
    {
        var result = _calculator.Divide(-2, 9);
        Assert.Equal(-0.22222m, result);
    }

    [Fact]
    public void Divide_Basic4()
    {
        var result = _calculator.Divide(-2, -9);
        Assert.Equal(0.22222m, result);
    }

    [Fact]
    public void Divide_Basic5()
    {
        Assert.Throws<DivideByZeroException>(() => _calculator.Divide((decimal)0.0000, 0));
    }

    [Fact]
    public void Factorial_Basic1()
    {
        var result = _calculator.Factorial(2);
        Assert.Equal(2, result);
    }

    [Fact]
    public void Factorial_Exception()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.Factorial(-1));
    }

    [Fact]
    public void Factorial_Basic2()
    {
        var result = _calculator.Factorial(9);
        Assert.Equal(362880, result);
    }

    [Fact]
    public void Factorial_Basic3()
    {
        var result = _calculator.Factorial(0);
        Assert.Equal(1, result);
    }

    [Fact]
    public void Power_Basic1()
    {
        var result = _calculator.Power(2, 9);
        Assert.Equal(512, result);
    }

    [Fact]
    public void Power_Basic2()
    {
        var result = _calculator.Power(2, -9);
        Assert.Equal(_calculator.Divide(1, 512), result);
    }

    [Fact]
    public void Root_Basic1()
    {
        var result = _calculator.Root(16, 2);
        Assert.Equal(4, result);
    }

    [Fact]
    public void Root_Basic_RootDegree_3()
    {
        var result = _calculator.Root(-8, 3);
        Assert.Equal(-2, result);
    }

    [Fact]
    public void Log_Basic1()
    {
        var result = _calculator.Log(100, 10);
        _output.WriteLine("Actual: " + result);
        _output.WriteLine("Expected: " + 2);
        Assert.Equal(0, result.CompareTo(2));
    }

    [Fact]
    public void Log_1()
    {
        var result = _calculator.Log(9, 2);
        _output.WriteLine("Actual: " + result);
        _output.WriteLine("Expected: " + 3.16993m);
        Assert.Equal(0, result.CompareTo(3.16993m));
    }

    [Fact]
    public void Log_2()
    {
        var result = _calculator.Log(2, 9);
        _output.WriteLine("Actual: " + result);
        _output.WriteLine("Expected: " + 0.31546m);
        Assert.Equal(0, result.CompareTo(0.31546m));
    }

    [Fact]
    public void Log_Exceptions()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.Log(0, 1));
        Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.Log(1, -1));
        Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.Log(-1, 1));
    }

    [Fact]
    public void Sin_0()
    {
        var result = _calculator.Sin(0);
        Assert.Equal(0, result);
    }

    [Fact]
    public void Sin_30()
    {
        var result = _calculator.Sin(30);
        Assert.Equal(0.5m, result);
    }

    [Fact]
    public void Sin_45()
    {
        var result = _calculator.Sin(45);
        Assert.Equal(0.70711m, result);
    }

    [Fact]
    public void Sin_60()
    {
        var result = _calculator.Sin(60);
        Assert.Equal(0.86603m, result);
    }

    [Fact]
    public void Sin_90()
    {
        var result = _calculator.Sin(90);
        Assert.Equal(1, result);
    }

    [Fact]
    public void Sin_180()
    {
        var result = _calculator.Sin(180);
        Assert.Equal(0, result);
    }

    [Fact]
    public void Sin_270()
    {
        var result = _calculator.Sin(270);
        Assert.Equal(-1, result);
    }

    [Fact]
    public void Sin_360()
    {
        var result = _calculator.Sin(360);
        Assert.Equal(0, result);
    }

    [Fact]
    public void Cos_0()
    {
        var result = _calculator.Cos(0);
        Assert.Equal(1, result);
    }

    [Fact]
    public void Cos_30()
    {
        var result = _calculator.Cos(30);
        Assert.Equal(0.86603m, result);
    }

    [Fact]
    public void Cos_45()
    {
        var result = _calculator.Cos(45);
        Assert.Equal(0.70711m, result);
    }

    [Fact]
    public void Cos_60()
    {
        var result = _calculator.Cos(60);
        Assert.Equal(0.5m, result);
    }

    [Fact]
    public void Cos_90()
    {
        var result = _calculator.Cos(90);
        Assert.Equal(0, result);
    }

    [Fact]
    public void Cos_180()
    {
        var result = _calculator.Cos(180);
        Assert.Equal(-1, result);
    }

    [Fact]
    public void Cos_270()
    {
        var result = _calculator.Cos(270);
        Assert.Equal(0, result);
    }

    [Fact]
    public void Cos_360()
    {
        var result = _calculator.Cos(360);
        Assert.Equal(1, result);
    }

    [Fact]
    public void Tan_0()
    {
        var result = _calculator.Tan(0);
        Assert.Equal(0, result);
    }

    [Fact]
    public void Tan_30()
    {
        var result = _calculator.Tan(30);
        Assert.Equal(0.57735m, result);
    }

    [Fact]
    public void Tan_45()
    {
        var result = _calculator.Tan(45);
        Assert.Equal(1m, result);
    }

    [Fact]
    public void Tan_60()
    {
        var result = _calculator.Tan(60);
        Assert.Equal(1.73205m, result);
    }

    [Fact]
    public void Tan_90()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.Tan(90));
    }

    [Fact]
    public void Tan_180()
    {
        var result = _calculator.Tan(180);
        Assert.Equal(0, result);
    }

    [Fact]
    public void Tan_270()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.Tan(270));
    }

    [Fact]
    public void Tan_360()
    {
        var result = _calculator.Tan(360);
        Assert.Equal(0, result);
    }

}