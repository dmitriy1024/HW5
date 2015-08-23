using System;

namespace HW5.Delegates.Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstNumStr;
            string secondNumStr;
            string opStr;
            double firstNum;
            double secondNum;
            Func<double, double, double> func = null;

            while (true)
            {
                Console.WriteLine("Enter the first number-> (x to exit)");
                firstNumStr = Console.ReadLine();

                if (firstNumStr == "x")
                    return;
                if (!Double.TryParse(firstNumStr, out firstNum))
                {
                    Console.WriteLine("Try again!");
                    continue;
                }
                
                Console.WriteLine("Enter the second number-> (x to exit)");
                secondNumStr = Console.ReadLine();
                if (secondNumStr == "x")
                    return;
                if (!Double.TryParse(secondNumStr, out secondNum))
                {
                    Console.WriteLine("Try again!");
                    continue;
                }
                
                Console.WriteLine("Enter the operation (like +,-,*,/) (x to exit)");
                opStr = Console.ReadLine();
                
                switch(opStr)
                {
                    case "+":
                        func = (x, y) => { return x + y; };
                        break;
                    case "-":
                        func = (x, y) => { return x - y; };
                        break;
                    case "*":
                        func = (x, y) => { return x * y; };
                        break;
                    case "/":
                        func = (x, y) => { if (y != 0) return x / y;
                                       else throw new DivideByZeroException(); };
                        break;
                    case "x":
                        return;                               
                }
                if(func != null)
                {
                    try
                    {
                        Console.WriteLine("Result: {0}", DoOperation(firstNum, secondNum, func));
                    }
                    catch(DivideByZeroException)
                    {
                        Console.WriteLine("Dividing by zero is imposssible!");
                    }                       
                }
                else
                {
                    Console.WriteLine("Try Again");
                }                   
            }
        }

        static double DoOperation(double a, double b, Func<double, double, double> func)
        {
            return func(a, b);
        }
    }
}
