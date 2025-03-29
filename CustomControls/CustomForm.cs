using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherSphereV4.CustomControls
{
    public partial class CustomForm : Form
    {
        //Fields
        private int borderRadius = 30;
        private Color borderColor = Color.PaleVioletRed;

        //Properties
        [Category("Special Properties")]
        public int BorderRadius
        {
            get { return borderRadius; }
            set
            {
                borderRadius = value;
                Invalidate();
            }
        }

        [Category("Special Properties")]
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                Invalidate();
            }
        }

        //Constructor
        public CustomForm()
        {
            FormBorderStyle = FormBorderStyle.None;
            DoubleBuffered = true;
        }

        //Methods
        private GraphicsPath GetFigurePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Rectangle rectSurface = ClientRectangle;
            Rectangle rectBorder = Rectangle.Inflate(rectSurface, -1, -1);

            if (borderRadius > 2) //Rounded form
            {
                using (GraphicsPath pathSurface = GetFigurePath(rectSurface, borderRadius))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - 1))
                using (Pen penBorder = new Pen(borderColor, 1))
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    //Form surface
                    Region = new Region(pathSurface);
                    //Draw border
                    e.Graphics.DrawPath(penBorder, pathBorder);
                }
            }
            else //Normal form
            {
                e.Graphics.SmoothingMode = SmoothingMode.None;
                //Form surface
                Region = new Region(rectSurface);
                //Form border
                using (Pen penBorder = new Pen(borderColor, 1))
                {
                    penBorder.Alignment = PenAlignment.Inset;
                    e.Graphics.DrawRectangle(penBorder, 0, 0, Width - 1, Height - 1);
                }
            }
        }
    }
}
