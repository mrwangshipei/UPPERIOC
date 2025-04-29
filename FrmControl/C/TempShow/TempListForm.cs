using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmControl.C.TempShow
{
    public partial class TempListForm : Form
    {
        Control At;
        Control Base;
        Control F;
        private int si;
        public int ItemHeight { get; set; } = 30;
        public bool ChangeText { get; set; }
        private BindingList<string> list;
        public event EventHandler<EventArgs> OnSelectIndexChanged;
        public event EventHandler<KeyEventArgs> OnKeyDownNew;
        public int SelectIndex { get=> si; set {
                if (value >= Items.Count || value < 0)
                {
                    return;
                }
                si = value;
                SelectIndexChanged(SelectIndex);
                OnSelectIndexChanged?.Invoke(this, EventArgs.Empty);
            } }
        public string SelectText { get => Source[SelectIndex]; }
        private void SelectIndexChanged(int selectIndex)
        {
            Items.All(i => {
                i.BackColor = Color.Transparent;
                return true;
                });
            Items[selectIndex].BackColor = Color.AliceBlue;
            if (ChangeText)
                At.Text = Source[selectIndex];

        }

        public List<Label> Items { get; set; } = new List<Label>();
        public BindingList<string> Source { get=>list; set {
                list = value;
                list.ListChanged += ListChanged;
                list.AddingNew += AddItem;
            } }

        private void ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded)
            {

                var item = Source[e.NewIndex];
                Label Txt = new Label();
                Txt.Text = item.ToString();
                Txt.Font = this.Font;
                Items.Add(Txt);
                Txt.MouseClick += (ee, aa) => {
                    SelectIndex = e.NewIndex;
                        if (ChangeText) 
                        At.Text = item.ToString();
                    this.Visible = false;
                };
                Txt.AutoSize = false;
                Txt.TextAlign = ContentAlignment.MiddleCenter;
                Txt.Width = this.Width;
                Txt.Height = ItemHeight;
                flowLayoutPanel1.Controls.Add(Txt);

            }
            else if (e.ListChangedType ==  ListChangedType.ItemDeleted)
            {
                var txt = Items[e.OldIndex];
                Items.RemoveAt(e.OldIndex);
                flowLayoutPanel1.Controls.Remove(txt);

            }
            else if (e.ListChangedType == ListChangedType.ItemChanged)
            {
                var txt = Items[e.NewIndex];
                 txt.Text = list[e.OldIndex];
            }
        }

        private void AddItem(object sender, AddingNewEventArgs e)
        { }

        private TempListForm()
        {
            InitializeComponent();
        }
        //浮动窗体
        public TempListForm(Control AtControl,bool ChangeText = false):this()
        {
            At = AtControl;
            Base = At.FindForm();
            Base.VisibleChanged += VisChange;
            flowLayoutPanel1.HorizontalScroll.Enabled = false;
            flowLayoutPanel1.HorizontalScroll.Visible = false;
            At.KeyDown += OnKeyDown;
            this.ChangeText = ChangeText;
            if (F != null)
            {
                //this.F = F;
                F.KeyDown += OnKeyDown;

            }
            SetFosucChanged(Base);
        }

        private void VisChange(object sender, EventArgs e)
        {
            if (!Base.Visible)
            {
                Visible = false;
            }
        }

        ~TempListForm() { 
            At.KeyDown -= OnKeyDown;
            if (F != null)
            {
                F.KeyDown -= OnKeyDown;
            }
            
        }
        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            OnKeyDown( e);
            OnKeyDownNew?.Invoke(sender,e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
        //   base.OnKeyDown(e);
            if (this.IsDisposed)
            {
                return; 
            }
            if (e.KeyCode== Keys.Up)
            {
                if (SelectIndex > 0) {
                    SelectIndex--;
                }
            }
            else if(e.KeyCode == Keys.Down)
            {
                if (SelectIndex < Source.Count)
                {
                    SelectIndex++;
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                SelectIndex = SelectIndex;
            }
        }
        private void SetFosucChanged(Control @base)
        {
            if (@base != At)
            {
                @base.GotFocus += (e, arg) => {
                this.Visible = false;
            };

            }
            foreach (Control item in @base.Controls)
            {
                SetFosucChanged(item);
            }
        }
        public new void Show() {
            
            Location = At.PointToScreen(new Point(0, At.Height));
            if (Source!= null)
            {
                
                Items.Clear();
                flowLayoutPanel1.Controls.Clear();
                for (int i = 0; i < Source.Count; i++)
                {
                    var item = Source[i];
                    Label Txt = new Label();
                    Txt.Text = item.ToString();
                    Txt.Font = this.Font;
                    Items.Add(Txt);
                    Txt.AutoSize = false;
                    int f = i;
                    Txt.Click += (ee,aa) => {
                        SelectIndex = f;
                        if (ChangeText) 
                        At.Text = item.ToString();
                        this.Visible = false;
                    };
                    Txt.TextAlign = ContentAlignment.MiddleCenter;
                    Txt.Width = this.Width;
                    Txt.Height = ItemHeight;
                    Txt.Padding = Padding.Empty;
                    Txt.Margin = Padding.Empty;
                    flowLayoutPanel1.Controls.Add(Txt);
                }
                var size = new Size(this.Width, ItemHeight * Items.Count + 3);
                SelectIndex = 0; 
                TopMost = true;
                flowLayoutPanel1.HorizontalScroll.Visible = false;
                Visible = true;
                this.Size = size;
            }
        }
    }
}
