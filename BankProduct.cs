using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    public abstract class BankProduct
    {
        protected abstract string name { get; }
        protected abstract double interestRate { get;}
        protected abstract int period { get; set; }
        protected decimal availableMoney;

        public void SetAvailableMoney(decimal availableMoney)
        {
            this.availableMoney = availableMoney;
        }

        public decimal GetAvailableMoney()
        {
            return availableMoney;
        }

      

        public string GetName()
        {
            return name;
        }
    }
}
