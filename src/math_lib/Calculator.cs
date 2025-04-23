using System.Numerics;
using ExtendedNumerics;

namespace math_lib;

public class Calculator : ICalculator
{
    public decimal Add(decimal x, decimal y)
    {
        return x + y;
    }

    public decimal Subtract(decimal x, decimal y)
    {
        return x - y;
    }

    public decimal Multiply(decimal x, decimal y)
    {
        return x * y;
    }

    public decimal Divide(decimal x, decimal y)
    {
        if (y == 0)
        {
            throw new DivideByZeroException("Division by zero is not allowed.");
        }

        return decimal.Round(x / y, 5);
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

    public BigDecimal Power(decimal baseNum, int exponent)
    {
        return BigDecimal.Pow(baseNum, exponent);
    }

    public BigDecimal Root(decimal baseNum, int rootDegree)
    {
        if (rootDegree <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(rootDegree), rootDegree,
                "Root degree must be greater than zero.");
        }

        if (baseNum < 0 && rootDegree % 2 == 0)
        {
            throw new ArgumentOutOfRangeException(nameof(baseNum), baseNum,
                "Root cannot be even when base number is negative.");
        }

        return BigDecimal.NthRoot(baseNum, rootDegree, 5);
    }

    public BigDecimal Log(decimal baseNum, int logBase)
    {
        if (baseNum <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(baseNum), baseNum, "Base number must be greater than zero.");
        }

        if (logBase is < 0 or 0 or 1)
        {
            throw new ArgumentOutOfRangeException(nameof(logBase), logBase,
                "logBase cannot be negative, equal to 0 or 1.");
        }

        return BigDecimal.Round(BigDecimal.Log(baseNum, logBase), 5);
    }

    public BigDecimal Sin(decimal angle)
    {
        var radians = angle * BigDecimal.π / 180;
        return BigDecimal.Sin(radians);
    }

    public BigDecimal Cos(decimal angle)
    {
        var radians = angle * BigDecimal.π / 180;
        return BigDecimal.Cos(radians);
    }

    public BigDecimal Tan(decimal angle)
    {
        var radians = angle * BigDecimal.π / 180;
        var sin = BigDecimal.Sin(radians);
        var cos = BigDecimal.Cos(radians);
        return sin / cos;
    }
}