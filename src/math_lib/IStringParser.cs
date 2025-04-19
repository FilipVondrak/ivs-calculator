namespace math_lib;

public interface IStringParser
{
    /// <summary>
    /// Returns the result of the operation between the variables in parentheses as a single variable.
    /// </summary>
    /// <param name="expression">A string containing parentheses</param>
    /// <returns>Results in brackets<paramref name="expression"/></returns>
    string CalculateBracket(string expression);
    
    /// <summary>
    /// Returns the result of the entire expression.
    /// </summary>
    /// <param name="expression">Expression for the solution</param>
    /// <returns>Solution of the expression<paramref name="expression"/></returns>
    string SolveExpression(string expression);
}

