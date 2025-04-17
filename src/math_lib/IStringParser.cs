namespace math_lib;

public interface IStringParser
{
    /// <summary>
    /// Returns the cosine value of a specific angle in radians
    /// </summary>
    /// <param name="angle">Angle in radians</param>
    /// <returns>The cosine value of <paramref name="angle"/></returns>
    string CalculateBracket(string expression);
    
    /// <summary>
    /// Returns the cosine value of a specific angle in radians
    /// </summary>
    /// <param name="angle">Angle in radians</param>
    /// <returns>The cosine value of <paramref name="angle"/></returns>
    string SolveExpression(string expression);
}

