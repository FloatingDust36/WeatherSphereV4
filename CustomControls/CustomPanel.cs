using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace WeatherSphereV4.CustomControls
{
    public class CustomPanel : Panel
    {
        //Fields
        private int borderSize = 0;
        private int borderRadius = 0;
        private Color borderColor = Color.PaleVioletRed;
        private Color color1 = Color.MediumSlateBlue;
        private Color color2 = Color.MediumSlateBlue;
        private LinearGradientMode colorOrientation = LinearGradientMode.Horizontal;
        private Image backgroundImage;
        private ImageLayout backgroundImageLayout = ImageLayout.Tile;

        //Properties
        [Category("Special Properties")]
        public int BorderSize
        {
            get { return borderSize; }
            set
            {
                borderSize = value;
                Invalidate();
            }
        }

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

        [Category("Special Properties")]
        public Color Color1
        {
            get { return color1; }
            set
            {
                color1 = value;
                Invalidate();
            }
        }

        [Category("Special Properties")]
        public Color Color2
        {
            get { return color2; }
            set
            {
                color2 = value;
                Invalidate();
            }
        }

        [Category("Special Properties")]
        public LinearGradientMode ColorOrientation
        {
            get { return colorOrientation; }
            set
            {
                colorOrientation = value;
                Invalidate();
            }
        }

        [Category("Special Properties")]
        public new Image BackgroundImage
        {
            get { return backgroundImage; }
            set
            {
                backgroundImage = value;
                Invalidate();
            }
        }

        [Category("Special Properties")]
        public new ImageLayout BackgroundImageLayout
        {
            get { return backgroundImageLayout; }
            set
            {
                backgroundImageLayout = value;
                Invalidate();
            }
        }

        //Constructor
        public CustomPanel()
        {
            Size = new Size(200, 100);
            BackColor = Color.MediumSlateBlue;
            Resize += new EventHandler(Panel_Resize);
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
            Rectangle rectBorder = Rectangle.Inflate(rectSurface, -borderSize, -borderSize);
            int smoothSize = 2;
            if (borderSize > 0)
                smoothSize = borderSize;

            using (LinearGradientBrush brush = new LinearGradientBrush(rectSurface, color1, color2, colorOrientation))
            {
                e.Graphics.FillRectangle(brush, rectSurface);
            }

            if (backgroundImage != null)
            {
                switch (backgroundImageLayout)
                {
                    case ImageLayout.Tile:
                        using (TextureBrush textureBrush = new TextureBrush(backgroundImage))
                        {
                            e.Graphics.FillRectangle(textureBrush, rectSurface);
                        }
                        break;
                    case ImageLayout.Center:
                        Point centerPoint = new Point((Width - backgroundImage.Width) / 2, (Height - backgroundImage.Height) / 2);
                        e.Graphics.DrawImage(backgroundImage, centerPoint);
                        break;
                    case ImageLayout.Stretch:
                        e.Graphics.DrawImage(backgroundImage, rectSurface);
                        break;
                    case ImageLayout.Zoom:
                        Size imageSize = backgroundImage.Size;
                        float ratio = Math.Min((float)Width / imageSize.Width, (float)Height / imageSize.Height);
                        Size newSize = new Size((int)(imageSize.Width * ratio), (int)(imageSize.Height * ratio));
                        Point newPoint = new Point((Width - newSize.Width) / 2, (Height - newSize.Height) / 2);
                        e.Graphics.DrawImage(backgroundImage, new Rectangle(newPoint, newSize));
                        break;
                    default:
                        e.Graphics.DrawImage(backgroundImage, rectSurface);
                        break;
                }
            }

            if (borderRadius > 2) //Rounded panel
            {
                using (GraphicsPath pathSurface = GetFigurePath(rectSurface, borderRadius))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - borderSize))
                using (Pen penSurface = new Pen(Parent.BackColor, smoothSize))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    //Panel surface
                    Region = new Region(pathSurface);
                    //Draw surface border for HD result
                    e.Graphics.DrawPath(penSurface, pathSurface);

                    //Panel border                    
                    if (borderSize >= 1)
                        //Draw control border
                        e.Graphics.DrawPath(penBorder, pathBorder);
                }
            }
            else //Normal panel
            {
                e.Graphics.SmoothingMode = SmoothingMode.None;
                //Panel surface
                Region = new Region(rectSurface);
                //Panel border
                if (borderSize >= 1)
                {
                    using (Pen penBorder = new Pen(borderColor, borderSize))
                    {
                        penBorder.Alignment = PenAlignment.Inset;
                        e.Graphics.DrawRectangle(penBorder, 0, 0, Width - 1, Height - 1);
                    }
                }
            }
        }

        private void Panel_Resize(object sender, EventArgs e)
        {
            if (borderRadius > Height)
                borderRadius = Height;
        }
    }
}
