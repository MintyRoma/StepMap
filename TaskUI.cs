using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NetworkGraph
{
    public partial class TaskUI : UserControl
    {
        private NetPoint task;

        public delegate void conschanged(object sender, EventArgs e);
        public event conschanged ConnectionsChanged;
        public Point APoint
        {
            get { return new Point(StartTrace.Location.X+this.Location.X,StartTrace.Location.Y+this.Location.Y); }
        }

        public NetPoint Task
        {
            get { return task; }
            set { task = value;
                UpdateData();
            }
        }
        public TaskUI(NetPoint point)
        {
            InitializeComponent();
            Task = point;
            LocationChanged += ChangeTask;
            Task.ConnectionsChanged += connectchanged;
            Task.TypeChanged += Recolor;
            WireAllControls(this);
        }

        private void ChangeTask(object sender, EventArgs e)
        {
            task.Location = this.Location ;
        }

        private void Recolor(object sender, EventArgs e)
        {
            //if (Task.PointType == TaskType.start)
            //{
            //    panel2.BackColor = Color.FromArgb(235, 76, 52);
            //    panel1.BackColor = Color.FromArgb(166, 49, 31);
            //}
            //if(Task.PointType==TaskType.end)
            //{
            //    panel2.BackColor = Color.FromArgb(54, 199, 52);
            //    panel1.BackColor = Color.FromArgb(29, 138, 28);
            //}
            //else
            //{
            //    panel1.BackColor = Color.FromArgb(64, 64, 64);
            //    panel2.BackColor = Color.DimGray;
            //}
        }

        private void connectchanged(object sender, EventArgs e)
        {
            this.ConnectionsChanged?.Invoke(this,EventArgs.Empty);
        }

        private void WireAllControls(Control cont)
        {
            foreach (Control ctrl in cont.Controls)
            {
                ctrl.Click += Clicked;
                ctrl.DoubleClick += DoubleClicked;
                ctrl.MouseClick += MouseClicked;
                ctrl.MouseDown += MouseDowned;
                ctrl.DragDrop += DragDropped;
                ctrl.DragEnter += DragEntered;
                ctrl.MouseUp += MouseUpped;
                ctrl.MouseMove += MouseMoved;
                if (ctrl.HasChildren)
                {
                    WireAllControls(ctrl);
                }
            }
        }

        private void MouseDowned(object sender, MouseEventArgs e)
        {
            this.OnMouseDown(e);
        }

        private void MouseMoved(object sender, MouseEventArgs e)
        {
            this.OnMouseMove(e);
        }

        private void MouseUpped(object sender, MouseEventArgs e)
        {
            this.OnMouseUp(e);
        }



        private void DragEntered(object sender, DragEventArgs e)
        {
            DragEventArgs dr = new DragEventArgs(null, 0, Cursor.Position.X, Cursor.Position.Y, DragDropEffects.Move, DragDropEffects.Move);
            this.OnDragEnter(dr);
        }

        private void DragDropped(object sender, DragEventArgs e)
        {
            this.OnDragDrop(e);
        }

        private void MouseClicked(object sender, MouseEventArgs e)
        {
            this.OnMouseClick(e);
        }

        private void DoubleClicked(object sender, EventArgs e)
        {
            this.OnDoubleClick(EventArgs.Empty);
        }

        private void UpdateData()
        {
            TasknameLabel.Text = task.Name;
            TimeLabel.Text = Convert.ToString(task.Time);
            this.Location = task.Location;
        }

        private void TaskUI_Load(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Clicked(object sender, EventArgs e)
        {
            this.InvokeOnClick(this, EventArgs.Empty);
        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
