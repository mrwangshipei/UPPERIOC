using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmControl.C.Btn
{
    public partial class FrmBtnImg : CBaseControl
    {
        public Image Icon { get => panel2.BackgroundImage; set => panel2.BackgroundImage = value; }
        public ImageLayout IconLayout{ get=>panel2.BackgroundImageLayout; set => panel2.BackgroundImageLayout = value; }
        public Padding IconPadding{ get=>panel2.Margin; set => panel2.Margin = value; }

        public float IconPrecent { get => tableLayoutPanel1.ColumnStyles[0].Width; set => tableLayoutPanel1.ColumnStyles[0].Width = value; }
        public float TextPrecent { get => tableLayoutPanel1.ColumnStyles[1].Width; set => tableLayoutPanel1.ColumnStyles[1].Width = value; }
        public SizeType IconSizeType { get => tableLayoutPanel1.ColumnStyles[0].SizeType; set => tableLayoutPanel1.ColumnStyles[0].SizeType= value; }
        public SizeType TextSizeType { get => tableLayoutPanel1.ColumnStyles[1].SizeType; set => tableLayoutPanel1.ColumnStyles[1].SizeType= value; }
        public override string Text { get=>base.Text; set{
                base.Text = value;
                this.label1.Text = value;
            } 
        }
        public FrmBtnImg()
        {
            InitializeComponent();
            AddEvent(this);
        }

        private void AddEvent(Control con)
        {
            con.MouseEnter += TheMouseEnter;
            con.MouseLeave += TheMouseLeave;
            con.MouseClick += TheMouseClick;
            con.MouseClick += TheMouseClick;
        }

        private void TheMouseClick(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void TheMouseLeave(object sender, EventArgs e)
        {

        }

        private void TheMouseEnter(object sender, EventArgs e)
        {
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        Color nomalc;
        protected override void OnMouseEnter(EventArgs e)
        {
            nomalc = this.BackColor;
            this.BackColor = Color.DarkGray;
            base.OnMouseEnter(e);
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.BackColor = nomalc;

        }
    }
}
