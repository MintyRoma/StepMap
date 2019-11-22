using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace NetworkGraph
{
    public class NetPoint
    {
        #region PrivateValues
        private string name;
        private EList<NetPoint> connected = new EList<NetPoint>();
        private Point location = new Point();
        private int time;
        private TaskType pointype = TaskType.center;
        private string description;
        #endregion


        #region Modifers
        public Point Location
        {
            get { return location; }
            set { location = value;
                LocationChanged?.Invoke(this, EventArgs.Empty);
            }
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
        }
        #endregion
    }
}
