using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UPPERIOC2.UPPER.MVVM.Extension
{
	public static class ExtentionClass
	{
		static Dictionary<Control, Action> Contain = new Dictionary<Control, Action>();
		public static void SetBindDataRefeash(this Control SourceControl,Action Bindfunc) 
		{
			Contain[SourceControl] = Bindfunc;
		}
		public static void RefeashBindData(this Control SourceControl)
		{
			List<Control> need = new List<Control>();
			var p = SourceControl;
			while (p != null)
			{
				if (p.Controls.Contains(SourceControl))
				{
					break;
				}
				var at = 0;
				if (p != null)
				{
					if (p.Controls.Count == at)
					{
						at = 0;
						p = p.Parent.Parent;

					}
					if (p.Controls[at] == null)
					{
						at++;
						p = p.Parent;
					}
					else
					{
						p = p.Controls[at];
					}
					need.Add(p);
					
				}
			}

			foreach (var item in Contain)
			{
			}
		}

	}

}
