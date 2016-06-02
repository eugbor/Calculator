using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = "3!+1*5-4^2";
            double r = Parse(s);
            Console.WriteLine(r);
            Console.ReadKey();
        }

        // sets the starting index
        // produces arithmetic operations
        //of addition and subtraction
        static double Parse(string s)
        {
            int index = 0;
            var v = MultDiv(s, ref index);
            while (index < s.Length)
            {
                switch (s[index])
                {
                    case '+':
                        index++;
                        v += MultDiv(s, ref index);
                        break;
                    case '-':
                        index++;
                        v -= MultDiv(s, ref index);
                        break;
                    default:
                        Console.WriteLine("Error!");
                        break;
                }
            }
            return v;
        }

        // produces arithmetic operations
        //of multiplication and division
        static double MultDiv(string s, ref int index)
        {
            var v = Sqr(s, ref index);
            while (index < s.Length)
            {
                if (s[index] == '*')
                {
                    index++;
                    v *= Sqr(s, ref index);
                }
                else if (s[index] == '/')
                {
                    index++;
                    v /= Sqr(s, ref index);
                }
                else { break; }
            }
            return v;
        }

        // involute
        static double Sqr(string s, ref int index)
        {
            var v = Fact(s, ref index);

            if (index < s.Length && s[index] == '^')
            {
                index++;
                v = Math.Pow(v, Fact(s, ref index));
            }
            return v;
        }

        // multiplies all the natural numbers from 1 to v
        static double Fact(string s, ref int index)
        {
            var v = GetNumber(s, ref index);
            while (index < s.Length)
            {
                if (s[index] == '!')
                {
                    index++;
                    v = fact(v);
                }
                else { break; }

            }
            return v;
        }

        // calculate the factorial
        static double fact(double v)
        {
            double f = 1;
            int i = 1;
            while ( i <= v )
            {
                f *= i;
                i++;
            }
            v = f;
            return v;
        }

        // parses string, checks each symbol
        //and recognizes the number of string
        static double GetNumber(string s, ref int index)
        {
            var tmp = "";
            foreach (var c in s.Substring(index))
            {
                if (!char.IsDigit(c))
                {
                    break;
                }
                tmp += c;
                index++;
            }
            return double.Parse(tmp);
        }
    }
}
