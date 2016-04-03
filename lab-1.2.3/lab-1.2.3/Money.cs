using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1._2._3
{
    // 1) declare enumeration CurrencyTypes, values UAH, USD, EU

    enum CurrencyTypes
    {
        UAH, USD, EU
    }
    class Money
    {
        // 2) declare 2 properties Amount, CurrencyType
        public double Amount { get; set; }
        public CurrencyTypes CurrencyType { get; set; }

        // 3) declare parameter constructor for properties initialization
        public Money (double set_Amount, CurrencyTypes set_CurrencyTypes) {
            this.Amount = set_Amount;
            this.CurrencyType = set_CurrencyTypes;
        }
        // 4) declare overloading of operator + to add 2 objects of Money
        public static Money operator +(Money value1, Money value2) {
            Money summ = new Money(value1.Amount + value2.Amount, value1.CurrencyType);
            return summ;
        }
        // 5) declare overloading of operator -- to decrease object of Money by 1
        public static Money operator --(Money value1)
        {
            Money mines = new Money(--value1.Amount, value1.CurrencyType);
            return mines;
        }
        // 6) declare overloading of operator * to increase object of Money 3 times
        public static Money operator *(Money value1, int incr)
        {
            Money res = new Money(value1.Amount *= incr, value1.CurrencyType);
            return res;
        }
        // 7) declare overloading of operator > and < to compare 2 objects of Money
        public static bool operator >(Money value1, Money value2)
        {
            if (value1.Amount > value2.Amount)
                return true;
            else
                return false;
        }
        public static bool operator <(Money value1, Money value2)
        {
            if (value1.Amount < value2.Amount)
                return true;
            else
                return false;
        }
        // 8) declare overloading of operator true and false to check CurrencyType of object
        public static bool operator true(Money v)
        {
            if (v.CurrencyType == CurrencyTypes.EU)
                return true;
            else
                return false;
        }

        public static bool operator false(Money v)
        {
            if (v.CurrencyType == CurrencyTypes.UAH)
                return false;
            else
                return true;
        }

        // 9) declare overloading of implicit/ explicit conversion  to convert Money to double, string and vice versa
        public static implicit operator double(Money arr)
        {
            double impl = arr.Amount;
            return impl;
        }

        public static explicit operator string(Money arr)
        {
            string expl = arr.Amount.ToString();
            return expl;
        }
        public static explicit operator Money(double arr)
        {
            Money expl = new Money(arr, CurrencyTypes.USD);
            return expl;
        }

    }
}
