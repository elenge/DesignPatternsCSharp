using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternCommandConsoleExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //Tutorial from the website https://code-maze.com/command/
            //Contains definition from the book Design Patterns - Elements of Reusable Object-Oriented Software -  
            //Erich Gamma,Ralph Johnson, John Vlissides, Richard Helm

            //Program here is the Client
            //who have to creates a ConcreteCommand object and sets its receiver

            //It's easy to add new Commands,
            //because you don't have to change existing classes (like Product here)

            //L'objet métier possède des attributs et des méthodes qui parfois ne nécessite pas d'être changés
            //mais il se peut que plusieurs "manipulations" de l'objet métier soient nécessaire
            //ou peuvent évoluer, c'est pourquoi
            //il suffira d'ajouter une concrete command pour manipuler différement l'objet sans modifier l'objet directement

            var modifyPrice = new ModifyPrice();
            var product = new Product("Phone", 500);

            Execute(modifyPrice, new ProductCommand(product, PriceAction.Increase, 100));

            Execute(modifyPrice, new ProductCommand(product, PriceAction.Increase, 50));

            Execute(modifyPrice, new ProductCommand(product, PriceAction.Decrease, 25));

            Console.WriteLine(product);

            Console.WriteLine();

            modifyPrice.UndoActions();
            Console.WriteLine(product);
        }

        private static void Execute(ModifyPrice modifyPrice, ICommand productCommand)
        {
            modifyPrice.SetCommand(productCommand);
            modifyPrice.Invoke();
        }
    }
}
