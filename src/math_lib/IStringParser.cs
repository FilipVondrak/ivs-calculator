namespace math_lib;

public interface IStringParser
{
    /// <summary>
    /// Returns the new expression with solved expression in deepest brackets.
    /// </summary>
    /// <param name="expression">String with mathematical expression</param>
    /// <returns>Results in brackets<paramref name="expression"/></returns>
    string CalculateDeepestBrackets(string expression);

    /// <summary>
    /// Returns the result of a single expression without brackets.
    /// Use for the solving expression s in brackets with no child brackets.
    /// </summary>
    /// <param name="expression">Expression for the solution</param>
    /// <returns>Solution of the expression <paramref name="expression"/></returns>
    string SolveExpression(string expression);

    /// <summary>
    /// Returns the result of the entire expression.
    /// </summary>
    /// <param name="expression">Expression for the solution</param>
    /// <returns>Solution of the expression <paramref name="expression"/></returns>
    decimal SolveWholeExpression(string expression);

    /// <summary>
    /// Returns true if brackets in expression
    ///         false if not
    /// </summary>
    /// <param name="expression">Expression to check</param>
    /// <returns>Solution of the expression <paramref name="expression"/></returns>
    bool BracketIn(string expression);

    /// <summary>
    /// Returns true if add function in expression
    ///         false if not
    /// </summary>
    /// <param name="expression">Expression to check</param>
    /// <returns>Solution of the expression <paramref name="expression"/></returns>
    bool AddIn(string expression);

    /// <summary>
    /// Returns true if subtract function in expression
    ///         false if not
    /// </summary>
    /// <param name="expression">Expression to check</param>
    /// <returns>Solution of the expression <paramref name="expression"/></returns>
    bool SubtractIn(string expression);

    /// <summary>
    /// Returns true if multiply function in expression
    ///         false if not
    /// </summary>
    /// <param name="expression">Expression to check</param>
    /// <returns>Solution of the expression <paramref name="expression"/></returns>
    bool MultiplyIn(string expression);

    /// <summary>
    /// Returns true if divide function in expression
    ///         false if not
    /// </summary>
    /// <param name="expression">Expression to check</param>
    /// <returns>Solution of the expression <paramref name="expression"/></returns>
    bool DivideIn(string expression);

    /// <summary>
    /// Returns true if factorial function in expression
    ///         false if not
    /// </summary>
    /// <param name="expression">Expression to check</param>
    /// <returns>Solution of the expression <paramref name="expression"/></returns>
    bool FactorialIn(string expression);

    /// <summary>
    /// Returns true if power function in expression
    ///         false if not
    /// </summary>
    /// <param name="expression">Expression to check</param>
    /// <returns>Solution of the expression <paramref name="expression"/></returns>
    bool PowerIn(string expression);

    /// <summary>
    /// Returns true if root function in expression
    ///         false if not
    /// </summary>
    /// <param name="expression">Expression to check</param>
    /// <returns>Solution of the expression <paramref name="expression"/></returns>
    bool RootIn(string expression);

    /// <summary>
    /// Returns true if log function in expression
    ///         false if not
    /// </summary>
    /// <param name="expression">Expression to check</param>
    /// <returns>Solution of the expression <paramref name="expression"/></returns>
    bool LogIn(string expression);

    /// <summary>
    /// Returns true if trigonometric functions in expression
    ///         false if not
    /// </summary>
    /// <param name="expression">Expression to check</param>
    /// <returns>Solution of the expression <paramref name="expression"/></returns>
    bool GonFuncsIn(string expression);
}