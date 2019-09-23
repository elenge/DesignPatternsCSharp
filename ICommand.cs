using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternCommandConsoleExample
{
    //Interface
    //Used by the client
    //All command should be a child to this class, 
    //then the client can use every specific command as a Interface command in method to use invoke
    interface ICommand
    {
        void ExecuteAction();
        void UndoAction();
    }
}
