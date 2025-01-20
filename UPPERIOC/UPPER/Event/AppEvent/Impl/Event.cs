using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPPERIOC.UPPER.Event.AppEvent.Impl
{
    public class ApplicationStartingEvent : UPPERApplicationEvent { }
    public class ApplicationStartedEvent : UPPERApplicationEvent { }
    public class ApplicationPreCreatInstaceEvent : UPPERApplicationEvent { }
    public class ApplicationCreatInstaceEvent : UPPERApplicationEvent { }
    public class ApplicationAfterCreatInstaceEvent : UPPERApplicationEvent { }
    public class ApplicationInitEndEvent : UPPERApplicationEvent { }

    public class ApplicationStoppingEvent : UPPERApplicationEvent { }
    public class ApplicationStoppedEvent : UPPERApplicationEvent { }

}
