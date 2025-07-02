using System.ComponentModel;

namespace FrmControl.C.Btn
{
    partial class FrmBtnImg
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.OutPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.IconPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.OutPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.OutPanel.Controls.Add(this.tableLayoutPanel1);
            this.OutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OutPanel.Location = new System.Drawing.Point(0, 0);
            this.OutPanel.Name = "panel1";
            this.OutPanel.Size = new System.Drawing.Size(215, 88);
            this.OutPanel.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.IconPanel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(211, 84);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.IconPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IconPanel.Location = new System.Drawing.Point(3, 3);
            this.IconPanel.Name = "panel2";
            this.IconPanel.Size = new System.Drawing.Size(99, 78);
            this.IconPanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(108, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 84);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmBtnImg
            // 
            this.Controls.Add(this.OutPanel);
            this.Name = "FrmBtnImg";
            this.Size = new System.Drawing.Size(215, 88);
            this.OutPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public Panel OutPanel;
        public TableLayoutPanel tableLayoutPanel1;
        public Panel IconPanel;
        public Label label1;
    }
}
