using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternCommandConsoleExample
{
    //Command
    //The ProductCommand class has all the information about the request and based on that executes required action
    class ProductCommand : ICommand
    {
        private readonly Product product;
        private readonly PriceAction priceAction;
        private readonly int amount;

        public bool IsCommandExecuted { get; private set; }

        public int Amount
        {
            get { return amount; }
        }

        public ProductCommand(Product aProduct, PriceAction aPriceAction,int anAmount)
        {
            product = aProduct;
            priceAction = aPriceAction;
            amount = anAmount;
        }

        public PriceAction PriceAction
        {
            get { return priceAction; }
        }


        public Product Product
        {
            get { return product; }
        }

        public void ExecuteAction()
        {
            if (priceAction == PriceAction.Increase)
            {
                product.IncreasePrice(amount);
                IsCommandExecuted = true;
            }
            else
            {
                IsCommandExecuted = product.DecreasePrice(amount);
            }
        }

        public void UndoAction()
        {
            if (!IsCommandExecuted) return;
            
            if (priceAction == PriceAction.Increase)
            {
                product.DecreasePrice(amount);
            }
            else
            {
                product.IncreasePrice(amount);
            }
        }
    }
}
