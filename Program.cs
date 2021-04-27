using System;
using System.Collections.Generic;
using System.Globalization;

namespace SimpleBank
{
    class Program
    {
        static List<Account> listAccount { get; set; }

        static void Main(string[] args)
        {
            listAccount = new List<Account>();
            string userOption = "";

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
                        Console.WriteLine("Invalid option, please type a menu option");
                        break;
                }
            }
        }

        private static void Exit()
        {
            Console.WriteLine("Thanks for using our services");
            Console.ReadLine();
        }

        private static void Deposit()
        {
            int accountNumber = 0;
            Console.Write("Type the account number: ");
            accountNumber = GetValidAccountNumber();

            Console.Write("Type the value to deposit: ");
            var value = GetValidMoneyInput();

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
            var originAccountNumber = GetValidAccountNumber();

            Console.Write("Type the destiny account number: ");
            var destinyAccountNumber = GetValidAccountNumber();

            Console.Write("Type the value to transfer: ");
            var value = GetValidMoneyInput();

            listAccount[originAccountNumber].Transfer(value, listAccount[destinyAccountNumber]);
        }

        private static int GetValidAccountNumber()
        {
            bool isInt = false;
            bool isInRange = false;
            int accountNumberInput = -1;
            var errorMessage = $"Invalid value, accounts numbers registred are between 0 and {listAccount.Count - 1}";
            while (!isInt || !isInRange)
            {
                isInt = int.TryParse(Console.ReadLine(), out accountNumberInput);

                if (isInt)
                {
                    isInRange = 0 <= accountNumberInput && accountNumberInput < listAccount.Count;
                    if (isInRange)
                    {
                        errorMessage = "";
                    }
                }

                if (!string.IsNullOrEmpty(errorMessage))
                {
                    Console.WriteLine(errorMessage);
                }
            }
            return accountNumberInput;

        }

        private static void AddNewAccount()
        {
            Console.WriteLine("Add new account");

            var accountType = GetValidAccountType();

            Console.WriteLine("\nType client's name");
            var name = Console.ReadLine();

            Console.WriteLine("\nType the credit limit");
            double creditLimit = GetValidMoneyInput();


            var newAccount =
                new Account((AccountType)accountType,
                    creditLimit,
                    name);

            listAccount.Add(newAccount);

            Console.WriteLine("Account added!");
        }

        private static double GetValidMoneyInput()
        {
            bool isDecimal = false;
            bool isPositive = false;
            double moneyImput = -1;
            while (!isDecimal || !isPositive)
            {
                isDecimal = double.TryParse(Console.ReadLine(), out moneyImput);
                isPositive = moneyImput >= 0;

                if (!isDecimal || !isPositive)
                {
                    Console.WriteLine("Type a value greater than or equal to 0");
                }
            }
            return moneyImput;
        }

        private static int GetValidAccountType()
        {
            bool validAccountType = false;
            bool isInt = false;
            int accountType = 0;

            while (!validAccountType)
            {

                Console.WriteLine("Type 1 to add personal account or 2 to add business account");

                isInt = int.TryParse(Console.ReadLine(), NumberStyles.Integer, null, out accountType);
                validAccountType = (AccountType)accountType == AccountType.BusinessAccount ||
                                   (AccountType)accountType == AccountType.PersonalAccount;

                if (!isInt || !validAccountType)
                {
                    Console.WriteLine("Invalid value.");
                }
            }

            return accountType;
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
                    Console.Write($"Account Number: {i} |");
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
