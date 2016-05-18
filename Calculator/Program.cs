using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = "!2+2*5";
            double r = Parse(s);
            Console.WriteLine(r);
            Console.ReadKey();
        }

        static double Parse(string s)
        {
            int index = 0;
            var v = Mult(s, ref index);
            while (index < s.Length)
            {
                switch (s[index])
                {
                    case '+':
                        index++;
                        v += Mult(s, ref index);
                        break;
                    case '-':
                        index++;
                        v -= Mult(s, ref index);
                        break;
                    default:
                        Console.WriteLine("Error!");
                        break;
                }
            }
            return v;
        }

        static double Mult(string s, ref int index)
        {
            var v = Fact(s, ref index);
            while (index < s.Length)
            {
                switch (s[index])
                {
                    case '*':
                        index++;
                        v *= Fact(s, ref index);
                        break;
                    case '/':
                        index++;
                        v /= Fact(s, ref index);
                        break;
                    default:
                        return v;
                }
            }
            return v;
        }

        static double Fact(string s, ref int index)
        {
            var v = GetNumber(s, ref index);
            while (index < s.Length)
            {
                switch (s[index])
                {
                    case '!':
                        index++;
                        v *= (v - 1) * GetNumber(s, ref index);
                        break;
                    default:
                        return v;
                }
            }
            return v;
        }

        static double GetNumber(string s, ref int index)
        {
            string result = string.Empty;
            foreach (char c in s.Substring(index))
            {
                if (char.IsDigit(c))
                {
                    result += c.ToString();
                    index++;
                }
                else if (c == '!')
                {
                    index++;
                    continue;
                }
                else break;
            }
            return double.Parse(result);
        }
    }
}

////////////////second try////////////////////////
/*   public static string Reverse(string s)
   {
       char[] charArray = s.ToCharArray();
       Array.Reverse(charArray);
       return new string(charArray);
   }

   static string DoMult(string s)
   {
       double val1;
       double val2;

       int index = 1;
       int reverseIndex = s.Length;

       string resString = s;

       foreach(char c in s)
       {
           if(c == '*' && index < s.Length)
           {
               val1 = GetNumber(Reverse(s), ref reverseIndex);
               val2 = GetNumber(s, ref index);

               val1 = int.Parse(Reverse(val1.ToString()));

               double res = val1 * val2;

               string expression = string.Format("{0}*{1}", val1, val2);

               resString = resString.Replace(expression, res.ToString());
           }

           reverseIndex--;
           index++;
       }

       return resString;
   }*/
////////////////first try////////////////////////
/*
 static void Main()
    {
        bool exit = false;
        while (!exit)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Калькулятор");
            Console.WriteLine(' ');
            double a, b;
            Console.WriteLine("Введите первое значение");
            a = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите второе значение");
            b = double.Parse(Console.ReadLine());
            Console.WriteLine(' ');
            Console.WriteLine(@"Выберите арифметическое действие: 
         - Умножение (введите *) 
         - Деление (введите /) 
         - Сложение (введите +) 
         - Вычитание (введите -)");
            string q = Console.ReadLine();
            if (q == "*")
                Console.WriteLine("Результат умножения = {0}", a * b);
            if (q == "/")
                Console.WriteLine("Результат деления = {0}", a / b);
            if (q == "+")
                Console.WriteLine("Результат сложения = {0}", a + b);
            if (q == "-")
                Console.WriteLine("Результат вычитания = {0}", a - b);

            Console.WriteLine("продолжить: Y/N");
            string exitCommand = Console.ReadLine();
            if (exitCommand.ToLower() == "n")
            {
                exit = true;
            }
            Console.Clear();
        }
    }*/
