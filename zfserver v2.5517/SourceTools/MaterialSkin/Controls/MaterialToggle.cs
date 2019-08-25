using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using MaterialSkin.Animations;
using System.Linq;
using System.Collections.Generic;
namespace MaterialSkin.Controls
{
    using ControlRenderExtension;
    [DefaultEvent("CheckedChanged")]
    public class MaterialToggle : Panel, IMaterialControl
    {
        [Browsable(false)]
        public Bitmap Shadow { get; set; }
        [Browsable(false)]
        public GraphicsPath ShadowShape { get; set; }
        GraphicsPath RoundedRectangle;
        private int _Depth = 0; public int Depth { get { return _Depth; } set { if (_Depth != value) Shadow = null; _Depth = value; if (Parent != null) Parent.Invalidate(); } }
        [Browsable(false)]
        public MouseState MouseState { get; set; }
        [Browsable(false)]
        public Point MouseLocation { get; set; }

        public delegate void CheckedChangedEventHandler(object sender, EventArgs e);
        public event CheckedChangedEventHandler CheckedChanged;

        private string text;
        [Category("Appearance"), Browsable(true)]
        public override string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
            }
        }

        private readonly AnimationManager rippleAnimationManager;

        private bool ripple;
        [Category("Behavior")]
        public bool Ripple
        {
            get { return ripple; }
            set
            {
                ripple = value;
                AutoSize = AutoSize; //Make AutoSize directly set the bounds.

                if (value)
                {
                    Margin = new Padding(0);
                }

                Invalidate();
            }
        }

        private bool _checked = false;
        [Category("Behavior"), Browsable(true)]
        public bool Checked
        {
            get
            {
                return _checked;
            }
            set
            {
                if (value == _checked)
                {
                    _checked = value;
                }
                else
                {
                    _checked = value;
                    CheckedChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            Checked = !Checked;
        }

        private readonly AnimationManager animationManager;

        public MaterialToggle()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            animationManager = new AnimationManager(true)
            {
                AnimationType = AnimationType.EaseInOut,
                Increment = 0.05
            };
            animationManager.OnAnimationProgress += sender => Invalidate();
            rippleAnimationManager = new AnimationManager(false)
            {
                AnimationType = AnimationType.Linear,
                Increment = 0.05,
                SecondaryIncrement = 0.05
            };
            rippleAnimationManager.OnAnimationProgress += sender => Invalidate();
            CheckedChanged += (sender, args) =>
            {
                animationManager.StartNewAnimation(Checked ? AnimationDirection.In : AnimationDirection.Out);
            };
            Height = 40; Width = 67; DoubleBuffered = true;
            BackColor = Color.Transparent;
            Ripple = true;
        }

        protected override void OnResize(EventArgs e)
        {
            Height = 40; Width = 67;

            RoundedRectangle = new GraphicsPath();
            int radius = 10;

            RoundedRectangle.AddArc(21, Height / 2f - 5.5f, radius - 1, radius, 180, 90);
            RoundedRectangle.AddArc(Width - 31, Height / 2f - 5.5f, radius - 1, radius, -90, 90);
            RoundedRectangle.AddArc(Width - 31, Height / 2f - 5.5f, radius - 1, radius, 0, 90);
            RoundedRectangle.AddArc(21, Height / 2f - 5.5f, radius - 1, radius, 90, 90);

            RoundedRectangle.CloseAllFigures();
            Invalidate();

            Shadow = null;
        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            var G = pevent.Graphics;
            G.SmoothingMode = SmoothingMode.AntiAlias;

            Color bColor;
            if (Enabled)
            {
                if (animationManager.IsAnimating())
                {
                    if (Checked)
                    {
                        bColor = DrawHelper.BlendColor(MaterialSkinManager.GetCheckboxOffColor(), MaterialSkinManager.ColorScheme.AccentColor, animationManager.GetProgress() * 255);
                    }
                    else
                    {
                        bColor = DrawHelper.BlendColor(MaterialSkinManager.ColorScheme.AccentColor, MaterialSkinManager.GetCheckboxOffColor(), 255 - animationManager.GetProgress() * 255);
                    }
                }
                else
                {
                    if (Checked)
                    {
                        bColor = MaterialSkinManager.ColorScheme.AccentColor;
                    }
                    else
                    {
                        bColor = MaterialSkinManager.GetCheckboxOffColor();
                    }
                }
            }
            else
            {
                bColor = MaterialSkinManager.GetCheckBoxOffDisabledColor();
            }
            Color aColor;
            if (Enabled)
            {
                if (animationManager.IsAnimating())
                {
                    if (Checked)
                    {
                        aColor = DrawHelper.BlendColor(MaterialSkinManager.ColorScheme.LightPrimaryColor, MaterialSkinManager.ColorScheme.PrimaryColor, animationManager.GetProgress() * 255);
                    }
                    else
                    {
                        aColor = DrawHelper.BlendColor(MaterialSkinManager.ColorScheme.PrimaryColor, MaterialSkinManager.ColorScheme.LightPrimaryColor, 255 - animationManager.GetProgress() * 255);
                    }
                }
                else
                {
                    if (Checked)
                    {
                        aColor = MaterialSkinManager.ColorScheme.PrimaryColor;
                    }
                    else
                    {
                        aColor = MaterialSkinManager.ColorScheme.LightPrimaryColor;
                    }
                }
            }
            else
            {
                aColor = MaterialSkinManager.GetCheckBoxOffDisabledColor();
            }

            G.FillPath(new SolidBrush(Color.FromArgb(115, bColor)), RoundedRectangle);
            G.DrawPath(new Pen(Color.FromArgb(50, bColor)), RoundedRectangle);
            
            
            // draw ripple animation
            if (Ripple && rippleAnimationManager.IsAnimating())
            {
                for (int i = 0; i < rippleAnimationManager.GetAnimationCount(); i++)
                {
                    var animationValue = rippleAnimationManager.GetProgress(i);
                    int colorAlpha = Enabled ? (int)(animationValue * 255.0) : MaterialSkinManager.GetCheckBoxOffDisabledColor().A;
                    var brush = new SolidBrush(Color.FromArgb(colorAlpha, Enabled ? MaterialSkinManager.ColorScheme.AccentColor : MaterialSkinManager.GetCheckBoxOffDisabledColor()));
                    var animationSource = new Point((int)(23f + 20f * (float)animationManager.GetProgress()), Height / 2);
                    var rippleBrush = new SolidBrush(Color.FromArgb((int)((animationValue * 40)), ((bool)rippleAnimationManager.GetData(i)[0]) ? Color.Black : brush.Color));
                    var rippleHeight = (Height % 2 == 0) ? Height - 3 : Height - 2;
                    var rippleSize = (rippleAnimationManager.GetDirection(i) == AnimationDirection.InOutIn) ? (int)(rippleHeight * (0.8d + (0.2d * animationValue))) : rippleHeight;
                    using (var path = DrawHelper.CreateRoundRect(animationSource.X - rippleSize / 2, animationSource.Y - rippleSize / 2, rippleSize, rippleSize, rippleSize / 2))
                    {
                        G.FillPath(rippleBrush, path);
                    }

                    rippleBrush.Dispose();
                }
            }

            G.FillEllipse(new SolidBrush(aColor), 14f + 20f * (float)animationManager.GetProgress(), Height / 2 - 9, 18, 18);
            G.DrawEllipse(new Pen(aColor), 14f + 20f * (float)animationManager.GetProgress(), Height / 2 - 9, 18, 18);
            if (!DesignMode && Controls.Count>0) this.DrawChildShadow(G);
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            Font = MaterialSkinManager.ROBOTO_MEDIUM_10;

            if (DesignMode) return;

            MouseState = MouseState.OUT;
            MouseEnter += (sender, args) =>
            {
                MouseState = MouseState.HOVER;
            };
            MouseLeave += (sender, args) =>
            {
                MouseLocation = new Point(-1, -1);
                MouseState = MouseState.OUT;
            };
            MouseDown += (sender, args) =>
            {
                MouseState = MouseState.DOWN;

                if (Ripple && args.Button == MouseButtons.Left)
                {
                    rippleAnimationManager.SecondaryIncrement = 0;
                    rippleAnimationManager.StartNewAnimation(AnimationDirection.InOutIn, new object[] { Checked });
                }
            };
            MouseUp += (sender, args) =>
            {
                MouseState = MouseState.HOVER;
                rippleAnimationManager.SecondaryIncrement = 0.08;
            };
            MouseMove += (sender, args) =>
            {
                MouseLocation = args.Location;
            };
        }
    }
}
