using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmControl.Util
{
    /// <summary>
    /// 点击那个控件进行移动类
    /// </summary>
    public class MoveShiJianEvent
    {
        private Form form = null;

        /// <summary>
        /// 绑定移动事件
        /// </summary>
        public void BangDingMove(Control control, Form ZhuChuanTi)
        {
            PointModel model = new PointModel();
            if (form == null)
            {
                form = ZhuChuanTi;
            }
            control.Tag = model;
            control.MouseDown += new MouseEventHandler(control_MouseDown);

            control.MouseUp += new MouseEventHandler(control_MouseUp);

            control.MouseMove += new MouseEventHandler(control_MouseMove);
        }

        void control_MouseMove(object sender, MouseEventArgs e)
        {
            PointModel model = (sender as Control).Tag as PointModel;
            if (model.IsAnXia)
            {
                int x = e.X - model.ChuShiDian.X;
                int y = e.Y - model.ChuShiDian.Y;
                form.Location = new Point(form.Location.X + x, form.Location.Y + y);
            }
        }

        void control_MouseUp(object sender, MouseEventArgs e)
        {
            PointModel model = (sender as Control).Tag as PointModel;
            model.ChuShiDian = new Point(e.X, e.Y);
            model.IsAnXia = false;
            //  (sender as Control).Tag = model;
        }

        void control_MouseDown(object sender, MouseEventArgs e)
        {
            PointModel model = (sender as Control).Tag as PointModel;
            model.ChuShiDian = new Point(e.X, e.Y);
            model.IsAnXia = true;
            //(sender as Control).Tag = model;
        }
    }

    internal class PointModel
    {
        public Point ChuShiDian { get; set; }

        public bool IsAnXia { get; set; }

        public PointModel()
        {
            ChuShiDian = new Point(0, 0);
            IsAnXia = false;
        }
    }
}
