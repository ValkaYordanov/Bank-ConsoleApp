using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    public class HomeCredit : Credit
    {
        protected override string name { get { return "Home Credit"; } }
        public override double interestRate { get { return 6; } }
        public override int period { get { return period; } set {  } }

    }
}
