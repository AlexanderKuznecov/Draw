using Draw.src.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Draw
{
    /// <summary>
    /// Основен клас за управление на рисуване и форми
    /// </summary>
    public class DialogProcessor : DisplayProcessor
    {
        #region Полета

        private Shape selection; // Текущо избрана форма
        private List<Shape> selectedShapes = new List<Shape>(); // Списък с избрани форми
        private bool isDragging; // Дали се влачи форма
        private PointF lastLocation; // Последна позиция на мишката
        private DateTime lastSelectionTime = DateTime.MinValue; // Време на последен избор
        private List<Shape> copiedShapes = new List<Shape>(); // Буфер за копирани форми

        #endregion

        #region Свойства

        public Shape Selection
        {
            get { return selection; }
            set { selection = value; }
        }

        public List<Shape> SelectedShapes
        {
            get { return selectedShapes; }
        }

        public bool IsDragging
        {
            get { return isDragging; }
            set { isDragging = value; }
        }

        public PointF LastLocation
        {
            get { return lastLocation; }
            set { lastLocation = value; }
        }

        #endregion

        #region Методи за създаване на форми

        // Добавя случаен правоъгълник
        public void AddRandomRectangle()
        {
            Random rnd = new Random();
            RectangleShape rect = new RectangleShape(new Rectangle(
                rnd.Next(100, 1000),
                rnd.Next(100, 600),
                100, 200));
            rect.FillColor = Color.White;
            ShapeList.Add(rect);
        }

        // Добавя случаен елипс
        public void AddRandomElipse()
        {
            Random rnd = new Random();
            ElipseShape elipse = new ElipseShape(new Rectangle(
                rnd.Next(100, 1000),
                rnd.Next(100, 600),
                100, 200));
            elipse.FillColor = Color.White;
            ShapeList.Add(elipse);
        }

        // Добавя случаен елипс
        public void AddRandomCircle()
        {
            Random rnd = new Random();
            CircleShape circle = new CircleShape(new Rectangle(
                rnd.Next(100, 1000),
                rnd.Next(100, 600),
                100, 200));
            circle.FillColor = Color.White;
            ShapeList.Add(circle);
        }

        // Добавя случаен триъгълник
        public void AddRandomPolygon()
        {
            Random rnd = new Random();
            TraingleShape triangle = new TraingleShape(new Rectangle(
                rnd.Next(100, 1000),
                rnd.Next(100, 600),
                100, 200));
            triangle.FillColor = Color.White;
            ShapeList.Add(triangle);
        }

        // Добавя случайна звезда
        public void AddRandomStar()
        {
            Random rnd = new Random();
            StarShape star = new StarShape(new Rectangle(
                rnd.Next(100, 1000),
                rnd.Next(100, 600),
                100, 200));
            star.FillColor = Color.White;
            ShapeList.Add(star);
        }

        // Добавя случайна Фигура от изпит 9
        public void AddRandomFiguraIzpit()
        {
            Random rnd = new Random();

            float width = 250;
            float height = 150;

            FiguraIzpit figuraIzpit = new FiguraIzpit(new RectangleF(
                rnd.Next(100, 1000),
                rnd.Next(100, 600),
                width,
                height));

            figuraIzpit.FillColor = Color.White;
            ShapeList.Add(figuraIzpit);
        }

        #endregion

        #region Методи за избор на форми

        // Проверява дали точка е във форма
        public Shape ContainsPoint(PointF point)
        {
            for (int i = ShapeList.Count - 1; i >= 0; i--)
            {
                if (ShapeList[i].Contains(point))
                    return ShapeList[i];
            }
            return null;
        }

        // Избира форма на дадена позиция
        public void SelectShapeAt(PointF location, bool ctrlPressed)
        {
            var shape = GetTopShapeAtPoint(location);

            if (shape != null)
            {
                if (ctrlPressed && shape is GroupShape)
                {
                    var subShape = GetShapeFromGroup((GroupShape)shape, location);
                    shape = subShape ?? shape;
                }

                if (ctrlPressed)
                {
                    if (SelectedShapes.Contains(shape))
                        SelectedShapes.Remove(shape);
                    else
                        SelectedShapes.Add(shape);
                }
                else
                {
                    SelectedShapes.Clear();
                    SelectedShapes.Add(shape);
                }
            }
            else if (!ctrlPressed)
            {
                SelectedShapes.Clear();
            }

            Selection = SelectedShapes.Count > 0 ? SelectedShapes.Last() : null;
        }

        // Връща най-горната форма на точка
        private Shape GetTopShapeAtPoint(PointF point)
        {
            for (int i = ShapeList.Count - 1; i >= 0; i--)
            {
                if (ShapeList[i].Contains(point))
                    return ShapeList[i];
            }
            return null;
        }

        // Връща форма от група на точка
        private Shape GetShapeFromGroup(GroupShape group, PointF point)
        {
            for (int i = group.SubShapes.Count - 1; i >= 0; i--)
            {
                if (group.SubShapes[i].Contains(point))
                    return group.SubShapes[i];
            }
            return null;
        }

        // Връща граници на избраните форми
        public RectangleF? GetSelectionBounds()
        {
            if (selectedShapes.Count == 0)
                return null;

            float left = selectedShapes.Min(s => s.Location.X);
            float top = selectedShapes.Min(s => s.Location.Y);
            float right = selectedShapes.Max(s => s.Location.X + s.Width);
            float bottom = selectedShapes.Max(s => s.Location.Y + s.Height);

            return new RectangleF(left, top, right - left, bottom - top);
        }

        #endregion

        #region Методи за манипулация

        // Изтрива избраните форми
        public void DeleteSelectedShapes()
        {
            foreach (var shape in SelectedShapes)
                ShapeList.Remove(shape);
            SelectedShapes.Clear();
        }

        // Премества избраните форми
        public void TranslateTo(PointF p)
        {
            if (selectedShapes.Count > 0)
            {
                float dx = p.X - lastLocation.X;
                float dy = p.Y - lastLocation.Y;

                foreach (var shape in selectedShapes)
                    shape.Translate(dx, dy);

                lastLocation = p;
            }
        }

        #endregion

        #region Операции с clipboard

        // Копира избраните форми
        public void CopySelectedShapes()
        {
            copiedShapes.Clear();
            foreach (var shape in SelectedShapes)
                copiedShapes.Add(shape.Clone());
        }

        // Поставя копирани форми
        public void PasteCopiedShapes()
        {
            foreach (var shape in copiedShapes)
            {
                var clone = shape.Clone();
                clone.Translate(20, 20);
                ShapeList.Add(clone);
            }
        }

        #endregion

        #region Операции с групи

        // Групира избраните форми
        public void GroupSelectedShapes()
        {
            if (SelectedShapes.Count < 2) return;

            var group = new GroupShape();
            foreach (var shape in SelectedShapes)
            {
                group.SubShapes.Add(shape);
                ShapeList.Remove(shape);
            }
            ShapeList.Add(group);
            SelectedShapes.Clear();
            SelectedShapes.Add(group);
            Selection = group;
        }

        // Разгрупира избраната група
        public void UngroupSelectedShapes()
        {
            if (SelectedShapes.Count != 1 || !(SelectedShapes[0] is GroupShape)) return;

            var group = (GroupShape)SelectedShapes[0];
            foreach (var shape in group.SubShapes)
                ShapeList.Add(shape);

            ShapeList.Remove(group);
            SelectedShapes.Clear();
            Selection = null;
        }

        #endregion

        #region Файлови операции

        // Запазва форми във файл
        public void SaveToFile(string fileName)
        {
            using (var stream = new FileStream(fileName, FileMode.Create))
            using (var writer = new BinaryWriter(stream))
            {
                writer.Write(ShapeList.Count);
                foreach (var shape in ShapeList)
                {
                    writer.Write(shape.GetType().Name);
                    shape.Serialize(writer);
                }
            }
        }

        // Зарежда форми от файл
        public void LoadFromFile(string fileName)
        {
            ShapeList.Clear();
            SelectedShapes.Clear();

            using (var stream = new FileStream(fileName, FileMode.Open))
            using (var reader = new BinaryReader(stream))
            {
                int count = reader.ReadInt32();
                for (int i = 0; i < count; i++)
                {
                    string typeName = reader.ReadString();
                    Shape shape = CreateShape(typeName);
                    shape.Deserialize(reader);
                    ShapeList.Add(shape);
                }
            }
        }

        // Създава форма по име
        private Shape CreateShape(string typeName)
        {
            switch (typeName)
            {
                case "RectangleShape": return new RectangleShape();
                case "ElipseShape": return new ElipseShape();
                case "TraingleShape": return new TraingleShape();
                case "StarShape": return new StarShape();
                case "CircleShape": return new CircleShape();
                case "FiguraIzpit": return new FiguraIzpit();
                case "GroupShape": return new GroupShape();
                default: throw new NotSupportedException($"Неподдържан тип форма: {typeName}");
            }
        }

        // Изчиства всички форми
        public void ClearAllShapes()
        {
            ShapeList.Clear();
            SelectedShapes.Clear();
            Selection = null;
        }

        #endregion
    }
}