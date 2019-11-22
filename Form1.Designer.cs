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
            this.TasksTable = new System.Windows.Forms.DataGridView();
            this.nme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Connected = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextPainter = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddtaskMB = new System.Windows.Forms.ToolStripMenuItem();
            this.EditTaskMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.link = new System.Windows.Forms.ToolStripMenuItem();
            this.unlink = new System.Windows.Forms.ToolStripMenuItem();
            this.TasksPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.Import = new System.Windows.Forms.Button();
            this.FindPath = new System.Windows.Forms.Button();
            this.SaveAsbtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TasksTable)).BeginInit();
            this.contextPainter.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // TasksTable
            // 
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
            this.unlink});
            this.contextPainter.Name = "contextPainter";
            this.contextPainter.Size = new System.Drawing.Size(194, 142);
            // 
            // AddtaskMB
            // 
            this.AddtaskMB.Name = "AddtaskMB";
            this.AddtaskMB.Size = new System.Drawing.Size(193, 22);
            this.AddtaskMB.Text = "Добавить задачу";
            this.AddtaskMB.Click += new System.EventHandler(this.AddtaskMB_Click);
            // 
            // EditTaskMenuItem
            // 
            this.EditTaskMenuItem.Name = "EditTaskMenuItem";
            this.EditTaskMenuItem.Size = new System.Drawing.Size(193, 22);
            this.EditTaskMenuItem.Text = "Редактировать задачу";
            this.EditTaskMenuItem.Click += new System.EventHandler(this.EditTaskMenuItem_Click);
            // 
            // delete
            // 
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(193, 22);
            this.delete.Text = "Удалить задачу";
            this.delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(190, 6);
            // 
            // link
            // 
            this.link.Name = "link";
            this.link.Size = new System.Drawing.Size(193, 22);
            this.link.Text = "Связать с";
            this.link.Click += new System.EventHandler(this.Link_Click);
            // 
            // unlink
            // 
            this.unlink.Name = "unlink";
            this.unlink.Size = new System.Drawing.Size(193, 22);
            this.unlink.Text = "Убрать связь с";
            this.unlink.Click += new System.EventHandler(this.Unlink_Click);
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
            this.TasksPanel.Size = new System.Drawing.Size(1003, 402);
            this.TasksPanel.TabIndex = 0;
            this.TasksPanel.Scroll += new System.Windows.Forms.ScrollEventHandler(this.TasksPanel_Scroll);
            this.TasksPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 145F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1015, 572);
            this.tableLayoutPanel1.TabIndex = 6;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.TableLayoutPanel1_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TasksPanel);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1009, 421);
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
            this.tableLayoutPanel3.Controls.Add(this.Import, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.SaveBtn, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.FindPath, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.SaveAsbtn, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(507, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(499, 133);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(252, 3);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(244, 42);
            this.SaveBtn.TabIndex = 0;
            this.SaveBtn.Text = "Сохранить";
            this.SaveBtn.UseVisualStyleBackColor = true;
            // 
            // Import
            // 
            this.Import.Location = new System.Drawing.Point(3, 69);
            this.Import.Name = "Import";
            this.Import.Size = new System.Drawing.Size(243, 42);
            this.Import.TabIndex = 0;
            this.Import.Text = "Открыть";
            this.Import.UseVisualStyleBackColor = true;
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
            // SaveAsbtn
            // 
            this.SaveAsbtn.Location = new System.Drawing.Point(252, 69);
            this.SaveAsbtn.Name = "SaveAsbtn";
            this.SaveAsbtn.Size = new System.Drawing.Size(244, 42);
            this.SaveAsbtn.TabIndex = 0;
            this.SaveAsbtn.Text = "Сохранить как";
            this.SaveAsbtn.UseVisualStyleBackColor = true;
            // 
            // NetworkGraphmap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 572);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "NetworkGraphmap";
            this.Text = "Сетевой график";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NetworkGraphmap_FormClosing);
            this.Load += new System.EventHandler(this.NetworkGraphmap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TasksTable)).EndInit();
            this.contextPainter.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
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
        private System.Windows.Forms.Button Import;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Button FindPath;
        private System.Windows.Forms.Button SaveAsbtn;
    }
}

