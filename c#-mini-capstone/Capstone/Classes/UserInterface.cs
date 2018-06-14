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
            HandleMainMenu(); 

        }

        public void RunInterface()
        {
            bool done = false;
            while (!done)
            {
                Console.WriteLine("This is the UserInterface");
                Console.ReadLine();
            }

        }

        private void HandleMainMenu()
        {
            Console.WriteLine("(1) Display Vending Machine Items");
            Console.WriteLine("(2) Purchase");
            Console.WriteLine("(3) Exit");
            Console.ReadLine();
        }

        private void DisplayMenu()
        {

        }

        private void HandlePurchaseMenu()
        {

        }

        private void Exit()
        {

        }

        private void PrintSalesReport()
        {

        }
    }
}
