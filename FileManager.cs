using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;

namespace NetworkGraph
{
    public class FileManager
    {

        public delegate void svd(string path);
        public event svd Saved;

        public delegate void opened(string path, List<NetPoint> listnp);
        public event opened Opened;

        /// <summary>
        /// Команда "Сохранить как"
        /// </summary>
        /// <param name="tasks"></param>
        public void Save(List<NetPoint> tasks, Panel pnl)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Сохранить карту как";
            dialog.Filter = "Файл карты (*.smf)|*.smf|Файл изображения карты (*.png)|*.png|Все файлы|*.*";
            if (dialog.ShowDialog()==DialogResult.OK)
            {
                if (dialog.FilterIndex == 2) CreateImage(dialog.FileName,pnl,tasks);
                else Create(dialog.FileName, tasks);
            }
            else
            {
                return;
            }
        }

        private void CreateImage(string fileName, Panel pnl, List<NetPoint>tasks)
        {
            int width = 10;
            int height = 10;
            foreach(TaskUI tsk in pnl.Controls)
            {
                if (tsk.Location.X > width) width = tsk.Location.X + 100;
                if (tsk.Location.Y > height) height = tsk.Location.Y + 200;
            }
            Bitmap bm = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bm);
            SolidBrush sb = new SolidBrush(Color.White);
            g.FillRectangle(sb, 0, 0, width, height);
            foreach (NetPoint np in tasks)
            {
                foreach(NetPoint link in np.Connections)
                {
                    Pen p = new Pen(Color.FromArgb(64,64,64), 3);
                    g.DrawLine(p, new Point(np.Location.X+35,np.Location.Y+47), new Point(link.Location.X+35,link.Location.Y+47));
                    p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                }
            }  
            foreach(TaskUI tsk in pnl.Controls)
            {
                tsk.DrawToBitmap(bm, new Rectangle(tsk.Location, tsk.Size));
            }
            bm.Save(fileName);
            MessageBox.Show("Файл успешно сохранен", "Сохранить", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Create(string fileName, List<NetPoint> tasks)
        {
            try
            {
                FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
                XmlWriter xml = XmlWriter.Create(fs);
                xml.WriteStartElement("map");
                foreach (NetPoint np in tasks)
                {
                    xml.WriteStartElement("task");

                    xml.WriteStartElement("id");
                    xml.WriteString(np.ID);
                    xml.WriteEndElement();

                    xml.WriteStartElement("name");
                    xml.WriteString(np.Name);
                    xml.WriteEndElement();

                    xml.WriteStartElement("description");
                    xml.WriteString(np.Description);
                    xml.WriteEndElement();

                    xml.WriteStartElement("type");
                    switch (np.PointType)
                    {
                        case TaskType.start:
                            xml.WriteString("start");
                            break;
                        case TaskType.end:
                            xml.WriteString("end");
                            break;
                        default:
                            xml.WriteString("center");
                            break;
                    }
                    xml.WriteEndElement();

                    xml.WriteStartElement("time");
                    xml.WriteString(Convert.ToString(np.Time));
                    xml.WriteEndElement();

                    xml.WriteStartElement("location");
                    xml.WriteStartElement("X");
                    xml.WriteString(Convert.ToString(np.Location.X));
                    xml.WriteEndElement();
                    xml.WriteStartElement("Y");
                    xml.WriteString(Convert.ToString(np.Location.Y));
                    xml.WriteEndElement();
                    xml.WriteEndElement();

                    xml.WriteStartElement("connections");
                    foreach (NetPoint con in np.Connections)
                    {
                        xml.WriteStartElement("taskID");
                        xml.WriteString(con.ID);
                        xml.WriteEndElement();
                    }
                    xml.WriteEndElement();

                    xml.WriteEndElement();
                }
                xml.WriteEndElement();
                xml.Close();
                fs.Close();
                MessageBox.Show("Файл успешно сохранен", "Сохранить", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Saved?.Invoke(fileName);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Команда "Сохранить"
        /// </summary>
        /// <param name="tasks"></param>
        /// <param name="path"></param>
        public void Save(List<NetPoint> tasks, string path)
        {
            if (path==null)
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Title = "Сохранить карту как";
                dialog.Filter = "Файл карты (*.smf)|*.smf|Файл изображения карты (*.png)|*.png|Все файлы|*.*";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Create(dialog.FileName, tasks);
                }
                else
                {
                    return;
                }
            }
            else Create(path, tasks);
        }
    

        /// <summary>
        /// Команда "Открыть"
        /// </summary>
        public void Open()
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Файл карты (*.smf)|*.smf";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    List<NetPoint> nplist = new List<NetPoint>();
                    FileStream fs = new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                    XmlDocument xml = new XmlDocument();
                    xml.Load(fs);
                    XmlNode doc = xml.DocumentElement;
                    Dictionary<string, string> links = new Dictionary<string, string>();
                    foreach (XmlNode node in doc)
                    {
                        if (node.Name == "task")
                        {
                            NetPoint point = new NetPoint();
                            foreach (XmlNode param in node)
                            {
                                if (param.Name == "id")
                                {
                                    point.InstallID(param.InnerText);
                                }
                                if (param.Name == "name") point.Name = param.InnerText;
                                if (param.Name == "description") point.Description = param.InnerText;
                                if (param.Name == "type")
                                {
                                    switch (param.InnerText)
                                    {
                                        case "start":
                                            point.PointType = TaskType.start;
                                            break;
                                        case "end":
                                            point.PointType = TaskType.end;
                                            break;
                                        default:
                                            point.PointType = TaskType.center;
                                            break;
                                    }
                                }
                                if (param.Name == "time") point.Time = Convert.ToInt32(param.InnerText);
                                if (param.Name == "location")
                                {
                                    Point import = new Point(0, 0);
                                    foreach (XmlNode loc in param)
                                    {
                                        if (loc.Name == "X") import.X = Convert.ToInt32(loc.InnerText);
                                        if (loc.Name == "Y") import.Y = Convert.ToInt32(loc.InnerText);
                                    }
                                    point.Location = import;
                                }
                                if (param.Name == "connections")
                                {
                                    string cons = "";
                                    foreach (XmlNode tsk in param)
                                    {
                                        if (tsk.Name == "taskID")
                                        {
                                            cons += tsk.InnerText + '|';
                                        }
                                    }
                                    if (cons.Length > 0) cons = cons.Substring(0, cons.Length - 1);
                                    links.Add(point.ID, cons);
                                }
                            }
                            nplist.Add(point);
                        }
                    }
                    List<NetPoint> connections = new List<NetPoint>();
                    foreach(NetPoint point in nplist)
                    {
                        NetPoint np = point;
                        foreach(string key in links.Keys)
                        {
                            if(key==np.ID)
                            {
                                List<string> cons = new List<string>();
                                cons = links[key].Split('|').ToList();
                                foreach(NetPoint pont in nplist)
                                {
                                    if (cons.Contains(pont.ID)) np.Connections.Add(pont);
                                }
                            }
                        }
                        connections.Add(np);
                    }
                    fs.Close();
                    Opened?.Invoke(dialog.FileName, connections);
                }
                else return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
