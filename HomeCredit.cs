using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    public class HomeCredit : Credit
    {
        protected override string name { get { return "Home Credit"; } }
        protected override double interestRate { get { return 6; } }
        protected override int period { get { return period; } set { this.period = period; } }

    }
}
