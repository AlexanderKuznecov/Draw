using Draw.src.GUI;
using Draw.src.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace Draw
{
    /// <summary>
    /// Главна форма на приложението за рисуване
    /// </summary>
    public partial class MainForm : Form
    {
        private DialogProcessor dialogProcessor = new DialogProcessor();

        public MainForm()
        {
            InitializeComponent();
        }

        #region Основни методи

        // Затваряне на приложението
        void ExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            Close();
        }

        // Прерисуване на платното
        private void ViewPortPaint(object sender, PaintEventArgs e)
        {
            dialogProcessor.ReDraw(sender, e);

            // Рисува селекционни кутии
            foreach (var shape in dialogProcessor.SelectedShapes)
            {
                var bounds = GetShapeBounds(shape);
                if (bounds.HasValue)
                {
                    using (Pen selectionPen = new Pen(Color.Blue, 1))
                    {
                        selectionPen.DashStyle = DashStyle.Dash;
                        e.Graphics.DrawRectangle(selectionPen, Rectangle.Round(bounds.Value));
                        DrawScaleHandles(e.Graphics, bounds.Value);
                    }
                }
            }
        }

        // Мащабиране на избраните форми
        private void ScaleSelected(float scaleFactor)
        {
            if (dialogProcessor.SelectedShapes.Count > 0)
            {
                foreach (var shape in dialogProcessor.SelectedShapes)
                    shape.Scale(scaleFactor);

                viewPort.Invalidate();
                statusBar.Items[0].Text = $"Мащабиране с фактор {scaleFactor}";
            }
            else
            {
                MessageBox.Show("Няма избрани фигури за мащабиране!");
            }
        }

        // Рисува малки квадратчета за мащабиране
        private void DrawScaleHandles(Graphics g, RectangleF bounds)
        {
            float handleSize = 8;
            Brush handleBrush = Brushes.White;
            Pen handlePen = Pens.Black;

            // Ъглови handles
            g.FillRectangle(handleBrush, bounds.Left - handleSize / 2, bounds.Top - handleSize / 2, handleSize, handleSize);
            g.DrawRectangle(handlePen, bounds.Left - handleSize / 2, bounds.Top - handleSize / 2, handleSize, handleSize);

            // Други handles...
        }

        // Връща границите на формата
        private RectangleF? GetShapeBounds(Shape shape)
        {
            if (shape is GroupShape group)
            {
                if (group.SubShapes.Count == 0) return null;

                float minX = group.SubShapes.Min(s => s.Location.X);
                float minY = group.SubShapes.Min(s => s.Location.Y);
                float maxX = group.SubShapes.Max(s => s.Location.X + s.Width);
                float maxY = group.SubShapes.Max(s => s.Location.Y + s.Height);

                return new RectangleF(minX, minY, maxX - minX, maxY - minY);
            }
            return new RectangleF(shape.Location.X, shape.Location.Y, shape.Width, shape.Height);
        }

        #endregion

        #region Методи за рисуване на форми

        // Добавя правоъгълник
        void DrawRectangleSpeedButtonClick(object sender, EventArgs e)
        {
            dialogProcessor.AddRandomRectangle();
            statusBar.Items[0].Text = "Последно действие: Рисуване на правоъгълник";
            viewPort.Invalidate();
        }

        // Добавя елипса
        private void drawElipseSpeedButton_Click(object sender, EventArgs e)
        {
            dialogProcessor.AddRandomElipse();
            statusBar.Items[0].Text = "Последно действие: Рисуване на елипса";
            viewPort.Invalidate();
        }

        // Добавя кръг
        private void drawCirlceSpeedButton_Click(object sender, EventArgs e)
        {
            dialogProcessor.AddRandomCircle();
            statusBar.Items[0].Text = "Последно действие: Рисуване на кръг";
            viewPort.Invalidate();
        }

        // Добавя триъгълник
        private void drawTriangleSpeedButton_Click(object sender, EventArgs e)
        {
            dialogProcessor.AddRandomPolygon();
            statusBar.Items[0].Text = "Последно действие: Рисуване на триъгълник";
            viewPort.Invalidate();
        }

        // Добавя звезда
        private void drawStarSpeedButton_Click(object sender, EventArgs e)
        {
            dialogProcessor.AddRandomStar();
            statusBar.Items[0].Text = "Последно действие: Рисуване на звезда";
            viewPort.Invalidate();
        }

        // Добавя фигура за изпит 9
        private void drawFiguraIzpitSpeedButton_Click(object sender, EventArgs e)
        {
            dialogProcessor.AddRandomFiguraIzpit();
            statusBar.Items[0].Text = "Последно действие: Рисуване на фигурата от изпит 9";
            viewPort.Invalidate();
        }


        #endregion

        #region Методи за манипулация на форми

        // Избира форма
        void ViewPortMouseDown(object sender, MouseEventArgs e)
        {
            if (pickUpSpeedButton.Checked)
            {
                bool ctrlPressed = (ModifierKeys & Keys.Control) == Keys.Control;
                dialogProcessor.SelectShapeAt(e.Location, ctrlPressed);

                if (dialogProcessor.SelectedShapes.Count > 0)
                {
                    statusBar.Items[0].Text = "Последно действие: Селекция на примитив";
                    dialogProcessor.IsDragging = true;
                    dialogProcessor.LastLocation = e.Location;
                    viewPort.Invalidate();
                }
            }
        }

        // Влачене на форма
        void ViewPortMouseMove(object sender, MouseEventArgs e)
        {
            if (dialogProcessor.IsDragging)
            {
                if (dialogProcessor.Selection != null)
                    statusBar.Items[0].Text = "Последно действие: Влачене";

                dialogProcessor.TranslateTo(e.Location);
                viewPort.Invalidate();
            }
        }

        // Край на влачене
        void ViewPortMouseUp(object sender, MouseEventArgs e)
        {
            dialogProcessor.IsDragging = false;
        }

        // Промяна на цвят на запълване
        private void drawColorPickerSpeedButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK && dialogProcessor.SelectedShapes.Count > 0)
            {
                foreach (var shape in dialogProcessor.SelectedShapes)
                    shape.FillColor = colorDialog1.Color;

                viewPort.Invalidate();
            }
        }

        // Промяна на дебелина на контур
        private void drawStrokeWidthSpeedTracker_Scroll(object sender, EventArgs e)
        {
            if (dialogProcessor.SelectedShapes.Count > 0)
            {
                foreach (var shape in dialogProcessor.SelectedShapes)
                    shape.StrokeWidth = drawStrokeWidthSpeedTracker.Value;

                viewPort.Invalidate();
            }
        }

        // Промяна на цвят на контур
        private void drawStrokeColorPickerSpeedButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK && dialogProcessor.SelectedShapes.Count > 0)
            {
                foreach (var shape in dialogProcessor.SelectedShapes)
                    shape.StrokeColor = colorDialog1.Color;

                viewPort.Invalidate();
            }
        }

        // Прилага градиент
        private void drawGradientSpeedButton_Click(object sender, EventArgs e)
        {
            if (dialogProcessor.SelectedShapes.Count > 0)
            {
                var currentFill = dialogProcessor.SelectedShapes[0].FillGradientType;
                Shape.GradientType newFill;

                switch (currentFill)
                {
                    case Shape.GradientType.None:
                        newFill = Shape.GradientType.Linear;
                        break;
                    case Shape.GradientType.Linear:
                        newFill = Shape.GradientType.Radial;
                        break;
                    default:
                        newFill = Shape.GradientType.None;
                        break;
                }

                foreach (var shape in dialogProcessor.SelectedShapes)
                {
                    shape.FillGradientType = newFill;
                    shape.StrokeGradientType = newFill;
                }

                viewPort.Invalidate();
                statusBar.Items[0].Text = $"Приложен градиент: {newFill}";
            }
        }


        // Завъртане на форми
        private void rotateSpeedButton_Click(object sender, EventArgs e)
        {
            if (dialogProcessor.SelectedShapes.Count > 0)
            {
                float rotationAngle = 15.0f;
                foreach (var shape in dialogProcessor.SelectedShapes)
                    shape.RotationAngle += rotationAngle;

                viewPort.Invalidate();
                statusBar.Items[0].Text = "Последно действие: Завъртане на примитиви";
            }
        }

        // Изтриване на форми
        private void deleteSpeedButton_Click(object sender, EventArgs e)
        {
            if (dialogProcessor.SelectedShapes.Count > 0)
            {
                dialogProcessor.DeleteSelectedShapes();
                viewPort.Invalidate();
                statusBar.Items[0].Text = "Последно действие: Изтриване на примитиви";
            }
            else
            {
                statusBar.Items[0].Text = "Няма селектирани примитиви за изтриване";
            }
        }

        // Копиране и поставяне
        private void copyAndPasteSpeedButton_Click(object sender, EventArgs e)
        {
            if (dialogProcessor.SelectedShapes.Count > 0)
            {
                dialogProcessor.CopySelectedShapes();
                dialogProcessor.PasteCopiedShapes();
                viewPort.Invalidate();
                statusBar.Items[0].Text = "Последно действие: Копиране и поставяне";
            }
            else
            {
                statusBar.Items[0].Text = "Няма селектирани примитиви за копиране";
            }
        }

        // Групиране на форми
        private void groupSpeedButton_Click(object sender, EventArgs e)
        {
            if (dialogProcessor.SelectedShapes.Count >= 2)
            {
                dialogProcessor.GroupSelectedShapes();
                viewPort.Invalidate();
                statusBar.Items[0].Text = "Последно действие: Групиране на примитиви";
            }
            else
            {
                statusBar.Items[0].Text = "Трябва да изберете поне 2 примитива за групиране";
            }
        }

        // Разгрупиране на форми
        private void ungroupSpeedButton_Click(object sender, EventArgs e)
        {
            dialogProcessor.UngroupSelectedShapes();
            viewPort.Invalidate();
            statusBar.Items[0].Text = "Последно действие: Разгрупиране на примитиви";
        }

        // Увеличаване на мащаба
        private void scaleUpSpeedButton_Click(object sender, EventArgs e)
        {
            ScaleSelectedShapes(1.25f);
        }

        // Намаляване на мащаба
        private void scaleDownSpeedButton_Click(object sender, EventArgs e)
        {
            ScaleSelectedShapes(0.8f);
        }

        // Мащабиране на избраните форми
        private void ScaleSelectedShapes(float scaleFactor)
        {
            if (dialogProcessor.SelectedShapes.Count == 0)
            {
                MessageBox.Show("Няма избрани фигури за мащабиране!", "Предупреждение",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (var shape in dialogProcessor.SelectedShapes)
                shape.Scale(scaleFactor);

            viewPort.Invalidate();
            statusBar.Items[0].Text = $"Мащабиране {(scaleFactor > 1 ? "увеличаване" : "намаляване")} с {Math.Abs((scaleFactor - 1) * 100):0}%";
        }

        // Преименуване на форми
        private void renameSpeedButton_Click(object sender, EventArgs e)
        {
            if (dialogProcessor.SelectedShapes.Count == 0)
            {
                MessageBox.Show("Няма избрани фигури за именуване!", "Предупреждение",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dialogProcessor.SelectedShapes.Count == 1)
            {
                var shape = dialogProcessor.SelectedShapes[0];
                using (var renameDialog = new RenameDialog(shape.Name))
                {
                    if (renameDialog.ShowDialog() == DialogResult.OK)
                    {
                        shape.Name = renameDialog.ShapeName;
                        statusBar.Items[0].Text = $"Фигурата е преименувана на: {shape.Name}";
                    }
                }
            }
            else
            {
                using (var renameDialog = new RenameDialog(""))
                {
                    if (renameDialog.ShowDialog() == DialogResult.OK)
                    {
                        string baseName = renameDialog.ShapeName;
                        int counter = 1;

                        foreach (var shape in dialogProcessor.SelectedShapes)
                            shape.Name = $"{baseName}_{counter++}";

                        statusBar.Items[0].Text = $"Преименувани {dialogProcessor.SelectedShapes.Count} фигури";
                    }
                }
            }

            viewPort.Invalidate();
        }

        #endregion

        #region Файлови операции

        // Зареждане от файл
        private void loadToolStripButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Shape Files (*.shp)|*.shp|All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                dialogProcessor.LoadFromFile(openFileDialog.FileName);
                viewPort.Invalidate();
                statusBar.Items[0].Text = "Файлът е зареден успешно";
            }
        }

        // Запазване във файл
        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Shape Files (*.shp)|*.shp|All Files (*.*)|*.*";
            saveFileDialog.DefaultExt = "shp";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                dialogProcessor.SaveToFile(saveFileDialog.FileName);
                statusBar.Items[0].Text = "Файлът е запазен успешно";
            }
        }

        // Изчистване на платното
        private void clearCanvasSpeedButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Сигурни ли сте, че искате да изтриете всички фигури?",
                "Потвърждение за изтриване",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                dialogProcessor.ClearAllShapes();
                viewPort.Invalidate();
                statusBar.Items[0].Text = "Всички фигури бяха изтрити";
            }
            else
            {
                statusBar.Items[0].Text = "Изтриването отменено";
            }
        }


        #endregion

        
    }
}