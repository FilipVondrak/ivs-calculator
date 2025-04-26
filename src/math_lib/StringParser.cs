using System.Numerics;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ExtendedNumerics;

namespace math_lib;

public class StringParser : IStringParser
{
    Calculator calc = new Calculator();
    
    public string[] ParseToTokens(string expression)
    {
        string pattern = @"(?<=^|\(|√|\^)-\d+([.,]\d+)?|\d+([.,]\d+)?|e|sin|cos|tan|ln|[()\[\]+\-\*/^%!√]";
             
        MatchCollection matches = Regex.Matches(expression, pattern);
             
        string[] tokens = new string[matches.Count];
        for (int i = 0; i < matches.Count; i++)
        {
            tokens[i] = matches[i].Value;
        }

        return tokens;
    }

    public string CalculateDeepestBrackets(string expression)
    {
        string[] tokens = ParseToTokens(expression);

        int level = 0;
        int maxLevel = 0;
        List<int> startIndices = new List<int>();

        // 1. Najít nejhlubší level a všechny startIndexy
        for (int i = 0; i < tokens.Length; i++)
        {
            if (tokens[i] == "(")
            {
                level++;
                if (level > maxLevel)
                {
                    maxLevel = level;
                    startIndices.Clear();
                    startIndices.Add(i);
                }
                else if (level == maxLevel)
                {
                    startIndices.Add(i);
                }
            }
            else if (tokens[i] == ")")
            {
                level--;
            }
        }

        if (startIndices.Count == 0)
            return expression; // nejsou žádné závorky

        // 2. Zpracovávat odzadu (aby se indexy neposunuly)
        startIndices.Reverse();

        foreach (int startIndex in startIndices)
        {
            // Najít endIndex pro tento startIndex
            int endIndex = startIndex;
            int innerLevel = 1;
            while (endIndex + 1 < tokens.Length && innerLevel > 0)
            {
                endIndex++;
                if (tokens[endIndex] == "(") innerLevel++;
                else if (tokens[endIndex] == ")") innerLevel--;
            }

            // Vybrat vnitřní tokeny
            List<string> innerTokens = new List<string>();
            for (int i = startIndex + 1; i < endIndex; i++)
            {
                innerTokens.Add(tokens[i]);
            }

            string innerExpression = string.Join("", innerTokens);
            string innerResult = SolveExpression(innerExpression);

            // Připravit nový seznam tokenů
            List<string> newTokens = new List<string>();

            // Přidat vše před funkcí nebo závorkou
            for (int i = 0; i < startIndex; i++)
            {
                newTokens.Add(tokens[i]);
            }

            // Zkontrolovat, jestli je před závorkou funkce
            bool isFunction = false;
            int functionIndex = startIndex - 1;

            if (functionIndex >= 0)
            {
                string functionName = tokens[functionIndex];
                if (functionName == "sin" || functionName == "cos" || functionName == "tan" || functionName == "ln")
                {
                    isFunction = true;
                    newTokens.RemoveAt(newTokens.Count - 1); // Odebrat funkci
                    newTokens.Add(functionName);
                    newTokens.Add("[");
                    newTokens.Add(innerResult);
                    newTokens.Add("]");
                }
            }

            if (!isFunction)
            {
                newTokens.Add(innerResult);
            }

            // Přidat vše po konci závorky
            for (int i = endIndex + 1; i < tokens.Length; i++)
            {
                newTokens.Add(tokens[i]);
            }

            tokens = newTokens.ToArray(); // aktualizace tokens po každé úpravě
        }

        return string.Join("", tokens);
    }

    
    public string SolveExpression(string expression)
    {
        expression = expression.Replace("e", Math.E.ToString());
        
        while (GonFuncsIn(expression))
        {
            string[] tokens = ParseToTokens(expression);

            for (int i = 0; i < tokens.Length; i++)
            {
                if ((tokens[i] == "sin" || tokens[i] == "cos" || tokens[i] == "tan") && tokens[i + 1] == "[")
                {
                    BigDecimal result;

                    if (tokens[i] == "sin") 
                        result = calc.Sin(decimal.Parse(tokens[i + 2]));
                    else if (tokens[i] == "cos") 
                        result = calc.Cos(decimal.Parse(tokens[i + 2]));
                    else 
                        result = calc.Tan(decimal.Parse(tokens[i + 2]));

                    string[] newTokens = new string[tokens.Length - 3];
                    int index = 0;

                    for (int j = 0; j < newTokens.Length; j++)
                    {
                        if (j < i)
                        {
                            newTokens[index++] = tokens[j];
                        }
                        else
                        {
                            newTokens[index++] = result.ToString();
                        }
                    }

                    tokens = newTokens;
                    break;
                }
            }
            expression = string.Join("", tokens);
        }

        while (LnIn(expression))
        {
            string[] tokens = ParseToTokens(expression);

            for (int i = 0; i < tokens.Length; i++)
            {
                if (tokens[i] == "ln" && tokens[i + 1] == "[")
                {
                    BigDecimal result = calc.Ln(decimal.Parse(tokens[i + 2]));
                    string[] newTokens = new string[tokens.Length - 3];
                    int index = 0;

                    for (int j = 0; j < tokens.Length; j++)
                    {
                        if (j == i)
                        {
                            newTokens[index++] = result.ToString();
                            j += 3;
                        }
                        else
                        {
                            newTokens[index++] = tokens[j];
                        }
                    }

                    tokens = newTokens;
                    break;
                }
            }
            expression = string.Join("", tokens);
        }
        
        while (MultiplyIn((expression)))
        {
            string[] tokens = ParseToTokens(expression);

            for (int i = 0; i < tokens.Length; i++)
            {
                if (tokens[i] == "*")
                {
                    decimal result = calc.Multiply(decimal.Parse(tokens[i - 1]), decimal.Parse(tokens[i + 1]));
                    string[] newTokens = new string[tokens.Length - 2];
                    int index = 0;

                    for (int j = 0; j < tokens.Length; j++)
                    {
                        if (j == i-1)
                        {
                            newTokens[index++] = result.ToString();
                            j += 2;
                        }
                        else
                        {
                            newTokens[index++] = tokens[j];
                        }
                    }
                    tokens = newTokens;
                    break;
                }
            }
            expression =  string.Join("", tokens);
        }
        
        while (DivideIn((expression)))
        {
            string[] tokens = ParseToTokens(expression);

            for (int i = 0; i < tokens.Length; i++)
            {
                if (tokens[i] == "/")
                {
                    decimal result = calc.Divide(decimal.Parse(tokens[i - 1]), decimal.Parse(tokens[i + 1]));
                    string[] newTokens = new string[tokens.Length - 2];
                    int index = 0;

                    for (int j = 0; j < tokens.Length; j++)
                    {
                        if (j == i-1)
                        {
                            newTokens[index++] = result.ToString();
                            j += 2;
                        }
                        else
                        {
                            newTokens[index++] = tokens[j];
                        }
                    }
                    tokens = newTokens;
                    break;
                }
            }
            expression =  string.Join("", tokens);
        }
        
        while (ModuloIn((expression)))
        {
            string[] tokens = ParseToTokens(expression);

            for (int i = 0; i < tokens.Length; i++)
            {
                if (tokens[i] == "%")
                {
                    BigDecimal result = calc.Mod(decimal.Parse(tokens[i - 1]), decimal.Parse(tokens[i + 1]));
                    string[] newTokens = new string[tokens.Length - 2];
                    int index = 0;

                    for (int j = 0; j < tokens.Length; j++)
                    {
                        if (j == i-1)
                        {
                            newTokens[index++] = result.ToString();
                            j += 2;
                        }
                        else
                        {
                            newTokens[index++] = tokens[j];
                        }
                    }
                    tokens = newTokens;
                    break;
                }
            }
            expression =  string.Join("", tokens);
        }
        
        while (PowerIn((expression)))
        {
            string[] tokens = ParseToTokens(expression);

            for (int i = 0; i < tokens.Length; i++)
            {
                if (tokens[i] == "^")
                {
                    BigDecimal result = calc.Power(double.Parse(tokens[i - 1]), double.Parse(tokens[i + 1]));
                    string[] newTokens = new string[tokens.Length - 2];
                    int index = 0;

                    for (int j = 0; j < tokens.Length; j++)
                    {
                        if (j == i-1)
                        {
                            newTokens[index++] = result.ToString();
                            j += 2;
                        }
                        else
                        {
                            newTokens[index++] = tokens[j];
                        }
                    }
                    tokens = newTokens;
                    break;
                }
            }
            expression =  string.Join("", tokens);
        }
        
        while (RootIn((expression)))
        {
            string[] tokens = ParseToTokens(expression);

            for (int i = 0; i < tokens.Length; i++)
            {
                if (tokens[i] == "√")
                {
                    BigDecimal result = calc.Root(decimal.Parse(tokens[i - 1]), int.Parse(tokens[i + 1]));
                    string[] newTokens = new string[tokens.Length - 2];
                    int index = 0;

                    for (int j = 0; j < tokens.Length; j++)
                    {
                        if (j == i-1)
                        {
                            newTokens[index++] = result.ToString();
                            j += 2;
                        }
                        else
                        {
                            newTokens[index++] = tokens[j];
                        }
                    }
                    tokens = newTokens;
                    break;
                }
            }
            expression =  string.Join("", tokens);
        }
        
        while (FactorialIn((expression)))
        {
            string[] tokens = ParseToTokens(expression);

            for (int i = 0; i < tokens.Length; i++)
            {
                if (tokens[i] == "!")
                {
                    BigDecimal result = calc.Factorial(int.Parse(tokens[i - 1]));
                    string[] newTokens = new string[tokens.Length - 1];
                    int index = 0;

                    for (int j = 0; j < newTokens.Length; j++)
                    {
                        if (j == i)
                        {
                            newTokens[index++] = tokens[j];
                            j += 1;
                        }
                        else
                        {
                            newTokens[index++] = result.ToString();
                        }
                    }
                    tokens = newTokens;
                    break;
                }
            }
            expression =  string.Join("", tokens);
        }
        
        while (AddIn((expression)))
        {
            string[] tokens = ParseToTokens(expression);

            for (int i = 0; i < tokens.Length; i++)
            {
                if (tokens[i] == "+")
                {
                    decimal result = calc.Add(decimal.Parse(tokens[i - 1]), decimal.Parse(tokens[i + 1]));
                    string[] newTokens = new string[tokens.Length - 2];
                    int index = 0;

                    for (int j = 0; j < tokens.Length; j++)
                    {
                        if (j == i-1)
                        {
                            newTokens[index++] = result.ToString();
                            j += 2;
                        }
                        else
                        {
                            newTokens[index++] = tokens[j];
                        }
                    }
                    tokens = newTokens;
                    break;
                }
            }
            expression =  string.Join("", tokens);
        }
        
        while (SubtractIn((expression)))
        {
            string[] tokens = ParseToTokens(expression);

            for (int i = 0; i < tokens.Length; i++)
            {
                if (tokens[i] == "-")
                {
                    decimal result = calc.Subtract(decimal.Parse(tokens[i - 1]), decimal.Parse(tokens[i + 1]));
                    string[] newTokens = new string[tokens.Length - 2];
                    int index = 0;

                    for (int j = 0; j < tokens.Length; j++)
                    {
                        if (j == i-1)
                        {
                            newTokens[index++] = result.ToString();
                            j += 2;
                        }
                        else
                        {
                            newTokens[index++] = tokens[j];
                        }
                    }
                    tokens = newTokens;
                    break;
                }
            }
            expression =  string.Join("", tokens);
        }

        return expression;
    }

    public decimal SolveWholeExpression(string expression)
    {
        /*while (BracketIn(expression))
        {
            expression = CalculateDeepestBrackets(expression);
        }
        SolveExpression(expression);

        return decimal.Parse(expression);*/
        return 1;
    }

    public bool BracketIn(string expression)
    {
        string[] tokens = ParseToTokens(expression);
        
        for (int i = 0; i < tokens.Length; i++)
        {
            if (tokens[i] == "(" || tokens[i] == ")")
            {
                return true;
            }
        }
        
        return false;
    }

    public bool AddIn(string expression)
    {
        string[] tokens = ParseToTokens(expression);
        
        for (int i = 0; i < tokens.Length; i++)
        {
            if (tokens[i] == "+")
            {
                return true;
            }
        }
        
        return false;
    }

    public bool SubtractIn(string expression)
    {
        string[] tokens = ParseToTokens(expression);
        
        for (int i = 0; i < tokens.Length; i++)
        {
            if (tokens[i] == "-")
            {
                return true;
            }
        }
        
        return false;
    }

    public bool MultiplyIn(string expression)
    {
        string[] tokens = ParseToTokens(expression);
        
        for (int i = 0; i < tokens.Length; i++)
        {
            if (tokens[i] == "*")
            {
                return true;
            }
        }
        
        return false;
    }

    public bool DivideIn(string expression)
    {
        string[] tokens = ParseToTokens(expression);
        
        for (int i = 0; i < tokens.Length; i++)
        {
            if (tokens[i] == "/")
            {
                return true;
            }
        }
        
        return false;
    }

    public bool FactorialIn(string expression)
    {
        string[] tokens = ParseToTokens(expression);
        
        for (int i = 0; i < tokens.Length; i++)
        {
            if (tokens[i] == "!")
            {
                return true;
            }
        }
        
        return false;
    }

    public bool PowerIn(string expression)
    {
        string[] tokens = ParseToTokens(expression);
        
        for (int i = 0; i < tokens.Length; i++)
        {
            if (tokens[i] == "^")
            {
                return true;
            }
        }
        
        return false;
    }

    public bool RootIn(string expression)
    {
        string[] tokens = ParseToTokens(expression);
        
        for (int i = 0; i < tokens.Length; i++)
        {
            if (tokens[i] == "√")
            {
                return true;
            }
        }
        
        return false;
    }

    public bool LnIn(string expression)
    {
        string[] tokens = ParseToTokens(expression);
        
        for (int i = 0; i < tokens.Length; i++)
        {
            if (tokens[i] == "ln")
            {
                return true;
            }
        }
        
        return false;
    }

    public bool GonFuncsIn(string expression)
    {
        string[] tokens = ParseToTokens(expression);
        
        for (int i = 0; i < tokens.Length; i++)
        {
            if (tokens[i] == "sin" || tokens[i] == "cos" || tokens[i] == "tan")
            {
                return true;
            }
        }
        
        return false;
    }

    public bool ModuloIn(string expression)
    {
        string[] tokens = ParseToTokens(expression);
        
        for (int i = 0; i < tokens.Length; i++)
        {
            if (tokens[i] == "%")
            {
                return true;
            }
        }
        
        return false;
    }
}
