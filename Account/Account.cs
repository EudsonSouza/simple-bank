using System;

namespace SimpleBank
{
    public class Account
    {
        private string Name { get; set; }

        private double Balance { get; set; }

        private double Credit { get; set; }

        private AccountType AccountType { get; set; }

        public Account(
            AccountType accountType,
            double balance,
            double credit,
            string name
        )
        {
            this.Name = name;
            this.Credit = credit;
            this.Balance = balance;
            this.AccountType = accountType;
        }

        public Account(AccountType accountType, double credit, string name)
        {
            this.Name = name;
            this.Credit = credit;
            this.Balance = 0;
            this.AccountType = accountType;
        }

        public bool Withdraw(double value)
        {
            if (this.Balance - value < Credit * -1)
            {
                Console.WriteLine("Insufficient Funds");
                return false;
            }
            this.Balance -= value;
            Console
                .WriteLine($"\nCurrent balance of {this.Name} is {this.Balance}");
            return true;
        }

        public void Deposit(double value)
        {
            this.Balance += value;
            Console
                .WriteLine($"\nCurrent balance of {this.Name} is {this.Balance}");
        }

        public void Transfer(double value, Account account)
        {
            if (Withdraw(value))
            {
                account.Deposit(value);
            }
        }

        public override string ToString()
        {
            return $"Account type: {this.AccountType} | Client's Name: {this.Name} | Current balance: {this.Balance} | Credit Limit: {this.Credit}";
        }
    }
}
