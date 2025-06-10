using System.Drawing.Drawing2D;
using System.Drawing;
using System;

namespace Draw.src.Model
{
    /// <summary>
    /// Клас за триъгълник, наследяващ базовия Shape
    /// </summary>
    public class TraingleShape : Shape
    {
        #region Конструктори

        // Конструктор с правоъгълник за граници
        public TraingleShape(RectangleF rect) : base(rect)
        {
        }

        // Конструктор по подразбиране (100x100)
        public TraingleShape() : this(new Rectangle(0, 0, 100, 100))
        {
        }

        // Конструктор за копиране
        public TraingleShape(TraingleShape triangle) : base(triangle)
        {
        }

        #endregion

        #region Основни методи

        // Създава копие на триъгълника
        public override Shape Clone()
        {
            return new TraingleShape(this);
        }

        // Проверява дали точка е в триъгълника
        public override bool Contains(PointF point)
        {
            return base.Contains(point); // Засега проверява само правоъгълника
        }

        // Рисува триъгълника
        public override void DrawSelf(Graphics grfx)
        {
            // Запазва състоянието на графиката
            GraphicsState state = grfx.Save();

            try
            {
                // Прилага завъртане
                ApplyRotationTransform(grfx);

                // Върхове на триъгълника
                PointF[] vertices = GetTriangleVertices();
                RectangleF bounds = new RectangleF(Location.X, Location.Y, Width, Height);

                // Рисува запълването
                DrawTriangleFill(grfx, vertices, bounds);

                // Рисува контура
                DrawTriangleStroke(grfx, vertices, bounds);
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

        // Връща върховете на триъгълника
        protected PointF[] GetTriangleVertices()
        {
            return new PointF[]
            {
                new PointF(Location.X + Width / 2, Location.Y),         // Горен връх
                new PointF(Location.X, Location.Y + Height),            // Долен ляв
                new PointF(Location.X + Width, Location.Y + Height)     // Долен десен
            };
        }

        // Рисува запълването
        protected void DrawTriangleFill(Graphics grfx, PointF[] vertices, RectangleF bounds)
        {
            switch (FillGradientType)
            {
                case GradientType.Linear:
                    Color endColor = LightenColor(FillColor, 0.5f);
                    using (var brush = new LinearGradientBrush(bounds, FillColor, endColor, LinearGradientMode.ForwardDiagonal))
                        grfx.FillPolygon(brush, vertices);
                    break;

                case GradientType.Radial:
                    using (var path = new GraphicsPath())
                    {
                        path.AddPolygon(vertices);
                        using (var brush = new PathGradientBrush(path))
                        {
                            brush.CenterColor = FillColor;
                            brush.SurroundColors = new Color[] { LightenColor(FillColor, 0.5f) };
                            grfx.FillPolygon(brush, vertices);
                        }
                    }
                    break;

                default:
                    grfx.FillPolygon(new SolidBrush(FillColor), vertices);
                    break;
            }
        }

        // Рисува контура
        protected void DrawTriangleStroke(Graphics grfx, PointF[] vertices, RectangleF bounds)
        {
            switch (StrokeGradientType)
            {
                case GradientType.Linear:
                    using (var brush = new LinearGradientBrush(bounds, StrokeColor, LightenColor(StrokeColor, 0.5f), LinearGradientMode.ForwardDiagonal))
                    using (var pen = new Pen(brush, StrokeWidth))
                        grfx.DrawPolygon(pen, vertices);
                    break;

                case GradientType.Radial:
                    using (var path = new GraphicsPath())
                    {
                        path.AddPolygon(vertices);
                        using (var brush = new PathGradientBrush(path))
                        {
                            brush.CenterColor = StrokeColor;
                            brush.SurroundColors = new Color[] { LightenColor(StrokeColor, 0.5f) };
                            using (var pen = new Pen(brush, StrokeWidth))
                                grfx.DrawPolygon(pen, vertices);
                        }
                    }
                    break;

                default:
                    grfx.DrawPolygon(new Pen(StrokeColor, StrokeWidth), vertices);
                    break;
            }
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