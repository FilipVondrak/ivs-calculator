using math_lib;
using Xunit.Abstractions;
using Xunit;

namespace math_tests;

public class ParserUnitTestTdd(ITestOutputHelper output)
{
    private readonly IStringParser _parser = new StringParser();

    private char[] operations = { '+', '-', '/', '*', '^', '√', '%', '!' };
    private string[] gonFuncs = { "sin", "cos", "tan" };

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
        foreach (var operand in operations)
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
    void CalculateDeepestBrackets_8()
    {
        string expression = "sin(90)+cos(1.5)+ln(17+(50*2))/(3^2)";
        string expected = "sin[90]+cos[1.5]+ln[17+100]/(3^2)";
        var result = _parser.CalculateDeepestBrackets(expression);
        output.WriteLine("Expression: " + expression);
        output.WriteLine("Actual: " + result);
        output.WriteLine("Expected: " + expected);
        Assert.Equal(expected, result);
    }

    [Fact]
    void CalculateDeepestBrackets_9()
    {
        string expression = "sin((90+5)*2)+90)+cos(1.5)+ln(17)/(3^2)";
        string expected = "sin[(95*2)+90]+cos[1.5]+ln[17]/(3^2)";
        var result = _parser.CalculateDeepestBrackets(expression);
        output.WriteLine("Expression: " + expression);
        output.WriteLine("Actual: " + result);
        output.WriteLine("Expected: " + expected);
        Assert.Equal(expected, result);
    }

    [Fact]
    void CalculateDeepestBrackets_10()
    {
        string expression = "sin(90*2+90)+cos(1.5)+ln(17)/(3^2)";
        string expected = "sin[270]+cos[1.5]+ln[17]/9";
        var result = _parser.CalculateDeepestBrackets(expression);
        output.WriteLine("Expression: " + expression);
        output.WriteLine("Actual: " + result);
        output.WriteLine("Expected: " + expected);
        Assert.Equal(expected, result);
    }

    [Fact]
    void SolveExpression_1()
    {
        string expression = "5+4*8-8/4+ln[e]+(8%3)+cos[90]";
        string expected = "38";
        var result = _parser.SolveExpression(expression);
        output.WriteLine("Expression: " + expression);
        output.WriteLine("Actual: " + result);
        output.WriteLine("Expected: " + expected);
        Assert.Equal(expected, result);
    }

    [Fact]
    void SolveExpression_2()
    {
        string expression = "50*(5+(10/5))";
        string expected = "350";
        var result = _parser.SolveExpression(expression);
        output.WriteLine("Expression: " + expression);
        output.WriteLine("Actual: " + result);
        output.WriteLine("Expected: " + expected);
        Assert.Equal(expected, result);
    }

    [Fact]
    void SolveExpression_3()
    {
        string expression = "cos(((80%30)*(2+(8/4)))*3)";
        string expected = "0.32578";
        var result = _parser.SolveExpression(expression);
        output.WriteLine("Expression: " + expression);
        output.WriteLine("Actual: " + result);
        output.WriteLine("Expected: " + expected);
        Assert.Equal(expected, result);
    }

    [Fact]
    void SolveExpression_4()
    {
        string expression = "55+e";
        string expected = "57.71828";
        var result = _parser.SolveExpression(expression);
        output.WriteLine("Expression: " + expression);
        output.WriteLine("Actual: " + result);
        output.WriteLine("Expected: " + expected);
        Assert.Equal(expected, result);
    }

    [Fact]
    void SolveExpression_5()
    {
        string expression = "55.10+e";
        string expected = "57.81828";
        var result = _parser.SolveExpression(expression);
        output.WriteLine("Expression: " + expression);
        output.WriteLine("Actual: " + result);
        output.WriteLine("Expected: " + expected);
        Assert.Equal(expected, result);
    }

    void SolveExpression_6()
    {
        string expression = "55.10+10.80";
        string expected = "65.90000";
        var result = _parser.SolveExpression(expression);
        output.WriteLine("Expression: " + expression);
        output.WriteLine("Actual: " + result);
        output.WriteLine("Expected: " + expected);
        Assert.Equal(expected, result);
    }

    [Fact]
    void SolveWholeExpression_1()
    {
        string expression = "5+9*(7/(2^2)+(8%5)+(3+sin(90)))";
        decimal expected = 59.75m;
        var result = _parser.SolveWholeExpression(expression);
        output.WriteLine("Expression: " + expression);
        output.WriteLine("Actual: " + result);
        output.WriteLine("Expected: " + expected);
        Assert.Equal(expected, result);
    }

    [Fact]
    void BracketIn_T()
    {
        string expression = "(5+8)-1";
        var result = _parser.BracketIn(expression);
        Assert.True(result);
    }

    [Fact]
    void BracketIn_F()
    {
        string expression = "5+8-1";
        var result = _parser.BracketIn(expression);
        Assert.False(result);
    }

    [Fact]
    void AddIn_T()
    {
        string expression = "(5+8)-1";
        var result = _parser.AddIn(expression);
        Assert.True(result);
    }

    [Fact]
    void AddIn_F()
    {
        string expression = "(5*8)-1";
        var result = _parser.AddIn(expression);
        Assert.False(result);
    }

    [Fact]
    void SubtractIn_T()
    {
        string expression = "(5+8)-1";
        var result = _parser.SubtractIn(expression);
        Assert.True(result);
    }

    [Fact]
    void SubtractIn_F()
    {
        string expression = "(5+8)/1";
        var result = _parser.SubtractIn(expression);
        Assert.False(result);
    }

    [Fact]
    void MultiplyIn_T()
    {
        string expression = "(5+8)-1*5";
        var result = _parser.MultiplyIn(expression);
        Assert.True(result);
    }

    [Fact]
    void MultiplyIn_F()
    {
        string expression = "(5+8)-1^5";
        var result = _parser.MultiplyIn(expression);
        Assert.False(result);
    }

    [Fact]
    void DivideIn_T()
    {
        string expression = "(5+8)/1";
        var result = _parser.DivideIn(expression);
        Assert.True(result);
    }

    [Fact]
    void DivideIn_F()
    {
        string expression = "(5+8)-1";
        var result = _parser.DivideIn(expression);
        Assert.False(result);
    }

    [Fact]
    void FactorialIn_T()
    {
        string expression = "(5+8)-1!";
        var result = _parser.FactorialIn(expression);
        Assert.True(result);
    }

    [Fact]
    void FactorialIn_F()
    {
        string expression = "(5+8)-1";
        var result = _parser.FactorialIn(expression);
        Assert.False(result);
    }

    [Fact]
    void PowerIn_T()
    {
        string expression = "(5+8)-1^8";
        var result = _parser.PowerIn(expression);
        Assert.True(result);
    }

    [Fact]
    void PowerIn_F()
    {
        string expression = "(5+8)-1*8";
        var result = _parser.PowerIn(expression);
        Assert.False(result);
    }

    [Fact]
    void RootIn_T()
    {
        string expression = "2√4+25";
        var result = _parser.RootIn(expression);
        Assert.True(result);
    }

    [Fact]
    void RootIn_F()
    {
        string expression = "2^4+25";
        var result = _parser.RootIn(expression);
        Assert.False(result);
    }

    [Fact]
    void LnIn_T()
    {
        string expression = "(5+8)-ln((10+80+10)-90-(3*3))";
        var result = _parser.LnIn(expression);
        Assert.True(result);
    }

    [Fact]
    void LnIn_F()
    {
        string expression = "(5+8)-sin(1)";
        var result = _parser.LnIn(expression);
        Assert.False(result);
    }

    [Fact]
    void Mod_T()
    {
        string expression = "(5%8)-ln(1)";
        var result = _parser.ModuloIn(expression);
        Assert.True(result);
    }

    [Fact]
    void Mod_F()
    {
        string expression = "(5+8)-sin(1)";
        var result = _parser.ModuloIn(expression);
        Assert.False(result);
    }

    [Fact]
    void GonFuncsIn_T()
    {
        foreach (var func in gonFuncs)
        {
            string expression = $"{func}(90)";
            var result = _parser.GonFuncsIn(expression);

            Assert.True(result);
        }
    }
}