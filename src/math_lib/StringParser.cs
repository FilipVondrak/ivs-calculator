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
        string pattern = @"-?\d+(\.\d+)?|sin|cos|tan|ln|[()+\-*/^%!√]";
             
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
        string[] tokens = ParseToTokens(expression);

        int level = 0;
        int maxLevel = 0;
        int startIndex = -1;
        
        // Najít nejhlubší (
        for (int i = 0; i < tokens.Length; i++)
        {
            if (tokens[i] == "(")
            {
                level++;
                if (level > maxLevel)
                {
                    maxLevel = level;
                    startIndex = i;
                }
            }
            else if (tokens[i] == ")")
            {
                level--;
            }
        }
        
        // Najít odpovídající )
        int endIndex = startIndex;
        int innerLevel = 1;
        while (endIndex + 1 < tokens.Length && innerLevel > 0)
        {
            endIndex++;
            if (tokens[endIndex] == "(") innerLevel++;
            else if (tokens[endIndex] == ")") innerLevel--;
        }
        
        // Složit výraz mezi startIndex a endIndex
        string innerExpression = "";
        for (int i = startIndex + 1; i < endIndex; i++)
        {
            innerExpression += tokens[i];
        }

        // Vyřešit vnitřní výraz
        string innerResult = SolveExpression(innerExpression);

        // Složit nový celý výraz
        string resultExpression = "";
        for (int i = 0; i < startIndex; i++)
        {
            resultExpression += tokens[i];
        }
        resultExpression += innerResult;
        for (int i = endIndex + 1; i < tokens.Length; i++)
        {
            resultExpression += tokens[i];
        }

        return resultExpression;
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
