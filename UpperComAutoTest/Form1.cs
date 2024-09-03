
using System.Configuration;
using UpperComAutoTest.ModelView;
using UpperComAutoTest.MyControls;
using UpperComAutoTest.View.Page.Interface;
using UPPERIOC;
using UPPERIOC.UPPER;

namespace UpperComAutoTest
{

	public partial class Form1 : Form
	{
		Form1ModelView modelView;
		public Form1()
		{
			modelView = UPPERIOCApplication.Container.GetInstance<Form1ModelView>();
			InitializeComponent();
			foreach (ToolStripItem item in toolStrip1.Items)
			{
				item.Click += Open;
			}
			NomalComPage.PerformClick();
		}



		/// <summary>
		/// ���ͽ�����ϣ������Ŷӿ���-
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Open(object sender, EventArgs e)
		{
			/*Loading.ShowForm(this, (loa) => {
				Thread.Sleep(1000);
				loa.SetMessage("����10", 10);
				Thread.Sleep(1000);
				loa.SetMessage("����20", 20);
				Thread.Sleep(1000);
				loa.SetMessage("����30", 30);
				Thread.Sleep(1000);
				loa.SetMessage("����40", 40);
				Thread.Sleep(1000);
				loa.SetMessage("����50", 50);
				Thread.Sleep(1000);
				loa.SetMessage("����60", 60);
				for (int i = 0; i < 40; i++)
				{

					Thread.Sleep(100);
					loa.SetMessage("����"+ (60+ i), (60 + i));
				}
				loa.SetMessage("����100", 100);
				Thread.Sleep(1000);

			});*/
			ToolStripItem send = sender as ToolStripItem;
			LogCenter.Log(UPPERIOC.UPPER.enums.LogType.Debug, $"����{send.Name}ҳ��");

			object page;
			if ((page = UPPERIOCApplication.Container.GetInstance(send.Name)) != null)
			{
				var ipage = page as IPage;
				if (ipage == null)
				{
				//	MyTips.ShowTips(this, Tipstype.Warn, "���廹û��ʵ��Ŷ", 2000);
				}
				panel1.Controls.Clear();
				ipage.Dock = DockStyle.Fill;
				panel1.Controls.Add(ipage);

			}
			else
			{
				//MyTips.ShowTips(this, Tipstype.Warn, "���廹û��ʵ��Ŷ", 2000);

			}
		}

		private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{

		}

		private void NomalComPage_Click(object sender, EventArgs e)
		{

		}
		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			modelView.Dosomething();
		}

		private void toolStripButton2_Click(object sender, EventArgs e)
		{
			modelView.Premission();
		}

		private void toolStripButton3_Click(object sender, EventArgs e)
		{
			modelView.Premission();
		}
	}
}
