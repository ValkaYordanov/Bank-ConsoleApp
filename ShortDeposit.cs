using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    public class ShortDeposit : Deposit
    {
        public override void SetPeriod(int period)
        {
            this.period = period;
        }
        public override int GetPeriod()
        {
            return 3;
        }

        public override string GetName()
        {
            return "Short Deposit";
        }

        public override double GetInterestRate()
        {
            return 3;
        }
    }
}
