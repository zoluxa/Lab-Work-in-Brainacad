using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Hello_Operators_lect
{
    class Program
    {
        static void Main(string[] args)
        {
            int a;
            try
            {
                do
                {
                    //do something
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(@"Please,  type the number:
                    1.  f(a,b) = |a-b| (unary)
                    2.  f(a) = a (binary)
                    3.  music
                    4.  morse sos
          
                    ");
                        try
                        {
                            a = (int)uint.Parse(Console.ReadLine());
                            switch (a)
                            {
                                case 2:
                                    My_Binary();
                                    Console.WriteLine("");
                                    break;
                                case 1:
                                    My_strings();
                                    Console.WriteLine("");
                                    break;
                                case 3:
                                    My_music();
                                    Console.WriteLine("");
                                    break;
                                case 4:
                                    Morse_code();
                                    Console.WriteLine("");
                                    break;

                                default:
                                    Console.WriteLine("Exit");
                                    break;
                            }

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Error");
                        }
                        finally
                        {

                        }
                    }
                    //end do something
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Press Spacebar to exit; press any key to continue");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                while (Console.ReadKey().Key != ConsoleKey.Spacebar);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }





        }
        #region ToFromBinary
        static void My_Binary()
        {
            int a;
            string a_str = "0";
            Console.WriteLine("Type  positive integer");
            a = (int)uint.Parse(Console.ReadLine());
            if (a > 0)
            {
                long hldr;
                char[] bnrary;
                a_str = "";
                while (a > 0)
                {
                    hldr = a % 2;
                    a_str += hldr;
                    a = a / 2;
                }
                bnrary = a_str.ToCharArray();
                Array.Reverse(bnrary);
                a_str = new string(bnrary);
            }

            Console.WriteLine(" Binary a = " + a_str);
            //Convert.ToInt64(str, 2).ToString(); - back
        }
        #endregion

        #region ToFromUnary
        static void My_strings()
        {
            int a, b;
            string a_str, b_str, ab_str, res_str;
            long a_length, b_length, min_length;


            Console.WriteLine("Type first positive integer");
            a = (int)uint.Parse(Console.ReadLine());
            Console.WriteLine("Type second positive integer");
            b = (int)uint.Parse(Console.ReadLine());

            {
                a_str = "";
                for (int ii = 0; ii < a; ii++)
                {
                    a_str += "1";
                }
                Console.WriteLine(a_str);

                b_str = "";
                for (int ii = 0; ii < b; ii++)
                {
                    b_str += "1";
                }
                Console.WriteLine(b_str);

                ab_str = a_str + "#" + b_str;
                a_length = a_str.Length;
                b_length = b_str.Length;
                if (a_length == 0)
                    res_str = b_str;
                else if (b_length == 0)
                    res_str = a_str;
                else
                {
                    if (a_length < b_length)
                        min_length = a_length;
                    else
                        min_length = b_length;
                    res_str = ab_str;
                    for (int i = 1; i <= min_length; i++)
                    {
                        res_str = res_str.Replace("1#1", "#");
                    }
                    res_str = res_str.Trim(new Char[] { '#' });


                }
                Console.WriteLine(" Unary |a-b|= " + res_str);
                int IntResult = 0;
                for (int iii = 1; iii <= res_str.Length; iii++)
                {
                    IntResult += 1;
                }
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(" Decimal |a-b|= " + IntResult);
            }
            Console.ForegroundColor = ConsoleColor.White;

        }
        #endregion

        #region My_music
        static void My_music()
        {
            //HappyBirthday
            Thread.Sleep(2000);
            Console.Beep(264, 125);
            Thread.Sleep(250);
            Console.Beep(264, 125);
            Thread.Sleep(125);
            Console.Beep(297, 500);
            Thread.Sleep(125);
            Console.Beep(264, 500);
            Thread.Sleep(125);
            Console.Beep(352, 500);
            Thread.Sleep(125);
            Console.Beep(330, 1000);
            Thread.Sleep(250);
            Console.Beep(264, 125);
            Thread.Sleep(250);
            Console.Beep(264, 125);
            Thread.Sleep(125);
            Console.Beep(297, 500);
            Thread.Sleep(125);
            Console.Beep(264, 500);
            Thread.Sleep(125);
            Console.Beep(396, 500);
            Thread.Sleep(125);
            Console.Beep(352, 1000);
            Thread.Sleep(250);
            Console.Beep(264, 125);
            Thread.Sleep(250);
            Console.Beep(264, 125);
            Thread.Sleep(125);
            Console.Beep(2642, 500);
            Thread.Sleep(125);
            Console.Beep(440, 500);
            Thread.Sleep(125);
            Console.Beep(352, 250);
            Thread.Sleep(125);
            Console.Beep(352, 125);
            Thread.Sleep(125);
            Console.Beep(330, 500);
            Thread.Sleep(125);
            Console.Beep(297, 1000);
            Thread.Sleep(250);
            Console.Beep(466, 125);
            Thread.Sleep(250);
            Console.Beep(466, 125);
            Thread.Sleep(125);
            Console.Beep(440, 500);
            Thread.Sleep(125);
            Console.Beep(352, 500);
            Thread.Sleep(125);
            Console.Beep(396, 500);
            Thread.Sleep(125);
            Console.Beep(352, 1000);
        }
        #endregion

        #region Morse
        static void Morse_code()
        {
            string word = "sos";

            string[,] Dictionary_arr = new string[,] { { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" },
            { ".-   ", "-... ", "-.-. ", "-..  ", ".    ", "..-. ", "--.  ", ".... ", "..   ", ".--- ", "-.-  ", ".-.. ", "--   ", "-.   ", "---  ", ".--. ", "--.- ", ".-.  ", "...  ", "-    ", "..-  ", "...- ", ".--  ", "-..- ", "-.-- ", "--.. ", "-----", ".----", "..---", "...--", "....-", ".....", "-....", "--...", "---..", "----." }};

            foreach (char c in word.ToCharArray())
            {

                string rslt = "";
                for (int i = 0; i < 36; i++)
                {
                    if (Dictionary_arr[0, i] == c.ToString())
                    {
                        rslt = Dictionary_arr[1, i];
                        rslt = rslt.Trim();
                    }
                }


                foreach (char c2 in rslt.ToCharArray())
                {
                    if (c2 == '.')
                        Console.Beep(1000, 250);
                    else
                        Console.Beep(1000, 750);
                }
                System.Threading.Thread.Sleep(50);
            }
        }

        #endregion
    }
}
