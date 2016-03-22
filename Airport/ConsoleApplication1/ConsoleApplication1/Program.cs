using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        { }
        public class ItemBase { }
        public class Widget : ItemBase { }
        class Worker
        {

            void DoWork(object obj)

            {

                Console.WriteLine("In DoWork(object)");

            }

            void DoWork(Widget widget)

            {

                Console.WriteLine("In DoWork(Widget)");

            }

            void DoWork(ItemBase itembase)

            {

                Console.WriteLine("In DoWork(ItemBase)");

            }

            private void Run()

            {

                object o = new Widget();

                DoWork(o is Widget);
                Console.ReadKey();
            }


        }

    }
        
    } 
