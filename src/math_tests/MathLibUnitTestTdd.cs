using math_lib;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace math_tests;

public class MathLibUnitTestTdd(ITestOutputHelper output)
{
    private readonly ICalculator _calculator = new Calculator();

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
    public void Add_decimals1()
    {
        var result = _calculator.Add(0.99999m, 0.11111m);
        Assert.Equal(1.1111m, result);
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
    public void Subtract_decimals1()
    {
        var result = _calculator.Subtract(0.0000m, 0.001m);
        Assert.Equal(-0.001m, result);
    }

    [Fact]
    public void Subtract_decimals2()
    {
        var result = _calculator.Subtract(-1.0177m, 0.0019m);
        Assert.Equal(-1.0196m, result);
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
    public void Multiply_decimals1()
    {
        var result = _calculator.Multiply(0.99999m, 0.99999m);
        Assert.Equal(0.99998m, result);
    }

    [Fact]
    public void Multiply_decimals2()
    {
        var result = _calculator.Multiply(-1.1234m, 1.1234m);
        Assert.Equal(-1.26203m, result);
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
    public void Divide_zero()
    {
        Assert.Throws<DivideByZeroException>(() => _calculator.Divide((decimal)0.0000, 0));
    }

    [Fact]
    public void Divide_decimals1()
    {
        var result = _calculator.Divide(1.53m, 3.1222m);
        Assert.Equal(0.49004m, result);
    }

    [Fact]
    public void Divide_decimals2()
    {
        var result = _calculator.Divide(11.78m, 7.811m);
        Assert.Equal(1.50813m, result);
    }

    [Fact]
    public void Divide_decimals3()
    {
        var result = _calculator.Divide(1.5m, 9m);
        Assert.Equal(0.16667m, result);
    }

    [Fact]
    public void Divide_decimals4()
    {
        var result = _calculator.Divide(9m, 1.89m);
        Assert.Equal(4.7619m, result);
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
    public void Power_Basic3()
    {
        var result = _calculator.Power(2, 0);
        Assert.Equal(1, result);
    }

    [Fact]
    public void Power_decimals1()
    {
        var result = _calculator.Power(2, 2.9);
        Assert.Equal(7.46426, result);
    }

    [Fact]
    public void Power_decimals2()
    {
        var result = _calculator.Power(2, -2.9);
        Assert.Equal(0.13397, result);
    }

    [Fact]
    public void Power_decimals3()
    {
        var result = _calculator.Power(29, -1.234);
        Assert.Equal(0.01568, result);
    }

    [Fact]
    public void Power_decimals4()
    {
        var result = _calculator.Power(2.999, 2);
        Assert.Equal(0, result.CompareTo(8.994));
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
    public void Root_decimals1()
    {
        var result = _calculator.Root(0.235m, 2);
        Assert.Equal(0.48477m, result);
    }

    [Fact]
    public void Root_decimals2()
    {
        var result = _calculator.Root(0.299m, 3);
        Assert.Equal(0.66869m, result);
    }

    [Fact]
    public void Root_decimals3()
    {
        var result = _calculator.Root(-29.029m, 29);
        Assert.Equal(-1.12316m, result);
    }

    [Fact]
    public void Log_Basic1()
    {
        var result = _calculator.Log(100, 10);
        output.WriteLine("Actual: " + result);
        output.WriteLine("Expected: " + 2);
        Assert.Equal(0, result.CompareTo(2));
    }

    [Fact]
    public void Log_1()
    {
        var result = _calculator.Log(9, 2);
        output.WriteLine("Actual: " + result);
        output.WriteLine("Expected: " + 3.16993m);
        Assert.Equal(0, result.CompareTo(3.16993m));
    }

    [Fact]
    public void Log_2()
    {
        var result = _calculator.Log(2, 9);
        output.WriteLine("Actual: " + result);
        output.WriteLine("Expected: " + 0.31546m);
        Assert.Equal(0, result.CompareTo(0.31546m));
    }

    [Fact]
    public void Log_decimals1()
    {
        var result = _calculator.Log(2.00333m, 2);
        output.WriteLine("Actual: " + result);
        output.WriteLine("Expected: " + 1.0024m);
        Assert.Equal(0, result.CompareTo(1.0024m));
    }

    [Fact]
    public void Log_decimals2()
    {
        var result = _calculator.Log(0.5m, 2);
        output.WriteLine("Actual: " + result);
        output.WriteLine("Expected: " + -1m);
        Assert.Equal(0, result.CompareTo(-1m));
    }

    [Fact]
    public void Log_Exceptions()
    {
        output.WriteLine("value can not be 0");
        Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.Log(0, 1));
        output.WriteLine("base can not be negative");
        Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.Log(1, -1));
        output.WriteLine("value can not be negative");
        Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.Log(-1, 1));
    }


    [Fact]
    public void Ln_Basic1()
    {
        var result = _calculator.Ln(100);
        output.WriteLine("Actual: " + result);
        output.WriteLine("Expected: " + 4.60517m);
        Assert.Equal(0, result.CompareTo(4.60517m));
    }

    [Fact]
    public void Ln_1()
    {
        var result = _calculator.Ln(9);
        output.WriteLine("Actual: " + result);
        output.WriteLine("Expected: " + 2.19722m);
        Assert.Equal(0, result.CompareTo(2.19722m));
    }

    [Fact]
    public void Ln_2()
    {
        var result = _calculator.Ln(2);
        output.WriteLine("Actual: " + result);
        output.WriteLine("Expected: " + 0.69315m);
        Assert.Equal(0, result.CompareTo(0.69315m));
    }

    [Fact]
    public void Ln_decimals1()
    {
        var result = _calculator.Ln(2.00333m);
        output.WriteLine("Actual: " + result);
        output.WriteLine("Expected: " + 0.69481m);
        Assert.Equal(0, result.CompareTo(0.69481m));
    }

    [Fact]
    public void Ln_decimals2()
    {
        var result = _calculator.Ln(0.5m);
        output.WriteLine("Actual: " + result);
        output.WriteLine("Expected: " + -0.69315m);
        Assert.Equal(0, result.CompareTo(-0.69315m));
    }

    [Fact]
    public void Ln_Exceptions()
    {
        output.WriteLine("value can not be 0");
        Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.Ln(0));
        output.WriteLine("value can not be negative");
        Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.Ln(-1));
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
    public void Sin_420()
    {
        var result = _calculator.Sin(420);
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
    public void Sin_720()
    {
        var result = _calculator.Sin(720);
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
    public void Cos_720()
    {
        var result = _calculator.Cos(720);
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


    [Fact]
    public void Tan_720()
    {
        var result = _calculator.Tan(720);
        Assert.Equal(0, result);
    }
}