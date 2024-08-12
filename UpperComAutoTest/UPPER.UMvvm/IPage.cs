
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPPERIOC.Interface;
using UPPERIOC.UPPER.IOC.Annaiation;
using UPPERIOC.UPPERMvvm;

namespace UpperComAutoTest.View.Page.Interface
{
    
	public class IPage :  UserControl,IMvvmCompent
	{

        public virtual string PageName { get => GetType().Name; }

	
	
	}
}
