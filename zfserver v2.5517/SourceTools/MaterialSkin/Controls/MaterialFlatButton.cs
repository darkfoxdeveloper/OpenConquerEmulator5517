using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using MaterialSkin.Animations;
using System.Collections.Generic;
using System.Linq;
using MaterialSkin;

namespace MaterialSkin.Controls
{
    using ControlRenderExtension;
    [DefaultEvent("Click")]
    public class MaterialFlatButton : Panel, IMaterialControl
    {
        [Browsable(false)]
        public Bitmap Shadow { get; set; }
        [Browsable(false)]
        public GraphicsPath ShadowShape { get; set; }
        private int _Depth = 0; public int Depth{ get{return _Depth;}set{if (_Depth!=value) Shadow = null;_Depth=value;if (Parent != null) Parent.Invalidate();}}
        [Browsable(false)]
        public MouseState MouseState { get; set; }
        public bool Primary { get; set; }

        public delegate void ClickAnimationFinishedEventHandler(object sender);
        public event ClickAnimationFinishedEventHandler ClickAnimationFinished;

        private readonly AnimationManager animationManager;
        private readonly AnimationManager hoverAnimationManager;

        private int _fSize = 9;
        [Category("Appearance")]
        public int FontSize
        {
            get
            {
                return _fSize;
            }
            set
            {
                _fSize = value;
                Font = new Font(MaterialSkinManager.ROBOTO_REGULAR_11.FontFamily, _fSize);
            }
        }

        private SizeF textSize;

        private Image _icon;
        public Image Icon
        {
            get { return _icon; }
            set
            {
                _icon = value;
                if (AutoSize)
                    Size = GetPreferredSize();
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

        public MaterialFlatButton()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            Primary = false;
            animationManager = new AnimationManager(false)
            {
                Increment = 0.03,
                AnimationType = AnimationType.EaseOut
            };
            hoverAnimationManager = new AnimationManager
            {
                Increment = 0.07,
                AnimationType = AnimationType.Linear
            };

            hoverAnimationManager.OnAnimationProgress += sender => Invalidate();
            animationManager.OnAnimationProgress += sender => Invalidate();
            animationManager.OnAnimationFinished += AnimationManager_OnAnimationFinished;

            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            AutoSize = false;
            Margin = new Padding(4, 6, 4, 6);
            Padding = new Padding(0);
            Font = new Font(MaterialSkinManager.ROBOTO_REGULAR_11.FontFamily, _fSize);
        }

        private void AnimationManager_OnAnimationFinished(object sender)
        {
            AnimationManager AM = (AnimationManager)sender;
            if (AM.GetAnimationCount() == 1)
            {
                ClickAnimationFinished?.Invoke(this);
            }
        }

        [Browsable(true)]
        public override string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value;
                textSize = CreateGraphics().MeasureString(value.ToUpper(), Font);
                if (AutoSize)
                    Size = GetPreferredSize();
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            var g = pevent.Graphics;
            g.TextRenderingHint = TextRenderingHint.AntiAlias;

            GraphicsPath bgGP = DrawHelper.CreateRoundRect(ClientRectangle.X,
                ClientRectangle.Y,
                ClientRectangle.Width - 1,
                ClientRectangle.Height - 1,
                _roundedCorner);

            //Hover
            Color c = MaterialSkinManager.GetFlatButtonHoverBackgroundColor();
            using (Brush b = new SolidBrush(Color.FromArgb((int)(hoverAnimationManager.GetProgress() * c.A), c.RemoveAlpha())))
                g.FillPath(b, bgGP);

            //Ripple
            if (animationManager.IsAnimating())
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                for (int i = 0; i < animationManager.GetAnimationCount(); i++)
                {
                    var animationValue = animationManager.GetProgress(i);
                    var animationSource = animationManager.GetSource(i);

                    using (Brush rippleBrush = new SolidBrush(Color.FromArgb((int)(101 - (animationValue * 100)), Color.Black)))
                    {
                        var rippleSize = (int)(animationValue * Width * 2);
                        g.FillEllipse(rippleBrush, new Rectangle(animationSource.X - rippleSize / 2, animationSource.Y - rippleSize / 2, rippleSize, rippleSize));
                    }
                }
                g.SmoothingMode = SmoothingMode.None;
            }
            //Text
            Rectangle textRect = ClientRectangle;

            //Icon
            if (Icon != null)
            {
                Rectangle iconRect = new Rectangle(8, textRect.Height / 2 - 12, 24, 24);

                if (String.IsNullOrEmpty(Text))
                    // Center Icon
                    iconRect.X = textRect.Width / 2 - 12;

                g.DrawImage(Icon, iconRect);
            }

            if (Icon != null)
            {
                //
                // Resize and move Text container
                //

                // First 8: left padding
                // 24: icon width
                // Second 4: space between Icon and Text
                // Third 8: right padding
                textRect.Width -= 8 + 24 + 4 + 8;

                // First 8: left padding
                // 24: icon width
                // Second 4: space between Icon and Text
                textRect.X += 8 + 24 + 4;
            }

            g.DrawString(
                Text.ToUpper(),
                Font,
                Enabled ? (Primary ? MaterialSkinManager.ColorScheme.PrimaryBrush : MaterialSkinManager.GetPrimaryTextBrush()) : MaterialSkinManager.GetFlatButtonDisabledTextBrush(),
                textRect,
                new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center }
                );
            if (!DesignMode && Controls.Count>0) this.DrawChildShadow(g);
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

        private Size GetPreferredSize()
        {
            return GetPreferredSize(new Size(0, 0));
        }

        public override Size GetPreferredSize(Size proposedSize)
        {
            // Provides extra space for proper padding for content
            int extra = 16;

            if (Icon != null)
                // 24 is for icon size
                // 4 is for the space between icon & text
                extra += 24 + 4;

            return new Size((int)Math.Ceiling(textSize.Width) + extra, 36);
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            if (DesignMode) return;
            MouseState = MouseState.OUT;
            MouseEnter += (sender, args) =>
            {
                MouseState = MouseState.HOVER;
                hoverAnimationManager.StartNewAnimation(AnimationDirection.In);
                Invalidate();
            };
            MouseLeave += (sender, args) =>
            {
                MouseState = MouseState.OUT;
                hoverAnimationManager.StartNewAnimation(AnimationDirection.Out);
                Invalidate();
            };
            MouseDown += (sender, args) =>
            {
                if (args.Button == MouseButtons.Left)
                {
                    MouseState = MouseState.DOWN;

                    animationManager.StartNewAnimation(AnimationDirection.In, args.Location);
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
