using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpperComAutoTest.MyControls;

namespace UpperComAutoTest.SendorEvent
{
	/// <summary>
	/// 停止自动测试并且弹一个提示条
	/// </summary>
	public  class StopAutosendTipEvent
	{
        public string Msg { get; set; }
        public Tipstype type{ get; set; }
		public bool showinwindow{ get; set; }
		public int waittime{ get; set; }


		public Action<Control> InvokeAction { get; set; }
	}
}
