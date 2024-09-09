
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
		/// 降低界面耦合，方便团队开发-
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Open(object sender, EventArgs e)
		{
			/*Loading.ShowForm(this, (loa) => {
				Thread.Sleep(1000);
				loa.SetMessage("加载10", 10);
				Thread.Sleep(1000);
				loa.SetMessage("加载20", 20);
				Thread.Sleep(1000);
				loa.SetMessage("加载30", 30);
				Thread.Sleep(1000);
				loa.SetMessage("加载40", 40);
				Thread.Sleep(1000);
				loa.SetMessage("加载50", 50);
				Thread.Sleep(1000);
				loa.SetMessage("加载60", 60);
				for (int i = 0; i < 40; i++)
				{

					Thread.Sleep(100);
					loa.SetMessage("加载"+ (60+ i), (60 + i));
				}
				loa.SetMessage("加载100", 100);
				Thread.Sleep(1000);

			});*/
			ToolStripItem send = sender as ToolStripItem;
			LogCenter.Log(UPPERIOC.UPPER.enums.LogType.Debug, $"打开了{send.Name}页面");

			object page;
			if ((page = UPPERIOCApplication.Container.GetInstance(send.Name)) != null)
			{
				var ipage = page as IPage;
				if (ipage == null)
				{
				//	MyTips.ShowTips(this, Tipstype.Warn, "窗体还没有实现哦", 2000);
				}
				panel1.Controls.Clear();
				ipage.Dock = DockStyle.Fill;
				panel1.Controls.Add(ipage);

			}
			else
			{
				//MyTips.ShowTips(this, Tipstype.Warn, "窗体还没有实现哦", 2000);

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
