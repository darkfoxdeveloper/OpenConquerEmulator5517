using MaterialSkin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MaterialSkin.Controls
{
    using ControlRenderExtension;
    public partial class MaterialPanel : Panel, IMaterialControl
    {
        [Browsable(false)]
        public Bitmap Shadow { get; set; }
        [Browsable(false)]
        public GraphicsPath ShadowShape { get; set; }
        private int _Depth = 0; public int Depth{ get{return _Depth;}set{if (_Depth!=value) Shadow = null;_Depth=value;if (Parent != null) Parent.Invalidate();}}
        [Browsable(false)]
        public MouseState MouseState { get; set; }

        private bool _primary;
        public bool Primary
        {
            get
            {
                return _primary;
            }
            set
            {
                _primary = value;
                Invalidate();
            }
        }

        private int _roundedCorner = 2;
        [Browsable(true)]
        [Category("Appearance")]
        public int RoundedCornerRadius
        {
            get
            {
                return _roundedCorner;
            }
            set
            {
                _roundedCorner = value;
                OnResize(null);
                Invalidate();
            }
        }

        public MaterialPanel()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            GraphicsPath bgGP = DrawHelper.CreateRoundRect(ClientRectangle.X,
                ClientRectangle.Y,
                ClientRectangle.Width - 1,
                ClientRectangle.Height - 1,
                _roundedCorner);
            e.Graphics.FillPath(MaterialSkinManager.GetPanelBackgroundBrush(_primary), bgGP);

            if (!DesignMode && Controls.Count>0) this.DrawChildShadow(e.Graphics);
        }

        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);
            Shadow = null;
            ShadowShape = DrawHelper.CreateRoundRect(ClientRectangle.X,
                ClientRectangle.Y,
                ClientRectangle.Width - 1,
                ClientRectangle.Height - 1,
                _roundedCorner);
        }
    }
}
