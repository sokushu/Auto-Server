using AutoServer.Core;
using AutoServer.InterFaces;
using SevenZip;
using System.IO.Compression;

public class Program
{
    public static void Main(string[] args)
    {
        GetArgs.SetArgs(args);

        CommandFactory commandFactory = new CommandFactory();
        ICommand command = commandFactory.CreateCommand(GetArgs.Get());

        command.Exce();
    }
}