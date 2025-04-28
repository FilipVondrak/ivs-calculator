using System.Diagnostics.CodeAnalysis;
using math_lib;

[SuppressMessage("ReSharper", "SuggestVarOrType_BuiltInTypes")]
internal static class Program
{
    private static void Main()
    {
        Calculator calc = new();
        decimal sum = 0m; // Sum of x_i
        decimal sumSq = 0m; // x_i ^ 2
        long count = 0; // N

        string? line;
        // Read until EOF
        while ((line = Console.ReadLine()) != null)
        {
            // (char[])null splits by every possible white space character
            foreach (var number in line.Split((char[])null, StringSplitOptions.RemoveEmptyEntries))
            {
                // Process only valid numbers
                if (decimal.TryParse(number, out var value))
                {
                    sum = calc.Add(sum, value);
                    var square = calc.Multiply(value, value);
                    sumSq = calc.Add(sumSq, square);
                    ++count;
                }
            }
        }

        if (count < 2)
        {
            Console.Error.WriteLine("You need to input at least two numbers.");
            return;
        }

        decimal mean = calc.Divide(sum, count); // Mean value of x
        decimal meanSq = (decimal)calc.Power((double)mean, 2); // x^2
        decimal numerator = calc.Add(sumSq, calc.Multiply(-(decimal)count, meanSq)); // Sum of x_i^2 − N * [mean value of x] ^2
        decimal variance = calc.Divide(numerator, count - 1); 
        decimal stddev = (decimal)calc.Root(variance, 2); // Standard deviance

        Console.WriteLine(stddev);
    }
}