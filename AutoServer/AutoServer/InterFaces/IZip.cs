using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoServer.InterFaces
{
    internal interface IZip
    {
        public void ZipFileExec(string FilePath, ref string OutFilePath);
    }
}
