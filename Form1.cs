using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NetworkGraph
{
    public partial class NetworkGraphmap : Form
    {
        private List<NetPoint> points = new List<NetPoint>();
        private Point mouseloc = new Point(0,0);
        private TaskUI editnow;
        private TaskUI ALink;
        private List<NetPoint> way = new List<NetPoint>();
        private LinkStat status=LinkStat.none;
        private bool drag = false;

        private enum LinkStat
        {
            linking,
            unlinking,
            none
        };

        /// <summary>
        /// Список задач
        /// </summary>
        public List<NetPoint> Tasks
        {
            get
            {   UpdateTable();
                return points;
            }
            set
            {
                points = value;
                UpdateTable();
            }
        }

        /// <summary>
        /// Обновляет таблицу задач
        /// </summary>
        private  void UpdateTable()
        {
            TasksTable.Rows.Clear();
            foreach(NetPoint np in points)
            {
                string connects="";
                if (np.Connections.Count>0) foreach(NetPoint nop in np.Connections)
                {
                        connects += $"{nop.Name};";
                }
                string[] data = new string[] { np.Name, Convert.ToString(np.Time), connects };
                TasksTable.Rows.Add(data);

            }
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        public NetworkGraphmap()
        {
            InitializeComponent();
            SizeChanged += StartPaintTrace;
        }

        private void StartPaintTrace(object sender, EventArgs e)
        {
            StartPaintTrace();
        }
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// Обработчик нажатия по панели для показа контекствного меню
        /// </summary>
        /// <param name="sender">Объект события</param>
        /// <param name="e">Аргумент события</param>
        private void Panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                foreach(ToolStripItem it in contextPainter.Items)
                {
                    it.Enabled = false;
                }
                contextPainter.Items[0].Enabled = true;
                mouseloc = new Point(Cursor.Position.X-TasksPanel.Location.X-this.Location.X,Cursor.Position.Y-TasksPanel.Location.Y-this.Location.Y);
                contextPainter.Show(Cursor.Position);
                StartPaintTrace();
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

        /// <summary>
        /// Обработчик для принудительной разблокировки формы
        /// </summary>
        /// <param name="sender">Объект события</param>
        /// <param name="e">Аргумент события</param>
        private void uxPlay(object sender, EventArgs e)
        {
            this.Enabled = true;
        }

        /// <summary>
        /// Обработчик события сохранения новой точки из дочерней формы.
        /// Создает новую задачу и регистрирует все события.
        /// </summary>
        /// <param name="sender">Объект события</param>
        /// <param name="e">Аргумент события</param>
        private void GetNewPoint(object sender, AddTask.SaveArgs e)
        {
            NetPoint pont = new NetPoint(e.Name, e.Description,e.Lenght,e.Type  ,mouseloc);
            pont.PointType = e.Type;
            List<NetPoint> np = Tasks;
            np.Add(pont);
            Tasks=np;
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

        private void UpdateTableLink(object sender, EventArgs e)
        {
            UpdateTable();
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
            //TaskUI tsk = null;
            //foreach(TaskUI tk in TasksPanel.Controls)
            //{
            //    if (tk.Task.Connections.Count>0)
            //    {
            //        tsk = tk;
            //        break;
            //    }
            //}
            //if (tsk!=null)StartPaintTrace(tsk);
            StartPaintTrace();
        }

        private void StartPaintTrace()
        {
            //if (trace.Task.Connections!=null)
            //{
            //    foreach(NetPoint np in trace.Task.Connections)
            //    {
            //        if (!way.Contains(np))
            //        {
            //            TaskUI Ui = null;
            //            foreach(TaskUI ttk in TasksPanel.Controls)
            //            {
            //                if (ttk.Task == np) Ui = ttk;
            //            }
            //            Graphics gr = TasksPanel.CreateGraphics();
            //            Pen pn = new Pen(Color.Black);
            //            gr.DrawLine(pn, new Point(trace.APoint.X,trace.APoint.Y), new Point(Ui.APoint.X,Ui.APoint.Y));
            //            way.Add(np);
            //            StartPaintTrace(Ui);
            //        }
            //    }
            //    return trace;
            //}
            //else
            //{
            //    return trace;
            //}
            TasksPanel.CreateGraphics().Clear(Color.White);
            foreach(TaskUI tk in TasksPanel.Controls)
            {
                foreach(NetPoint np in tk.Task.Connections)
                {
                    TaskUI link = null;
                    foreach(TaskUI tik in TasksPanel.Controls)
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
            editnow = (TaskUI)sender;
            drag=true;
        }

        /// <summary>
        /// Обработчик события перемещения курсора для перемещения TaskUI
        /// </summary>
        /// <param name="sender">Объект события</param>
        /// <param name="e">Аргумент события</param>
        private void ReplacePoint(object sender, MouseEventArgs e)
        {
            StartPaintTrace();
            if (drag)
            {
                editnow.Location = new Point(Cursor.Position.X - TasksPanel.Location.X - this.Location.X-10, Cursor.Position.Y - TasksPanel.Location.Y - this.Location.Y-30);
            }
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
        /// Обработчик нажатия мышью по TaskUI
        /// </summary>
        /// <param name="sender">Объект события</param>
        /// <param name="e">Аргумент события</param>
        private void ClickPoint(object sender, MouseEventArgs e)
        {
            if (status==LinkStat.none)
            {
                editnow = (TaskUI)sender;
                drag = true;
                if (e.Button == MouseButtons.Right)
                {
                    foreach (ToolStripItem ts in contextPainter.Items) ts.Enabled = false;
                    contextPainter.Items[2].Enabled = true;
                    contextPainter.Items[1].Enabled = true;
                    contextPainter.Items[3].Enabled = true;
                    if (editnow.Task.Connections.Count > 0) contextPainter.Items[5].Enabled = true;
                    if (points.Count > 1) contextPainter.Items[4].Enabled = true;
                    contextPainter.Show(Cursor.Position);
                }
            }
            if (status==LinkStat.linking)
            {
                way = null;
                NetPoint linked = ((TaskUI)sender).Task;
                if (((TaskUI)sender)!=ALink) ALink.Task.Connections.Add(linked);
                else if(ALink.Task.Connections.Contains(linked))
                {
                    ALink.Task.Connections.Remove(linked);
                    ALink.Task.Connections.Add(linked);
                    MessageBox.Show("С данной задачей уже установлена связь", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                Cursor = Cursors.Default;
                status=LinkStat.none;
            }
            if(status==LinkStat.unlinking)
            {
                way = null;
                NetPoint unlink = ((TaskUI)sender).Task;
                if (((TaskUI)sender) != ALink && ALink.Task.Connections.Contains(unlink)) ALink.Task.Connections.Remove(unlink);
                else MessageBox.Show("С данным объектом не установлена связь", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
                status = LinkStat.none;
            }
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
            this.Enabled = false;
            edit.Show();
            StartPaintTrace();
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
            foreach(TaskUI tk in TasksPanel.Controls)
            {
                for(int i =0; i<tk.Task.Connections.Count;i++)
                {
                    NetPoint np = tk.Task.Connections[i];
                    if ( np == editnow.Task)
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
        }


        private void NetworkGraphmap_Load(object sender, EventArgs e)
        {

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

        /// <summary>
        /// Проверка на закрытые окна при закрытии текущего окна.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NetworkGraphmap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.Enabled) { MessageBox.Show("Перед выходом сперва закройте все диалоговые окна", "Присутствуют активные окна", MessageBoxButtons.OK, MessageBoxIcon.Error); System.Media.SystemSounds.Asterisk.Play(); e.Cancel = true; }
        }

        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

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
            status = LinkStat.linking;
            ALink = editnow;
        }

        private void TasksPanel_Scroll(object sender, ScrollEventArgs e)
        {
            StartPaintTrace();
        }

        private void TableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

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
            }
        }

        private void Unlink_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Выберите задачу, с которой необходимо разорвать связь", "Подсказка", MessageBoxButtons.OK,MessageBoxIcon.Information);
            status = LinkStat.unlinking;
            Cursor = Cursors.Hand;
            ALink = editnow;
        }
    }
}
