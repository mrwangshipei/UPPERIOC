using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UPPERIOC.UPPER.IOC.Center.IProvider;
using UPPERIOC2.UPPER.Translate.Model;
using UPPERIOC2.UPPER.UFileModel.Center;
using UPPERIOC2.UPPER.Util;
using static System.Net.Mime.MediaTypeNames;

namespace UPPERIOC2.UPPER.Translate.Center
{
	public class TranslateCenter
	{
		public static TranslateCenter Instance { get; set; } = new TranslateCenter();
		internal TranslateModel TranslateModel;
		internal Translateblock TranslateBlock;
		internal IContainerProvider ipd;
		internal string L;
		List<Control> root = new List<Control>(25);
		List<Control> Ignore= new List<Control>(25);
		internal TranslateCenter(IContainerProvider ipd) {

			this.ipd = ipd;
		}
		internal TranslateCenter()
		{

		}
		public void SetRootWindows(Component com) {
			if (ipd == null)
			{
				return;
			}
			if (com is ToolStrip it)
			{
				foreach (ToolStripItem item in it.Items)
				{
					SetRootWindows(item);
				}
				it.Text = GetText(it.Text);

			}else
			if (com is ToolStripItem ita)
			{
				ita.Text = GetText(ita.Text);

			}
			else			if (com is Control con)
			{
				foreach (Control item in con.Controls)
					{
						SetRootWindows(item);
					}
					con.Text  = GetText(con.Text);
			}
		
		/*	con.ControlAdded -= SetControlAdd;
			con.ControlAdded += SetControlAdd;
			con.TextChanged -= SetTextChange;
			con.TextChanged += SetTextChange;*/
		}
		public void SetLanguage(string lan)
		{
			L = lan;
			if (null == TranslateModel)
			{
				TranslateModel =F.I.GetModel(new TranslateModel());
			}
			if (null != TranslateModel)
			{
				TranslateBlock = TranslateModel.Translateblocks.Find(x=> x.Name == lan);
				if (TranslateBlock == null)
				{
					TranslateBlock = new Translateblock();
					TranslateBlock.Name = lan;
					TranslateModel.Translateblocks.Add(TranslateBlock);
				}
			}
		}
		public void SetIgnoreCon(Control con) 
		{
			Ignore.Add(con);
		}
		private void SetControlAdd(object sender, ControlEventArgs e)
		{

			if (Ignore.Contains(e.Control))
			{
				return;
			}
			e.Control.ControlAdded -= SetControlAdd;
			e.Control.ControlAdded += SetControlAdd;
			if (!string.IsNullOrWhiteSpace(e.Control.Text))
			{
				e.Control.Text = GetText(e.Control.Text);

			}

			e.Control.TextChanged -= SetTextChange;
			e.Control.TextChanged += SetTextChange;
			
		}

		private void SetTextChange(object sender, EventArgs e)
		{
			Control con = sender as Control;
			if (!string.IsNullOrWhiteSpace(con.Text) && con.Text != GetText(con.Text))
			{
				con.TextChanged -= SetTextChange;
				con.Text = GetText(con.Text);
				con.TextChanged += SetTextChange;
			}
		}

		public string GetText(string text)
		{
			if (ipd == null)
			{
				return text;
			}
			if (string.IsNullOrWhiteSpace(text))
			{
				return text;
			}

			var str = TranslateBlock.Values.Find(x => x.Key == text && !string.IsNullOrWhiteSpace(x.Value)).Value;
			if (string.IsNullOrWhiteSpace(str))
			{
				str = TranslateUtil.Transcale(text);
				TranslateBlock.Values.Add(new KeyValue(text,str));
				F.I.SaveModel(TranslateModel);
			}
			if (string.IsNullOrWhiteSpace(str))
			{
				return text;
			}
			return str;
		}
	}
}
