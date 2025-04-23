using System.Numerics;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ExtendedNumerics;

namespace math_lib;

public class StringParser : IStringParser
{
    Calculator calc = new Calculator();
    // public string CalculateBracket(string expression)
    // {
    //     string input = expression; //   "1 + ((2 + 3) * 4)"
    //     
    //     string pattern = @"\d+|[()+\-*/]|\s+";
    //     
    //     MatchCollection matches = Regex.Matches(input, pattern);
    //     
    //     string[] tokens = new string[matches.Count];
    //     for (int i = 0; i < matches.Count; i++)
    //     {
    //         tokens[i] = matches[i].Value;
    //     }
    //
    //     int level = 0;
    //     int maxLevel = 0;
    //     int maxLevelIndex = -1;
    //
    //     for (int i = 0; i < tokens.Length; i++)
    //     {
    //         if (tokens[i] == "(")
    //         {
    //             level ++;
    //             if (level > maxLevel)
    //             {
    //                 maxLevel = level;
    //                 maxLevelIndex = i;
    //             }
    //         }
    //         else if (tokens[i] == ")")
    //         {
    //             level--;
    //         }
    //     }
    //     
    //     for (int i = maxLevelIndex; tokens[i] == "("; i++)
    //     {
    //         switch (tokens[i])
    //         {
    //             case "+":
    //                 calc.Add(decimal.Parse(tokens[i+1]), decimal.Parse(tokens[i + 1]));
    //                 break;
    //
    //             case "-":
    //                 
    //                 break;
    //
    //             case "*":
    //                 
    //                 break;
    //             
    //             case "/":
    //                 
    //                 break;
    //             
    //             default:
    //                 
    //                 break;
    //         }
    //
    //     }
    //     
    //     return "";
    // }

    public string CalculateDeepestBrackets(string expression)
    {
        /*
         *  najdi indexy nejhlubsich zavorek a predej do SolveExpression vyrazy v tech zavorkach
         *
         * doporucil bych ti chekovat vsechny zavorky i kdyz pred nimi je sin
         * treba jako sin(60)m jen pak zamenit to za sin[60], viz SolveExpression
         *
         * protoze kdyby doslo k sin(ln(17)+sin(cos(11)+5)) tak potrebujes resit taky zavorky vevnitr
         *
         * tip: ln(x) je v math_lib log()
         */
        throw new NotImplementedException();
    }

    public string SolveExpression(string expression)
    {
        /*
         * pouzij boolove funkce do while:
         *
         * while(GonFuncsIn(expression)){
         *  najdi prvni vyskyt goneomtricke funkci a vyres(pouzij mathlib)
         *  ...
         *  expression = new_expression; // vyresena prvni nalezena gon funkce 
         * }
         *
         * while(LogIn(expression)){
         *  najdi prvni vyskyt log funkci a vyres(pouzij mathlib)
         *  ...
         *  expression = new_expression; // vyresena prvni nalezena log funkce 
         * }
         *
         * a pokracuj tak se vsemi matematickimi funkcemi v poradi priority funkce, nasobeni pred souctem atd...
         *
         * Poznamka: doporucil bych ti kdyz najdes zavorku (60) tak zkontrolovat jestli pred
         *            ni neni sin, tan, cos atd(zalezi na implementaci frontend logu root atd)
         *             a pak zamenit (60) na [60] kdyz pred tim je nejaka takova funkce
         *              az budes v SolveExpression resit ty funkce tak jen predas do funkce z math_lib to co je v []
         */
        throw new NotImplementedException();
    }

    public decimal SolveWholeExpression(string expression)
    {
        /*
         * while(BracketIn(expression = CalculateDeepestBrackets(expression)))
         *  ;
         *
         * SolveExpression(expression);
         *
         * return (decimal)expression;
         */
        throw new NotImplementedException();
    }

    public bool BracketIn(string expression)
    {
        throw new NotImplementedException();
    }

    public bool AddIn(string expression)
    {
        throw new NotImplementedException();
    }

    public bool SubtractIn(string expression)
    {
        throw new NotImplementedException();
    }

    public bool MultiplyIn(string expression)
    {
        throw new NotImplementedException();
    }

    public bool DivideIn(string expression)
    {
        throw new NotImplementedException();
    }

    public bool FactorialIn(string expression)
    {
        throw new NotImplementedException();
    }

    public bool PowerIn(string expression)
    {
        throw new NotImplementedException();
    }

    public bool RootIn(string expression)
    {
        throw new NotImplementedException();
    }

    public bool LogIn(string expression)
    {
        throw new NotImplementedException();
    }

    public bool GonFuncsIn(string expression)
    {
        throw new NotImplementedException();
    }
}
