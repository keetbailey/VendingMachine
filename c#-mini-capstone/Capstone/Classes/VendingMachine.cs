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
        private Dictionary<string, VendingMachineItem> itemsDic = new Dictionary<string, VendingMachineItem>();
        public decimal customerBalance;
        public decimal revenue;
        public decimal totalSales;

        public VendingMachine()
        {
            customerBalance = 0;
            revenue = 0;
            totalSales = 0;
            GetInformation();
        }

        public Dictionary<string, VendingMachineItem> ItemsDic
        {
            get
            {
                return itemsDic;
            }
        }

        private void GetInformation()
        {
            string directory = Environment.CurrentDirectory;// = @"C:\Users\kbailey\team1-c-week4-pair-exercises\c#-mini-capstone\etc";
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
       
        public void SaveSaleReport()
        {
            // create new doc called date-time-SalesReport.txt
            string directory = Environment.CurrentDirectory;
            string fileName = "SalesReport-" + DateTime.Now.Date.Month + DateTime.Now.Day  +
                DateTime.Now.Year + DateTime.Now.TimeOfDay.Hours +
                DateTime.Now.TimeOfDay.Minutes + DateTime.Now.TimeOfDay.Milliseconds
                + @".txt";
                
            string filePath = Path.Combine(directory, fileName);

            using (StreamWriter sw = new StreamWriter(filePath))
            {
                foreach (KeyValuePair<string, VendingMachineItem> KVP in ItemsDic)
                {
                    sw.WriteLine(KVP.Value.Name + "|" + (KVP.Value.GetInitialQuantity() - KVP.Value.Quantity));
                }
                sw.WriteLine();
                sw.WriteLine($"**Total Sales** {totalSales.ToString("C")}");
            }
        }

        public void AuditTransaction(decimal dollarsFed, decimal customerBalance)
        {
            DateTime dateTimeOfTransaction = DateTime.Now;
            string auditString = $"{dateTimeOfTransaction} FEED MONEY: {dollarsFed.ToString("C")}\t{customerBalance.ToString("C")}";


            AddToAudit(auditString);
        }

        public void AuditTransaction(decimal changeBalance)
        {
            DateTime dateTimeOfTransaction = DateTime.Now;
            string auditString = $"{dateTimeOfTransaction} GIVE CHANGE: {changeBalance.ToString("C")}\t${0.00m}";

            
            AddToAudit(auditString);
        }

        public void AuditTransaction(decimal startingBalance, decimal endingBalance, string slot)
        {
            DateTime dateTimeOfTransaction = DateTime.Now;
            string auditString = $"{dateTimeOfTransaction} {itemsDic[slot].Name} {slot}  {startingBalance.ToString("C")}\t{endingBalance.ToString("C")}";

            

            AddToAudit(auditString);
        }

        public void AddToAudit(string auditString)
        {
            string fileName = "Log.txt";

            using (StreamWriter sw = new StreamWriter(fileName, true))
            {
                sw.WriteLine(auditString);
            }
        }
    }
}

