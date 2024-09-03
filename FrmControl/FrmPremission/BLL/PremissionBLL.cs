using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPPERIOC2.UPPER.Premission.Center;
using UPPERIOC2.UPPER.Premission.UAttribute;

namespace FrmControl.FrmPremission.BLL
{
	[ProxyClass]
	public class PremissionBLL
	{

		public virtual void SaveChange() {
			PremissionCenter.Instance.SaveChange();
		}
		public virtual void ReMoveChange()
		{
			PremissionCenter.Instance.RemoveChange();

		}
	}
}
