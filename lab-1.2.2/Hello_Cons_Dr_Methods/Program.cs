using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Cons_Dr_Methods
{
    class Program
    {
        internal class Box
        {
            internal uint width_pos;
            internal uint x_pos;
            internal uint y_pos;
            internal uint height_pos;
            internal char symb_dr;
            internal string mess;

            internal void DrawRectangle()
            {
                this.draw((int)x_pos, (int)y_pos, width_pos, (int)height_pos, symb_dr, ref mess);
            }
            private void draw(int X, int Y, uint Width, int Height, char Symb, ref string Message)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                if ((Width >= 3) && (Height >= 3))
                {
                    Console.SetCursorPosition((int)(X + (Width - Message.Length) / 2), (int)(Y + Height / 2));
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(Message);

                    Console.SetCursorPosition(X, Y);


                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    for (int i = 0; i <= Height - 1; i++)
                    {
                        for (int j = 0; j <= Width - 1; j++)
                        {

                            if (i % (Height - 1) == 0 || j % (Width - 1) == 0)
                            {
                                Console.SetCursorPosition(X + j, Y + i);
                                Console.Write(Symb);
                            }
                        }

                    }
                }
            }
            static int Fact(int n)
            {
                if (n <= 1)
                    return 1;
                return n * Fact(n - 1);
            }

            static int Factorial(int n)
            {
                if (n <= 1)
                    return 1;
                int result = 1;
                for (int i = 2; i <= n; i++)
                {
                    result = result * i;
                }
                return result;
            }

            public static void Main()
            {
                // Clear the screen, then save the top and left coordinates.
                Console.Clear();

                try
                {
                    Box p1 = new Box();
                    Console.WriteLine("Type  position of the box, x = ");
                    p1.x_pos = uint.Parse(Console.ReadLine());
                    Console.WriteLine("Type  position of the box: y = ");
                    p1.y_pos = uint.Parse(Console.ReadLine());
                    Console.WriteLine("Type  width of the box: width = ");
                    p1.width_pos = uint.Parse(Console.ReadLine());
                    Console.WriteLine("Type  height of the box: height = ");
                    p1.height_pos = uint.Parse(Console.ReadLine());
                    Console.WriteLine("Type one of chars : *, +, .  ");
                    p1.symb_dr = char.Parse(Console.ReadLine());
                    Console.WriteLine("Type  the message :  ");
                    p1.mess = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("Drawing ...");
                    p1.DrawRectangle();
                    Console.WriteLine();
                    Console.WriteLine("Press any key...");
                    Console.ReadLine();
                }
                catch (Exception)
                {
                    Console.WriteLine("Error!");
                }
                Console.WriteLine();
                Console.ReadKey();
                Console.Clear();
                Console.Write("Enter a Number to find factorial: ");
                int n = Convert.ToInt32(Console.ReadLine());
                int r = Fact(n);
                Console.WriteLine(n.ToString() + "! = " + r.ToString());

                Console.Write("Enter a Number to find factorial: ");
                n = Convert.ToInt32(Console.ReadLine());
                r = Factorial(n);
                Console.WriteLine(n.ToString() + "! = " + r.ToString());
                Console.ReadKey();
            }

        }
    }
}
