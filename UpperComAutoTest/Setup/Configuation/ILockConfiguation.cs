
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UPPERIOC.UPPER.IOC.Annaiation;
using UPPERIOC2.UPPER.MLOCK.IConfiguation;
using UPPERIOC2.UPPER.MLOCK.Util;
using static UPPERIOC.UPPER.IOC.Moudle.UPPERMLockMoudle;

namespace Setup.Configuation
{
	[IOCObject]
	public class ILockConfiguation : MLockConfiguation
	{
		public override string Solt { get =>"-fdskjlskjasklfjaskljf"; set => base.Solt = value; }
		public override string Listenaddr { get => "Lis"; set => base.Listenaddr = value; }
		public override void Noregister()
		{
			var r = MessageBox.Show("软件版本归属于东莞市翱翔科技所有，有需要请联系厂商,确认开始注册","", MessageBoxButtons.OKCancel);

			if (r == DialogResult.OK)
			{
				PWD pwd = new PWD();
				var pr = pwd.ShowDialog();
				if (pr == DialogResult.Yes)
				{
					var x = HashHelper.EncryptWithSalt(Solt);
					RegistryHelper.WriteRegistry("Software\\" + m.Listenaddr, "RGK", x);


				}
			}

			Environment.Exit(0);
		}
	}
}
