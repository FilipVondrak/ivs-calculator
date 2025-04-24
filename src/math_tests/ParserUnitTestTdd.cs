using math_lib;
using Xunit.Abstractions;
using Xunit;

namespace math_tests;

public class ParserUnitTestTdd(ITestOutputHelper output)
{
    private readonly IStringParser _parser = new StringParser();

    private char[] operands = { '+', '-', '/', '*', '^' };
    private string[] gonFuncs = { "sin", "cos", "tan", "ln" };

    [Fact]
    void CalculateDeepestBrackets_funcsBrackets()
    {
        foreach (var func in gonFuncs)
        {
            string expression = $"{func}(90)";
            var result = _parser.CalculateDeepestBrackets(expression);
            Assert.Equal($"{func}[90]", result);
        }
    }

    [Fact]
    void CalculateDeepestBrackets_1()
    {
        foreach (var operand in operands)
        {
            string expression = $"1{operand}5";
            var result = _parser.CalculateDeepestBrackets(expression);
            Assert.Equal($"1{operand}5", result);
        }
    }

    [Fact]
    void CalculateDeepestBrackets_2()
    {
        string expression = "(2+9)";
        var result = _parser.CalculateDeepestBrackets(expression);
        Assert.Equal("11", result);
    }

    [Fact]
    void CalculateDeepestBrackets_3()
    {
        string expression = "1+(2+9)";
        var result = _parser.CalculateDeepestBrackets(expression);
        Assert.Equal("1+11", result);
    }

    [Fact]
    void CalculateDeepestBrackets_4()
    {
        string expression = "5+9*(7/(2^2))";
        string expected = "5+9*(7/4)";
        var result = _parser.CalculateDeepestBrackets(expression);
        output.WriteLine("Expression: " + expression);
        output.WriteLine("Actual: " + result);
        output.WriteLine("Expected: " + expected);
        Assert.Equal(expected, result);
    }

    [Fact]
    void CalculateDeepestBrackets_5()
    {
        string expression = "5+9*(7/(2^2)+(3+sin(90)))";
        string expected = "5+9*(7/(2^2)+(3+sin[90]))";
        var result = _parser.CalculateDeepestBrackets(expression);
        output.WriteLine("Expression: " + expression);
        output.WriteLine("Actual: " + result);
        output.WriteLine("Expected: " + expected);
        Assert.Equal(expected, result);
    }

    [Fact]
    void CalculateDeepestBrackets_6()
    {
        string expression = "5+9*(7/(2^2)+(3+sin[90]))";
        string expected = "5+9*(7/4+4)";
        var result = _parser.CalculateDeepestBrackets(expression);
        output.WriteLine("Expression: " + expression);
        output.WriteLine("Actual: " + result);
        output.WriteLine("Expected: " + expected);
        Assert.Equal(expected, result);
    }

    [Fact]
    void CalculateDeepestBrackets_7()
    {
        string expression = "sin(90)+cos(1.5)+ln(17)/(3^2)";
        string expected = "sin[90]+cos[1.5]+ln[17]/9";
        var result = _parser.CalculateDeepestBrackets(expression);
        output.WriteLine("Expression: " + expression);
        output.WriteLine("Actual: " + result);
        output.WriteLine("Expected: " + expected);
        Assert.Equal(expected, result);
    }

    [Fact]
    void SolveExpression_1()
    {
        string expression = "5+4*8-8/4+ln[e]+cos[90]";
        string expected = "36";
        var result = _parser.SolveExpression(expression);
        output.WriteLine("Expression: " + expression);
        output.WriteLine("Actual: " + result);
        output.WriteLine("Expected: " + expected);
        Assert.Equal(expected, result);
    }

    [Fact]
    void SolveWholeExpression_1()
    {
        string expression = "5+9*(7/(2^2)+(3+sin(90)))";
        decimal expected = 56.75m;
        var result = _parser.SolveWholeExpression(expression);
        output.WriteLine("Expression: " + expression);
        output.WriteLine("Actual: " + result);
        output.WriteLine("Expected: " + expected);
        Assert.Equal(expected, result);
    }

    [Fact]
    void BracketIn_1()
    {
        string expression = "(5+8)-1";
        var result = _parser.BracketIn(expression);
        Assert.True(result);
    }

    [Fact]
    void AddIn_1()
    {
        string expression = "(5+8)-1";
        var result = _parser.AddIn(expression);
        Assert.True(result);
    }

    [Fact]
    void SubtractIn_1()
    {
        string expression = "(5+8)-1";
        var result = _parser.SubtractIn(expression);
        Assert.True(result);
    }

    [Fact]
    void MultiplyIn_1()
    {
        string expression = "(5+8)-1*5";
        var result = _parser.MultiplyIn(expression);
        Assert.True(result);
    }

    [Fact]
    void DivideIn_1()
    {
        string expression = "(5+8)/1";
        var result = _parser.DivideIn(expression);
        Assert.True(result);
    }

    [Fact]
    void FactorialIn_1()
    {
        string expression = "(5+8)-1!";
        var result = _parser.FactorialIn(expression);
        Assert.True(result);
    }

    [Fact]
    void PowerIn_1()
    {
        string expression = "(5+8)-1^8";
        var result = _parser.PowerIn(expression);
        Assert.True(result);
    }

    [Fact]
    void RootIn_1()
    {
        string expression = "";
        var result = _parser.RootIn(expression);
        Assert.False(result);
    }

    [Fact]
    void LnIn_1()
    {
        string expression = "(5+8)-ln(1)";
        var result = _parser.LnIn(expression);
        Assert.True(result);
    }

    [Fact]
    void GonFuncsIn_1()
    {
        string expression = "sin(90)";
        var result = _parser.GonFuncsIn(expression);
        Assert.True(result);
    }
}