using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FCT.Model;
using FCT.MyControls;
using FrmControl.C.Base;
using FrmControl.C.Btn;
using FrmControl.C.CMenu_;
using FrmControl.C.CMenu_.Node_;
using FrmControl.Properties;

namespace FrmControl.C.ComboBox_
{
    [DefaultEvent("SelectValueChanged")]

    public class CComboBox : CBaseControl
    {
        private BtnSide selectSide;
        PlaceholderTextBox placeholderTextBox = new PlaceholderTextBox();
        private Color selectBtnBackColor;
        private int outLength;
        private BindingList<string> dataSource;
        private int itemSize = 60;
        private int maxHeight = 600;
        private int selectedIndex;

        [Obsolete("Radius property is deprecated. ")]
        public new int Radius { get; set; }
        public int ShowHeight { get => dataSource.Count * ItemSize > MaxHeight ? MaxHeight : dataSource.Count * ItemSize; }
        public int MaxHeight { get => maxHeight; set {
                this.DoInvoke(new Action(() =>
                {
                    maxHeight = value;
                    this.OnMaxHeightChanged(value);
                }));
            }
        }
        public int SelectedIndex {
            get => selectedIndex;
            set
            {
                if (dataSource == null || value >= dataSource.Count)
                {
                    return;
                }
                selectedIndex = value;
                OnSelectIndexChanged(this, value);

            }
        }

        private void OnSelectIndexChanged(CComboBox cComboBox, int value)
        {
            SelectedIndexChanged?.Invoke(this,value);
            if (dataSource == null || dataSource.Count == 0)
            {
                return;
            }
            Text = dataSource[SelectedIndex];
        }

        private void OnMaxHeightChanged(int value)
        {
            SetTpHeight();
            MaxHeightChanged?.Invoke(this, value);

        }
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            placeholderTextBox.Text = Text;
            if (DataSource == null || DataSource.Count== 0)
            {
                return;
            }
            if (DataSource.Contains(Text))
            {
                ICTreeNode x;
                if (tm != null)
                {
                    x = tm.SelectNode(Text);
                }
                else
                {
                    x = new CTreeNodeTxt()
                    {
                        Text = Text,
                        Selected = true
                    };
                    
                }
            }
        }
        public int ItemSize { get => itemSize; set {
                this.DoInvoke(new Action(() =>
                {
                    itemSize = value;
                    this.OnItemSizeChanged(value);
                }));
            } 
        }
        public event EventHandler<int> ItemSizeChanged;
        public event EventHandler<int> MaxHeightChanged;
        private void OnItemSizeChanged(int value)
        {
            SetTpHeight();
            ItemSizeChanged?.Invoke(this, value);
        }

        private void SetTpHeight()
        {
            if (null == tp)
            {
                return;
            }
            if (tp?.Visible != true)
            {
                return;
            }
            if (DataSource != null && dataSource.Count > 0)
            {
                tp.Height = ShowHeight;
            }
            else {
                tp.Height = 1;
            }
        }

        public BindingList<string> DataSource { get => dataSource; set {
                this.DoInvoke(new Action(() =>
                {
                    dataSource = value;
                    if (value == null)
                    {
                        return;
                    }
                    dataSource.ListChanged += dataSource_ListChanged;
                }));
            }
        }

        private void dataSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            //InitTempForm();
            tm = new CTreeMenu();
            if (dataSource == null) {
                tm.Nodes = new BindingList<ICTreeNode>();
                return;
            }
            tm.Nodes = new BindingList<ICTreeNode>(dataSource.Select(x => new CTreeNodeTxt() { Text = x } as ICTreeNode).ToList()); ;
        }

        public int OutLength { 
            get => outLength; 
            set 
            {
                this.DoInvoke(new Action(() =>
                {
                    outLength = value;
                    SetRegion(value);
                }));
            }
        }

        private void SetRegion(int value)
        {
            if (lastr == this.Bounds)
            {
                return;
            } 
            lastr = this.Bounds;
            this.Region?.Dispose();
            this.RegionPath = this.ClientRectangle.ToSlantedRegion(value);
            this.Region = new Region(RegionPath);
            Ou.Padding = new Padding(outLength,1,1,1);
            this.Invalidate();
         }

        

        public Color SelectBtnBackColor { get => selectBtnBackColor; set
            {
                this.DoInvoke(new Action(() =>
                {
                    selectBtnBackColor = value;
                    btnImg.BackColor = SelectBtnBackColor;
                }));
                } 
        }

        public Rectangle lastr { get; private set; }
        public GraphicsPath RegionPath { get; private set; }
        public event EventHandler<int> SelectedIndexChanged;

        public enum BtnSide { 
        Left,Right
        }
        public CComboBox() {
            InitControl();
            DataSource = new BindingList<string>();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;

            // 禁止子控件绘制
     
            // 绘制边框
            using (Pen borderPen = new Pen(Color.Black, 2))
            {
              //  if (this.RegionPath != null)
                {
                    System.Drawing.Drawing2D.GraphicsPath path = RegionPath;
                  //  if (path != null)
                    {
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        g.DrawPath(borderPen, path);
                    }
                }
            }

        
        }


        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            SetRegion(OutLength);
        }
        protected override void OnLocationChanged(EventArgs e)
        {
            base.OnLocationChanged(e);
            SetRegion(OutLength);

        }
        private void InitControl()
        {
            InitPanelall();
            //InitTempForm();
        }

        Panel Ou = new Panel();
        private void InitPanelall()
        {
            Ou.Dock = DockStyle.Fill;
            Ou.BackColor = Color.Transparent;
            this.Controls.Add(Ou);
            InitPanel1();
            InitPanel2();
        }

        TempForm tp ;
        CTreeMenu tm ;
        FlowLayoutPanel f;
        private void InitTempForm()
        {
            tp = new TempForm();
            tp.StartAtMouse = false;
            tp.StartPosition = FormStartPosition.Manual;
            tp.Width = Width;
            tp.Controls.Clear();
            f = new FlowLayoutPanel();
            f.AutoScroll = true;
            f.HorizontalScroll.Visible = false;
            f.Dock = DockStyle.Fill;
            tp.Controls.Add(f);
            tm = new CTreeMenu();
            tm.Font = Font;
            tm.Width = f.Width - SystemInformation.VerticalScrollBarWidth -6;
            tm.Location = new Point(0,0);
            tm.Height = DataSource.Count * ItemSize;
            tm.ItemHeight = itemSize;
            
            tm.LayoutType = CTreeMenu.Layout.V;
            tm.Nodes = new BindingList<ICTreeNode>(dataSource.Select(x => new CTreeNodeTxt() { Text = x } as ICTreeNode).ToList()); ;
            tm.SelectNode(SelectedIndex);
            tm.SelectedNodeChanged += OnMouseSelectedChanged;
            f.Controls.Add(tm);
        }
        public event EventHandler<string> SelectValueChanged;
        private void OnMouseSelectedChanged(object sender, ICTreeNode e)
        {
        //    placeholderTextBox.Text = e.Text;
            if (Text != e.Text)
            {
                Text = e.Text;
            }
            tp?.Close();
            if (tm != null && tm.Nodes.IndexOf(e) > 0)
            {
                if (SelectedIndex != tm.Nodes.IndexOf(e))
                {
                    SelectedIndex = tm.Nodes.IndexOf(e);
                }
            }
            //   SelectValueChanged?.Invoke(this,e.Text);
        }

        private void InitPanel2()
        {
            Panel panel2 = new Panel();
            panel2.SizeChanged += (x1, x2) => {
                if (panel2.Width != panel2.Height)
                {
                    panel2.Width = panel2.Height;
                }
            };
            panel2.Dock = DockStyle.Right;
            Ou.Controls.Add(panel2);
            InitBtn(panel2);
        }

            Panel panel1 = new Panel();
        private void InitPanel1()
        {

            panel1.Dock = DockStyle.Fill ;
            Ou.Controls.Add(panel1);

            InitTextBoxSource(panel1);
        }

        FrmBtnImg btnImg = new FrmBtnImg();
        private void InitBtn(Panel panel2)
        {
            panel2.Controls.Add(btnImg);
            btnImg.Dock = DockStyle.Fill;
            btnImg.BackColor = SelectBtnBackColor;
            btnImg.IconPanel.Margin = new Padding(12);
            btnImg.IconLayout = ImageLayout.Zoom;
            btnImg.IconPrecent = 100;
            btnImg.TextPrecent = 0;
            btnImg.IconSizeType = SizeType.Percent;
            using (MemoryStream me = new MemoryStream(Resources.more))
            {
                btnImg.Icon = Image.FromStream(me);
            }
            btnImg.Click += ShowItems;
        }

        private void ShowItems(object sender, EventArgs e)
        {
            InitTempForm();
            tp.Location =this.PointToScreen(new Point(0,this.Height));

            tp.Show();
            SetTpHeight();
        }

      
        private void InitTextBoxSource(Panel panel1)
        {
            // 创建一个新的 PlaceholderTextBox 实例
            placeholderTextBox.BorderStyle = BorderStyle.None;
            // 设置 PlaceholderTextBox 的属性
            placeholderTextBox.Text = "";  // 初始化文本框为空
            placeholderTextBox.Enabled = true;
            // 设置文本框大小
            placeholderTextBox.Size = new Size(panel1.Width , 30); // 例如设置为 panel 宽度的一半，高度为 30

            // 使 PlaceholderTextBox 居中
            placeholderTextBox.Location = new Point(
                (panel1.Width - placeholderTextBox.Width) / 2,
                (panel1.Height - placeholderTextBox.Height) / 2
            );

            // 将 PlaceholderTextBox 添加到 panel1 控件
            panel1.Controls.Add(placeholderTextBox);

            // 通过事件处理大小变化时，重新调整位置
            panel1.Resize += (sender, e) =>
            {
                placeholderTextBox.Size = new Size(panel1.Width, 30); // 例如设置为 panel 宽度的一半，高度为 30

                placeholderTextBox.Location = new Point(
                    outLength + 2,
                    (panel1.Height - placeholderTextBox.Height) / 2
                );
            };
            this.BackColorChanged += (sender, e) => {
                placeholderTextBox.BackColor = BackColor;
            };
            this.ForeColorChanged += (sender, e) => { 
                placeholderTextBox.ForeColor = ForeColor;
            };
        }

    }
}
