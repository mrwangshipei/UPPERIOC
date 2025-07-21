using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UPPER.Test.ApplicationEventTests;
using UPPERIOC;
using UPPERIOC.UPPER.Event.AppEvent.Impl;
using UPPERIOC2.UPPER.UIOC.Center;
using UPPERTest.Util;
using Xunit;

namespace UPPERTest
{
 
    public class ApplicationEventTests
    {

      
        [Fact]
        public void TestFullLifecycleEventOrder()
        {
            FileTempFile f = new FileTempFile();
            var assemblyPath = typeof(ProgramEntry).Assembly.Location;
            assemblyPath = assemblyPath.Replace(".dll",".exe");
            //传入f._tempFile到程序中应该如何传;
            var process = Process.Start(new ProcessStartInfo
            {
                FileName = assemblyPath,
                Arguments = $"\"{f._tempFile}\"",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            });

            process.WaitForExit();

            Assert.True(File.Exists(f._tempFile), "ProcessExit 未触发或未生成文件");
            Assert.Equal(File.ReadAllText(f._tempFile), "ok");
        }
    }

}
