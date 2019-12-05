using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NetworkGraph
{
    public partial class NetworkGraphmap : Form
    {
        private TaskUI ALink;
        private bool drag = false;
        private TaskUI editnow;
        private Point mousecorrection = new Point();
        private Point mouseloc = new Point(0, 0);
        private string path = null;
        private List<NetPoint> points = new List<NetPoint>();
        private MapStat status = MapStat.none;
        private List<NetPoint> way = new List<NetPoint>();
        /// <summary>
        /// Конструктор
        /// </summary>
        public NetworkGraphmap()
        {
            InitializeComponent();
            SizeChanged += StartPaintTrace;
        }

        private enum MapStat
        {
            linking,
            unlinking,
            none,
            createnew,
            edit,
            delete
        };
        /// <summary>
        /// Список задач
        /// </summary>
        public List<NetPoint> Tasks
        {
            get
            {   //UpdateTable();
                return points;
            }
            set
            {
                points = value;
                UpdateTable();
            }
        }

        /// <summary>
        /// Обработчик нажатия по "Добавить задачу"
        /// </summary>
        /// <param name="sender">Объект события</param>
        /// <param name="e">Аргумент события</param>
        private void AddtaskMB_Click(object sender, EventArgs e)
        {
            AddTask form = new AddTask();
            form.FormClosing += uxPlay;
            this.Enabled = false;
            form.SavingChanges += GetNewPoint;
            form.Show();
            StartPaintTrace();
        }

        private void AddTaskStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.Cross;
            MessageBox.Show("Разместите задачу на карте", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            status = MapStat.createnew;
        }

        private void ClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            points.Clear();
            TasksPanel.Controls.Clear();
            StartPaintTrace();
        }

        /// <summary>
        /// Обработчик нажатия мышью по TaskUI
        /// </summary>
        /// <param name="sender">Объект события</param>
        /// <param name="e">Аргумент события</param>
        private void ClickPoint(object sender, MouseEventArgs e)
        {
            if (status == MapStat.none)
            {

                editnow = (TaskUI)sender;
                mousecorrection = e.Location;
                drag = true;
                if (e.Button == MouseButtons.Right)
                {
                    foreach (ToolStripItem ts in contextPainter.Items) ts.Enabled = false;
                    contextPainter.Items[2].Enabled = true;
                    contextPainter.Items[1].Enabled = true;
                    contextPainter.Items[3].Enabled = true;
                    if (editnow.Task.Connections.Count > 0) contextPainter.Items[5].Enabled = true;
                    if (points.Count > 1) contextPainter.Items[4].Enabled = true;
                    if (points.Count > 0) contextPainter.Items[6].Enabled = true;
                    contextPainter.Show(Cursor.Position);
                }
            }
            if (status == MapStat.delete)
            {
                editnow = (TaskUI)sender;
                Cursor = Cursors.Arrow;
                status = MapStat.none;
                List<NetPoint> np = Tasks;
                np.Remove(editnow.Task);
                Tasks = np;
                way = null;
                TasksPanel.Controls.Remove(editnow);
                List<NetPoint> update = new List<NetPoint>();
                foreach (NetPoint nep in Tasks)
                {
                    NetPoint updated = nep;
                    if (updated.Connections.Contains(editnow.Task))
                    {
                        updated.Connections.Remove(editnow.Task);
                    }
                    update.Add(updated);
                }
                Tasks = update;
                StartPaintTrace();
            }
            if (status == MapStat.edit)
            {
                Cursor = Cursors.Default;
                status = MapStat.none;
                TaskUI sen = (TaskUI)sender;
                editnow = sen;
                editnow.Task.PointType = sen.Task.PointType;
                NetPoint task = sen.Task;
                EditTask edit = new EditTask(task);
                edit.SavingChanges += EditPoint;
                edit.FormClosing += uxPlay;
                this.Enabled = false;
                edit.Show();
                StartPaintTrace();
            }
            if (status == MapStat.linking)
            {
                if (editnow == null && ALink == null)
                {
                    ALink = (TaskUI)sender;
                    MessageBox.Show("Выберите задачу, с которой необходимо образовать связь", "Подсказка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (editnow == null && ALink != null)
                {
                    editnow = (TaskUI)sender;
                }
                way = null;
                NetPoint linked = ((TaskUI)sender).Task;
                if (((TaskUI)sender) != ALink) ALink.Task.Connections.Add(linked);
                else if (ALink.Task.Connections.Contains(linked))
                {
                    ALink.Task.Connections.Remove(linked);
                    ALink.Task.Connections.Add(linked);
                    MessageBox.Show("С данной задачей уже установлена связь", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                Cursor = Cursors.Default;
                status = MapStat.none;
                UpdateTable();
                StartPaintTrace();
            }
            if (status == MapStat.unlinking)
            {
                if (ALink==null && editnow==null)
                {
                    ALink = (TaskUI)sender;
                    MessageBox.Show("Выберите задачу, с которой необходимо разорвать связь", "Подсказка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (ALink!=null && editnow==null)
                {
                    editnow=(TaskUI)sender;
                }
                way = null;
                NetPoint unlink = ((TaskUI)sender).Task;
                if (((TaskUI)sender) != ALink && ALink.Task.Connections.Contains(unlink))
                {
                    ALink.Task.Connections.Remove(unlink);
                    List<NetPoint> nplist = new List<NetPoint>();
                    foreach (NetPoint np in points)
                    {
                        nplist.Add(np);
                        if (np.ID == ALink.Task.ID)
                        {
                            nplist.Add(ALink.Task);
                            break;
                        }
                    }

                }
                else MessageBox.Show("С данным объектом не установлена связь", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
                status = MapStat.none;
                UpdateTable();
                StartPaintTrace();
            }
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// Обработчик события нажатия "Удалить задачу" из контекстного меню
        /// </summary>
        /// <param name="sender">Объект события</param>
        /// <param name="e">Аргумент события</param>
        private void Delete_Click(object sender, EventArgs e)
        {
            List<NetPoint> np = Tasks;
            np.Remove(editnow.Task);
            Tasks = np;
            way = null;
            TasksPanel.Controls.Remove(editnow);
            List<NetPoint> update = new List<NetPoint>();
            foreach (NetPoint nep in Tasks)
            {
                NetPoint updated = nep;
                if (updated.Connections.Contains(editnow.Task))
                {
                    updated.Connections.Remove(editnow.Task);
                }
                update.Add(updated);
            }
            Tasks = update;
            StartPaintTrace();
        }

        private void DrawShortPath()
        {
            if (way == null) return;
            Graphics g = TasksPanel.CreateGraphics();
            Pen p = new Pen(Color.Red, 5);
            List<TaskUI> tk = new List<TaskUI>();
            foreach (NetPoint np in way)
            {
                foreach (TaskUI tik in TasksPanel.Controls)
                {
                    if (tik.Task == np)
                    {
                        tk.Add(tik);
                        break;
                    }
                }
            }
            for (int i = 0; i < tk.Count - 1; i++)
            {
                g.DrawLine(p, tk[i].APoint, tk[i + 1].APoint);
                Point center = new Point((tk[i].APoint.X + tk[i + 1].APoint.X) / 2, (tk[i].APoint.Y + tk[i + 1].APoint.Y) / 2);
                AdjustableArrowCap bigArrow = new AdjustableArrowCap(5, 5);
                p.CustomEndCap = bigArrow;
                g.DrawLine(p, tk[i].APoint, center);
            }
        }

        /// <summary>
        /// Применение изменений после получения события от формы редактирования задачи
        /// </summary>
        /// <param name="sender">Объект события</param>
        /// <param name="e">Аргумент сохранения</param>
        private void EditPoint(object sender, EditTask.SaveArgs e)
        {
            this.Enabled = true;
            NetPoint point = new NetPoint(e.Name, e.Description, e.Lenght, e.Type, editnow.Location);
            point.Connections = editnow.Task.Connections;
            foreach (TaskUI tk in TasksPanel.Controls)
            {
                for (int i = 0; i < tk.Task.Connections.Count; i++)
                {
                    NetPoint np = tk.Task.Connections[i];
                    if (np == editnow.Task)
                    {
                        tk.Task.Connections[i] = point;
                    }
                }
            }
            int pos = points.IndexOf(editnow.Task);
            points[pos] = point;
            editnow.Task = point;
            way = null;
            UpdateTable();
            StartPaintTrace();
        }

        /// <summary>
        /// Обработчик события нажатия "Редактировать задачу" из контекстного меню.
        /// </summary>
        /// <remarks>Копирует TaskUI и NetPoint и отображает форму с подпиской на сохранение.</remarks>
        /// <param name="sender">Объект события</param>
        /// <param name="e">Аргумент события</param>
        private void EditTask(object sender, EventArgs e)
        {
            TaskUI sen = (TaskUI)sender;
            editnow = sen;
            editnow.Task.PointType = sen.Task.PointType;
            NetPoint task = sen.Task;
            EditTask edit = new EditTask(task);
            edit.SavingChanges += EditPoint;
            edit.FormClosing += uxPlay;
            this.Enabled = false;
            edit.Show();
            StartPaintTrace();
        }

        /// <summary>
        /// Обработчик нажатия "Редактирование задачи"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditTaskMenuItem_Click(object sender, EventArgs e)
        {
            EditTask(editnow, EventArgs.Empty);
        }

        private void EditTaskStripMenuItem1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
            MessageBox.Show("Выберите задачу для редактирования на карте", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            status = MapStat.edit;
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (path == null)
            {
                DialogResult res = MessageBox.Show("Вы не сохранили проект, желаете ли сохранить проект?", "Внимание", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (res == DialogResult.Cancel) return;
                else if (res == DialogResult.No) Application.Exit();
                else if (res == DialogResult.Yes)
                {
                    FileManager fm = new FileManager();
                    fm.Save(Tasks, TasksPanel);
                }
            }
            else
            {
                FileManager fms = new FileManager();
                List<NetPoint> np = fms.Open(path);
                if (np == null) return;
                if (np != Tasks)
                {
                    DialogResult res = MessageBox.Show("Вы не сохранили проект, желаете ли сохранить проект?", "Внимание", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (res == DialogResult.Cancel) return;
                    else if (res == DialogResult.No) ;
                    else
                    {
                        FileManager fm = new FileManager();
                        fm.Save(Tasks, path);
                    }
                }
            }
        }

        private void FindPath_Click(object sender, EventArgs e)
        {
            if (points.Count < 1)
            {
                if (MessageBox.Show("Карта пуста", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK) return;
            }
            BackgroundWorker work = new BackgroundWorker(points);
            work.ResultCalculated += GetCalculatedTrace;
            work.Show();
            work.Start();
            work.Close();
            this.Activate();
        }

        private void GetCalculatedTrace(List<NetPoint> ppts)
        {
            way = ppts;
            DrawShortPath();
        }

        /// <summary>
        /// Обработчик события сохранения новой точки из дочерней формы.
        /// Создает новую задачу и регистрирует все события.
        /// </summary>
        /// <param name="sender">Объект события</param>
        /// <param name="e">Аргумент события</param>
        private void GetNewPoint(object sender, AddTask.SaveArgs e)
        {
            NetPoint pont = new NetPoint(e.Name, e.Description, e.Lenght, e.Type, mouseloc);
            pont.PointType = e.Type;
            List<NetPoint> np = Tasks;
            np.Add(pont);
            Tasks = np;
            TaskUI tsk = new TaskUI(pont);
            tsk.Location = mouseloc;
            tsk.DoubleClick += EditTask;
            tsk.MouseClick += ClickPoint;
            tsk.MouseUp += MousePointUp;
            tsk.MouseMove += ReplacePoint;
            tsk.MouseDown += StartReplace;
            tsk.ConnectionsChanged += UpdateTableLink;
            tsk.Task.ConnectionsChanged += RedrawTasks;
            TasksPanel.Controls.Add(tsk);
            StartPaintTrace();
        }

        private void Import_Click(object sender, EventArgs e)
        {
            FileManager fms = new FileManager();
            fms.Opened += OpenedFile;
            fms.Open();
        }

        /// <summary>
        /// Обработчик события нажатия "Связать с"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Link_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Выберите задачу для связывания", "Подсказка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Cursor = Cursors.Hand;
            status = MapStat.linking;
            ALink = editnow;
        }

        /// <summary>
        /// Обработчик события прекращения перемещения TaskUI
        /// </summary>
        /// <param name="sender">Объект события</param>
        /// <param name="e">Аргумент события</param>
        private void MousePointUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        /// <summary>
        /// Проверка на закрытые окна при закрытии текущего окна.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NetworkGraphmap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.Enabled)
            {
                MessageBox.Show("Перед выходом сперва закройте все диалоговые окна", "Присутствуют активные окна", MessageBoxButtons.OK, MessageBoxIcon.Error); System.Media.SystemSounds.Asterisk.Play(); e.Cancel = true;
            }
            if (path == null)
            {
                DialogResult res = MessageBox.Show("Вы не сохранили проект, желаете ли сохранить проект?", "Внимание", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (res == DialogResult.Cancel) e.Cancel = true;
                else if (res == DialogResult.Yes)
                {
                    FileManager fm = new FileManager();
                    fm.Save(Tasks, TasksPanel);
                }
            }
            else
            {
                FileManager fms = new FileManager();
                List<NetPoint> np = fms.Open(path);
                if (np == null) return;
                if (np != Tasks)
                {
                    DialogResult res = MessageBox.Show("Вы не сохранили проект, желаете ли сохранить проект?", "Внимание", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (res == DialogResult.Cancel) e.Cancel = true;
                    else if (res == DialogResult.Yes)
                    {
                        FileManager fm = new FileManager();
                        fm.Save(Tasks, path);
                    }
                }
            }
        }

        private void NetworkGraphmap_Load(object sender, EventArgs e)
        {

        }

        private void OpenedFile(string pathr, List<NetPoint> nplist)
        {
            TasksPanel.Controls.Clear();
            if (pathr != null)
            {
                path = pathr;
                this.Text = "Сетевой график: " + pathr.Substring(pathr.LastIndexOf('\\') + 1);
            }
            else this.Text = "Сетевой график: Безымянный";
            Tasks = nplist;
            foreach (NetPoint np in Tasks)
            {
                TaskUI tsk = new TaskUI(np);
                tsk.DoubleClick += EditTask;
                tsk.MouseClick += ClickPoint;
                tsk.MouseUp += MousePointUp;
                tsk.MouseMove += ReplacePoint;
                tsk.MouseDown += StartReplace;
                tsk.ConnectionsChanged += UpdateTableLink;
                tsk.Task.ConnectionsChanged += RedrawTasks;

                TasksPanel.Controls.Add(tsk);
                tsk.Location = np.Location;

            }
            StartPaintTrace();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileManager fms = new FileManager();
            fms.Opened += OpenedFile;
            fms.Open();
        }

        /// <summary>
        /// Обработчик нажатия по панели для показа контекствного меню
        /// </summary>
        /// <param name="sender">Объект события</param>
        /// <param name="e">Аргумент события</param>
        private void Panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (status == MapStat.createnew && e.Button == MouseButtons.Left)
            {
                mouseloc = e.Location;
                Cursor = Cursors.Arrow;
                status = MapStat.none;
                AddTask form = new AddTask();
                form.FormClosing += uxPlay;
                this.Enabled = false;
                form.SavingChanges += GetNewPoint;
                form.Show();
                StartPaintTrace();
            }
            else if (e.Button == MouseButtons.Right)
            {
                foreach (ToolStripItem it in contextPainter.Items)
                {
                    it.Enabled = false;
                }
                contextPainter.Items[0].Enabled = true;
                if (points.Count > 0) contextPainter.Items[6].Enabled = true;
                mouseloc = new Point(Cursor.Position.X - TasksPanel.Location.X - this.Location.X, Cursor.Position.Y - TasksPanel.Location.Y - this.Location.Y);
                contextPainter.Show(Cursor.Position);
                StartPaintTrace();
            }
        }

        /// <summary>
        /// Обработчик события изменения данных внутри NetPoint для дальнейшей перерисовки панели.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RedrawTasks(object sender, EventArgs e)
        {
            Graphics gr = TasksPanel.CreateGraphics();
            gr.Clear(Color.White);
            gr.Dispose();
            StartPaintTrace();
        }

        /// <summary>
        /// Обработчик события перемещения курсора для перемещения TaskUI
        /// </summary>
        /// <param name="sender">Объект события</param>
        /// <param name="e">Аргумент события</param>
        private void ReplacePoint(object sender, MouseEventArgs e)
        {

            if (drag)
            {
                StartPaintTrace();
                editnow.Location = new Point(Cursor.Position.X - TasksPanel.Location.X - this.Location.X - mousecorrection.X - 20, Cursor.Position.Y - TasksPanel.Location.Y - this.Location.Y - mousecorrection.Y - 60);
            }
        }

        private void SaveAsbtn_Click(object sender, EventArgs e)
        {
            FileManager fms = new FileManager();
            fms.Saved += TakeFileName;
            fms.Save(points, TasksPanel);
        }

        private void SaveAsКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileManager fms = new FileManager();
            fms.Saved += TakeFileName;
            fms.Save(points, TasksPanel);
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            FileManager fms = new FileManager();
            fms.Saved += TakeFileName;
            fms.Save(points, path);
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileManager fms = new FileManager();
            fms.Saved += TakeFileName;
            fms.Save(points, path);
        }

        private void StartPaintTrace(object sender, EventArgs e)
        {
            StartPaintTrace();
        }

        private void StartPaintTrace()
        {
            TasksPanel.CreateGraphics().Clear(Color.White);
            foreach (TaskUI tk in TasksPanel.Controls)
            {
                foreach (NetPoint np in tk.Task.Connections)
                {
                    TaskUI link = null;
                    foreach (TaskUI tik in TasksPanel.Controls)
                    {
                        if (tik.Task == np)
                        {
                            link = tik;
                            break;
                        }
                    }
                    if (link == null) continue;
                    Graphics g = TasksPanel.CreateGraphics();
                    Pen p = new Pen(Color.Black, 3);
                    g.DrawLine(p, tk.APoint, link.APoint);

                    Point center = new Point((tk.APoint.X + link.APoint.X) / 2, (tk.APoint.Y + link.APoint.Y) / 2);
                    AdjustableArrowCap bigArrow = new AdjustableArrowCap(5, 5);
                    p.CustomEndCap = bigArrow;
                    g.DrawLine(p, tk.APoint, center);
                }
            }
            DrawShortPath();
        }

        /// <summary>
        /// Обработчик события начала перемещения TaskUI
        /// </summary>
        /// <param name="sender">Объект события</param>
        /// <param name="e">Аргумент события</param>
        private void StartReplace(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) return;
            if (status != MapStat.none) return;
            mousecorrection = e.Location;
            editnow = (TaskUI)sender;
            drag = true;
        }

        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TakeFileName(string path)
        {
            if (path != null)
            {
                this.Text = "Сетевой график: " + path.Substring(path.LastIndexOf('\\') + 1);
            }
            else this.Text = "Сетевой график: Безымянный";
        }

        private void TasksPanel_Scroll(object sender, ScrollEventArgs e)
        {
            StartPaintTrace();
        }

        private void Unlink_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Выберите задачу, с которой необходимо разорвать связь", "Подсказка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            status = MapStat.unlinking;
            Cursor = Cursors.Hand;
            ALink = editnow;
        }

        /// <summary>
        /// Обновляет таблицу задач
        /// </summary>
        private void UpdateTable()
        {
            TasksTable.Rows.Clear();
            foreach (NetPoint np in points)
            {
                string connects = "";
                if (np.Connections.Count > 0) foreach (NetPoint nop in np.Connections)
                    {
                        connects += $"{nop.Name};";
                    }
                string[] data = new string[] { np.Name, Convert.ToString(np.Time), connects };
                TasksTable.Rows.Add(data);

            }
        }
        private void UpdateTableLink(object sender, EventArgs e)
        {
            UpdateTable();
        }

        /// <summary>
        /// Обработчик для принудительной разблокировки формы
        /// </summary>
        /// <param name="sender">Объект события</param>
        /// <param name="e">Аргумент события</param>
        private void uxPlay(object sender, EventArgs e)
        {
            this.Enabled = true;
        }

        private void DeleteTaskMenuStripItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
            status = MapStat.delete;
            MessageBox.Show("Укажите задачу для удаления на карте", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FindShortpathStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (points.Count < 1)
            {
                if (MessageBox.Show("Карта пуста", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK) return;
            }
            BackgroundWorker work = new BackgroundWorker(points);
            work.ResultCalculated += GetCalculatedTrace;
            work.Show();
            work.Start();
            work.Close();
            this.Activate();
        }

        private void CreateLinkMenuItem1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
            status = MapStat.linking;
            MessageBox.Show("Укажите задачу от которого будет происходить связывание на карте", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            editnow = null;
            ALink = null;
        }

        private void DeleteLinkStripMenuItem1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
            status = MapStat.unlinking;
            MessageBox.Show("Укажите задачу от которого будет происходить отвязка на карте", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            editnow = null;
            ALink = null;
        }

        private void ОПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox ab = new AboutBox();
            ab.ShowDialog();
        }

        private void NewStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Application.ExecutablePath);
        }
    }
}
