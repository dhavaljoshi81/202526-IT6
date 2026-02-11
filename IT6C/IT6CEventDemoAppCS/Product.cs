using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT6CEventDemoAppCS
{
    public delegate string InventoryStatusHandler();

    internal class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public event InventoryStatusHandler LowInventory;

        public event InventoryStatusHandler OverStockInventory;

        public string CurrentStock 
        {
            get
            {
                return "Current stock of " + Name + " is " + Quantity;
            }
        }

        public int Sell 
        {
            set
            {
                if (value > Quantity)
                {
                    Console.WriteLine(
                        "{0} can not be slod as current stock is {1} and selling quantity is demanded by {2} "
                        , Name, Quantity, value);
                }
                else
                {
                    if (Quantity - value < 5)
                    {
                        if (LowInventory != null)
                        {
                            string status = LowInventory();
                            Console.WriteLine(status);
                        }
                        else
                        {
                            Console.WriteLine("No message of low inventory available.");
                        }
                    }
                    Quantity -= value;
                }
            }
        }

        public int Purchase
        {
            set
            {
                if (Quantity + value > 100)
                {
                    if (OverStockInventory != null)
                    {
                        string status = OverStockInventory();
                        Console.WriteLine(status);
                    }
                    else
                    {
                        Console.WriteLine("No message of over stock inventory available.");
                    }
                }
                else 
                    Quantity += value;

            }
        }
    }
}
