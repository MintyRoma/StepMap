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
    public partial class EditTask : Form
    {
        public EditTask(NetPoint point)
        {
            InitializeComponent();
            if (point.PointType == TaskType.end) endType.Checked = true;
            else if (point.PointType == TaskType.start) StartTypeTask.Checked = true;
            else centerType.Checked = true;
            nametxtbox.Text = point.Name;
            descrtxtbox.Text = point.Description;
            timenud.Value = point.Time;
        }

        public delegate void save(object sender, SaveArgs e);
        public event save SavingChanges;

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Savebtn_Click(object sender, EventArgs e)
        {
            SaveArgs args;
            if (nametxtbox.Text == "")
            {
                MessageBox.Show("Введите название задачи", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                System.Media.SystemSounds.Exclamation.Play();
                return;
            }
            string type = "";
            if (StartTypeTask.Checked) type = "start";
            else if (endType.Checked) type = "end";
            else type = "center";
            args = new SaveArgs(nametxtbox.Text, descrtxtbox.Text,type,Convert.ToInt32(timenud.Value));
            SavingChanges?.Invoke(this, args);
            this.Close();
        }

        public class SaveArgs: EventArgs
        {
            private string name;
            private string desc;
            private NetworkGraph.TaskType taskType;
            private int lenght;

            public string Name
            {
                get { return name; }
            }

            public string Description
            {
                get { return desc; }
            }

            public NetworkGraph.TaskType Type
            {
                get { return taskType; }
            }

            public int Lenght
            {
                get { return lenght; }
            }
            public SaveArgs()
            {
                Random rnd = new Random(2019);
                string seed = "MintyProjects";
                string contr = "";
                char[] lib = { 'A','B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
                for(int i=0;i<6;i++)
                {
                    contr += lib[rnd.Next(lib.Length - 1)];
                }
                name = "Task" + contr;
                desc = "";
                taskType = TaskType.center;
                lenght = 9;
            }

            public SaveArgs(string nam, string descr, string type, int leng)
            {
                name = nam;
                desc = descr;
                lenght = leng;
                switch(type)
                {
                    case "start":
                        taskType = TaskType.start;
                        break;
                    case "end":
                        taskType = TaskType.end;
                        break;
                    default:
                        taskType = TaskType.center;
                        break;
                }
            }
        }

        private void AddTask_Load(object sender, EventArgs e)
        {

        }

        private void EditTask_Load(object sender, EventArgs e)
        {

        }

        private void EditTask_Leave(object sender, EventArgs e)
        {
            Focus();
            System.Media.SystemSounds.Exclamation.Play();
        }

        private void EditTask_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) Savebtn_Click(null, EventArgs.Empty);
        }

        private void EditTask_Scroll(object sender, ScrollEventArgs e)
        {
            
        }
    }
}
