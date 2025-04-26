namespace math_lib;

public interface IStringParser
{
    /// <summary>
    /// Solves the expression in the deepest brackets.
    /// </summary>
    /// <param name="expression">String with mathematical expression</param>
    /// <returns>The new expression with solved <param name="expression"></param> in the deepest brackets.</returns>
    string CalculateDeepestBrackets(string expression);

    /// <summary>
    /// Solves an expression without brackets
    /// </summary>
    /// <param name="expression">Expression for the solution</param>
    /// <returns>Solution of the expression <paramref name="expression"/></returns>
    string SolveExpression(string expression);

    /// <summary>
    /// Solves the entire expression
    /// </summary>
    /// <param name="expression">Expression for the solution</param>
    /// <returns>Solution of the expression <paramref name="expression"/></returns>
    decimal SolveWholeExpression(string expression);

    /// <summary>
    /// Checks if there are brackets in the expression
    /// </summary>
    /// <param name="expression">Expression to check</param>
    /// <returns>True if there are brackets</returns>
    bool BracketIn(string expression);

    /// <summary>
    /// Checks for an add operation in the expression
    /// </summary>
    /// <param name="expression">Expression to check</param>
    /// <returns>True if there is an add operation</returns>
    bool AddIn(string expression);

    /// <summary>
    /// Checks for a subtract operation in the expression
    /// </summary>
    /// <param name="expression">Expression to check</param>
    /// <returns>True if there is a subtract operation</returns>
    bool SubtractIn(string expression);

    /// <summary>
    /// Checks for a multiply operation in the expression
    /// </summary>
    /// <param name="expression">Expression to check</param>
    /// <returns>True if there is a multiply operation</returns>
    bool MultiplyIn(string expression);

    /// <summary>
    /// Checks for a divide operation in the expression
    /// </summary>
    /// <param name="expression">Expression to check</param>
    /// <returns>True if there is a divide operation</returns>
    bool DivideIn(string expression);

    /// <summary>
    /// Checks for a factorial operation in the expression
    /// </summary>
    /// <param name="expression">Expression to check</param>
    /// <returns>True if there is a factorial operation</returns>
    bool FactorialIn(string expression);

    /// <summary>
    /// Checks for a power operation in the expression
    /// </summary>
    /// <param name="expression">Expression to check</param>
    /// <returns>True if there is a power operation</returns>
    bool PowerIn(string expression);

    /// <summary>
    /// Checks for a root operation in the expression
    /// </summary>
    /// <param name="expression">Expression to check</param>
    /// <returns>True if there is a root operation</returns>
    bool RootIn(string expression);

    /// <summary>
    /// Checks for a natural logarithm operation in the expression
    /// </summary>
    /// <param name="expression">Expression to check</param>
    /// <returns>True if there is a natural logarithm operation</returns>
    bool LnIn(string expression);

    /// <summary>
    /// Checks for trigonometric operations in the expression
    /// </summary>
    /// <param name="expression">Expression to check</param>
    /// <returns>True if there are trigonometric operations</returns>
    bool GonFuncsIn(string expression);
    
    /// <summary>
    /// Checks for modulo operations in the expression
    /// </summary>
    /// <param name="expression">Expression to check</param>
    /// <returns>True if there are modulo operations</returns>
    bool ModuloIn(string expression);
}