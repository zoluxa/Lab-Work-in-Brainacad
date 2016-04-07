using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Net_module1_4_1_lab
{
    class Customer
    {
        // 6) declare private field name
        private string name;

        // 7) declare constructor to initialize name
        public Customer(string LastName) {
            name = LastName;
        }

        // 8) declare method GotNewGoods with 2 parameters:
        public void GotNewGoods(object shipp, GoodsInfoEventArgs evShipp) {
            Console.WriteLine("Hello {0}! You must receive new product {1}", name, evShipp.GoodsName);
        }
        // 1 - object type
        // 2 - GoodsInfoEventArgs type

    }
}
