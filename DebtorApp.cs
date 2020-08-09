using System;
using System.Collections.Generic;
using System.Text;
using Debtor.Core;

namespace Debtor
{
    public class DebtorApp
    {
        public BorrowerManager BorrowerManager { get; set; } = new BorrowerManager();  
        public void IntroduceDebtorApp()
        {
            Console.WriteLine("Witaj w aplikacji Dłużnik, w której zapisujesz dłużników," +
                "tak abyś wiedział kto ile kasy Ci jest dłużny.");
        }

        public void AddBorrower()
        {
            Console.WriteLine("Podaj nazwę dłużnika, którego chcesz dodać do listy: ");
            var userName = Console.ReadLine();
            Console.WriteLine("Podaj kwotę długu: ");
            var userAmount = Console.ReadLine();
            var amountInDecimal = default(decimal);

            while (!decimal.TryParse(userAmount, out amountInDecimal))
            {
                Console.WriteLine("Podano niepoprawną kwotę");
                Console.WriteLine("Podaj kwotę długu:");
                userAmount = Console.ReadLine();
            }
            BorrowerManager.AddBorrower(userName, amountInDecimal);

        }

        public void DeleteBorrower()
        {
            Console.WriteLine("Podaj nazwę dłużnika, którego chcesz usunąć z listy: ");
            var userName = Console.ReadLine();

            BorrowerManager.DeleteBorrower(userName);
            Console.WriteLine("Udało się usunąć dłużnika.");
        }

        public void ListAllBorrowers()
        {
            Console.WriteLine("Oto lista Twoich dłużników: ");
            foreach (var borrower in BorrowerManager.ListBorrowers())
            {
                Console.WriteLine(borrower);
            }
        }

        public void AskForAction()
        {
            Console.WriteLine("Podaj czynność, którą checsz wykonać");
            var userInput = default(string);

            while (userInput != "exit")
            {
                Console.WriteLine("add - Dodawanie dłużnika");
                Console.WriteLine("del - Usuwanie dłużnika");
                Console.WriteLine("list - Wyświetlanie listy dłużników");
                Console.WriteLine("exit - Wyjście z aplikacji");

                userInput = Console.ReadLine();
                userInput = userInput.ToLower();

                switch (userInput)
                {
                    case "add":
                        AddBorrower();
                        break;
                    case "del":
                        DeleteBorrower();
                        break;
                    case "list":
                        ListAllBorrowers();
                        break;
                    default:
                        Console.WriteLine("Podano złą wartość.");
                        break;
                }
            }
        }
    }
}
