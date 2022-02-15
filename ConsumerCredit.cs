using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    public class ConsumerCredit : Credit
    {
        protected override string name { get { return "Consumer Credit"; } }
        protected override double interestRate { get { return 10; } }
        protected override int period { get { return period; } set { this.period = period; } }
    }
}
