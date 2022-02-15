using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    public class LongDeposit : Deposit
    {
        protected override string name { get { return "Long Deposit"; } }
        protected override double interestRate { get { return 5; } }
        protected override int period { get { return 12; } set { this.period = period; } }

    }
}
