using AutoServer.Core.Uploader;
using AutoServer.Core.Zips;
using AutoServer.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoServer.Core.Commands
{
    /// <summary>
    /// -115 下载的路径 准备存放压缩文件的路径
    /// </summary>
    internal class Command115 : ICommand
    {
        public void Exce()
        {
            string SoucePath = GetArgs.Get();
            string targetPath = GetArgs.Get();

            Console.WriteLine(SoucePath);
            Console.WriteLine(targetPath);

            string fileName = Path.GetFileNameWithoutExtension(SoucePath);
            targetPath = Path.Combine(targetPath, fileName);

            Console.WriteLine(targetPath);

            Directory.CreateDirectory(targetPath);

            IZip zip = new ZipSevenZip();
            IFileCouldUpload fileCouldUpload = new Uploader_115Pan();

            zip.ZipFileExec(SoucePath, ref targetPath);
            fileCouldUpload.UploadFile(targetPath);
        }
    }
}
