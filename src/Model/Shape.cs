using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

namespace Draw
{
    /// <summary>
    /// Абстрактен базов клас за всички графични форми
    /// </summary>
    [Serializable]
    public abstract class Shape
    {
        #region Променливи

        private string name; // Име на формата
        private RectangleF rectangle; // Граници на формата
        private Color fillColor; // Цвят на запълване
        private Color strokeColor = Color.Black; // Цвят на контур
        private float strokeWidth; // Дебелина на контур
        private GradientType fillGradientType = GradientType.None; // Градиент на запълване
        private GradientType strokeGradientType = GradientType.None; // Градиент на контур
        private float rotationAngle = 0; // Ъгъл на завъртане
        private bool isSelected; // Дали е избрана
        private bool showName = false; // Дали да показва името

        #endregion

        #region Конструктори

        // Конструктор по подразбиране
        public Shape()
        {
            Name = $"Shape_{DateTime.Now.Ticks}";
        }

        // Конструктор с правоъгълник
        public Shape(RectangleF rect) : this()
        {
            rectangle = rect;
        }

        // Копиращ конструктор
        public Shape(Shape shape) : this()
        {
            this.Height = shape.Height;
            this.Width = shape.Width;
            this.Location = shape.Location;
            this.rectangle = shape.rectangle;
            this.FillColor = shape.FillColor;
            this.StrokeColor = shape.StrokeColor;
            this.StrokeWidth = shape.StrokeWidth;
            this.RotationAngle = shape.RotationAngle;
            this.FillGradientType = shape.FillGradientType;
            this.StrokeGradientType = shape.StrokeGradientType;
            this.Name = shape.Name + "_Copy";
        }

        #endregion

        #region Абстрактни методи

        // Създава копие на формата
        public abstract Shape Clone();

        #endregion

        #region Основни методи

        // Премества формата
        public virtual void Translate(float dx, float dy)
        {
            Location = new PointF(Location.X + dx, Location.Y + dy);
        }

        // Проверява дали точка е във формата
        public virtual bool Contains(PointF point)
        {
            return Rectangle.Contains(point.X, point.Y);
        }

        // Рисува формата
        public virtual void DrawSelf(Graphics grfx)
        {
            GraphicsState state = grfx.Save();
            try
            {
                PointF center = GetCenter();
                grfx.TranslateTransform(center.X, center.Y);
                grfx.RotateTransform(RotationAngle);
                grfx.TranslateTransform(-center.X, -center.Y);
                DrawName(grfx);
            }
            finally
            {
                grfx.Restore(state);
            }
        }

        // Връща центъра на формата
        public virtual PointF GetCenter()
        {
            return new PointF(Rectangle.Left + Rectangle.Width / 2,
                            Rectangle.Top + Rectangle.Height / 2);
        }

        // Мащабира формата
        public virtual void Scale(float scaleFactor)
        {
            PointF center = new PointF(
                Location.X + Width / 2,
                Location.Y + Height / 2
            );

            Width *= scaleFactor;
            Height *= scaleFactor;

            Location = new PointF(
                center.X - Width / 2,
                center.Y - Height / 2
            );
        }

        // Записва формата във файл
        public virtual void Serialize(BinaryWriter writer)
        {
            writer.Write(Name);
            writer.Write(Location.X);
            writer.Write(Location.Y);
            writer.Write(Width);
            writer.Write(Height);
            writer.Write(FillColor.ToArgb());
            writer.Write(StrokeColor.ToArgb());
            writer.Write(StrokeWidth);
            writer.Write(RotationAngle);
            writer.Write((int)FillGradientType);
            writer.Write((int)StrokeGradientType);
            writer.Write(Name ?? "");
        }

        // Чете форма от файл
        public virtual void Deserialize(BinaryReader reader)
        {
            Name = reader.ReadString();
            Location = new PointF(reader.ReadSingle(), reader.ReadSingle());
            Width = reader.ReadSingle();
            Height = reader.ReadSingle();
            FillColor = Color.FromArgb(reader.ReadInt32());
            StrokeColor = Color.FromArgb(reader.ReadInt32());
            StrokeWidth = reader.ReadSingle();
            RotationAngle = reader.ReadSingle();
            FillGradientType = (GradientType)reader.ReadInt32();
            StrokeGradientType = (GradientType)reader.ReadInt32();
            Name = reader.ReadString();
            if (string.IsNullOrEmpty(Name)) Name = "Без име";
        }

        #endregion

        #region Помощни методи

        // Рисува името на формата
        protected virtual void DrawName(Graphics grfx)
        {
            if (!IsSelected) return;

            using (var font = new Font("Arial", 10, FontStyle.Bold))
            using (var brush = new SolidBrush(Color.DarkBlue))
            {
                PointF nameLocation = new PointF(
                    Location.X + Width / 2 - 20,
                    Location.Y - 20
                );
                grfx.DrawString(Name, font, brush, nameLocation);
            }
        }

        #endregion

        #region Свойства

        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

        public virtual RectangleF Rectangle
        {
            get { return rectangle; }
            set { rectangle = value; }
        }

        public virtual float Width
        {
            get { return Rectangle.Width; }
            set { rectangle.Width = value; }
        }

        public virtual float Height
        {
            get { return Rectangle.Height; }
            set { rectangle.Height = value; }
        }

        public virtual PointF Location
        {
            get { return Rectangle.Location; }
            set { rectangle.Location = value; }
        }

        public virtual Color FillColor
        {
            get { return fillColor; }
            set { fillColor = value; }
        }

        public virtual Color StrokeColor
        {
            get { return strokeColor; }
            set { strokeColor = value; }
        }

        public virtual float StrokeWidth
        {
            get { return strokeWidth; }
            set { strokeWidth = value; }
        }

        // Типове градиенти
        public enum GradientType { None, Linear, Radial }

        public virtual GradientType FillGradientType
        {
            get { return fillGradientType; }
            set { fillGradientType = value; }
        }

        public virtual GradientType StrokeGradientType
        {
            get { return strokeGradientType; }
            set { strokeGradientType = value; }
        }

        public virtual float RotationAngle
        {
            get { return rotationAngle; }
            set { rotationAngle = value; }
        }

        public virtual bool IsSelected
        {
            get { return isSelected; }
            set { isSelected = value; }
        }

        public virtual bool ShowName
        {
            get { return showName; }
            set { showName = value; }
        }

        #endregion
    }
}