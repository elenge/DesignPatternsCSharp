using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternCommandConsoleExample
{
    //RECEIVER CLASS
    //Knows how to perform the operations associated with carrying out a request. Any class may serve as a Receiver.
    //We have not to use directly this class from the client,
    //we have to extract all the requst details into a command class who implements command interface with execute method
    //Command class : defines a binding between a Receiver object and an action.
    //Command class : implements Execute by invoking the corresponding operation(s) on Receiver
    class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }

        public Product(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public void IncreasePrice(int amount)
        {
            Price += amount;
            Console.WriteLine($"The price for the {Name} has been increased by {amount}$.");
        }

        public bool DecreasePrice(int amount)
        {
            if(amount<Price)
            {
                Price -= amount;
                Console.WriteLine($"The price for the {Name} has been decreased by {amount}$.");
                return true;
            }
            return false;
        }

        public override string ToString() => $"Current price for the {Name} product is {Price}$.";

    }
}
