using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Net_module1_4_1_lab
{
    class Program
    {
        static void Main(string[] args)
        {
            // 9) declare object of OnlineShop 
            OnlineShop shop = new OnlineShop();
            // 10) declare several objects of Customer
            Customer FirstCustomer = new Customer("Pavlo");
            Customer SecondCustomer = new Customer("Denis");
            Customer ThirdCustomer = new Customer("Igor");
            // 11) subscribe method GotNewGoods() of every Customer instance 
            // to event NewGoodsInfo of object of OnlineShop
            shop.ex += FirstCustomer.GotNewGoods;
            shop.ex += SecondCustomer.GotNewGoods;
            shop.ex += ThirdCustomer.GotNewGoods;

            // 12) invoke method NewGoods() of object of OnlineShop
            // discuss results
            shop.NewGoods("Kolbasa");
            shop.NewGoods("Smetana");
            shop.NewGoods("Kefir");

        }
    }
}
