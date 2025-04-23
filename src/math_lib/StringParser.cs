using System.Numerics;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace math_lib;

public class StringParser : IStringParser
{
    Calculator calc = new Calculator();
    public string CalculateBracket(string expression)
    {
        string input = expression; //   "1 + ((2 + 3) * 4)"
        
        string pattern = @"\d+|[()+\-*/]|\s+";
        
        MatchCollection matches = Regex.Matches(input, pattern);
        
        string[] tokens = new string[matches.Count];
        for (int i = 0; i < matches.Count; i++)
        {
            tokens[i] = matches[i].Value;
        }

        int level = 0;
        int maxLevel = 0;
        int maxLevelIndex = -1;

        for (int i = 0; i < tokens.Length; i++)
        {
            if (tokens[i] == "(")
            {
                level ++;
                if (level > maxLevel)
                {
                    maxLevel = level;
                    maxLevelIndex = i;
                }
            }
            else if (tokens[i] == ")")
            {
                level--;
            }
        }
        
        for (int i = maxLevelIndex; tokens[i] == "("; i++)
        {
            switch (tokens[i])
            {
                case "+":
                    calc.Add(double.Parse(tokens[i+1]), double.Parse(tokens[i + 1]));
                    break;

                case "-":
                    
                    break;

                case "*":
                    
                    break;
                
                case "/":
                    
                    break;
                
                default:
                    
                    break;
            }

        }
        
        return "";
    }

    public string SolveExpression(string expression)
    {
        
        return "";
    }
}
