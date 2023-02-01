using System;
using System.Diagnostics;
using Timer = System.Timers.Timer;

namespace AutoServer.Command
{
    internal class CommandInvoker
    {
        public static List<string> Commands { get; } = new List<string>();

        private readonly Timer Timer = new(TimeSpan.FromSeconds(20).TotalMilliseconds);

        public CommandInvoker()
        {
            Timer.Elapsed += Timer_Elapsed;
            Timer.Start();
        }

        private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            Timer.Stop();
            if (Commands.Count == 0)
            {
                Timer.Start();
                return;
            }

            
            using (Process Proc = new Process())
            {
                string OutPutLines = string.Empty;
                Proc.StartInfo = new ProcessStartInfo()
                {
                    StandardOutputEncoding = System.Text.Encoding.UTF8,
                    StandardInputEncoding = System.Text.Encoding.UTF8,
                    RedirectStandardOutput = true,
                    RedirectStandardInput = true,
                    UseShellExecute = false,
                    FileName = "cmd.exe",
                    CreateNoWindow = false,
                };

                Proc.Start();
                foreach (var Command in Commands)
                {
                    Proc.StandardInput.WriteLine(Command);
                }
                Proc.StandardInput.WriteLine("exit");
                using (StreamWriter sw = File.CreateText($"{DateTime.Now:yyyy-MM-dd HH-mm-ss fffff}.log"))
                {
                    sw.AutoFlush = true;
                    while (!Proc.StandardOutput.EndOfStream)
                    {
                        sw.WriteLine(Proc.StandardOutput.ReadToEnd());
                    }
                }

                if (!Proc.WaitForExit((int)TimeSpan.FromMinutes(1).TotalMilliseconds))
                {
                    Proc.Kill();
                }
            }
            

            Commands.Clear();
            Timer.Start();
        }
    }
}
