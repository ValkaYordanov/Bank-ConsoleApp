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
        private const int percentageOfSalaryToCheckIfClientHasEnoughMoneyToPayAlsoNewCredit = 50; 
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

        public void SetSalary(decimal salary)
        {
            this.salary = salary;
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
            var typeOfDeposit = bank.ChooseDepositeObject(moneyToDeposite);
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
            credit.SetPeriod(period);
            decimal interestMoney = amount * (decimal)credit.GetInterestRate() / 100;
            decimal moneyToReturnForCredit = amount + interestMoney;
            credit.SetAvailableMoney(moneyToReturnForCredit * -1);
            credit.SetMonthlyPayment(moneyToReturnForCredit / period);
            return credit;

        }

        public bool CheckIfClientHasEnoughMoneyInSalaryBasedOnAllCreditInstallments(decimal newMonthlyPaymentOfTheDesiredCredit)
        {
            bool hasEnoughMoney = true;
            decimal allMoneyForPayments = 0.0M;
            decimal percentOfSalary = this.GetSalary() * percentageOfSalaryToCheckIfClientHasEnoughMoneyToPayAlsoNewCredit / 100;


            foreach (var credit in listOfCredits)
            {
                allMoneyForPayments += credit.GetMonthlyPayment();
            }

            allMoneyForPayments = allMoneyForPayments + newMonthlyPaymentOfTheDesiredCredit;

            if (allMoneyForPayments > percentOfSalary)
            {
                hasEnoughMoney = false;
            }

            return hasEnoughMoney;
        }

        public void PaidInstallment(Credit credit)
        {
            decimal salary = GetSalary();
            SetSalary(salary - credit.GetMonthlyPayment());
            credit.SetAvailableMoney(credit.GetAvailableMoney() + credit.GetMonthlyPayment());

            if (credit.GetAvailableMoney() == 0)
            {
                Console.WriteLine("Congradilations " + GetName() + " you close the credit!");
            }
            else
            {
                Console.WriteLine(GetName() + " you still have " + Math.Round(credit.GetAvailableMoney() * -1, 2) + " to return!");
            }
        }
        public decimal CalculateAllMoneyForAllCredits()
        {
            decimal allMoney = 0.0M;
            foreach (var credit in listOfCredits)
            {
                allMoney += credit.GetAvailableMoney() * -1;
            }

            return allMoney;
        }

        public decimal CalculateAllMoneyForAllDeposits()
        {
            decimal allMoney = 0.0M;
            foreach (var deposit in listOfDeposits)
            {
                allMoney += deposit.GetAvailableMoney();
            }

            return allMoney;
        }


    }
}
