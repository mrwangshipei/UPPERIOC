﻿using COMIEEE;
using Scancodeupload.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpperComAutoTest.Model;
using UPPERIOC2.UPPER.Premission.Center;
using UPPERIOC2.UPPER.Premission.UAttribute;

namespace UpperComAutoTest.ModelView
{
	[ProxyClass]
	public class Form1ModelView
	{
		[ProxyCon]
		public Form1ModelView(NomalComPageModel no) {
			//MessageBox.Show("PremissionSuccess");

		}
		[PremissionRequired(2)]
		public virtual void Dosomething() {
			//MessageBox.Show("PremissionSuccess");
		}

		public virtual void addRole()
		{

		}
		[PremissionRequired(0)]

		public virtual void Premission()
		{
			PremissionEditForm g = new PremissionEditForm();
			g.ShowDialog();
		}
	}
}
