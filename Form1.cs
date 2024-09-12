using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Deployment.Internal;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WireworldForms
{
    public partial class Form1 : Form
    {
        Presets presets = new Presets();
        // все цвета
        Color emptyColor = Color.FromArgb(51, 51, 51);
        Color wireColor = Color.FromArgb(239, 185, 73);
        Color headColor = Color.FromArgb(73, 208, 239);
        Color tailColor = Color.FromArgb(239, 73, 73);
        Color linesColor = Color.FromArgb(73, 73, 73);
        // актуальный цвет
        Color color;
        Timer timer = new Timer();
        string tag;
        string preset = "";
        // высота и ширина ячейки
        int wh = 20;

        List<Point> wireL = new List<Point>();
        List<Point> headL = new List<Point>();
        List<Point> tailL = new List<Point>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoagGrid();
            ClearGrid();
            Settings();
        }


        // рисовка таблицы
        private void LoagGrid()
        {
            DataTable table = new DataTable();

            // вычисляем сколько ячеек поместится в таблице
            int w = grid.Width - 10;
            int h = grid.Height - 10;

            int col = w / wh;
            int row = h / wh;

            // заполняем таблицу
            for (int i = 0; i < col; i++)
            {
                table.Columns.Add();
            }

            for (int i = 0; i < row; i++)
            {
                table.Rows.Add();
            }


            // указываем dataGridViev таблицу в качестве источника данных
            grid.DataSource = table;


            // задаём размер ячеек
            foreach (DataGridViewColumn item in grid.Columns)
            {
                item.Width = wh;
            }

            foreach (DataGridViewRow item in grid.Rows)
            {
                item.Height = wh;
            }
        }


        // очищение таблицы
        private void ClearGrid()
        {
            // пробегаемся по всем ячейкам
            for (int i = 0; i < grid.Columns.Count; i++)
            {
                for (int j = 0; j < grid.Rows.Count; j++)
                {
                    // устанавливаем стандартные значения
                    grid[i, j].Style.BackColor = emptyColor;
                    grid[i, j].Tag = "";
                }
            }
        }


        // настройки всего прочего
        private void Settings()
        {
            // цвет фона
            grid.BackgroundColor = emptyColor;
            // присвоение метода, вызывающегося при выборе какой либо ячейки
            grid.SelectionChanged += Grid_SelectionChanged;
            // цвет сетки таблицы (такой же как и фон, чтобы не было видно) 
            grid.GridColor = linesColor;
            // отключение видимости заголовков
            grid.ColumnHeadersVisible = false;
            grid.RowHeadersVisible = false;
            // отбираем право пользователя менять размер
            grid.AllowUserToResizeColumns = false;
            grid.AllowUserToResizeRows = false;
            // отбираем право пользователя изменять значение
            grid.ReadOnly = true;
            grid.Dock = DockStyle.Right;
            grid.Width = 1063;

            // цвета обводки
            emptyBtn.FlatAppearance.BorderColor = Color.White;
            wireBtn.FlatAppearance.BorderColor = Color.White;
            headBtn.FlatAppearance.BorderColor = Color.White;
            tailBtn.FlatAppearance.BorderColor = Color.White;
            startBtn.FlatAppearance.BorderColor = Color.White;
            stopBtn.FlatAppearance.BorderColor = Color.White;
            stopBtn.FlatAppearance.BorderSize = 1;
            orPresetBtn.FlatAppearance.BorderColor = Color.White;
            andPresetBtn.FlatAppearance.BorderColor = Color.White;

            // выбираем кнопку по дефолту
            SetBtn(2);
            color = wireColor;

            // настраиваем таймер
            timer.Interval = 300;
            timer.Tick += Timer_Tick;
        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateGrid();
        }



        private void Grid_SelectionChanged(object sender, EventArgs e)
        {
            // находим выбранную ячейку
            DataGridViewCell c = grid.CurrentCell;

            // если пресет не выбран
            if (preset == "")
            {
                // устанавливаем цвет и тег
                c.Style.BackColor = color;
                c.Tag = tag;

                // ищем ячейку в листе проводников
                Point wire = wireL.Find(p => p.X == c.ColumnIndex && p.Y == c.RowIndex);
                switch (tag)
                {
                    // если пользователь рисует проводником, то 
                    case "wire":
                        // если в листе проводников ничего не нашли
                        if (wire.IsEmpty)
                        {
                            // то добавляем новую ячейку в него
                            wireL.Add(new Point(c.ColumnIndex, c.RowIndex));
                        }
                        break;
                    // если рисует пустотой
                    case "empty":
                        // и в листе мы нашли проводник по таким же координатам
                        if (!wire.IsEmpty)
                        {
                            // то удаляем его
                            wireL.Remove(wire);
                        }
                        break;
                }

                // убираем выделение (для визуала)
                grid.ClearSelection();
            }
            // если при нажатии установлен пресет, то рисуем его
            else if (preset == "or")
            {
                PaintOR(c.ColumnIndex, c.RowIndex);
            }
            else if (preset == "and")
            {
                PaintAND(c.ColumnIndex, c.RowIndex);
            }
        }


        // отрисовка OR 
        private void PaintOR(int col, int row)
        {
            // если объект помещается в таблицу
            if (col + presets.GetOrSize.Width < grid.Columns.Count - 1 && row + presets.GetOrSize.Height < grid.Rows.Count - 1)
            {
                // берём массив точек для пресета из класса Presets
                foreach (Point point in presets.GetOR)
                {

                    // получаем ячейку из координат
                    DataGridViewCell cell = grid[point.X + col, point.Y + row];

                    // если она не является проводником, создаём проводник
                    if (cell.Tag.ToString() != "wire")
                    {
                        cell.Style.BackColor = wireColor;
                        cell.Tag = tag;
                        wireL.Add(new Point(cell.ColumnIndex, cell.RowIndex));
                    }
                }
            }
            else
            {
                MessageBox.Show("Объект не помещается в текущие координаты!");
            }

        }


        // отрисовка AND
        private void PaintAND(int col, int row)
        {
            // если объект помещается в таблицу
            if (col + presets.GetAndSize.Width < grid.Columns.Count - 1 && row + presets.GetAndSize.Height < grid.Rows.Count - 1)
            {
                foreach (Point point in presets.GetAND)
                {
                    DataGridViewCell cell = grid[point.X + col, point.Y + row];

                    if (cell.Tag.ToString() != "wire")
                    {
                        cell.Style.BackColor = wireColor;
                        cell.Tag = tag;
                        wireL.Add(new Point(cell.ColumnIndex, cell.RowIndex));
                    }
                }
            }
            else
            {
                MessageBox.Show("Объект не помещается в текущие координаты!");
            }
        }


        // обновление таблицы каждый тик таймера
        private void UpdateGrid()
        {
            // очищаем листы для голов и хвостов
            headL.Clear();
            tailL.Clear();


            // проходимся по всей таблице
            for (int i = 0; i < grid.Columns.Count; i++)
            {
                for (int j = 0; j < grid.Rows.Count; j++)
                {
                    // проверяем тег ячейки
                    switch (grid[i, j].Tag)
                    {
                        case "empty":
                            break;
                        case "wire":
                            // если соседей 1 или 2
                            if (GetNeighbours(i, j) == 1 || GetNeighbours(i, j) == 2)
                            {
                                // то добавляем в лист с головами позицию ячейки
                                headL.Add(new Point(i, j));
                            }
                            break;
                        case "head":
                            // добавляем новый хвост
                            tailL.Add(new Point(i, j));
                            break;
                        case "tail":
                            // ищем в листе с проводниками ячейку с такими же координатами
                            Point wire = wireL.Find(p => p.X == i && p.Y == j);
                            // если она не найдена
                            if (wire.IsEmpty)
                            {
                                // добавляем новую
                                wireL.Add(new Point(i, j));
                            }
                            break;
                    }
                }
            }

            // очищаем таблицу
            ClearGrid();

            // пробегаемся по всем листам и рисуем их содержимое
            foreach (Point wire in wireL)
            {
                grid[wire.X, wire.Y].Style.BackColor = wireColor;
                grid[wire.X, wire.Y].Tag = "wire";
            }
            foreach (Point head in headL)
            {
                grid[head.X, head.Y].Style.BackColor = headColor;
                grid[head.X, head.Y].Tag = "head";
            }
            foreach (Point tail in tailL)
            {
                grid[tail.X, tail.Y].Style.BackColor = tailColor;
                grid[tail.X, tail.Y].Tag = "tail";
            }
        }


        // поиск соседей
        public int GetNeighbours(int col, int row)
        {
            int count = 0;

            try
            {
                if (grid[col - 1, row].Tag.ToString() == "head")
                {
                    count += 1;
                }
                if (grid[col - 1, row + 1].Tag.ToString() == "head")
                {
                    count += 1;
                }
                if (grid[col - 1, row - 1].Tag.ToString() == "head")
                {
                    count += 1;
                }
                if (grid[col, row - 1].Tag.ToString() == "head")
                {
                    count += 1;
                }
                if (grid[col, row + 1].Tag.ToString() == "head")
                {
                    count += 1;
                }
                if (grid[col + 1, row + 1].Tag.ToString() == "head")
                {
                    count += 1;
                }
                if (grid[col + 1, row - 1].Tag.ToString() == "head")
                {
                    count += 1;
                }
                if (grid[col + 1, row].Tag.ToString() == "head")
                {
                    count += 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            return count;
        }


        // запуск таймера
        private void startBtn_Click(object sender, EventArgs e)
        {
            timer.Start();
            // выделение кнопки
            startBtn.FlatAppearance.BorderSize = 1;
            stopBtn.FlatAppearance.BorderSize = 0;
        }

        // остановка таймера
        private void stopBtn_Click(object sender, EventArgs e)
        {
            timer.Stop();
            // выделение кнопки
            startBtn.FlatAppearance.BorderSize = 0;
            stopBtn.FlatAppearance.BorderSize = 1;
        }

        // очистка таблицы
        private void clearBtn_Click(object sender, EventArgs e)
        {
            ClearGrid();
            wireL.Clear();
            headL.Clear();
            tailL.Clear();
        }


        // нажатие на пресет OR
        private void orPresetBtn_Click(object sender, EventArgs e)
        {
            // если пресет уже выбран, то отключаем его
            if (preset == "or")
            {
                preset = "";
                orPresetBtn.FlatAppearance.BorderSize = 0;
            }
            else
            {
                // иначе выбираем пресет
                preset = "or";
                orPresetBtn.FlatAppearance.BorderSize = 1;
                andPresetBtn.FlatAppearance.BorderSize = 0;
            }
        }

        // нажатие на пресет AND 
        private void andPresetBtn_Click(object sender, EventArgs e)
        {
            if (preset == "and")
            {
                preset = "";
                andPresetBtn.FlatAppearance.BorderSize = 0;
            }
            else
            {
                preset = "and";
                orPresetBtn.FlatAppearance.BorderSize = 0;
                andPresetBtn.FlatAppearance.BorderSize = 1;
            }
        }


        // нажатие на кнопку сохранения
        private void saveBtn_Click(object sender, EventArgs e)
        {
            // путь до рабочего стола
            string DesktopFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            SaveFileDialog sfd = new SaveFileDialog();
            // расширение файла
            sfd.DefaultExt = ".txt";
            sfd.AddExtension = true;
            // путь по умолчанию
            sfd.InitialDirectory = DesktopFolder;

            // если пользователь нажал закрыть
            if (sfd.ShowDialog() == DialogResult.Cancel)
                return;

            // полученный от пользователя путь
            string filename = sfd.FileName;

            // если путь до файла не пуст, то вызываем метод сохранения
            if (filename != "")
            {
                Save(filename);
            }
        }

        // метод сохранения
        private void Save(string filePath)
        {
            string saveString = "";

            // помещаем в специальную строку все проводники в формате X-Y;X-Y;...
            foreach (Point point in wireL)
            {
                saveString += $"{point.X}-{point.Y};";
            }

            // записываем в файл созданную строку
            File.WriteAllText(filePath, saveString);
        }


        // загрузка сохранённого пресета
        private void loadBtn_Click(object sender, EventArgs e)
        {
            // если на таблице что то нарисовано
            if (wireL.Count > 0)
            {
                // предупреждаем пользователя о том, что всё удалится
                DialogResult result = MessageBox.Show(
                "Загрузив пресет вы потеряйте текущие элементы\nПродолжить?",
                "",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);

                // если пользователь нажал окей, вызываем метод загрузки
                if (result == DialogResult.Yes)
                {
                    LoadPreset();
                }
            }
            // если в таблице ничего не нарисовано без предупреждения вызываем метод загрузки
            else
            {
                LoadPreset();
            }
        }


        // метод загрузки
        private void LoadPreset()
        {
            // путь до рабочего стола
            string DesktopFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            OpenFileDialog ofd = new OpenFileDialog();
            // путь по умолчанию
            ofd.InitialDirectory = DesktopFolder;

            if (ofd.ShowDialog() == DialogResult.Cancel)
                return;

            // полученный от пользователя путь
            string filename = ofd.FileName;

            if (filename != "")
            {
                // помещаем в лист содержимое файла, разделяя его по ;
                List<string> points = File.ReadAllText(filename).Split(';').ToList();
                // удаляем последний элемент т к он пустой
                points.RemoveRange(points.Count - 1, 1);

                // чистим таблицу
                ClearGrid();
                wireL.Clear();
                headL.Clear();
                tailL.Clear();

                // перебераем лист
                foreach (string point in points)
                {
                    // разделяем каждый элемент по '-'
                    string[] XY = point.Split('-');
                    // добавляем каждый элемент в лист проводников
                    wireL.Add(new Point(int.Parse(XY[0]), int.Parse(XY[1])));
                }

                // отрисовываем все проводники
                foreach (Point point in wireL)
                {
                    grid[point.X, point.Y].Style.BackColor = wireColor;
                    grid[point.X, point.Y].Style.Tag = "wire";
                }
            }
        }

        #region btns

        // выбор кнопки по индексу
        private void SetBtn(int index)
        {
            // если выбран какой то пресет
            if (preset != "")
            {
                // то убираем его и выделение с кнопок
                preset = "";
                orPresetBtn.FlatAppearance.BorderSize = 0;
                andPresetBtn.FlatAppearance.BorderSize = 0;
            }
            switch (index)
            {
                case 1:
                    // убираем выделение с других кнопок
                    UnsetBtn();
                    // устанавливаем обводку
                    emptyBtn.FlatAppearance.BorderSize = 1;
                    // устанавливаем тег
                    tag = "empty";
                    break;
                case 2:
                    UnsetBtn();
                    wireBtn.FlatAppearance.BorderSize = 1;
                    tag = "wire";
                    break;
                case 3:
                    UnsetBtn();
                    headBtn.FlatAppearance.BorderSize = 1;
                    tag = "head";
                    break;
                case 4:
                    UnsetBtn();
                    tailBtn.FlatAppearance.BorderSize = 1;
                    tag = "tail";
                    break;
            }
        }


        // убираем обводку у всех кнопок
        public void UnsetBtn()
        {
            emptyBtn.FlatAppearance.BorderSize = 0;
            wireBtn.FlatAppearance.BorderSize = 0;
            headBtn.FlatAppearance.BorderSize = 0;
            tailBtn.FlatAppearance.BorderSize = 0;
        }

        // нажатия на каждую кнопку
        private void emptyBtn_Click(object sender, EventArgs e)
        {
            SetBtn(1);
            color = emptyColor;
        }

        private void wireBtn_Click(object sender, EventArgs e)
        {
            SetBtn(2);
            color = wireColor;
        }

        private void headBtn_Click(object sender, EventArgs e)
        {
            SetBtn(3);
            color = headColor;
        }

        private void tailBtn_Click(object sender, EventArgs e)
        {
            SetBtn(4);
            color = tailColor;
        }

        #endregion
    }
}