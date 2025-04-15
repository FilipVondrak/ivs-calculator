namespace math_lib;

public class Calculator : ICalculator
{
    public double Add(double x, double y)
    {
        return x + y;
    }

    public double Subtract(double x, double y)
    {
        return x - y;
    }

    public double Multiply(double x, double y)
    {
        return x * y;
    }

    public double Divide(double x, double y)
    {
        if (y == 0)
        {
            throw new DivideByZeroException("Division by zero is not allowed.");
        }
        return double.Round(x/y, 5);
    }

    public long Factorial(int n)
    {
        if (n < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(n), n, "Negative numbers are not allowed.");
        }
        
        long result = 1;
        for (int i = 2; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }

    public double Power(double baseNum, int exponent)
    {
        return Math.Pow(baseNum, exponent);
    }

    public double Root(double baseNum, int rootDegree)
    {
        if (rootDegree <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(rootDegree), rootDegree, "Root degree must be greater than zero.");
        }
        if (baseNum < 0 && rootDegree % 2 == 0)
        {
            throw new ArgumentOutOfRangeException(nameof(baseNum), baseNum, "Root cannot be even when base number is negative.");
        }
        
        return Math.Pow(baseNum, 1.0 / rootDegree);
        
    }

    public double Log(double baseNum, double logBase)
    {
        if (baseNum <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(baseNum), baseNum, "Base number must be greater than zero.");
        }
        if (logBase is < 0 or 0 or 1)
        {
            throw new ArgumentOutOfRangeException(nameof(logBase), logBase, "logBase cannot be negative, equal to 0 or 1.");
        }
        return Math.Log(baseNum, logBase);
    }

    public double Sin(double angle)
    {
        return double.Round(Math.Sin(angle));
    }

    public double Cos(double angle)
    {
        return double.Round(Math.Cos(angle));
    }

    public double Tan(double angle)
    {
        return double.Round(Math.Tan(angle));
    }
}