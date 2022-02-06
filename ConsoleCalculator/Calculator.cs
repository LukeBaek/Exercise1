using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    internal class Calculator
    {
        public static double DoOperation(double num1, double num2, string op)
        {
            double result = double.NaN; 
            
            switch (op)
            {
                case "+":
                    result = num1 + num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                case "/":
                    // non-zero divisor.
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    if (num2 == 0)
                    {
                        Console.Write("\nDividing by Zero is undefined \n");
                    }
                    break;                    
                default:                    
                    break;
            }
            return result;
        }
        public static bool IsNumeric(string value)
        {
            return value.All(char.IsNumber);
        }
    }
}

