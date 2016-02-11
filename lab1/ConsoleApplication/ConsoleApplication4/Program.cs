using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Net_module1_1_2_lab
{
    class Program
    {
        static void Main(string[] args)
        {
            // Use "Debugging" and "Watch" to study variables and constants

            //1) declare variables of all simple types:
            //bool, char, byte, sbyte, short, ushort, int, uint, long, ulong, decimal, float, double
            // their names should be: 
            //boo, ch, sb, sh, ush, i, ui, l, ul, de, fl, do
            // initialize them with 1, 100, 250.7, 150, 10000, -25, -223, 300, 100000.6, 8, -33.1
            // Check results (types and values). Is possible to do initialization?
            // Fix compilation errors (change values for impossible initialization)
            bool boo = true;
            char ch = default(char);
            byte b = 1;
            sbyte sb = 100;
            short sh = 150;
            ushort ush = 25;
            int i = 10000;
            uint ui = 22;
            long l = -223;
            ulong ul = 12324123412;
            decimal de = 213.213M;
            float fl = 123.123214F;
            double d = 1.213412;

            //2) declare constants of int and double. Try to change their values.
            const int ii = 22;
            const double dd = -231.123;

            //3) declare 2 variables with var. Initialize them 20 and 20.5. Check types. 
            // Try to reinitialize by 20.5 and 20 (change values). What results are there?
            var a = 20.5;
            var bb = 20;
            // 4) declare variables of System.Int32 and System.Double.
            // Initialize them by values of i and do. Is it possible?
            System.Int32 aa = 123;
            System.Double bbb = 321.123;
            if (true)
            {
                // 5) declare variables of int, char, double 
                // with names i, ch, do
                // is it possible?
                Console.WriteLine("It's not posible");

                // 6) change values of variables from 1)
                Console.WriteLine("Changing Values...");
            }

            // 7)check values of variables from 1). Are they changed? Think, why

            // 8) use implicit/ explicit conversion to convert variables from 1). 
            // Is it possible? 
            // Fix compilation errors (in case of impossible conversion commemt that line).
            // int -> char

            // bool -> short

            // double -> long

            // float -> char 

            // decimal -> double

            // byte -> uint

            // ulong -> sbyte

            // 9) and reverse conversion with fixing compilation errors.

            // 10) declare int nullable value. Initialize it with 'null'. 
            // Try to initialize variable i with 'null'. Is it possible?

        }
    }
}
