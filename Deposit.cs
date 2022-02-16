using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    public abstract class Deposit : BankProduct
    {
        protected decimal monthlyPaidMoney;

        public void SetMonthlyPaidMoney(decimal monthlyPaidMoney)
        {
            this.monthlyPaidMoney = monthlyPaidMoney;
        }

        public decimal GetmMnthlyPaidMoney()
        {
            return monthlyPaidMoney;
        }
    }
}
