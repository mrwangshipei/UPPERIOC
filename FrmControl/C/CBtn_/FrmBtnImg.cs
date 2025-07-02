using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrmControl.C.Base;

namespace FrmControl.C.Btn
{
    public partial class FrmBtnImg : CBaseControl
    {
        public Image Icon { get => IconPanel.BackgroundImage; set => IconPanel.BackgroundImage = value; }
        public ImageLayout IconLayout{ get=>IconPanel.BackgroundImageLayout; set => IconPanel.BackgroundImageLayout = value; }
        public Padding IconPadding{ get=>IconPanel.Margin; set => IconPanel.Margin = value; }
        public new EventHandler Click;
        public new EventHandler MouseLeave;
        public new EventHandler MouseEnter;
        public new EventHandler MouseDown;
        public float IconPrecent { get => tableLayoutPanel1.ColumnStyles[0].Width; set => tableLayoutPanel1.ColumnStyles[0].Width = value; }
        public float TextPrecent { get => tableLayoutPanel1.ColumnStyles[1].Width; set => tableLayoutPanel1.ColumnStyles[1].Width = value; }
        public SizeType IconSizeType { get => tableLayoutPanel1.ColumnStyles[0].SizeType; set => tableLayoutPanel1.ColumnStyles[0].SizeType= value; }
        public SizeType TextSizeType { get => tableLayoutPanel1.ColumnStyles[1].SizeType; set => tableLayoutPanel1.ColumnStyles[1].SizeType= value; }
        public override string Text { get=>base.Text; set{
                base.Text = value;
                this.label1.Text = value;
            } 
        }

        public Color MouseEnterColor { get; set; } = Color.LightGray;

        public FrmBtnImg()
        {
            SetStyle( ControlStyles.SupportsTransparentBackColor,true);
            InitializeComponent();
            AddEvent(this);
        }

        private void AddEvent(Control con)
        {
            con.MouseEnter += TheMouseEnter;
            con.MouseLeave += TheMouseLeave;
            con.MouseClick += TheMouseClick;
            con.MouseDown += TheMouseDown;
            foreach (Control item in con.Controls)
            {
                AddEvent(item);
            }
        }

        private void TheMouseDown(object sender, MouseEventArgs e)
        {
            MouseDown?.Invoke(sender, e);
        }

        private void TheMouseClick(object sender, MouseEventArgs e)
        {
            Click?.Invoke(sender,e);
        }

        private void TheMouseLeave(object sender, EventArgs e)
        {
            this.BackColor = nomalc;
            MouseLeave?.Invoke(sender, e);

        }

        private void TheMouseEnter(object sender, EventArgs e)
        {
            nomalc = this.BackColor;
            this.BackColor = MouseEnterColor;
            MouseEnter?.Invoke(sender, e);

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        Color nomalc;
        protected override void OnMouseEnter(EventArgs e)
        {
           
            base.OnMouseEnter(e);
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

        }
    }
}
