using AutoServer.InterFaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoServer.Core.Uploader
{
    internal class Uploader_115Pan : IFileCouldUpload
    {
        public void UploadFile(string FilePath)
        {
            using (Process Proc = new Process())
            {
                Proc.StartInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    RedirectStandardOutput = true,
                    RedirectStandardInput = true,
                    StandardInputEncoding = Encoding.UTF8,
                    StandardOutputEncoding = Encoding.UTF8,
                };
                Proc.Start();

                Proc.StandardInput.WriteLine("echo Hello");
                Proc.StandardInput.WriteLine("E:");
                Proc.StandardInput.WriteLine("cd \"E:\\OneDrive - 77schools\\fake115\"");
                Proc.StandardInput.WriteLine($"fake115uploader -m -recursive \"{FilePath}\"");
                Proc.StandardInput.WriteLine("exit");

                Proc.WaitForExit();
                Console.WriteLine(Proc.StandardOutput.ReadToEnd());
            }
        }
    }
}
