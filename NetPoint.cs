using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;

namespace NetworkGraph
{
    public class NetPoint
    {
        #region PrivateValues
        private string name;
        private EList<NetPoint> connected = new EList<NetPoint>();
        private EList<string> Ids = new EList<string>();
        private Point location = new Point();
        private int time;
        private TaskType pointype = TaskType.center;
        private string description;
        private string id = null;
        #endregion


        #region Modifers
        public Point Location
        {
            get { return location; }
            set { location = value;
                LocationChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public string ID
        {
            get { return id; }
        }

        public string Name
        {
            get { return name; }
            set { name = value;}
        }
            
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public TaskType PointType
        {
            get { return pointype; }
            set { pointype = value;
                TypeChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public int Time
        {
            get { return time; }
            set { time = value;
                TimeChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public EList<NetPoint> Connections
        {
            get { return connected; }
            set { connected = value;
                ConnectionsChanged?.Invoke(this, EventArgs.Empty);
                Rebuildids();
            }
        }

        private void Rebuildids()
        {
            Ids.Clear();
            foreach(NetPoint np in Connections)
            {
                Ids.Add(np.ID);
            }
        }
        #endregion

        #region Events
        public delegate void locationchanged(object sender, EventArgs e);
        public event locationchanged LocationChanged;

        public delegate void typechanged(object sender, EventArgs e);
        public event typechanged TypeChanged;

        public delegate void timechanged(object sender, EventArgs e);
        public event timechanged TimeChanged;

        public delegate void listchanged(object sender, EventArgs e);
        public event listchanged ConnectionsChanged;
        #endregion

        #region Functions
        public NetPoint(string nam, string desc, int lenght, Point loc)
        {
            name = nam;
            description = desc;
            time = lenght;
            location = loc;
            connected.CollectionChanged += ChangeInside;
            TypeChanged?.Invoke(this, EventArgs.Empty);
            string dict = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            for(int i=0;i<8;i++)
            {
                Random rnd = new Random();
                id += dict[rnd.Next(dict.Count() - 1)];
            }
        }

        private void ChangeInside(object sender, EventArgs e)
        {
            ConnectionsChanged?.Invoke(this,EventArgs.Empty);
        }

        public NetPoint(string nam, string desc, int lenght, TaskType typ, Point loc)
        {
            name = nam;
            description = desc;
            time = lenght;
            location = loc;
            PointType = typ;
            connected.CollectionChanged += ChangeInside;
            TypeChanged?.Invoke(this,EventArgs.Empty);
            string dict = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            for (int i = 0; i < 8; i++)
            {
                Random rnd = new Random();
                id += dict[rnd.Next(dict.Count() - 1)];
                Thread.Sleep(10);
            }
        }

        public NetPoint()
        {
        }

        public void InstallID(string ida)
        {
            if (id == null) id = ida;
        }
        #endregion
    }
}
