using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class VendingMachineItem
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public string Type { get; private set; }
        public string Message { get; private set; }
        public int Quantity { get; private set; }

        public VendingMachineItem(string name, decimal price, string type)
        {
            Name = name;
            Price = price;
            Type = type;
            Quantity = 5;
            Message = SetMessage(Type);
        }

        public string SetMessage(string type)
        {
            if (type == "Chip")
            {
                return "Crunch Crunch, Yum!";

            }
            else if (type == "Candy")
            {
                return "Munch Munch, Yum!";
            }
            else if (type == "Drink")
            {
                return "Glug Glug, Yum!";
            }
            else
            {
                return "Chew Chew, Yum!";
            }
        }
    }
}
