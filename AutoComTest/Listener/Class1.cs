using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPPERIOC.UPPER.Event.AppEvent.Impl;
using UPPERIOC.UPPER.IOC.Annaiation;

namespace AutoComTest.Listener
{
    [IOCObject]
    internal class Class1 : IUPPERApplicationListener<ApplicationStoppingEvent>
    {
        public string MoudleName => "监听器";

        public void OnEvent(ApplicationStoppingEvent applicationEvent)
        {
            File.AppendAllText("y.TXT", "终止容器");
        }
    }
}
