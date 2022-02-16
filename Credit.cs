using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    public abstract class Credit : BankProduct
    {
        private decimal monthlyPayment;

        public void SetMonthlyPayment(decimal monthlyPayment)
        {
            this.monthlyPayment = monthlyPayment;
        }

        public decimal GetMonthlyPayment()
        {
            return monthlyPayment;
        }
    }
}
