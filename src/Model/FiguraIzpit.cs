using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.src.Model
{
    public class FiguraIzpit : Shape
    {
        public FiguraIzpit() : this(new Rectangle(0, 0, 100, 100)) { }

        public FiguraIzpit(RectangleF rect) : base(rect) { }

        public FiguraIzpit(FiguraIzpit shape) : base(shape) { }

        public override bool Contains(PointF point)
        {
            return base.Contains(point);
        }

        public override Shape Clone()
        {
            return new FiguraIzpit(this);
        }

        public override void DrawSelf(Graphics grfx)
        {
            GraphicsState state = grfx.Save();

            try
            {
                PointF center = GetCenter();
                grfx.TranslateTransform(center.X, center.Y);
                grfx.RotateTransform(RotationAngle);
                grfx.TranslateTransform(-center.X, -center.Y);

                
                float x = Rectangle.X;
                float y = Rectangle.Y;
                float w = Rectangle.Width;
                float h = Rectangle.Height;

                PointF topLeft = new PointF(x, y);
                PointF topRight = new PointF(x + w, y);
                PointF bottomLeft = new PointF(x, y + h);
                PointF bottomRight = new PointF(x + w, y + h);
                PointF middleLeft = new PointF(x, y + h / 2);
                PointF centerPoint = new PointF(x + w / 2, y + h / 2);

                using (Brush brush = new SolidBrush(FillColor))
                using (Pen pen = new Pen(StrokeColor, StrokeWidth))
                {
                    
                    PointF[] triangle1 = { topLeft, topRight, centerPoint };
                    PointF[] triangle2 = { bottomLeft, bottomRight, centerPoint };
                    PointF[] triangle3 = { middleLeft, topLeft, centerPoint };

                    grfx.FillPolygon(brush, triangle1);
                    grfx.FillPolygon(brush, triangle2);
                    grfx.FillPolygon(brush, triangle3);

                    
                    grfx.DrawRectangle(pen, x, y, w, h);
                    grfx.DrawLine(pen, topRight, centerPoint);
                    grfx.DrawLine(pen, bottomRight, centerPoint);
                    grfx.DrawLine(pen, middleLeft, centerPoint);
                }
            }
            finally
            {
                grfx.Restore(state);
            }
        }


    }
}
