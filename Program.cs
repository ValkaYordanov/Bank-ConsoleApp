using System;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank bank = Bank.Instance;
            Random random = new Random();

            Client[] clients = {

            new Client("Valentin Yordanov", "Sofia", 10000.0M, 1300.0M) ,
            new Client("Petur Petrov", "Vidin", 8000.0M, 2500.0M),
            new Client("Ivan Ivanov", "Smolqn", 15000.0M, 4230.0M),
            new Client("Yordan Yordanov", "Stara Zagora", 12000.0M, 2300.0M),
            new Client("Petq Boyklieva", "Varnensko", 10800.0M, 2500.0M),
            new Client("Chefo Hristov", "Petrich", 10520.0M, 3000.0M),
            new Client("Ico Petrov", "Ruse", 5000.0M, 1500.0M),
            new Client("Daqna Kazashka", "Yambol", 2000.0M, 450.0M),
            new Client("Gergana Ivanova", "Burgas", 6800.0M, 800.0M),
            new Client("Valeria Peteva", "Pernik", 1000.0M, 500.0M)
        };

            for (int i = 0; i < clients.Length; i++)
            {
                int percentageMoneyToDeposit = random.Next(80, 101);
                decimal moneyToDeposite = (decimal)percentageMoneyToDeposit * clients[i].GetAvailableMoney() / 100;
                decimal availableMoneyAfterDeposit = clients[i].GetAvailableMoney() - moneyToDeposite;
                clients[i].SetAvailableMoney(availableMoneyAfterDeposit);
                clients[i].OpenDeposite(moneyToDeposite, bank);

            }

           
            Console.WriteLine("Available money in the bank: " + bank.GetBankAvailableMoney());
            Console.WriteLine("Bank reserve: " + bank.CheckBankReserve());

            for (int i = 0; i < clients.Length; i++)
            {
                int period = random.Next(1, 61);
                int amaount = random.Next(6000, 20000);
                Credit credit = clients[i].TakeCredit(amaount, period);
                bool isConfirmed = bank.ConfirmCredit(clients[i], credit);
                if (isConfirmed)
                {
                    clients[i].listOfCredits.Add(credit);
                    Console.WriteLine(clients[i].GetName() + " -> You get the money!");
                }
                else
                {
                    clients[i].listOfCredits.Remove(credit);
                    Console.WriteLine(clients[i].GetName() + " -> You don't get the money!");
                }
                Console.WriteLine();
            }

            for (int i = 0; i < clients.Length; i++)
            {
                decimal allCreditsMoney = clients[i].CalculateAllMoneyForAllCredits();
                decimal allDepositMoney = clients[i].CalculateAllMoneyForAllDeposits();


                Console.WriteLine(clients[i].GetName());
                Console.WriteLine("Has available money: " + clients[i].GetAvailableMoney());
                Console.WriteLine("Has salary: " + clients[i].GetSalary());
                Console.WriteLine("Has " + clients[i].listOfCredits.Count + " number of credits for " + allCreditsMoney + "leva.");
                Console.WriteLine("Has " + clients[i].listOfDeposits.Count + " number of deposits for " + allDepositMoney + "leva.");
                Console.WriteLine();
            }

            foreach (var product in bank.listOfBankProducts)
            {
                Console.WriteLine(product.GetName());
                Console.WriteLine("Period: " + product.GetPeriod());
                Console.WriteLine("Interest rate: " + product.GetInterestRate());
                Console.WriteLine("Available money: " + product.GetAvailableMoney());
                Console.WriteLine();
            }

          
            Console.WriteLine("Available money in the bank: " + bank.GetBankAvailableMoney());
            Console.WriteLine("Bank reserve: " + bank.CheckBankReserve());
        }
    }
}
