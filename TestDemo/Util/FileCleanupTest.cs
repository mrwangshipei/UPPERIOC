using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UPPERTest.Util
{
    public class FileTempFile : IDisposable
    {
        public readonly string _tempFile;

        public FileTempFile()
        {
            _tempFile = Path.GetTempFileName();
            File.WriteAllText(_tempFile, "test content");
        }

     

        public void Dispose()
        {
            if (File.Exists(_tempFile))
                File.Delete(_tempFile);
        }
    }

}
