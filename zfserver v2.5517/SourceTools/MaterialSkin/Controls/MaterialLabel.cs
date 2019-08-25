using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MaterialSkin.Controls
{
    public class MaterialLabel : Label, IMaterialControl
    {
        [Browsable(false)]
        public Bitmap Shadow { get; set; }
        [Browsable(false)]
        public GraphicsPath ShadowShape { get; set; }
        private int _Depth = 0; public int Depth{ get{return _Depth;}set{if (_Depth!=value) Shadow = null;_Depth=value;if (Parent != null) Parent.Invalidate();}}
        [Browsable(false)]
        public MouseState MouseState { get; set; }
        [Category("Appearance")]
        public bool Primary { get; set; }
        private int _fSize = 11;
        [Category("Appearance")]
        public int FontSize {
            get {
                return _fSize;
            }
            set
            {
                _fSize = value;
                Font = new Font(MaterialSkinManager.ROBOTO_REGULAR_11.FontFamily, _fSize);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Shadow = null;
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            if (Primary)
            {
                ForeColor = MaterialSkinManager.GetPrimaryTextColor();
            }
            else
            {
                ForeColor = MaterialSkinManager.GetSecondaryTextColor();
            }
            Font = new Font(MaterialSkinManager.ROBOTO_REGULAR_11.FontFamily, FontSize);

            BackColorChanged += (sender, args) =>
            {
                if (Primary)
                {
                    ForeColor = MaterialSkinManager.GetPrimaryTextColor();
                }
                else
                {
                    ForeColor = MaterialSkinManager.GetSecondaryTextColor();
                }
            };
        }
    }
}
