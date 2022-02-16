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
        private const int reservePercentage = 10;

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

        public void SetBankAvailableMoney(decimal availableMoney)
        {
            this.availableMoney = availableMoney;
        }
        public decimal GetBankAvailableMoney()
        {
            return availableMoney;
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
            availableMoney += moneyToDeposit;

            decimal moneyOverInterestRate = moneyToDeposit * (decimal)deposite.interestRate / 100;
            deposite.SetMonthlyPaidMoney(moneyOverInterestRate / deposite.period);

            return deposite;
        }

        public decimal CheckBankReserve()
        {
            decimal availableMoney = GetBankAvailableMoney();
            decimal reserve = availableMoney * reservePercentage / 100;
            return reserve;
        }


        public bool ConfirmCredit(Client client, Credit credit)
        {
            bool confirmed = false;
            bool lessThanFiftyPercentOfTheSalary = client.CheckAllPayments();

            if(lessThanFiftyPercentOfTheSalary)
            {
                if(CheckAvailability(credit.GetAvailableMoney() * -1))
                {
                    confirmed = true;
                    client.SetAvailableMoney(client.GetAvailableMoney() + (credit.GetAvailableMoney() * -1));
                    SetBankAvailableMoney(GetBankAvailableMoney() - (credit.GetAvailableMoney() * -1));
                    listOfBankProducts.Add(credit);
                }

            }

            return confirmed;
        }

        private bool CheckAvailability(decimal amountOfMoneyForCredit)
        {
            bool enoughAvailableMoney = false;
            decimal reserve = CheckBankReserve();
            decimal moneyInBankAfterCredit = GetBankAvailableMoney() - amountOfMoneyForCredit;

            if(moneyInBankAfterCredit > reserve)
            {
                enoughAvailableMoney = true;
            }

            return enoughAvailableMoney;
        }

        public void PayInterestRatesMoneyToAllDeposite()
        {
            foreach (var product in listOfBankProducts)
            {
                if(product is Deposit)
                {

                }

            }
        }

    }
}
