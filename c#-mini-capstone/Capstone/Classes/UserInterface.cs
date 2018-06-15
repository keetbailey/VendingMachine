using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class UserInterface
    {
        private VendingMachine vendingMachine;

        public UserInterface(VendingMachine vendingMachine)
        {
            this.vendingMachine = new VendingMachine();
        }

        public void RunInterface()
        {
            HandleMainMenu();
        }

        private void HandleMainMenu()
        {
            int choice = 1;
            while (choice != 3)
            {
                Console.WriteLine();
                Console.WriteLine("(1) Display Vending Machine Items");
                Console.WriteLine("(2) Purchase");
                Console.WriteLine("(3) Exit");
                choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    DisplayMenu();
                }
                else if (choice == 2)
                {
                    HandlePurchaseMenu();
                }
                else if (choice == 4)
                {
                    vendingMachine.SaveSaleReport();
                }
                else if (choice != 3)
                {
                    Console.WriteLine("Invalid Entry");
                }
            }
            
        }

        private void DisplayMenu()
        {
            // display slot, name, price, quantity
            // if quantity == 0, then must display "Sold Out"
            string quantity;
            foreach (KeyValuePair<string, VendingMachineItem> KVP in vendingMachine.ItemsDic)
            {

                if (KVP.Value.Quantity <= 0)
                {
                    quantity = "Sold Out";
                }
                else
                {
                    quantity = KVP.Value.Quantity.ToString();
                }

                Console.Write($"{KVP.Key}\t{KVP.Value.Name}\t{quantity}\t${KVP.Value.Price}\n");
            }
            Console.WriteLine("\n");
        }

        private void HandlePurchaseMenu()
        {
            int choice = 0;

            while (choice != 3)
            {
                Console.WriteLine();
                Console.WriteLine("(1) Feed Money");
                Console.WriteLine("(2) Select Product");
                Console.WriteLine("(3) Finish Transaction");
                Console.WriteLine("Customer Balance: $" + vendingMachine.customerBalance);
                choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    FeedMoney();
                }
                if (choice == 2)
                {
                    SelectProduct();
                }
            }
            vendingMachine.customerBalance = CalculateChange(vendingMachine.customerBalance);
        }

        private void FeedMoney()
        {
            int input = -1;
            string choice = "";
            decimal total = vendingMachine.customerBalance;

            while (choice.ToUpper() != "B")
            {
                Console.WriteLine();
                Console.WriteLine("Current Balance: $" + total);
                Console.WriteLine("Insert Bill: ($1, $2, $5, $10) ");
                Console.WriteLine("Press B to return to Purchase Menu");
                Console.Write("Choice: ");
               
                choice = Console.ReadLine();

                if (choice.ToUpper() == "B")
                {
                    choice = choice.ToUpper();
                }
                else {
                    input = int.Parse(choice);

                    if (input == 1 || input == 2 || input == 5 || input == 10)
                    {
                        total += input;
                        vendingMachine.AuditTransaction(input, total);
                    }
                    else
                    {
                        Console.WriteLine("Invalid Bill Type");
                    }
                }              
            }
            vendingMachine.customerBalance = total;
            
        }

        private void SelectProduct()
        {
            bool isMatched = false;

            DisplayMenu();
            Console.WriteLine();
            Console.WriteLine();

            Console.Write("Enter Selection: ");
            string code = Console.ReadLine();

            foreach (KeyValuePair<string, VendingMachineItem> KVP in vendingMachine.ItemsDic)
            {
                if (KVP.Key == code.ToUpper())
                {
                    isMatched = true;
                    if (KVP.Value.Quantity > 0)
                    {
                        if (vendingMachine.customerBalance >= KVP.Value.Price)
                        {
                            decimal startingBalance = vendingMachine.customerBalance;
                            vendingMachine.totalSales += KVP.Value.Price;
                            vendingMachine.customerBalance -= KVP.Value.Price;
                            decimal endingBalance = vendingMachine.customerBalance;

                            KVP.Value.Quantity--;
                            Console.WriteLine(KVP.Value.Name + " " + KVP.Value.Price.ToString("C") + " Remaining Balance: " + endingBalance.ToString("C"));//name cost remaining

                            Console.WriteLine(KVP.Value.Message);

                            vendingMachine.AuditTransaction(startingBalance, endingBalance, KVP.Key);
                        }
                        else
                        {
                            Console.WriteLine("Insufficient Balance");
                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Item is Out of Stock");
                    }
                }
            }

            if (!isMatched)
            {
                Console.WriteLine("Invalid Selection");
            }
        }

        private decimal CalculateChange(decimal balance)
        {
            vendingMachine.AuditTransaction(balance);

            int nickels = 0, dimes = 0, quarters = 0;

            Console.WriteLine("Balance: $" + balance);
            while (balance > 0)
            {
                if (balance >= .25m)
                {
                    balance -= 0.25m;
                    quarters++;
                }
                else if (balance >= 0.10m)
                {
                    balance -= .10m;
                    dimes++;
                }
                else
                {
                    balance -= .05m;
                    nickels++;
                }
            }
            Console.WriteLine( $"Change is {quarters} quarters, {dimes} dimes and {nickels} nickels." );


            return balance;
        }
    }
}
