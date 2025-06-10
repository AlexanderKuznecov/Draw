using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Draw.src.Model
{
    [Serializable]
    public class GroupShape : Shape
    {
        // Списък с подформи в групата
        private List<Shape> subShapes = new List<Shape>();

        // Свойство за достъп до подформите
        public List<Shape> SubShapes
        {
            get { return subShapes; }
            set { subShapes = value; }
        }

        // Проверява дали точка е в някоя от подформите
        public override bool Contains(PointF point)
        {
            return subShapes.Any(shape => shape.Contains(point));
        }

        // Рисува групата и всички подформи
        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx); // Рисува името на групата

            foreach (var shape in subShapes)
            {
                shape.DrawSelf(grfx);
            }
        }

        // Рисува името на групата
        protected override void DrawName(Graphics grfx)
        {
            using (var font = new Font("Arial", 10, FontStyle.Bold))
            using (var brush = new SolidBrush(Color.DarkBlue))
            {
                PointF nameLocation = new PointF(
                    Location.X + Width / 2 - 20,
                    Location.Y - 20
                );
                grfx.DrawString($"[Group] {Name}", font, brush, nameLocation);
            }
        }

        // Премества всички подформи
        public override void Translate(float dx, float dy)
        {
            foreach (var shape in subShapes)
            {
                shape.Translate(dx, dy);
            }
        }

        // Създава копие на групата
        public override Shape Clone()
        {
            var newGroup = new GroupShape();
            newGroup.Name = this.Name + "_Copy";
            foreach (var shape in subShapes)
            {
                newGroup.SubShapes.Add(shape.Clone());
            }
            return newGroup;
        }

        // Позиция на групата (горен ляв ъгъл)
        public override PointF Location
        {
            get
            {
                if (subShapes.Count == 0) return PointF.Empty;

                float minX = subShapes.Min(s => s.Location.X);
                float minY = subShapes.Min(s => s.Location.Y);
                return new PointF(minX, minY);
            }
            set
            {
                if (subShapes.Count == 0) return;

                var oldLocation = this.Location;
                float dx = value.X - oldLocation.X;
                float dy = value.Y - oldLocation.Y;

                this.Translate(dx, dy);
            }
        }

        // Ширина на групата
        public override float Width
        {
            get
            {
                if (subShapes.Count == 0) return 0;

                float minX = subShapes.Min(s => s.Location.X);
                float maxX = subShapes.Max(s => s.Location.X + s.Width);
                return maxX - minX;
            }
            set { /* Не се поддържа */ }
        }

        // Височина на групата
        public override float Height
        {
            get
            {
                if (subShapes.Count == 0) return 0;

                float minY = subShapes.Min(s => s.Location.Y);
                float maxY = subShapes.Max(s => s.Location.Y + s.Height);
                return maxY - minY;
            }
            set { /* Не се поддържа */ }
        }

        // Цвят на запълване (взет от първата подформа)
        public override Color FillColor
        {
            get => subShapes.Count > 0 ? subShapes[0].FillColor : Color.White;
            set
            {
                foreach (var shape in subShapes)
                {
                    shape.FillColor = value;
                }
            }
        }

        // Цвят на контура (взет от първата подформа)
        public override Color StrokeColor
        {
            get => subShapes.Count > 0 ? subShapes[0].StrokeColor : Color.Black;
            set
            {
                foreach (var shape in subShapes)
                {
                    shape.StrokeColor = value;
                }
            }
        }

        // Дебелина на контура (взета от първата подформа)
        public override float StrokeWidth
        {
            get => subShapes.Count > 0 ? subShapes[0].StrokeWidth : 1;
            set
            {
                foreach (var shape in subShapes)
                {
                    shape.StrokeWidth = value;
                }
            }
        }

        // Ъгъл на завъртане (взет от първата подформа)
        public override float RotationAngle
        {
            get => subShapes.Count > 0 ? subShapes[0].RotationAngle : 0f;
            set
            {
                float centerX = Location.X + Width / 2;
                float centerY = Location.Y + Height / 2;
                float angleDelta = value - RotationAngle;

                foreach (var shape in subShapes)
                {
                    // Изчислява новите координати след завъртане
                    float dx = shape.Location.X + shape.Width / 2 - centerX;
                    float dy = shape.Location.Y + shape.Height / 2 - centerY;

                    float newX = (float)(centerX + dx * Math.Cos(angleDelta * Math.PI / 180)
                                - dy * Math.Sin(angleDelta * Math.PI / 180) - shape.Width / 2);
                    float newY = (float)(centerY + dx * Math.Sin(angleDelta * Math.PI / 180)
                                + dy * Math.Cos(angleDelta * Math.PI / 180) - shape.Height / 2);

                    shape.Location = new PointF(newX, newY);
                    shape.RotationAngle += angleDelta;
                }
            }
        }

        // Тип градиент на запълване
        public override GradientType FillGradientType
        {
            get => subShapes.Count > 0 ? subShapes[0].FillGradientType : GradientType.None;
            set
            {
                foreach (var shape in subShapes)
                {
                    shape.FillGradientType = value;
                }
            }
        }

        // Тип градиент на контура
        public override GradientType StrokeGradientType
        {
            get => subShapes.Count > 0 ? subShapes[0].StrokeGradientType : GradientType.None;
            set
            {
                foreach (var shape in subShapes)
                {
                    shape.StrokeGradientType = value;
                }
            }
        }

        // Мащабиране на групата
        public override void Scale(float scaleFactor)
        {
            PointF groupCenter = new PointF(
                this.Location.X + this.Width / 2,
                this.Location.Y + this.Height / 2
            );

            foreach (var shape in SubShapes)
            {
                PointF shapeCenter = new PointF(
                    shape.Location.X + shape.Width / 2,
                    shape.Location.Y + shape.Height / 2
                );

                float newWidth = shape.Width * scaleFactor;
                float newHeight = shape.Height * scaleFactor;

                // Изчислява новата позиция след мащабиране
                shape.Location = new PointF(
                    groupCenter.X - (groupCenter.X - shapeCenter.X) * scaleFactor - newWidth / 2,
                    groupCenter.Y - (groupCenter.Y - shapeCenter.Y) * scaleFactor - newHeight / 2
                );

                shape.Width = newWidth;
                shape.Height = newHeight;
            }

            RecalculateGroupBounds();
        }

        // Преизчислява границите на групата
        private void RecalculateGroupBounds()
        {
            if (SubShapes.Count == 0) return;

            float minX = SubShapes.Min(s => s.Location.X);
            float minY = SubShapes.Min(s => s.Location.Y);
            float maxX = SubShapes.Max(s => s.Location.X + s.Width);
            float maxY = SubShapes.Max(s => s.Location.Y + s.Height);

            this.Location = new PointF(minX, minY);
            this.Width = maxX - minX;
            this.Height = maxY - minY;
        }

        // Записва групата във файл
        public override void Serialize(BinaryWriter writer)
        {
            base.Serialize(writer);
            writer.Write(SubShapes.Count);
            foreach (var shape in SubShapes)
            {
                writer.Write(shape.GetType().Name);
                shape.Serialize(writer);
            }
        }

        // Чете група от файл
        public override void Deserialize(BinaryReader reader)
        {
            base.Deserialize(reader);
            int count = reader.ReadInt32();
            for (int i = 0; i < count; i++)
            {
                string typeName = reader.ReadString();
                Shape shape = CreateShape(typeName);
                shape.Deserialize(reader);
                SubShapes.Add(shape);
            }
        }

        // Създава конкретна форма по име
        private Shape CreateShape(string typeName)
        {
            switch (typeName)
            {
                case "RectangleShape": return new RectangleShape();
                case "ElipseShape": return new ElipseShape();
                case "TraingleShape": return new TraingleShape();
                case "StarShape": return new StarShape();
                case "CircleShape":return new CircleShape();
                case "FiguraIzpit": return new FiguraIzpit();
                case "GroupShape": return new GroupShape();
                default: throw new NotSupportedException($"Unknown shape type: {typeName}");
            }
        }
    }
}