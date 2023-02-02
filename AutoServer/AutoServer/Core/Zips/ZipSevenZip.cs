using AutoServer.InterFaces;
using SevenZip;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoServer.Core.Zips
{
    internal class ZipSevenZip : IZip
    {
        public string Password = "gfa*rd6pTxE8ZEUXcagZuP2cpaokJ_Bo@omANY7wv!n8bUihZXixZAeydP3!C@QwhaxaN8ttWbfV6owoRBFv8RKJkQdwfUexahfw";
        
        static ZipSevenZip()
        {
            SevenZipBase.SetLibraryPath("C:\\Program Files\\7-Zip\\7z.dll");
        }

        public void ZipFileExec(string FilePath, ref string OutFilePath)
        {
            SevenZipCompressor compressor = new SevenZipCompressor();
            compressor.ZipEncryptionMethod = ZipEncryptionMethod.Aes256;
            compressor.CompressionMethod = CompressionMethod.Default;
            compressor.CompressionLevel = SevenZip.CompressionLevel.Normal;
            compressor.VolumeSize = (long)1024 /*1KB*/ * 1024 /*1MB*/ * 1024 /*1GB*/ * 20/*20GB*/;
            compressor.EncryptHeaders = true;

            string OutFileName;
            if (string.IsNullOrEmpty(Path.GetExtension(OutFilePath)))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(FilePath);
                if (!directoryInfo.Exists)
                    directoryInfo.Create();
                OutFileName = Path.Combine(OutFilePath, $"{directoryInfo.Name}.7z");
            }
            else
            {
                OutFileName = OutFilePath;
            }

            compressor.CompressDirectory(FilePath, OutFileName, Password);
        }
    }
}
