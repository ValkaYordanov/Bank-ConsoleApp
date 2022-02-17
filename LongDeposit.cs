using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    public class LongDeposit : Deposit
    {
        public override void SetPeriod(int period)
        {
            this.period = period;
        }
        public override int GetPeriod()
        {
            return 12;
        }

        public override string GetName()
        {
            return "Long Deposit";
        }

        public override double GetInterestRate()
        {
            return 5;
        }
    }
}
