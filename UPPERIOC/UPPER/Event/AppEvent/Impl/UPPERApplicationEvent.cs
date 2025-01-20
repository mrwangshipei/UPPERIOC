using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPPERIOC.UPPER.Event.AppEvent;

namespace UPPERIOC.UPPER.Event.AppEvent.Impl
{
    public abstract class UPPERApplicationEvent : IUPPERApplicationEvent
    {
        public DateTime Timestamp { get; } = DateTime.Now;
    }
}
