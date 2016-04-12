using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Generics_stud
{
    public sealed class Derived_public_field : Base_public_field<Derived_public_field>
    {
        public Derived_public_field() {
            Console.WriteLine("Derived from...");
        }
        private Derived_public_field _instances;
        public Derived_public_field Instances
        {
            get
            {
                Console.WriteLine("Public field");
                _instances = new Derived_public_field();
                return _instances;
            }
        }
    }
}
