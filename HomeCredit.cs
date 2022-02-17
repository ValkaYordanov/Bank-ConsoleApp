using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    public class HomeCredit : Credit
    {
        public override void SetPeriod(int period)
        {
            this.period = period;
        }
        public override int GetPeriod()
        {
            return period;
        }

        public override string GetName()
        {
            return "Home Credit";
        }

        public override double GetInterestRate()
        {
            return 6;
        }
    }
}
