using System.ComponentModel;
using System.Numerics;
using ExtendedNumerics;

namespace math_lib;

public class Calculator : ICalculator
{
    public decimal Add(decimal x, decimal y) => x + y;

    public decimal Subtract(decimal x, decimal y) => x - y;

    public decimal Multiply(decimal x, decimal y)
    {
        return decimal.Round(x*y, 5, MidpointRounding.AwayFromZero);
    }

    public decimal Divide(decimal x, decimal y)
    {
        if (y == 0)
        {
            throw new DivideByZeroException("Division by zero is not allowed.");
        }

        return decimal.Round(x / y, 5, MidpointRounding.AwayFromZero);
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

    public BigDecimal Power(double baseNum, double exponent)
    {
        return BigDecimal.Round(BigDecimal.Pow(baseNum, exponent), 5, RoundingStrategy.AwayFromZero);
    }

    public BigDecimal Root(decimal baseNum, int rootDegree)
    {
        bool invert = false;
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

        if (baseNum < 0 && rootDegree % 2 != 0)
        {
            // BigDecimal.NthRoot doesn't support negative base numbers
            invert = true;
            baseNum = decimal.Abs(baseNum);
        }
        BigDecimal result = BigDecimal.Round(BigDecimal.NthRoot(baseNum, rootDegree, 10),
            precision: 5, RoundingStrategy.AwayFromZero);
        if (invert) return -result;
        return result;
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

        return BigDecimal.Round(BigDecimal.Log(baseNum, logBase), 5, RoundingStrategy.AwayFromZero);
    }

    public BigDecimal Ln(decimal baseNum)
    {
        if (baseNum <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(baseNum), baseNum, "Base number must be greater than zero.");
        }

        return BigDecimal.Round(BigDecimal.Ln(baseNum), 5, RoundingStrategy.AwayFromZero);
    }

    public BigDecimal Sin(decimal angle)
    {
        var radians = angle * BigDecimal.π / 180;
        return BigDecimal.Round(BigDecimal.Sin(radians), 5, RoundingStrategy.AwayFromZero);
    }

    public BigDecimal Cos(decimal angle)
    {
        //BigDecimal.Cos returns the wrong sign on multiples of 360, which are equal to 0
        if (angle % 360 == 0)
        {
            angle = 0;
        }
        var radians = angle * BigDecimal.π / 180;
        return BigDecimal.Round(BigDecimal.Cos(radians), 5, RoundingStrategy.AwayFromZero);
    }

    public BigDecimal Tan(decimal angle)
    {
        var radians = angle * BigDecimal.π / 180;
        var sin = BigDecimal.Sin(radians);
        var cos = BigDecimal.Cos(radians);
        if (cos == 0)
        {
            throw new ArgumentOutOfRangeException(nameof(angle), angle, "Cosine angle must be greater than zero.");
        }
        return Divide((decimal)sin, (decimal)cos);
    }
}