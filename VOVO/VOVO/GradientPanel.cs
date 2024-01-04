using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace VOVO
{
    public class GradientPanel : Panel
    {
        public Color[] Colors { get; set; }
        public float Angle { get; set; }
        public int CornerRadius { get; set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (Colors != null)
            {
                using (GraphicsPath path = RoundedRectangle.Create(this.ClientRectangle, CornerRadius))
                {
                    LinearGradientBrush brush = new LinearGradientBrush(path.GetBounds(), Colors[0], Colors[Colors.Length - 1], this.Angle);
                    ColorBlend colorBlend = new ColorBlend();
                    colorBlend.Colors = Colors;
                    colorBlend.Positions = new float[Colors.Length];
                    for (int i = 0; i < Colors.Length; i++)
                    {
                        colorBlend.Positions[i] = (float)i / (Colors.Length - 1);
                    }
                    brush.InterpolationColors = colorBlend;

                    e.Graphics.FillPath(brush, path);
                }
            }
        }
    }

    public class RoundedRectangle
    {
        public static GraphicsPath Create(Rectangle bounds, int radius)
        {
            GraphicsPath path = new GraphicsPath();

            path.AddArc(bounds.X, bounds.Y, radius * 2, radius * 2, 180, 90);
            path.AddArc(bounds.X + bounds.Width - radius * 2, bounds.Y, radius * 2, radius * 2, 270, 90);
            path.AddArc(bounds.X + bounds.Width - radius * 2, bounds.Y + bounds.Height - radius * 2, radius * 2, radius * 2, 0, 90);
            path.AddArc(bounds.X, bounds.Y + bounds.Height - radius * 2, radius * 2, radius * 2, 90, 90);

            path.CloseFigure();
            return path;
        }
    }
}
