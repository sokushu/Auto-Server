using AutoServer.Core.Commands;
using AutoServer.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoServer.Core
{
    internal class CommandFactory : ICommandFactory
    {
        public ICommand CreateCommand(string Command)
        {
            switch (Command)
            {
                case "-115":
                    return new Command115();
                default:
                    return null!;
            }
        }
    }
}
