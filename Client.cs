using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    public class Client
    {
        private string name;
        private string address;
        private decimal availableMoney;
        private decimal salary;
        public List<Deposit> listOfDeposits = new List<Deposit>();
        public List<Credit> listOfCredits = new List<Credit>();
        public enum CreditTypes { HomeCredit = 1, ConsumerCredit = 2 }
        Random random = new Random();

        public Client(string name, string address, decimal availableMoney, decimal salary)
        {
            this.name = name;
            this.address = address;
            this.availableMoney = availableMoney;
            this.salary = salary;
        }

        public void SetAvailableMoney(decimal availableMoney)
        {
            this.availableMoney = availableMoney;
        }
        public decimal GetAvailableMoney()
        {
            return availableMoney;
        }
        public decimal GetSalary()
        {
            return salary;
        }
        public string GetName()
        {
            return name;
        }
        public void OpenDeposite(decimal moneyToDeposite, Bank bank)
        {
            var typeOfDeposit = bank.ChooseDepositeType(moneyToDeposite);
            listOfDeposits.Add(bank.CreateDeposit(moneyToDeposite, typeOfDeposit));
        }

        public Credit TakeCredit(decimal amount, int period)
        {
            int randomCreditType = random.Next(1, 3);
            Credit credit = null;
            if (randomCreditType == (int)CreditTypes.HomeCredit)
            {
                credit = new HomeCredit();
            }
            else
            {
                credit = new ConsumerCredit();
            }
            credit.period= period;
            decimal interestMoney = amount * (decimal)credit.interestRate / 100;
            decimal moneyToReturnForCredit = amount + interestMoney;
            credit.SetAvailableMoney(moneyToReturnForCredit * -1);
            credit.SetMonthlyPayment(moneyToReturnForCredit / period);
            return credit;

        }

        public bool CheckAllPayments()
        {
            bool enoughMoney = true;
            decimal allMoneyForPayments = 0.0M;
            decimal percentOfSalary = this.GetSalary() * 50 / 100;


            foreach (var credit in listOfCredits)
            {
                allMoneyForPayments += credit.GetMonthlyPayment();
            }

            if(allMoneyForPayments > percentOfSalary)
            {
                enoughMoney = false;
            }

            return enoughMoney;
        }

    }
}
