using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoServer.Core
{
    internal class GetArgs
    {
        private static List<string> Args { get; } = new List<string>();

        public static void SetArgs(string[] args) 
        {
            Args.Clear();
            Args.AddRange(args);
        }

        public static string Get()
        {
            try
            {
                return Get(0);
            }
            finally
            {
                Args.RemoveAt(0);
            }
        }

        private static string Get(int index)
        {
            if (index < 0 || index >= Args.Count)
                return string.Empty;

            return Args[index];
        }
    }
}
