using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Generics_stud
{
    public class Base_static_field<T> where T : new()
    {
        static Base_static_field()
        {
            Console.WriteLine("Static Base Constructor");
            T test = new T();
        }
    }
}
