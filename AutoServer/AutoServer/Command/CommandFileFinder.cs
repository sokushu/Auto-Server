using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoServer.Command
{
    internal class CommandFileFinder
    {

        private FileSystemWatcher Watcher { get; }

        public CommandFileFinder(string Path)
        {
            Watcher = new FileSystemWatcher(Path);
            Watcher.NotifyFilter = NotifyFilters.Attributes
                                 | NotifyFilters.CreationTime
                                 | NotifyFilters.DirectoryName
                                 | NotifyFilters.FileName
                                 | NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.Security
                                 | NotifyFilters.Size;

            Watcher.Created += Watcher_Created;

            Watcher.Filter = "*.txt";
            Watcher.IncludeSubdirectories = true;
            Watcher.EnableRaisingEvents = true;
        }

        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            string Path = e.FullPath;

            if (Directory.Exists(Path))
                return;

            if (!File.Exists(Path))
                return;

            Thread.Sleep(5000);

            string[] Commands = File.ReadAllLines(Path);

            CommandInvoker.Commands.AddRange(Commands);

            File.Delete(Path);
        }
    }
}
