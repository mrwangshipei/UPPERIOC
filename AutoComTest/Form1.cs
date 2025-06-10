
using FrmBase_;
using FrmControl.C;
using FrmControl.Frm;
using System;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UpperComAutoTest.ModelView;
using UpperComAutoTest.MyControls;
using UpperComAutoTest.MyControls.Frm;
using UpperComAutoTest.View.Page.Interface;
using UPPERIOC;
using UPPERIOC.UPPER;
using UPPERIOC2.UPPER.Translate.Center;

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
			TranslateCenter.Instance.SetRootWindows(this);

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

	
		private void toolStripButton1_Click_2(object sender, EventArgs e)
        {// 普通提示
			//Task.Factory.StartNew(() => { 
			//	MyTips.ShowTipTip("这是一个普通提示（Tip）", 2000);
			//	Thread.Sleep(2000);

			//	// 成功提示
			//	MyTips.ShowTipSuccess("操作成功！", 2000);
			//	Thread.Sleep(2000);

			//	// 警告提示
			//	MyTips.ShowTipWarn("请注意，操作可能存在风险", 2000);
			//	Thread.Sleep(2000);

			//	// 错误提示
			//	MyTips.ShowTipError("发生错误，请重试", 2000);
			//});
			TempForm tp = new TempForm();
			tp.ShowDialog();
            //FrmDialog.ShowDialog(this,"dasda0","asda");
            //MyTips.ShowTips(this, Tipstype.Tip, "adsfkladshjfnkladshfjkadshfjkadsfkladshjfnkladshfjkadshfjkadsfkladshjfnkladshfjkadshfjkadsfkladshjfnkladshfjkadshfjkadsfkladshjfnkladshfjkadshfjkadsfkladshjfnkladshfjkadshfjkadsfkladshjfnkladshfjkadshfjkadsfkladshjfnkladshfjkadshfjkadsfkladshjfnkladshfjkadshfjkadsfkladshjfnkladshfjkadshfjkadsfkladshjfnkladshfjkadshfjkadsfkladshjfnkladshfjkadshfjk");
            //Thread.Sleep(15000);
        }

		private void toolStripButton2_Click_1(object sender, EventArgs e)
		{
			TextLoading.ShowForm(this,act => {
				for (int i = 1; i <= 100; i++) 
				{
					act.SetMessage($"加载中... ...", (int)(GetBFB(i)*100));
					Thread.Sleep(30);
				}
			
			});
		}

        private float GetBFB(int i)
        {
			return (1.0f / (100 * 100 * 100) ) * i * i * i;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
		{

		}

		private void toolStripButton1_DisplayStyleChanged(object sender, EventArgs e)
		{

		}
	}
}
