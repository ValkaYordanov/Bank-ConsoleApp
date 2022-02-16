using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    public class ConsumerCredit : Credit
    {
        protected override string name { get { return "Consumer Credit"; } }
        public override double interestRate { get { return 10; } }
        public override int period { get { return period; } set { } }
    }
}
