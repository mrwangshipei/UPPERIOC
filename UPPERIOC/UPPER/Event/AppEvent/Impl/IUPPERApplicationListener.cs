using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPPERIOC.UPPER.Event.AppEvent;
using UPPERIOC2.UPPER.UIOC.Center;

namespace UPPERIOC.UPPER.Event.AppEvent.Impl
{
    public interface IUPPERApplicationListener<T> where T : IUPPERApplicationEvent, new()
    {
        string MoudleName { get; }
        void OnEvent(T applicationEvent);
    }
   
}
