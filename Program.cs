using System;
using System.Collections.Generic;

namespace SimpleBank
{
    class Program
    {
        static List<Account> listAccount { get; set; }

        static void Main(string[] args)
        {
            listAccount = new List<Account>();
            string userOption = "";
            listAccount.Add(new Account(AccountType.BusinessAccount, 0, 200, "Eudson business"));
            listAccount.Add(new Account(AccountType.PersonalAccount, 0, 20, "Eudson personal"));
            while (userOption != "X")
            {
                userOption = GetUserOption();
                switch (userOption)
                {
                    case "1":
                        ListAccounts();
                        break;
                    case "2":
                        AddNewAccount();
                        break;
                    case "3":
                        Transfer();
                        break;
                    case "4":
                        Withdraw();
                        break;
                    case "5":
                        Deposit();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    case "X":
                        Exit();
                        return;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
        }

        private static void Exit()
        {
            Console.WriteLine("Thanks for using our services");
        }

        private static void Deposit()
        {
            Console.Write("Type the account number: ");
            var accountNumber = int.Parse(Console.ReadLine());

            Console.Write("Type the value to withdraw: ");
            var value = double.Parse(Console.ReadLine());

            listAccount[accountNumber].Deposit(value);
        }

        private static void Withdraw()
        {
            Console.Write("Type the account number: ");
            var accountNumber = int.Parse(Console.ReadLine());

            Console.Write("Type the value to withdraw: ");
            var value = double.Parse(Console.ReadLine());

            listAccount[accountNumber].Withdraw(value);
        }

        private static void Transfer()
        {
            Console.Write("Type the origin account number: ");
            var originAccountNumber = int.Parse(Console.ReadLine());

            Console.Write("Type the origin account number: ");
            var destinyAccountNumber = int.Parse(Console.ReadLine());

            Console.Write("Type the value to transfer: ");
            var value = double.Parse(Console.ReadLine());

            listAccount[originAccountNumber].Transfer(value, listAccount[destinyAccountNumber]);
        }

        private static void AddNewAccount()
        {
            Console.WriteLine("Add new account\n");

            Console
                .WriteLine("Type 1 to add personal account or 2 to add business account");
            var inputTypeAccount = int.Parse(Console.ReadLine());

            Console.WriteLine("\nType client's name");
            var inputName = Console.ReadLine();

            Console.WriteLine("\nType CreditLimit");
            var inputCreditLimit = double.Parse(Console.ReadLine());

            var newAccount =
                new Account((AccountType)inputTypeAccount,
                    inputCreditLimit,
                    inputName);

            listAccount.Add(newAccount);
        }

        private static void ListAccounts()
        {
            if (listAccount.Count == 0)
            {
                Console.WriteLine("\nThere is no accounts registred");
            }
            else
            {
                for (int i = 0; i < listAccount.Count; i++)
                {
                    Console.Write($"[{i}] ");
                    Console.WriteLine(listAccount[i].ToString());
                }
            }
        }

        private static string GetUserOption()
        {
            Console.WriteLine("\nWelcome to Bank");
            Console.WriteLine("Choose an option");
            Console.WriteLine("1 - List accounts");
            Console.WriteLine("2 - Add new account");
            Console.WriteLine("3 - Transfer");
            Console.WriteLine("4 - Withdraw");
            Console.WriteLine("5 - Deposit");
            Console.WriteLine("C - Clear screen");
            Console.WriteLine("X - Exit");
            Console.WriteLine("");

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }
    }
}
