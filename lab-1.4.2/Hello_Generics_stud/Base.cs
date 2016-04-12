using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Generics_stud
{
  
        public class Base<T> where T : new()
        {
            static Base() {
                Console.WriteLine("Static Base Constructor");
                T test = new T();
            }
        }
    
}
