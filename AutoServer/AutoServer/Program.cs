// See https://aka.ms/new-console-template for more information
using AutoServer.Command;

Task.Run(() =>
{
    var FileFinder = new CommandFileFinder("D:\\个人文件\\新建文件夹\\");

    var Invoker = new CommandInvoker();
});

Console.ReadLine();
