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

        public Client(string name, string address, decimal availableMoney, decimal salary)
        {
            this.name = name;
            this.address = address;
            this.availableMoney = availableMoney;
            this.salary = salary;
        }

        public decimal GetAvailableMoney()
        {
            return availableMoney;
        }

        internal void OpenDeposite(decimal moneyToDeposite, Bank bank)
        {
            var typeOfDeposit = bank.ChooseDepositeType(moneyToDeposite);
            listOfDeposits.Add(bank.CreateDeposit(moneyToDeposite, typeOfDeposit));
        }
    }
}
