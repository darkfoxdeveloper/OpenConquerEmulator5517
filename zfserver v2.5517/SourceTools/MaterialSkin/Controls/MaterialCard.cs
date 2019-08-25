using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace MaterialSkin.Controls
{
    using ControlRenderExtension;
    public partial class MaterialCard : Panel, IMaterialControl
    {
        [Browsable(false)]
        public Bitmap Shadow { get; set; }
        [Browsable(false)]
        public GraphicsPath ShadowShape { get; set; }
        private int _Depth = 0; public int Depth{ get{return _Depth;}set{if (_Depth!=value) Shadow = null;_Depth=value;if (Parent != null) Parent.Invalidate();}}
        [Browsable(false)]
        public MouseState MouseState { get; set; }
        public bool Primary { get; set; }

        private bool Growing;

        private Image _image;
        [Category("Appearance")]
        public Image Image
        {
            get { return _image; }
            set
            {
                _image = value;
                Invalidate();
            }
        }

        [Category("Appearance"), Browsable(true)]
        public override string Text { get; set; }

        [Category("Appearance"), Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        public string ContentText
        {
            get { return InfoLabel.Text; }
            set
            {
                InfoLabel.Text = value;
                ResizeLabel();

                Invalidate();
            }
        }

        [Category("Appearance"), Browsable(true)]
        public string ButtonText
        {
            get { return OKButton.Text; }
            set
            {
                OKButton.Text = value;
                ResizeLabel();
                Invalidate();
            }
        }

        public delegate void ActionButtonClickedEventHandler(object sender);
        public event ActionButtonClickedEventHandler ActionButtonClicked;

        public delegate void ActionButtonClickAnimationFinishedEventHandler(object sender);
        public event ActionButtonClickAnimationFinishedEventHandler ActionButtonClickAnimationFinished;

        Label InfoLabel = new MaterialLabel();
        MaterialFlatButton OKButton = new MaterialFlatButton();

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Width = 294;
            if (!Growing)
            {
                this.Height = InfoLabel.Location.Y + InfoLabel.Height + 74;
            }
            Shadow = null;
            ShadowShape = DrawHelper.CreateRoundRect(1, 1, Width - 3, Height - 4, 2);
        }

        public MaterialCard()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            Width = 294; Height = 348; DoubleBuffered = true;
            BackColor = Color.Transparent;

            AddLabel();
            AddButton();
            Controls.Add(InfoLabel);
            Controls.Add(OKButton);

            OKButton.Click += (sender,args) => ActionButtonClicked?.Invoke(this);
            OKButton.ClickAnimationFinished += sender => ActionButtonClickAnimationFinished?.Invoke(this);

            ResizeLabel();

            Primary = true;

            AutoSize = true;
        }

        public void AddLabel()
        {
            InfoLabel.AutoSize = false;
            InfoLabel.Location = new Point(13, 209);

            InfoLabel.Width = 265;
            InfoLabel.Text = "Info of the card";
        }
        public void AddButton()
        {
            OKButton.Location = new Point(210, InfoLabel.Bottom + 26);
            OKButton.Size = new Size(69, 33);
            OKButton.Text = "Got it";
        }

        private void ResizeLabel()
        {
            if (Growing) return;
            try
            {
                Growing = true;
                Size sz = new Size(InfoLabel.Width, Int32.MaxValue);
                sz = TextRenderer.MeasureText(InfoLabel.Text, MaterialSkinManager.ROBOTO_REGULAR_11, sz, TextFormatFlags.WordBreak);
                InfoLabel.Height = sz.Height;
            }
            finally
            {
                Growing = false;
            }

            OKButton.Location = new Point(210, InfoLabel.Bottom + 26);
            this.Height = InfoLabel.Bottom + 76;
            Refresh();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics G = e.Graphics;
            G.SmoothingMode = SmoothingMode.HighQuality;
            G.TextRenderingHint = TextRenderingHint.AntiAlias;

            Color NonColor = MaterialSkinManager.GetDisabledOrHintColor();

            var PicBG = DrawHelper.CreateRoundRect(1, 1, 292, 164, 1);
            var UpRoundedRec = DrawHelper.CreateRoundRect(1, 1, 291, 164, 1);
            var BG = DrawHelper.CreateRoundRect(1, 1, Width - 3, Height - 5, 1);
            var ShadowBG = DrawHelper.CreateRoundRect(1, 1, Width - 3, Height - 4, 2);

            G.FillPath(new SolidBrush(NonColor), ShadowBG);
            G.DrawPath(new Pen(NonColor), ShadowBG);

            //if (MouseState == MouseState.HOVER)
            //{
            //    Color c = MaterialSkinManager.GetApplicationBackgroundColor();
            //    G.FillPath(new SolidBrush(Color.FromArgb((int)(0.7*c.A), c.RemoveAlpha())), BG);
            //}
            //else
            //{
            G.FillPath(new SolidBrush(MaterialSkinManager.GetApplicationBackgroundColor()), BG);
            //}
            G.DrawPath(new Pen(MaterialSkinManager.GetDividersColor()), BG);


            G.DrawString(Text, MaterialSkinManager.ROBOTO_MEDIUM_15, Primary ? MaterialSkinManager.ColorScheme.PrimaryBrush : MaterialSkinManager.GetPrimaryTextBrush(), 12, 176);

            G.SmoothingMode = SmoothingMode.None;
            G.FillRectangle(MaterialSkinManager.GetDividersBrush(), 16, InfoLabel.Bottom + 14, 261, 1);

            if (_image != null)
            {
                G.SetClip(PicBG);
                G.DrawImage(_image, 0, 0, 293, 166);
            }
            else
            {
                G.FillPath(new SolidBrush(NonColor), UpRoundedRec);
                G.DrawPath(new Pen(NonColor), UpRoundedRec);
            }
            G.DrawPath(new Pen(MaterialSkinManager.GetDividersColor()), BG);
            if (!DesignMode && Controls.Count>0) this.DrawChildShadow(G);
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            if (DesignMode) return;

            MouseState = MouseState.OUT;
            MouseEnter += (sender, args) =>
            {
                MouseState = MouseState.HOVER;
                Invalidate();
            };
            MouseLeave += (sender, args) =>
            {
                MouseState = MouseState.OUT;
                Invalidate();
            };
            MouseDown += (sender, args) =>
            {
                if (args.Button == MouseButtons.Left)
                {
                    MouseState = MouseState.DOWN;
                    Invalidate();
                }
            };
            MouseUp += (sender, args) =>
            {
                MouseState = MouseState.HOVER;

                Invalidate();
            };
        }
    }
}
