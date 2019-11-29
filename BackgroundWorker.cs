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
    public partial class BackgroundWorker : Form
    {
        private List<NetPoint> points;
        private int record = 99999;
        private List<NetPoint> recordlist = null;
        private bool everseen = false;

        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        public delegate void calculated(List<NetPoint> ppts);
        public event calculated ResultCalculated;
        public delegate void errored(object sender);
        public event errored ErrorInside;

        public BackgroundWorker(List<NetPoint> pointlist)
        {
            InitializeComponent();
            points=pointlist;
        }

        public void Start()
        {
            bool start = false;
            bool end = false;
            NetPoint startnp = null;
            NetPoint endnp = null;
            OperationName.Text = "Проверка";
            bool destroy = false;
            int count = 1;
            try
            {
                Bar.Maximum = points.Count();
                TraceNum.Text = "Операция 0 из " + points.Count();

                foreach (NetPoint np in points)
                {
                    if (np.PointType == TaskType.start && start == true) throw new Exception("Присутствует более 1 начальной задачи");
                    if (np.PointType == TaskType.start && start == false)
                    {
                        start = true;
                        startnp = np;
                    }
                    if (np.PointType == TaskType.end && end == true) throw new Exception("Присутствует более 1 конечной задачи");
                    if (np.PointType == TaskType.end && end == false)
                    {
                        end = true;
                        endnp = np;
                    }
                    TraceNum.Text = $"Операция {count} из {points.Count}";
                    Bar.Value = count;
                }
                if (start == false) throw new Exception("Отсутствует начальная задача");
                if (end == false) throw new Exception("Отсутствует конечная задача");
                if (startnp.Connections.Count == 0) throw new Exception("Стартовая задача изолирована");
                bool isolated = true;
                foreach (NetPoint np in points)
                {
                    if (np.Connections.Contains(endnp))
                    {
                        isolated = false;
                        break;
                    }
                }
                if (isolated) throw new Exception("Конечная задача изолирована");
            }
            catch (Exception ex)
            {
                if (MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK) return; ;
            }
            count = 1;
            OperationName.Text = "Просчет";
            TraceNum.Text = $"Операция {count} из {points.Count * points.Count}";
            Bar.Maximum = 100000;
            Bar.Value = 0;
            Stack<NetPoint> way = new Stack<NetPoint>();
            Trace(startnp, endnp, 0, way);
            if (!everseen)
            {
                if (MessageBox.Show("Конечные задачи не связаны промежуточными задачами", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    return;
                }
            }
            ResultCalculated?.Invoke(recordlist);
            return;
        }

        private void Trace(NetPoint startnp, NetPoint endnp, int time,Stack<NetPoint> way)
        {
            Bar.Value++;
            if (startnp != endnp && !way.Contains(startnp))
            {
                way.Push(startnp);
                time += startnp.Time;
                foreach (NetPoint np in startnp.Connections)
                {
                    Trace(np,endnp,time,way);
                }
            }
            else
            {
                way.Push(endnp);
                time += endnp.Time;
                everseen = true;
                if (time<record)
                {
                    recordlist = way.ToList();
                    recordlist.Reverse();
                    record = time;
                }
            }
            way.Pop();
            return;
        }

        private void BackgroundWorker_Load(object sender, EventArgs e)
        {

        }
    }
}
