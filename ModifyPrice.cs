using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternCommandConsoleExample
{
    //Invoker role : asks the command to carry out the request
    //Can work with any command that implements the ICommand interface and store all the operations as well
    class ModifyPrice
    {
        private readonly List<ICommand> _commands;
        private ICommand _command;

        public ModifyPrice()
        {
            _commands = new List<ICommand>();
        }

        public void SetCommand(ICommand command) => _command = command;

        public void UndoActions() {
            foreach (var command in Enumerable.Reverse(_commands))
            {
                command.UndoAction();
            };
        }

        public void Invoke()
        {
            _commands.Add(_command);
            _command.ExecuteAction();
        }
    }
}
