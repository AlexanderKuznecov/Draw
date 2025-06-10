using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Draw.src.Model
{
    public class CircleShape : ElipseShape
    {
        // Конструктор с правоъгълник
        public CircleShape(RectangleF rect) : base(MakeSquare(rect))
        {
        }

        // Конструктор по подразбиране (100x100)
        public CircleShape() : base(new RectangleF(0, 0, 100, 100))
        {
        }

        // Конструктор за копиране

        public CircleShape(CircleShape circle) : base(circle)
        {
        }

        // Създава копие на кръга
        public override Shape Clone()
        {
            return new CircleShape(this);
        }

        // Уверява се, че правоъгълникът е квадратен (за кръг)
        private static RectangleF MakeSquare(RectangleF rect)
        {
            float size = Math.Min(rect.Width, rect.Height);
            return new RectangleF(rect.X, rect.Y, size, size);
        }

        // Рисува кръга
        public override void DrawSelf(Graphics grfx)
        {
            GraphicsState state = grfx.Save();

            try
            {
                // Завъртане
                PointF center = GetCenter();
                grfx.TranslateTransform(center.X, center.Y);
                grfx.RotateTransform(RotationAngle);
                grfx.TranslateTransform(-center.X, -center.Y);

                // Правоъгълник за кръга (той вече е квадрат)
                RectangleF circleRect = new RectangleF(Location.X, Location.Y, Width, Height);

                // Запълване
                if (FillGradientType == GradientType.Linear)
                {
                    Color endColor = LightenColor(FillColor, 0.5f);
                    using (var brush = new LinearGradientBrush(circleRect, FillColor, endColor, LinearGradientMode.ForwardDiagonal))
                        grfx.FillEllipse(brush, circleRect);
                }
                else if (FillGradientType == GradientType.Radial)
                {
                    using (var path = new GraphicsPath())
                    {
                        path.AddEllipse(circleRect);
                        using (var brush = new PathGradientBrush(path))
                        {
                            brush.CenterColor = FillColor;
                            brush.SurroundColors = new Color[] { LightenColor(FillColor, 0.5f) };
                            grfx.FillEllipse(brush, circleRect);
                        }
                    }
                }
                else
                {
                    grfx.FillEllipse(new SolidBrush(FillColor), circleRect);
                }

                // Контур
                if (StrokeGradientType == GradientType.Linear)
                {
                    using (var brush = new LinearGradientBrush(circleRect, StrokeColor, LightenColor(StrokeColor, 0.5f), LinearGradientMode.ForwardDiagonal))
                    using (var pen = new Pen(brush, StrokeWidth))
                        grfx.DrawEllipse(pen, circleRect);
                }
                else if (StrokeGradientType == GradientType.Radial)
                {
                    using (var path = new GraphicsPath())
                    {
                        path.AddEllipse(circleRect);
                        using (var brush = new PathGradientBrush(path))
                        {
                            brush.CenterColor = StrokeColor;
                            brush.SurroundColors = new Color[] { LightenColor(StrokeColor, 0.5f) };
                            using (var pen = new Pen(brush, StrokeWidth))
                                grfx.DrawEllipse(pen, circleRect);
                        }
                    }
                }
                else
                {
                    grfx.DrawEllipse(new Pen(StrokeColor, StrokeWidth), circleRect);
                }
            }
            finally
            {
                grfx.Restore(state);
            }

        }


        // Осветлява цвета
        private Color LightenColor(Color color, float factor)
        {
            int r = Math.Min(255, color.R + (int)((255 - color.R) * factor));
            int g = Math.Min(255, color.G + (int)((255 - color.G) * factor));
            int b = Math.Min(255, color.B + (int)((255 - color.B) * factor));
            return Color.FromArgb(color.A, r, g, b);
        }
    }
}
