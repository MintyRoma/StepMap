namespace NetworkGraph
{
    partial class NetworkGraphmap
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NetworkGraphmap));
            this.TasksTable = new System.Windows.Forms.DataGridView();
            this.nme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Connected = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextPainter = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ClearMapContextMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.TasksPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.FindPath = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MapStripmenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.программаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsКакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddTaskStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditTaskStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteTaskMenuStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateLinkMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteLinkStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.FindShortpathStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddtaskMB = new System.Windows.Forms.ToolStripMenuItem();
            this.EditTaskMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delete = new System.Windows.Forms.ToolStripMenuItem();
            this.link = new System.Windows.Forms.ToolStripMenuItem();
            this.unlink = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.TasksTable)).BeginInit();
            this.contextPainter.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TasksTable
            // 
            this.TasksTable.AllowUserToAddRows = false;
            this.TasksTable.AllowUserToDeleteRows = false;
            this.TasksTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TasksTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nme,
            this.Time,
            this.Connected});
            this.TasksTable.Location = new System.Drawing.Point(3, 3);
            this.TasksTable.Name = "TasksTable";
            this.TasksTable.Size = new System.Drawing.Size(498, 133);
            this.TasksTable.TabIndex = 3;
            this.TasksTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellContentClick);
            // 
            // nme
            // 
            this.nme.HeaderText = "Название";
            this.nme.Name = "nme";
            // 
            // Time
            // 
            this.Time.HeaderText = "Время исполнения";
            this.Time.Name = "Time";
            // 
            // Connected
            // 
            this.Connected.HeaderText = "Связан";
            this.Connected.Name = "Connected";
            // 
            // contextPainter
            // 
            this.contextPainter.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddtaskMB,
            this.EditTaskMenuItem,
            this.delete,
            this.toolStripSeparator1,
            this.link,
            this.unlink,
            this.ClearMapContextMenuStrip});
            this.contextPainter.Name = "contextPainter";
            this.contextPainter.Size = new System.Drawing.Size(194, 164);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(190, 6);
            // 
            // ClearMapContextMenuStrip
            // 
            this.ClearMapContextMenuStrip.Image = global::NetworkGraph.Properties.Resources.CleanData_16x;
            this.ClearMapContextMenuStrip.Name = "ClearMapContextMenuStrip";
            this.ClearMapContextMenuStrip.Size = new System.Drawing.Size(193, 22);
            this.ClearMapContextMenuStrip.Text = "Очистить карту";
            this.ClearMapContextMenuStrip.Click += new System.EventHandler(this.ClearToolStripMenuItem_Click);
            // 
            // TasksPanel
            // 
            this.TasksPanel.AllowDrop = true;
            this.TasksPanel.AutoScroll = true;
            this.TasksPanel.BackColor = System.Drawing.Color.White;
            this.TasksPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TasksPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TasksPanel.Location = new System.Drawing.Point(3, 16);
            this.TasksPanel.Name = "TasksPanel";
            this.TasksPanel.Size = new System.Drawing.Size(1003, 372);
            this.TasksPanel.TabIndex = 0;
            this.TasksPanel.Scroll += new System.Windows.Forms.ScrollEventHandler(this.TasksPanel_Scroll);
            this.TasksPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.menuStrip1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 145F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1015, 572);
            this.tableLayoutPanel1.TabIndex = 6;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.TableLayoutPanel1_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TasksPanel);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1009, 391);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Карта";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.TasksTable, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 430);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1009, 139);
            this.tableLayoutPanel2.TabIndex = 8;
            this.tableLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.TableLayoutPanel2_Paint);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.FindPath, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(507, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(499, 133);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // FindPath
            // 
            this.FindPath.Location = new System.Drawing.Point(3, 3);
            this.FindPath.Name = "FindPath";
            this.FindPath.Size = new System.Drawing.Size(243, 42);
            this.FindPath.TabIndex = 0;
            this.FindPath.Text = "Найти кратчайшее решение";
            this.FindPath.UseVisualStyleBackColor = true;
            this.FindPath.Click += new System.EventHandler(this.FindPath_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.MapStripmenuItem,
            this.программаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1015, 30);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewStripMenuItem,
            this.OpenToolStripMenuItem,
            this.SaveToolStripMenuItem,
            this.SaveAsКакToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 26);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // MapStripmenuItem
            // 
            this.MapStripmenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddTaskStripMenuItem,
            this.EditTaskStripMenuItem1,
            this.DeleteTaskMenuStripItem,
            this.toolStripSeparator2,
            this.CreateLinkMenuItem1,
            this.DeleteLinkStripMenuItem1,
            this.toolStripSeparator3,
            this.FindShortpathStripMenuItem1});
            this.MapStripmenuItem.Name = "MapStripmenuItem";
            this.MapStripmenuItem.Size = new System.Drawing.Size(50, 26);
            this.MapStripmenuItem.Text = "Карта";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(228, 6);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(228, 6);
            // 
            // программаToolStripMenuItem
            // 
            this.программаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справкаToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
            this.программаToolStripMenuItem.Name = "программаToolStripMenuItem";
            this.программаToolStripMenuItem.Size = new System.Drawing.Size(84, 26);
            this.программаToolStripMenuItem.Text = "Программа";
            // 
            // NewStripMenuItem
            // 
            this.NewStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("NewStripMenuItem.Image")));
            this.NewStripMenuItem.Name = "NewStripMenuItem";
            this.NewStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.NewStripMenuItem.Text = "Создать";
            this.NewStripMenuItem.Click += new System.EventHandler(this.NewStripMenuItem_Click);
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("OpenToolStripMenuItem.Image")));
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.OpenToolStripMenuItem.Text = "Открыть";
            this.OpenToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("SaveToolStripMenuItem.Image")));
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.SaveToolStripMenuItem.Text = "Сохранить";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // SaveAsКакToolStripMenuItem
            // 
            this.SaveAsКакToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("SaveAsКакToolStripMenuItem.Image")));
            this.SaveAsКакToolStripMenuItem.Name = "SaveAsКакToolStripMenuItem";
            this.SaveAsКакToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.SaveAsКакToolStripMenuItem.Text = "Сохранить как";
            this.SaveAsКакToolStripMenuItem.Click += new System.EventHandler(this.SaveAsКакToolStripMenuItem_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ExitToolStripMenuItem.Image")));
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.ExitToolStripMenuItem.Text = "Выход из программы";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // AddTaskStripMenuItem
            // 
            this.AddTaskStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("AddTaskStripMenuItem.Image")));
            this.AddTaskStripMenuItem.Name = "AddTaskStripMenuItem";
            this.AddTaskStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.AddTaskStripMenuItem.Text = "Добавить задачу";
            this.AddTaskStripMenuItem.Click += new System.EventHandler(this.AddTaskStripMenuItem_Click);
            // 
            // EditTaskStripMenuItem1
            // 
            this.EditTaskStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("EditTaskStripMenuItem1.Image")));
            this.EditTaskStripMenuItem1.Name = "EditTaskStripMenuItem1";
            this.EditTaskStripMenuItem1.Size = new System.Drawing.Size(231, 22);
            this.EditTaskStripMenuItem1.Text = "Редактировать задачу";
            this.EditTaskStripMenuItem1.Click += new System.EventHandler(this.EditTaskStripMenuItem1_Click);
            // 
            // DeleteTaskMenuStripItem
            // 
            this.DeleteTaskMenuStripItem.Image = ((System.Drawing.Image)(resources.GetObject("DeleteTaskMenuStripItem.Image")));
            this.DeleteTaskMenuStripItem.Name = "DeleteTaskMenuStripItem";
            this.DeleteTaskMenuStripItem.Size = new System.Drawing.Size(231, 22);
            this.DeleteTaskMenuStripItem.Text = "Удалить задачу";
            this.DeleteTaskMenuStripItem.Click += new System.EventHandler(this.DeleteTaskMenuStripItem_Click);
            // 
            // CreateLinkMenuItem1
            // 
            this.CreateLinkMenuItem1.Image = global::NetworkGraph.Properties.Resources.AddLink_16x;
            this.CreateLinkMenuItem1.Name = "CreateLinkMenuItem1";
            this.CreateLinkMenuItem1.Size = new System.Drawing.Size(231, 22);
            this.CreateLinkMenuItem1.Text = "Создать связь";
            this.CreateLinkMenuItem1.Click += new System.EventHandler(this.CreateLinkMenuItem1_Click);
            // 
            // DeleteLinkStripMenuItem1
            // 
            this.DeleteLinkStripMenuItem1.Image = global::NetworkGraph.Properties.Resources.RemoveLink_16x;
            this.DeleteLinkStripMenuItem1.Name = "DeleteLinkStripMenuItem1";
            this.DeleteLinkStripMenuItem1.Size = new System.Drawing.Size(231, 22);
            this.DeleteLinkStripMenuItem1.Text = "Удалить связь";
            this.DeleteLinkStripMenuItem1.Click += new System.EventHandler(this.DeleteLinkStripMenuItem1_Click);
            // 
            // FindShortpathStripMenuItem1
            // 
            this.FindShortpathStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("FindShortpathStripMenuItem1.Image")));
            this.FindShortpathStripMenuItem1.Name = "FindShortpathStripMenuItem1";
            this.FindShortpathStripMenuItem1.Size = new System.Drawing.Size(231, 22);
            this.FindShortpathStripMenuItem1.Text = "Найти кратчайшее решение";
            this.FindShortpathStripMenuItem1.Click += new System.EventHandler(this.FindShortpathStripMenuItem1_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("справкаToolStripMenuItem.Image")));
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("оПрограммеToolStripMenuItem.Image")));
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.ОПрограммеToolStripMenuItem_Click);
            // 
            // AddtaskMB
            // 
            this.AddtaskMB.Image = global::NetworkGraph.Properties.Resources.AddEvent_16x;
            this.AddtaskMB.Name = "AddtaskMB";
            this.AddtaskMB.Size = new System.Drawing.Size(193, 22);
            this.AddtaskMB.Text = "Добавить задачу";
            this.AddtaskMB.Click += new System.EventHandler(this.AddtaskMB_Click);
            // 
            // EditTaskMenuItem
            // 
            this.EditTaskMenuItem.Image = global::NetworkGraph.Properties.Resources.EventModify_16x;
            this.EditTaskMenuItem.Name = "EditTaskMenuItem";
            this.EditTaskMenuItem.Size = new System.Drawing.Size(193, 22);
            this.EditTaskMenuItem.Text = "Редактировать задачу";
            this.EditTaskMenuItem.Click += new System.EventHandler(this.EditTaskMenuItem_Click);
            // 
            // delete
            // 
            this.delete.Image = global::NetworkGraph.Properties.Resources.DeleteEvent_16x;
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(193, 22);
            this.delete.Text = "Удалить задачу";
            this.delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // link
            // 
            this.link.Image = global::NetworkGraph.Properties.Resources.AddLink_16x;
            this.link.Name = "link";
            this.link.Size = new System.Drawing.Size(193, 22);
            this.link.Text = "Связать с";
            this.link.Click += new System.EventHandler(this.Link_Click);
            // 
            // unlink
            // 
            this.unlink.Image = global::NetworkGraph.Properties.Resources.RemoveLink_16x;
            this.unlink.Name = "unlink";
            this.unlink.Size = new System.Drawing.Size(193, 22);
            this.unlink.Text = "Убрать связь с";
            this.unlink.Click += new System.EventHandler(this.Unlink_Click);
            // 
            // NetworkGraphmap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 572);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "NetworkGraphmap";
            this.Text = "Сетевой график: Безымянный";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NetworkGraphmap_FormClosing);
            this.Load += new System.EventHandler(this.NetworkGraphmap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TasksTable)).EndInit();
            this.contextPainter.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView TasksTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn nme;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Connected;
        private System.Windows.Forms.ContextMenuStrip contextPainter;
        private System.Windows.Forms.ToolStripMenuItem AddtaskMB;
        private System.Windows.Forms.ToolStripMenuItem link;
        private System.Windows.Forms.ToolStripMenuItem unlink;
        private System.Windows.Forms.ToolStripMenuItem delete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem EditTaskMenuItem;
        private System.Windows.Forms.Panel TasksPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button FindPath;
        private System.Windows.Forms.ToolStripMenuItem ClearMapContextMenuStrip;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveAsКакToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem программаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MapStripmenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddTaskStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteTaskMenuStripItem;
        private System.Windows.Forms.ToolStripMenuItem CreateLinkMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem DeleteLinkStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem FindShortpathStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem EditTaskStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}

