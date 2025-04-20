using math_lib;
using Xunit;

namespace math_tests;

public class ParserUnitTestTdd
{
    private readonly IStringParser _parser = new StringParser();

    [Fact]
    public void Calculating_multiple_bracket()
    {
        string expression = "1 + ((2 + 3) * 4)";
        string result = _parser.CalculateBracket(expression);

        Assert.Equal("1 + (5 * 4)", result);
    }

    [Fact]
    public void Calculating_expression() // 1 * 8 / 9 + 11 - 48 * 8
    {
        string expression = "1 + ((2 + 3) * 4)";
        string result = _parser.CalculateBracket(expression);

        Assert.Equal("21", result);
    }
}