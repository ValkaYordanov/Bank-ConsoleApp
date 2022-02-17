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
        private const int moneyForDecisionOfDepositObject = 5000;

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
        public Deposit ChooseDepositeObject(decimal moneyToDeposit)
        {
            if (moneyToDeposit > moneyForDecisionOfDepositObject)
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

            decimal moneyOverInterestRate = moneyToDeposit * (decimal)deposite.GetInterestRate() / 100;
            deposite.SetMonthlyPaidMoney(moneyOverInterestRate / deposite.GetPeriod());

            return deposite;
        }

        public decimal CheckBankReserve() 
        {
            decimal moneyFromDeposit = 0.0M;

            foreach (var product in listOfBankProducts)
            {
                if (product is Deposit)
                {
                    moneyFromDeposit += product.GetAvailableMoney();
                }

            }
            decimal reserve = moneyFromDeposit * reservePercentage / 100;
            return reserve;
        }


        public bool ConfirmCredit(Client client, Credit credit)
        {
            bool isConfirmed = false;
            bool lessThanFiftyPercentOfTheSalary = client.CheckIfClientHasEnoughMoneyInSalaryBasedOnAllCreditInstallments(credit.GetmMonthlyPaidMoney()); //

            if(lessThanFiftyPercentOfTheSalary)
            {
                if(CheckAvailability(credit.GetAvailableMoney() * -1))
                {
                    isConfirmed = true;
                    client.SetAvailableMoney(client.GetAvailableMoney() + (credit.GetAvailableMoney() * -1));
                    SetBankAvailableMoney(GetBankAvailableMoney() - (credit.GetAvailableMoney() * -1));
                    listOfBankProducts.Add(credit);
                }

            }

            return isConfirmed;
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
                    product.SetAvailableMoney(product.GetAvailableMoney() + product.GetmMonthlyPaidMoney());
                    SetBankAvailableMoney(GetBankAvailableMoney() - product.GetmMonthlyPaidMoney());
                }

            }
        }

    }
}
