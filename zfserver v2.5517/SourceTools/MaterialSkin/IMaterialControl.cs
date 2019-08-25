using System.Drawing;
using System.Drawing.Drawing2D;

namespace MaterialSkin
{
    public interface IMaterialControl
    {
        int Depth { get; set; }
        MouseState MouseState { get; set; }
        Bitmap Shadow { get; set; }
        GraphicsPath ShadowShape { get; set; }
    }

    public enum MouseState
    {
        HOVER,
        DOWN,
        OUT
    }
}
