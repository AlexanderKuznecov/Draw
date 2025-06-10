using System.Drawing.Drawing2D;
using System.Drawing;
using System;

namespace Draw.src.Model
{
    /// <summary>
    /// Клас за звезда с 10 върха, наследяващ базовия Shape
    /// </summary>
    public class StarShape : Shape
    {
        #region Конструктори

        // Конструктор с правоъгълник за граници
        public StarShape(RectangleF rect) : base(rect)
        {
        }

        // Конструктор по подразбиране (100x100)
        public StarShape() : this(new Rectangle(0, 0, 100, 100))
        {
        }

        // Конструктор за копиране
        public StarShape(StarShape star) : base(star)
        {
        }

        #endregion

        #region Основни методи

        // Създава копие на звездата
        public override Shape Clone()
        {
            return new StarShape(this);
        }

        // Проверява дали точка е вътре в звездата
        public override bool Contains(PointF point)
        {
            PointF[] starPoints = CreateStarPoints();
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddPolygon(starPoints);
                return path.IsVisible(point);
            }
        }

        // Рисува звездата
        public override void DrawSelf(Graphics grfx)
        {
            // Запазва състоянието на графиката
            GraphicsState state = grfx.Save();

            try
            {
                // Прилага завъртане
                ApplyRotationTransform(grfx);

                // Създава точките на звездата
                PointF[] starPoints = CreateStarPoints();
                RectangleF bounds = new RectangleF(Location.X, Location.Y, Width, Height);

                // Рисува запълването
                DrawStarFill(grfx, starPoints, bounds);

                // Рисува контура и линиите
                DrawStarStroke(grfx, starPoints, bounds);
            }
            finally
            {
                // Възстановява състоянието
                grfx.Restore(state);
            }
        }

        #endregion

        #region Помощни методи

        // Прилага завъртане
        protected void ApplyRotationTransform(Graphics grfx)
        {
            PointF center = GetCenter();
            grfx.TranslateTransform(center.X, center.Y);
            grfx.RotateTransform(RotationAngle);
            grfx.TranslateTransform(-center.X, -center.Y);
        }

        // Рисува запълването
        protected void DrawStarFill(Graphics grfx, PointF[] starPoints, RectangleF bounds)
        {
            switch (FillGradientType)
            {
                case GradientType.Linear:
                    Color endColor = LightenColor(FillColor, 0.5f);
                    using (var brush = new LinearGradientBrush(bounds, FillColor, endColor, LinearGradientMode.ForwardDiagonal))
                        grfx.FillPolygon(brush, starPoints);
                    break;

                case GradientType.Radial:
                    using (var path = new GraphicsPath())
                    {
                        path.AddPolygon(starPoints);
                        using (var brush = new PathGradientBrush(path))
                        {
                            brush.CenterColor = FillColor;
                            brush.SurroundColors = new Color[] { LightenColor(FillColor, 0.5f) };
                            grfx.FillPolygon(brush, starPoints);
                        }
                    }
                    break;

                default:
                    grfx.FillPolygon(new SolidBrush(FillColor), starPoints);
                    break;
            }
        }

        // Рисува контура и линиите
        protected void DrawStarStroke(Graphics grfx, PointF[] starPoints, RectangleF bounds)
        {
            using (Pen strokePen = CreateGradientPen(bounds, starPoints))
            {
                // Контур на звездата
                grfx.DrawPolygon(strokePen, starPoints);

                // Линии от центъра към върховете
                PointF center = GetCenter();
                foreach (PointF point in starPoints)
                {
                    grfx.DrawLine(strokePen, center, point);
                }
            }
        }

        // Създава молив с градиент
        protected Pen CreateGradientPen(RectangleF bounds, PointF[] starPoints)
        {
            if (StrokeGradientType == GradientType.Linear)
            {
                Color endColor = LightenColor(StrokeColor, 0.5f);
                return new Pen(new LinearGradientBrush(bounds, StrokeColor, endColor, LinearGradientMode.ForwardDiagonal), StrokeWidth);
            }
            else if (StrokeGradientType == GradientType.Radial)
            {
                var path = new GraphicsPath();
                path.AddPolygon(starPoints);
                var brush = new PathGradientBrush(path)
                {
                    CenterColor = StrokeColor,
                    SurroundColors = new Color[] { LightenColor(StrokeColor, 0.5f) }
                };
                return new Pen(brush, StrokeWidth);
            }
            return new Pen(StrokeColor, StrokeWidth);
        }

        // Генерира точките на звездата
        protected PointF[] CreateStarPoints()
        {
            PointF[] points = new PointF[10];
            float cx = Location.X + Width / 2;
            float cy = Location.Y + Height / 2;
            float outerRadius = Math.Min(Width, Height) / 2;
            float innerRadius = outerRadius / 2.5f;

            // Изчислява всеки връх
            for (int i = 0; i < 10; i++)
            {
                float angle = i * (float)(Math.PI / 5); // 36 градуса на връх
                float radius = (i % 2 == 0) ? outerRadius : innerRadius;
                points[i] = new PointF(
                    cx + radius * (float)Math.Cos(angle - Math.PI / 2), // Завъртане с -90 градуса
                    cy + radius * (float)Math.Sin(angle - Math.PI / 2)
                );
            }
            return points;
        }

        // Осветлява цвета
        protected Color LightenColor(Color color, float factor)
        {
            int r = Math.Min(255, color.R + (int)((255 - color.R) * factor));
            int g = Math.Min(255, color.G + (int)((255 - color.G) * factor));
            int b = Math.Min(255, color.B + (int)((255 - color.B) * factor));
            return Color.FromArgb(color.A, r, g, b);
        }

        #endregion
    }
}