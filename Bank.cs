using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    public class Bank
    {
        private string name;
        private string address;
        public List<BankProduct> listOfBankProducts = new List<BankProduct>();
        private decimal availableMoney;

        private static Bank instance = null;
        private Bank() { }

        public static Bank Instance
        {
            get
            {
                if (instance == null)
                    instance = new Bank();
                return instance;

            }
        }

        public Deposit ChooseDepositeType(decimal moneyToDeposit)
        {
            if (moneyToDeposit > 5000)
            {
                return new ShortDeposit();
            }
            else
            {
                return new LongDeposit();
            }
        }

        public Deposit CreateDeposit(decimal moneyToDeposit, Deposit typeOfDeposit)
        {
            Deposit deposite = typeOfDeposit;
            deposite.SetAvailableMoney(moneyToDeposit);
            listOfBankProducts.Add(deposite);
           return deposite;
        }
    }
}
