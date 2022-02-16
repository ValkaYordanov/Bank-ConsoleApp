using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    public abstract class BankProduct
    {
        protected abstract string name { get; }
        public abstract double interestRate { get;}
        public abstract int period { get; set; }

        protected decimal availableMoney;

        protected decimal monthlyPaidMoney;

        public void SetMonthlyPaidMoney(decimal monthlyPaidMoney)
        {
            this.monthlyPaidMoney = monthlyPaidMoney;
        }

        public decimal GetmMnthlyPaidMoney()
        {
            return monthlyPaidMoney;
        }
        public void SetAvailableMoney(decimal availableMoney)
        {
            this.availableMoney = availableMoney;
        }

        public decimal GetAvailableMoney()
        {
            return availableMoney;
        }

        //public void SetPeriod(int period)
        //{
        //    this.period = period;
        //}

        //public int GetPeriod()
        //{
        //    return period;
        //}

        public string GetName()
        {
            return name;
        }
    }
}
