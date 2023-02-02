using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoServer.InterFaces
{
    internal interface ICommandFactory
    {
        public ICommand CreateCommand(string Command);
    }
}
