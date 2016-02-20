using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloOperators_stud
{
    class Program
    {
        static void Main(string[] args)
        {
            long a;
            Console.WriteLine(@"Please,  type the number:
            1. Farmer, wolf, goat and cabbage puzzle
            2. Console calculator
            3. Factirial calculation
            ");
            
            a = long.Parse(Console.ReadLine());
            switch (a)
            {
                case 1:
                    Farmer_puzzle();
                    Console.WriteLine("");
                    break;
                case 2:
                    Calculator();
                    Console.WriteLine("");
                    break;
                case 3:
                    Factorial_calculation();
                    Console.WriteLine("");
                    break;
                default:
                    Console.WriteLine("Exit");
                    break;
            }
            Console.WriteLine("Press any key");
            Console.ReadLine();
        }
        #region farmer
        static void Farmer_puzzle()
        {
            Console.WriteLine(@"Choose option:
                There: farmer and wolf - 1
                There: farmer and cabbage - 2
                There: farmer and goat - 3
                There: farmer  - 4
                Back: farmer and wolf - 5
                Back: farmer and cabbage - 6
                Back: farmer and goat - 7
                Back: farmer  - 8
                ");
            bool finish = false;

            bool farmer = false;
            bool wolf = false;
            bool goat = false;
            bool cabbage = false;

            while (!finish)
            {
                String action = Console.ReadLine();
                switch (action)
                {
                    case "1":
                        farmer = true;
                        wolf = true;
                    break;
                    case "2":
                        farmer = true;
                        cabbage = true;
                        break;
                    case "3":
                        farmer = true;
                        goat = true;
                                             
                        break;
                    case "4":
                        farmer = true;
                        break;
                    case "5":
                        farmer = false;
                        wolf = false;
                        break;
                    case "6":
                        farmer = false;
                        cabbage = false;
                        break;
                    case "7":
                        farmer = false;
                        goat = false;
                        break;
                    case "8":
                        farmer = false;
                        break;
                    default:
                        Console.WriteLine("Enter valid value: ");
                        break;

                }
                if (farmer && cabbage && wolf && goat)
                {
                    Console.WriteLine("Yeah!!!");
                        finish = true;
                }
                if ((!farmer && !wolf && goat && cabbage) || (farmer && !cabbage && !goat && wolf) 
                    || (farmer && cabbage && !goat && !wolf) || (!farmer && wolf && goat && !cabbage))
                {
                    Console.WriteLine("Fail!!!");
                        finish = true;
                    break;
                }
               
            }
            Console.ReadKey();
        }
        #endregion

        #region calculator
        static void Calculator()
        {
            //RV: This message is misleading.
            Console.WriteLine(@"Select the arithmetic operation: 
                                1. Multiplication 
                                2. Divide 
                                3. Addition 
                                4. Subtraction
                                5. Exponentiation ");
            double x, y;
            String action;
            Console.WriteLine("Type first number:");
            x = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Type operator * / + - ^:");
            action = Console.ReadLine();
            Console.WriteLine("Type last number:");
            y = Convert.ToDouble(Console.ReadLine());
            switch (action)
            {
                case "*":
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Ansver=");
                    Console.WriteLine(x * y);
                    break;
                case "/":
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Ansver=");
                    Console.WriteLine(x / y);
                    break;
                case "+":
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Ansver=");
                    Console.WriteLine(x + y);

                    break;
                case "-":
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Ansver=");
                    Console.WriteLine(x - y);
                    break;
                case "^":
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Ansver=");
                    Console.WriteLine(Math.Pow(x, y));
                    break;
                default:
                    Console.WriteLine("Enter valid value: ");
                    break;
            }
        }
        #endregion

        #region Factorial
        //RV: It looks like the actual implementation is commented out.
        static void Factorial_calculation()
        {
            int n = 5;
            Console.WriteLine("Enter argument:");
            n = int.Parse(Console.ReadLine());
            if (n<0)
            {
                throw new ArgumentException("Invalid value, use positive");
            }
            int result=1; 
            //if (n != 0)
            //{
             //   while (n > 1)
              //  {
                //    result *= n--;
               // }
           // }
                       
            
            Console.WriteLine(result);
        }



        static int CalculateFact(int n)
        {
            if (n == 1) {
                return n = 1;
            }
            return n * CalculateFact(n - 1);
            
        }
        #endregion
    }
}
