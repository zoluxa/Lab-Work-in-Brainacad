using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1._2._3
{
    class Program
    {
        static void Main(string[] args)
        {
            // 10) declare 2 objects
            Money obj1 = new Money(150, CurrencyTypes.UAH);
            Money obj2 = new Money(200, CurrencyTypes.UAH);

            Console.WriteLine("Money in my bag: {0} and {1}", obj1.Amount, obj2.Amount);
            // 11) do operations
            // add 2 objects of Money
            obj2 += obj1;
            Console.WriteLine("I have {0} UAH", obj2.Amount);
            // add 1st object of Money and double
            
            obj1.Amount += 10.4;
            Console.WriteLine("I get payment {0} UAH", obj1.Amount);
            // decrease 2nd object of Money by 1 
            --obj2;
            Console.WriteLine("Comission payment: {0}", obj2.Amount);
            // increase 1st object of Money
            obj1 *= 2;
            Console.WriteLine("Bonus: {0}", obj1.Amount);
            // compare 2 objects of Money
            if (obj1>obj2)
            {
                Console.WriteLine("Object 1 bigger than Object 2");
            }
            else if (obj1 == obj2)
            {
                Console.WriteLine("Object 1 have the same money that Object 2");
            }
            else
            {
                Console.WriteLine("Object 1 smaller than Object 2");
            }
            // compare 2nd object of Money and string
            string comp = "222";
            Console.WriteLine("Compare Object 2 {0} and string {1}", obj2.Amount, comp);
            if (String.Equals(obj2.Amount,comp))
            {
                Console.WriteLine("They are equal");
            }
            else
            {
                Console.WriteLine("They are not equal");
            }
            // check CurrencyType of every object
            Console.WriteLine("Currency types of Object 1 - {0} and Object 2 - {1}", obj1.CurrencyType, obj2.CurrencyType);
            // convert 1st object of Money to string
            Convert.ToString(obj1);
            Console.WriteLine("Object 1 converted to string... ", obj1);
        }
    }
}
