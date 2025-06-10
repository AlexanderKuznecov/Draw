using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Draw
{
    /// <summary>
    /// Клас за правоъгълник, наследяващ базовия Shape
    /// </summary>
    public class RectangleShape : Shape
    {
        #region Конструктори

        // Конструктор по подразбиране (100x100)
        public RectangleShape() : this(new Rectangle(0, 0, 100, 100))
        {
        }

        // Конструктор с зададен правоъгълник
        public RectangleShape(RectangleF rect) : base(rect)
        {
        }

        // Конструктор за копиране
        public RectangleShape(RectangleShape rectangle) : base(rectangle)
        {
        }

        #endregion

        #region Основни методи

        // Проверява дали точка е вътре в правоъгълника
        public override bool Contains(PointF point)
        {
            return base.Contains(point);
        }

        // Рисува правоъгълника
        public override void DrawSelf(Graphics grfx)
        {
            // Запазва текущото състояние
            GraphicsState state = grfx.Save();

            try
            {
                // Прилага завъртане
                PointF center = GetCenter();
                grfx.TranslateTransform(center.X, center.Y);
                grfx.RotateTransform(RotationAngle);
                grfx.TranslateTransform(-center.X, -center.Y);

                // Рисува запълването
                DrawFill(grfx);

                // Рисува контура
                DrawStroke(grfx);
            }
            finally
            {
                // Възстановява оригиналното състояние
                grfx.Restore(state);
            }
        }

        // Създава копие на правоъгълника
        public override Shape Clone()
        {
            return new RectangleShape(this);
        }

        #endregion

        #region Помощни методи

        // Рисува запълването
        private void DrawFill(Graphics grfx)
        {
            switch (FillGradientType)
            {
                case GradientType.Linear:
                    // Линеен градиент
                    Color endColor = LightenColor(FillColor, 0.5f);
                    using (var brush = new LinearGradientBrush(Rectangle, FillColor, endColor, LinearGradientMode.Horizontal))
                    {
                        grfx.FillRectangle(brush, Rectangle);
                    }
                    break;

                case GradientType.Radial:
                    // Радиален градиент
                    using (var path = new GraphicsPath())
                    {
                        path.AddRectangle(Rectangle);
                        using (var brush = new PathGradientBrush(path))
                        {
                            brush.CenterColor = FillColor;
                            Color surroundColor = LightenColor(FillColor, 0.5f);
                            brush.SurroundColors = new Color[] { surroundColor };
                            grfx.FillRectangle(brush, Rectangle);
                        }
                    }
                    break;

                default:
                    // Обикновено запълване
                    grfx.FillRectangle(new SolidBrush(FillColor), Rectangle);
                    break;
            }
        }

        // Рисува контура
        private void DrawStroke(Graphics grfx)
        {
            switch (StrokeGradientType)
            {
                case GradientType.Linear:
                    // Градиентен контур
                    Color endStrokeColor = LightenColor(StrokeColor, 0.5f);
                    using (var brush = new LinearGradientBrush(Rectangle, StrokeColor, endStrokeColor, LinearGradientMode.Horizontal))
                    using (var pen = new Pen(brush, StrokeWidth))
                    {
                        grfx.DrawRectangle(pen, Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
                    }
                    break;

                case GradientType.Radial:
                    // Радиален градиент за контур
                    using (var path = new GraphicsPath())
                    {
                        path.AddRectangle(Rectangle);
                        using (var brush = new PathGradientBrush(path))
                        {
                            brush.CenterColor = StrokeColor;
                            Color surroundStrokeColor = LightenColor(StrokeColor, 0.5f);
                            brush.SurroundColors = new Color[] { surroundStrokeColor };
                            using (var pen = new Pen(brush, StrokeWidth))
                            {
                                grfx.DrawRectangle(pen, Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
                            }
                        }
                    }
                    break;

                default:
                    // Обикновен контур
                    grfx.DrawRectangle(new Pen(StrokeColor, StrokeWidth), Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
                    break;
            }
        }

        // Осветлява цвета
        private Color LightenColor(Color color, float lightenFactor)
        {
            int r = (int)(color.R + (255 - color.R) * lightenFactor);
            int g = (int)(color.G + (255 - color.G) * lightenFactor);
            int b = (int)(color.B + (255 - color.B) * lightenFactor);

            r = Math.Max(0, Math.Min(255, r));
            g = Math.Max(0, Math.Min(255, g));
            b = Math.Max(0, Math.Min(255, b));

            return Color.FromArgb(color.A, r, g, b);
        }

        #endregion
    }
}