using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    public class ShortDeposit : Deposit
    {
        protected override string name { get { return "Short Deposit"; }}
        protected override double interestRate { get { return 3; } }
        protected override int period { get { return 3; } set { this.period = period; } }

    }
}
