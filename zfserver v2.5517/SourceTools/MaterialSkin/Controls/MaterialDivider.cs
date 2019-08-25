using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MaterialSkin.Controls
{
    public sealed class MaterialDivider : Control, IMaterialControl
    {
        [Browsable(false)]
        public Bitmap Shadow { get; set; }
        [Browsable(false)]
        public GraphicsPath ShadowShape { get; set; }
        private int _Depth = 0; public int Depth{ get{return _Depth;}set{if (_Depth!=value) Shadow = null;_Depth=value;if (Parent != null) Parent.Invalidate();}}
        [Browsable(false)]
        public MouseState MouseState { get; set; }
        
        public MaterialDivider()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            Height = 1;
            BackColor = MaterialSkinManager.GetDividersColor();
            ShadowShape = null;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Shadow = null;
        }
    }
}
