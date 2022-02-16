using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    public class ShortDeposit : Deposit
    {
        protected override string name { get { return "Short Deposit"; }}
        public override double interestRate { get { return 3; } }
        public override int period { get { return 3; } set { this.period = period; } }

    }
}
