using System.Drawing.Drawing2D;
using System.Drawing;
using System;

namespace Draw.src.Model
{
    // Клас за овална форма
    public class ElipseShape : Shape
    {
        // Конструктор с правоъгълник
        public ElipseShape(RectangleF rect) : base(rect)
        {
        }

        // Конструктор по подразбиране (100x100)
        public ElipseShape() : this(new Rectangle(0, 0, 100, 100))
        {
        }

        // Конструктор за копиране
        public ElipseShape(ElipseShape elipse) : base(elipse)
        {
        }

        // Създава копие на овала
        public override Shape Clone()
        {
            return new ElipseShape(this);
        }

        // Проверява дали точка е в овала
        public override bool Contains(PointF point)
        {
            return base.Contains(point);
        }

        // Рисува овала
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