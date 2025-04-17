using math_lib;
using Xunit;

namespace math_tests;

public class ParserUnitTestTdd
{
    private IStringParser _parser;

    [Fact]
    public void Calculating_multiple_bracket()
    {
        // inicializace třídy
        _parser = new StringParser();

        string expression = "1 + ((2 + 3) * 4)";
        string result = _parser.CalculateBracket(expression);

        Assert.Equal("1 + (5 * 4)", result);
    }

    [Fact]
    public void Calculating_expression()
    {
        // inicializace třídy
        _parser = new StringParser();

        string expression = "1 + ((2 + 3) * 4)";
        string result = _parser.CalculateBracket(expression);

        Assert.Equal("21", result);
    }
}