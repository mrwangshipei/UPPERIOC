using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPPERIOC.UPPER.Event.AppEvent.Impl
{
    public class ApplicationPreInitializationEvent : UPPERApplicationEvent { }
    public class ApplicationModuleInitializedEvent : UPPERApplicationEvent { }
    public class ApplicationModulePreCreationEvent : UPPERApplicationEvent { }
    public class ApplicationInstanceCreatedEvent : UPPERApplicationEvent { }
    public class ApplicationInitEndEvent : UPPERApplicationEvent { }

    public class ApplicationStoppingEvent : UPPERApplicationEvent { }
    public class ApplicationStoppedEvent : UPPERApplicationEvent { }

}
