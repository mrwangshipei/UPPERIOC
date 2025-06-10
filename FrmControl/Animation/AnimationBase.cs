using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrmControl.C;
using FrmControl.FrmBase_;
using UPPERIOC.UPPER.IOC.Annaiation;

namespace FrmControl.Animation
{
    public abstract class AnimationBase<T> where T : Control
    {
        public AnimationBase(T me)
        {
            Register();
            Me = me;
        }
        public virtual T Me
        {
            get; set;
        }
        public abstract void Register();
        public abstract void Play();
    }
}
