using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        public Dictionary<string, VendingMachineItem> itemsDic = new Dictionary<string, VendingMachineItem>();
        public decimal customerBalance;
        public decimal revenue;

        public VendingMachine()
        {
            customerBalance = 0;
            revenue = 0;
            GetInformation();

        }

        public Dictionary<string, VendingMachineItem> VMArray
        {
            get
            {
                return itemsDic;
            }
            private set
            {
                itemsDic = value;
            }
        }

        private void GetInformation()
        {
            string directory = @"C:\Users\kbailey\team1-c-week4-pair-exercises\c#-mini-capstone\etc";
            string filename = "vendingmachine.csv";
            string fullPath = Path.Combine(directory, filename);

            using (StreamReader sr = new StreamReader(fullPath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string name= "";
                    decimal price= 0;
                    string type = "";
                    string slot = "";

                    for (int i = 0; i < 4; i++)
                    {
                        int n=0;
                        if (i < 3)
                        {
                            n = line.IndexOf("|");
                        }
                        
                        if (i == 0)
                        {
                            slot = line.Substring(0, n);

                        }
                        else if (i == 1)
                        {
                            name = line.Substring(0, n);
                        }
                        else if (i == 2)
                        {
                            price = decimal.Parse(line.Substring(0, n));
                        }
                        else if (i == 3)
                        {
                            type = line.Substring(0);
                        }
                        line = line.Substring(n+1);

                    }
                    
                    itemsDic.Add(slot, new VendingMachineItem(name, price, type));

                }
            }
        }
    }
}

