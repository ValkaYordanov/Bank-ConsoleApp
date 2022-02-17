using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    public abstract class BankProduct
    {
        //protected abstract string name { get; }
        //public abstract double interestRate { get;}
        //public abstract int period { get; set; }


        protected string name;
        protected double interestRate;
        protected int period;

        protected decimal availableMoney;

        protected decimal monthlyPaidMoney;

        public abstract void SetPeriod(int period);
        public abstract string GetName();
        public abstract double GetInterestRate();
        public abstract int GetPeriod();

        public void SetMonthlyPaidMoney(decimal monthlyPaidMoney)
        {
            this.monthlyPaidMoney = monthlyPaidMoney;
        }

        public decimal GetmMonthlyPaidMoney()
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

       
    }
}
