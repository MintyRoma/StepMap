namespace NetworkGraph
{
    partial class AddTask
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cancelbtn = new System.Windows.Forms.Button();
            this.savebtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.timenud = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.endType = new System.Windows.Forms.RadioButton();
            this.centerType = new System.Windows.Forms.RadioButton();
            this.StartTypeTask = new System.Windows.Forms.RadioButton();
            this.descrtxtbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nametxtbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timenud)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelbtn
            // 
            this.cancelbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancelbtn.Location = new System.Drawing.Point(290, 350);
            this.cancelbtn.Name = "cancelbtn";
            this.cancelbtn.Size = new System.Drawing.Size(81, 30);
            this.cancelbtn.TabIndex = 0;
            this.cancelbtn.Text = "Отмена";
            this.cancelbtn.UseVisualStyleBackColor = true;
            this.cancelbtn.Click += new System.EventHandler(this.Cancelbtn_Click);
            // 
            // savebtn
            // 
            this.savebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.savebtn.Location = new System.Drawing.Point(159, 350);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(100, 30);
            this.savebtn.TabIndex = 0;
            this.savebtn.Text = "Сохранить";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.Savebtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.timenud);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.endType);
            this.groupBox1.Controls.Add(this.centerType);
            this.groupBox1.Controls.Add(this.StartTypeTask);
            this.groupBox1.Controls.Add(this.descrtxtbox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.nametxtbox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(358, 331);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Создание задачи";
            // 
            // timenud
            // 
            this.timenud.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.timenud.Location = new System.Drawing.Point(113, 290);
            this.timenud.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.timenud.Name = "timenud";
            this.timenud.Size = new System.Drawing.Size(108, 22);
            this.timenud.TabIndex = 5;
            this.timenud.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(4, 290);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Длительность:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(71, 210);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Тип:";
            // 
            // endType
            // 
            this.endType.AutoSize = true;
            this.endType.Location = new System.Drawing.Point(113, 256);
            this.endType.Name = "endType";
            this.endType.Size = new System.Drawing.Size(91, 20);
            this.endType.TabIndex = 2;
            this.endType.TabStop = true;
            this.endType.Text = "Конечный";
            this.endType.UseVisualStyleBackColor = true;
            // 
            // centerType
            // 
            this.centerType.AutoSize = true;
            this.centerType.Location = new System.Drawing.Point(113, 233);
            this.centerType.Name = "centerType";
            this.centerType.Size = new System.Drawing.Size(134, 20);
            this.centerType.TabIndex = 2;
            this.centerType.TabStop = true;
            this.centerType.Text = "Промежуточный";
            this.centerType.UseVisualStyleBackColor = true;
            // 
            // StartTypeTask
            // 
            this.StartTypeTask.AutoSize = true;
            this.StartTypeTask.Location = new System.Drawing.Point(113, 210);
            this.StartTypeTask.Name = "StartTypeTask";
            this.StartTypeTask.Size = new System.Drawing.Size(100, 20);
            this.StartTypeTask.TabIndex = 2;
            this.StartTypeTask.TabStop = true;
            this.StartTypeTask.Text = "Начальный";
            this.StartTypeTask.UseVisualStyleBackColor = true;
            // 
            // descrtxtbox
            // 
            this.descrtxtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.descrtxtbox.Location = new System.Drawing.Point(113, 99);
            this.descrtxtbox.Multiline = true;
            this.descrtxtbox.Name = "descrtxtbox";
            this.descrtxtbox.Size = new System.Drawing.Size(239, 105);
            this.descrtxtbox.TabIndex = 1;
            this.descrtxtbox.TextChanged += new System.EventHandler(this.TextBox2_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(31, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Описание:";
            this.label2.Click += new System.EventHandler(this.Label2_Click);
            // 
            // nametxtbox
            // 
            this.nametxtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nametxtbox.Location = new System.Drawing.Point(113, 49);
            this.nametxtbox.Name = "nametxtbox";
            this.nametxtbox.Size = new System.Drawing.Size(239, 22);
            this.nametxtbox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(30, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название:";
            // 
            // AddTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 386);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.savebtn);
            this.Controls.Add(this.cancelbtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddTask";
            this.Text = "Добавить задачу";
            this.Load += new System.EventHandler(this.AddTask_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.AddTask_KeyUp);
            this.Leave += new System.EventHandler(this.AddTask_Leave);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timenud)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelbtn;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton StartTypeTask;
        private System.Windows.Forms.TextBox descrtxtbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nametxtbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown timenud;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton endType;
        private System.Windows.Forms.RadioButton centerType;
    }
}