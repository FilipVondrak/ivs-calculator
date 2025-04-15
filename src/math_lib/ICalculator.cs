namespace math_lib;

/// <summary>
/// Definition of basic calculator operations
/// </summary>
public interface ICalculator
{
    /// <summary>
    /// Adds two numbers
    /// </summary>
    /// <returns>x + y</returns>
    double Add(double x, double y);
    
    /// <summary>
    /// Subtracts the second number from the first
    /// </summary>
    /// <returns>x - y</returns>
    double Subtract(double x, double y);
    
    /// <summary>
    /// Multiplies the first number with the second
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns>x * y</returns>
    double Multiply(double x, double y);
    
    /// <summary>
    /// Divides the first number by the second, rounding to 5 decimal places
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <exception cref="DivideByZeroException">Thrown when y is 0</exception>
    /// <returns>x / y</returns>
    double Divide(double x, double y);

    /// <summary>
    /// Returns the factorial of a non-negative integer
    /// </summary>
    /// <param name="n">A non-negative integer</param>
    /// <returns>The factorial of n if n is non-negative.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if n is negative</exception>
    long Factorial(int n);
    
    /// <summary>
    /// Raises a number to the power of an exponent
    /// </summary>
    /// <param name="baseNum">The base number for exponentiation</param>
    /// <param name="exponent">The exponent</param>
    /// <returns></returns>
    double Power(double baseNum, int exponent);
    
    /// <summary>
    /// Calculates the root of a number
    /// </summary>
    /// <param name="baseNum">The base number to take the root of</param>
    /// <param name="rootDegree">The degree of the root</param>
    /// <returns>The n-th root of baseNum</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="rootDegree"/> is less than or equal to 0,
    /// or if <paramref name="baseNum"/> is negative and <paramref name="rootDegree"/> is even</exception>
    double Root(double baseNum, int rootDegree);
    
    /// <summary>
    /// Calculates the logarithm of a value in a specified base
    /// </summary>
    /// <param name="baseNum">The value to calculate logarithm for</param>
    /// <param name="logBase">Base of the logarithm. Must be greater than 0 and not equal to 1</param>
    /// <returns>The logarithm of baseNum in logBase base</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="baseNum"/> is less than or equal to 0
    /// or when <paramref name="logBase"/> is less than 0 or equal to 1 or 0</exception>
    double Log(double baseNum, double logBase);
    
    /// <summary>
    /// Returns the sine value of a specific angle in radians
    /// </summary>
    /// <param name="angle">Angle in radians</param>
    /// <returns>The sine value of <paramref name="angle"/></returns>
    double Sin(double angle);
    
    /// <summary>
    /// Returns the cosine value of a specific angle in radians
    /// </summary>
    /// <param name="angle">Angle in radians</param>
    /// <returns>The cosine value of <paramref name="angle"/></returns>
    double Cos(double angle);
    
    /// <summary>
    /// Returns the tangent of a specific angle in radians
    /// </summary>
    /// <param name="angle">Angle in radians</param>
    /// <returns>The tangent of <paramref name="angle"/></returns>
    double Tan(double angle);
    
}