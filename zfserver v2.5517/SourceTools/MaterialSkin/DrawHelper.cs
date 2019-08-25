using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MaterialSkin
{
    namespace ControlRenderExtension
    {
        public static class ControlHelper
        {
            #region Redraw Suspend/Resume
            [DllImport("user32.dll", EntryPoint = "SendMessageA", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            private static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
            private const int WM_SETREDRAW = 0xB;

            public static void SuspendDrawing(this Control target)
            {
                SendMessage(target.Handle, WM_SETREDRAW, 0, 0);
            }

            public static void ResumeDrawing(this Control target) { ResumeDrawing(target, true); }
            public static void ResumeDrawing(this Control target, bool redraw)
            {
                SendMessage(target.Handle, WM_SETREDRAW, 1, 0);

                if (redraw)
                {
                    target.Refresh();
                }
            }
            #endregion
        }

        public static class ShadowHelper
        {
            public static void DrawChildShadow(this IMaterialControl target, Graphics g)
            {
                if (!MaterialSkinManager.SoftShadow) return;
                Control panel = (Control)target;
                foreach (IMaterialControl p in panel.Controls.OfType<IMaterialControl>())
                {
                    Control p2 = (Control)p;
                    if (p2.Visible != false && p.Depth != 0)
                    {
                        if (p.Shadow == null)
                        {
                            Bitmap sBMP = new Bitmap(p2.Width + p.Depth * 18, p2.Height + p.Depth * 18);
                            Graphics sg = Graphics.FromImage(sBMP);
                            Color shadow = Color.FromArgb(MaterialSkinManager.SHADOW_COLOR.A - p.Depth, MaterialSkinManager.SHADOW_COLOR);
                            Color softShadow = Color.FromArgb(Math.Max(10, MaterialSkinManager.SOFT_SHADOW_COLOR.A - p.Depth * 3 / 2), MaterialSkinManager.SOFT_SHADOW_COLOR);
                            //if (p.ShadowShape != null)
                            //{//NOT IMPLEMENTED
                            //    PointF midPt = new Point(p2.Left + p2.Width / 2, p2.Top + p2.Height / 2);
                            //    GraphicsPath gp = (GraphicsPath)p.ShadowShape.Clone();
                            //    gp.ScaleAroundPivot(1.5f, 1.5f, midPt.X, midPt.Y);
                            //    sg.FillPath(new SolidBrush(softShadow), gp);
                            //    GraphicsPath gp2 = (GraphicsPath)p.ShadowShape.Clone();
                            //    gp2.ScaleAroundPivot(1.5f, 1.5f, midPt.X, midPt.Y);
                            //    sg.FillPath(new SolidBrush(shadow), gp2);
                            //}
                            //else
                            //{
                            sg.FillRectangle(new SolidBrush(softShadow), p.Depth * 9 - p.Depth * 3 / 2, p.Depth * 9 - p.Depth * 3 / 2, p2.Width + p.Depth * 3, p2.Height + p.Depth * 3);
                            sg.FillRectangle(new SolidBrush(shadow), p.Depth * 9 + p.Depth * 3 / 8 + 4, p.Depth * 9 + p.Depth / 2 + 5, p2.Width - p.Depth * 3 / 4 - 8, p2.Height + p.Depth / 2 - 7);
                            //}
                            sg.Flush(FlushIntention.Sync);
                            GaussianBlur gb = new GaussianBlur(sBMP);
                            p.Shadow = gb.Process(p.Depth + 1);
                        }
                        g.DrawImage(p.Shadow, p2.Left - p.Depth * 9, p2.Top - p.Depth * 9);
                    }
                }
            }

            public static void DrawChildShadow_GP(this IMaterialControl target, Graphics g)
            {
                if (!MaterialSkinManager.SoftShadow) return;
                Control panel = (Control)target;
                foreach (IMaterialControl p in panel.Controls.OfType<IMaterialControl>())
                {
                    Control p2 = (Control)p;
                    if (p2.Visible != false && p.Depth!=0)
                    {
                        if (p.Shadow == null) {
                            Bitmap sBMP = new Bitmap(p2.Width + p.Depth * 18, p2.Height + p.Depth * 18);
                            Graphics sg = Graphics.FromImage(sBMP);
                            Color shadow = Color.FromArgb(MaterialSkinManager.SHADOW_COLOR.A - p.Depth , MaterialSkinManager.SHADOW_COLOR);
                            Color softShadow = Color.FromArgb(Math.Max(10, MaterialSkinManager.SOFT_SHADOW_COLOR.A - p.Depth * 3 / 2), MaterialSkinManager.SOFT_SHADOW_COLOR);
                            if (p.ShadowShape != null)
                            {//NOT IMPLEMENTED
                                PointF midPt = new Point(p2.Left + p2.Width / 2, p2.Top + p2.Height / 2);
                                GraphicsPath gp = (GraphicsPath)p.ShadowShape.Clone();
                                gp.ScaleAroundPivot((p2.Width + p.Depth * 3) / p2.Width, (p2.Height + p.Depth * 3) / p2.Height, midPt.X, midPt.Y);
                                gp.Translate(-p2.ClientRectangle.Left + p.Depth * 9, -p2.ClientRectangle.Top + p.Depth * 9);
                                sg.FillPath(new SolidBrush(softShadow), gp);
                            }
                            else
                            {
                                sg.FillRectangle(new SolidBrush(softShadow), p.Depth * 9 - p.Depth * 3 / 2, p.Depth * 9 - p.Depth * 3 / 2, p2.Width + p.Depth * 3, p2.Height + p.Depth * 3);
                                sg.FillRectangle(new SolidBrush(shadow), p.Depth * 9 + p.Depth * 3 / 8 + 4, p.Depth * 9 + p.Depth / 2 + 5, p2.Width - p.Depth * 3 / 4 - 8, p2.Height + p.Depth / 2 - 7);
                            }
                            sg.Flush(FlushIntention.Sync);
                            GaussianBlur gb = new GaussianBlur(sBMP);
                            p.Shadow = gb.Process(p.Depth + 1);
                        }
                        g.DrawImage(p.Shadow, p2.Left - p.Depth * 9, p2.Top - p.Depth * 9);
                    }
                }
            }

            private static void Translate(this GraphicsPath gp, float x, float y)
            {
                Matrix m = new Matrix();
                m.Translate(x, y, MatrixOrder.Append);
                gp.Transform(m);
            }
            
            private static void ScaleAroundPivot(this GraphicsPath gp, 
                float scalex, float scaley, float px, float py)
            {
                Matrix m = new Matrix();
                m.Translate(-px, -py, MatrixOrder.Append);
                m.Scale(scalex, scaley, MatrixOrder.Append);
                m.Translate(px, py, MatrixOrder.Append);
                gp.Transform(m);
            }
        }
    }

    static class DrawHelper
    {
        public static GraphicsPath CreateRoundRect(float x, float y, float width, float height, float radius)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddLine(x + radius, y, x + width - (radius * 2), y);
            gp.AddArc(x + width - (radius * 2), y, radius * 2, radius * 2, 270, 90);
            gp.AddLine(x + width, y + radius, x + width, y + height - (radius * 2));
            gp.AddArc(x + width - (radius * 2), y + height - (radius * 2), radius * 2, radius * 2, 0, 90);
            gp.AddLine(x + width - (radius * 2), y + height, x + radius, y + height);
            gp.AddArc(x, y + height - (radius * 2), radius * 2, radius * 2, 90, 90);
            gp.AddLine(x, y + height - (radius * 2), x, y + radius);
            gp.AddArc(x, y, radius * 2, radius * 2, 180, 90);
            gp.CloseFigure();
            return gp;
        }

        public static GraphicsPath CreateUpRoundRect(float x, float y, float width, float height, float radius)
        {
            GraphicsPath gp = new GraphicsPath();

            gp.AddLine(x + radius, y, x + width - (radius * 2), y);
            gp.AddArc(x + width - (radius * 2), y, radius * 2, radius * 2, 270, 90);

            gp.AddLine(x + width, y + radius, x + width, y + height - (radius * 2) + 1);
            gp.AddArc(x + width - (radius * 2), y + height - (radius * 2), radius * 2, 2, 0, 90);

            gp.AddLine(x + width, y + height, x + radius, y + height);
            gp.AddArc(x, y + height - (radius * 2) + 1, radius * 2, 1, 90, 90);

            gp.AddLine(x, y + height, x, y + radius);
            gp.AddArc(x, y, radius * 2, radius * 2, 180, 90);

            gp.CloseFigure();
            return gp;
        }

        public static GraphicsPath CreateLeftRoundRect(float x, float y, float width, float height, float radius)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddLine(x + radius, y, x + width - (radius * 2), y);
            gp.AddArc(x + width - (radius * 2), y, radius * 2, radius * 2, 270, 90);

            gp.AddLine(x + width, y + 0, x + width, y + height);
            gp.AddArc(x + width - (radius * 2), y + height - (1), radius * 2, 1, 0, 90);

            gp.AddLine(x + width - (radius * 2), y + height, x + radius, y + height);
            gp.AddArc(x, y + height - (radius * 2), radius * 2, radius * 2, 90, 90);

            gp.AddLine(x, y + height - (radius * 2), x, y + radius);
            gp.AddArc(x, y, radius * 2, radius * 2, 180, 90);

            gp.CloseFigure();
            return gp;
        }

        public static GraphicsPath CreateRoundRect(Rectangle rect, float radius)
        {
            return CreateRoundRect(rect.X, rect.Y, rect.Width, rect.Height, radius);
        }

        public static Color BlendColor(Color backgroundColor, Color frontColor, double blend)
        {
            double ratio = blend / 255d;
            double invRatio = 1d - ratio;
            int a = (int)((backgroundColor.A * invRatio) + (frontColor.A * ratio));
            int r = (int)((backgroundColor.R * invRatio) + (frontColor.R * ratio));
            int g = (int)((backgroundColor.G * invRatio) + (frontColor.G * ratio));
            int b = (int)((backgroundColor.B * invRatio) + (frontColor.B * ratio));
            return Color.FromArgb(a, r, g, b);
        }

        public static Color BlendColor(Color backgroundColor, Color frontColor)
        {
            return BlendColor(backgroundColor, frontColor, frontColor.A);
        }
    }
}
