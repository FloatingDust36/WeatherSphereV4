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
    public class CustomButton : Button
    {
        //Fields
        private int borderSize = 0;
        private int borderRadius = 0;
        private Color borderColor = Color.PaleVioletRed;
        private Color color1 = Color.MediumSlateBlue;
        private Color color2 = Color.MediumSlateBlue;
        private LinearGradientMode colorOrientation = LinearGradientMode.Horizontal;

        private Color originalColor1;
        private Color originalColor2;

        private bool isHovered = false;
        private bool isRipple = false;
        private int rippleSize = 0;
        private Point rippleLocation;
        private System.Windows.Forms.Timer rippleTimer;

        private Color shadowColor = Color.Gray;
        private int shadowSize = 5;
        private Color glowColor = Color.FromArgb(128, Color.White);
        private int glowSize = 10;

        private bool isPressed = false;
        private int originalWidth;
        private int originalHeight;

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
        public Color ShadowColor
        {
            get { return shadowColor; }
            set
            {
                shadowColor = value;
                Invalidate();
            }
        }

        [Category("Special Properties")]
        public int ShadowSize
        {
            get { return shadowSize; }
            set
            {
                shadowSize = value;
                Invalidate();
            }
        }

        [Category("Special Properties")]
        public Color GlowColor
        {
            get { return glowColor; }
            set
            {
                glowColor = value;
                Invalidate();
            }
        }

        [Category("Special Properties")]
        public int GlowSize
        {
            get { return glowSize; }
            set
            {
                glowSize = value;
                Invalidate();
            }
        }

        //Constructor
        public CustomButton()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            Size = new Size(150, 40);
            BackColor = Color.MediumSlateBlue;
            ForeColor = Color.White;
            Resize += new EventHandler(Button_Resize);

            rippleTimer = new System.Windows.Forms.Timer();
            rippleTimer.Interval = 15; // Adjust the interval for ripple speed
            rippleTimer.Tick += new EventHandler(RippleTimer_Tick);
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

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            Rectangle rectSurface = ClientRectangle;
            Rectangle rectBorder = Rectangle.Inflate(rectSurface, -borderSize, -borderSize);
            int smoothSize = 2;
            if (borderSize > 0)
                smoothSize = borderSize;

            // Draw shadow
            if (shadowSize > 0)
            {
                Rectangle shadowRect = new Rectangle(rectSurface.X + shadowSize, rectSurface.Y + shadowSize, rectSurface.Width - shadowSize, rectSurface.Height - shadowSize);
                using (GraphicsPath shadowPath = GetFigurePath(shadowRect, borderRadius))
                using (PathGradientBrush shadowBrush = new PathGradientBrush(shadowPath))
                {
                    shadowBrush.CenterColor = shadowColor;
                    shadowBrush.SurroundColors = new Color[] { Color.Transparent };
                    pevent.Graphics.FillPath(shadowBrush, shadowPath);
                }
            }

            // Draw glow
            if (isHovered && glowSize > 0)
            {
                Rectangle glowRect = new Rectangle(rectSurface.X - glowSize / 2, rectSurface.Y - glowSize / 2, rectSurface.Width + glowSize, rectSurface.Height + glowSize);
                using (GraphicsPath glowPath = GetFigurePath(glowRect, borderRadius + glowSize / 2))
                using (PathGradientBrush glowBrush = new PathGradientBrush(glowPath))
                {
                    glowBrush.CenterColor = glowColor;
                    glowBrush.SurroundColors = new Color[] { Color.Transparent };
                    pevent.Graphics.FillPath(glowBrush, glowPath);
                }
            }

            using (LinearGradientBrush brush = new LinearGradientBrush(rectSurface, color1, color2, colorOrientation))
            {
                pevent.Graphics.FillRectangle(brush, rectSurface);
            }

            if (borderRadius > 2) //Rounded button
            {
                using (GraphicsPath pathSurface = GetFigurePath(rectSurface, borderRadius))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - borderSize))
                using (Pen penSurface = new Pen(Parent.BackColor, smoothSize))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    //Button surface
                    Region = new Region(pathSurface);
                    //Draw surface border for HD result
                    pevent.Graphics.DrawPath(penSurface, pathSurface);

                    //Button border                    
                    if (borderSize >= 1)
                        //Draw control border
                        pevent.Graphics.DrawPath(penBorder, pathBorder);
                }
            }
            else //Normal button
            {
                pevent.Graphics.SmoothingMode = SmoothingMode.None;
                //Button surface
                Region = new Region(rectSurface);
                //Button border
                if (borderSize >= 1)
                {
                    using (Pen penBorder = new Pen(borderColor, borderSize))
                    {
                        penBorder.Alignment = PenAlignment.Inset;
                        pevent.Graphics.DrawRectangle(penBorder, 0, 0, Width - 1, Height - 1);
                    }
                }
            }

            // Draw the text
            TextRenderer.DrawText(pevent.Graphics, Text, Font, rectSurface, ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

            // Draw ripple effect
            if (isRipple && rippleSize > 0)
            {
                using (GraphicsPath ripplePath = new GraphicsPath())
                {
                    ripplePath.AddEllipse(rippleLocation.X - rippleSize / 2, rippleLocation.Y - rippleSize / 2, rippleSize, rippleSize);
                    using (PathGradientBrush rippleBrush = new PathGradientBrush(ripplePath))
                    {
                        rippleBrush.CenterColor = Color.FromArgb(50, Color.White);
                        rippleBrush.SurroundColors = new Color[] { Color.FromArgb(0, Color.White) };
                        rippleBrush.FocusScales = new PointF(0.2f, 0.2f); // Adjust the focus scale for a more dynamic effect
                        pevent.Graphics.FillPath(rippleBrush, ripplePath);
                    }
                }
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);
        }

        private void Container_BackColorChanged(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Button_Resize(object sender, EventArgs e)
        {
            if (borderRadius > Height)
                borderRadius = Height;
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            originalColor1 = color1;
            originalColor2 = color2;
            color1 = ControlPaint.Dark(color1);
            color2 = ControlPaint.Dark(color2);
            rippleLocation = mevent.Location;
            rippleSize = 0;
            isRipple = true;
            isPressed = true;
            originalWidth = Width;
            originalHeight = Height;
            Width -= 2;
            Height -= 2;
            rippleTimer.Start();
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            color1 = originalColor1;
            color2 = originalColor2;
            isRipple = false;
            isPressed = false;
            Width = originalWidth;
            Height = originalHeight;
            rippleTimer.Stop();
            Invalidate();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            isHovered = true;

            // Interchange Color1 and Color2
            var tempColor = color1;
            color1 = color2;
            color2 = tempColor;

            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            isHovered = false;

            // Revert Color1 and Color2
            var tempColor = color1;
            color1 = color2;
            color2 = tempColor;

            Invalidate();
        }

        private void RippleTimer_Tick(object sender, EventArgs e)
        {
            rippleSize += 15; // Adjust the increment for ripple size
            if (rippleSize > Width * 2)
            {
                isRipple = false;
                rippleTimer.Stop();
            }
            Invalidate();
        }
    }
}