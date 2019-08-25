using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using MaterialSkin.Animations;
using System.Collections.Generic;
using System.Linq;

namespace MaterialSkin.Controls
{
    using ControlRenderExtension;
    public class MaterialSmallCard : Panel, IMaterialControl
    {
        [Browsable(false)]
        public Bitmap Shadow { get; set; }
        [Browsable(false)]
        public GraphicsPath ShadowShape { get; set; }
        private int _Depth = 0; public int Depth{ get{return _Depth;}set{if (_Depth!=value) Shadow = null;_Depth=value;if (Parent != null) Parent.Invalidate();}}
        [Browsable(false)]
        public MouseState MouseState { get; set; }
        public bool Primary { get; set; }
        private string info;

        private readonly AnimationManager hoverAnimationManager;
        private bool autoexpand;

        private SizeF textSize;
        private SizeF infoSize;

        [Category("Appearance"), Browsable(true)]
        public override string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value;
                textSize = CreateGraphics().MeasureString(value, MaterialSkinManager.ROBOTO_MEDIUM_10);
                if (AutoSize)
                    Size = new Size(52, 0) + GetPreferredSize();
                Invalidate();
            }
        }

        [Category("Appearance")]
        public bool AutoExpand
        {
            get
            {
                return autoexpand;
            }
            set
            {
                autoexpand = value;
                if (value) OnMouseLeave(EventArgs.Empty);
                else Width = 52 + GetPreferredSize().Width;
            }
        }

        Image image;
        [Category("Appearance")]
        public Image Image
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        public string Info
        {
            get { return info; }
            set
            {
                info = value;
                infoSize = CreateGraphics().MeasureString(value, MaterialSkinManager.ROBOTO_REGULAR_9);
                if (AutoSize)
                    Size = new Size(52, 0) + GetPreferredSize();
                Invalidate();
            }
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            if (AutoExpand) Width = 52;
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            MouseState = MouseState.HOVER;
            hoverAnimationManager.StartNewAnimation(AnimationDirection.In);
            Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            MouseState = MouseState.OUT;
            hoverAnimationManager.StartNewAnimation(AnimationDirection.Out);
            Invalidate();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Height = 52;
            Shadow = null;
            ShadowShape = DrawHelper.CreateRoundRect(1, 1, Width - 3, Height - 3, 1);
        }

        public MaterialSmallCard()
        {
            Height = 52; Width = 182; DoubleBuffered = true;
            BackColor = Color.Transparent;
            hoverAnimationManager = new AnimationManager
            {
                Increment = 0.08,
                AnimationType = AnimationType.Linear
            };

            hoverAnimationManager.OnAnimationProgress += HoverAnimationManager_OnAnimationProgress;
        }

        private void HoverAnimationManager_OnAnimationProgress(object sender)
        {
            if (autoexpand)
            {
                Width = 52 + (int)(GetPreferredSize().Width * hoverAnimationManager.GetProgress());
            }
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics G = e.Graphics;
            G.SmoothingMode = SmoothingMode.HighQuality;

            var BG = DrawHelper.CreateRoundRect(1, 1, Width - 3, Height - 3, 1);
            var ThumbnailBG = DrawHelper.CreateLeftRoundRect(1, 1, 50, 49, 1);

            G.FillPath(new SolidBrush(MaterialSkinManager.GetApplicationBackgroundColor()), BG);
            //Hover
            Color c = MaterialSkinManager.GetFlatButtonHoverBackgroundColor();
            using (Brush b = new SolidBrush(Color.FromArgb((int)(hoverAnimationManager.GetProgress() * c.A), c.RemoveAlpha())))
                G.FillPath(b, BG);
            G.DrawPath(new Pen(MaterialSkinManager.GetDividersColor()), BG);

            G.FillPath(MaterialSkinManager.ColorScheme.PrimaryBrush, ThumbnailBG);
            G.DrawPath(MaterialSkinManager.ColorScheme.PrimaryPen, ThumbnailBG);

            if (image != null)
            { G.DrawImage(image, 3, 3, 48, 47); }
            if (Enabled)
            { G.DrawString(Text, MaterialSkinManager.ROBOTO_MEDIUM_10, Primary ? MaterialSkinManager.ColorScheme.PrimaryBrush : MaterialSkinManager.GetPrimaryTextBrush(), new PointF(58.6f, 9f)); }
            else
            { G.DrawString(Text, MaterialSkinManager.ROBOTO_MEDIUM_10, new SolidBrush(MaterialSkinManager.GetDisabledOrHintColor()), new PointF(58.6f, 9f)); }

            G.TextRenderingHint = TextRenderingHint.AntiAlias;
            G.DrawString(info, MaterialSkinManager.ROBOTO_REGULAR_9, new SolidBrush(MaterialSkinManager.GetSecondaryTextColor()), new PointF(59.1f, 26f));
            if (!DesignMode && Controls.Count>0) this.DrawChildShadow(G);
        }

        private Size GetPreferredSize()
        {
            return GetPreferredSize(new Size(0, 0));
        }

        public override Size GetPreferredSize(Size proposedSize)
        {
            // Provides extra space for proper padding for content
            int extra = 15;

            return new Size((int)Math.Max(130, Math.Max(textSize.Width + extra, infoSize.Width + extra)), 52);
        }
    }
}
