using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Generics_stud
{
    public class Base_publ<T> where T : new()
    {
        static Base_publ()
        {
            Console.WriteLine("Base_publ static constructor ");
        }
    }

    public sealed class Derived_publ : Base_publ<Derived_publ>
    {
        public Derived_publ()
        {
            Console.WriteLine("Derived_publ constructor ");
        }
    }
}
