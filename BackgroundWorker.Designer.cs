namespace NetworkGraph
{
    partial class BackgroundWorker
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
            this.ProgressPanel = new System.Windows.Forms.Panel();
            this.TraceNum = new System.Windows.Forms.Label();
            this.OperationName = new System.Windows.Forms.Label();
            this.Bar = new System.Windows.Forms.ProgressBar();
            this.ProgressPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProgressPanel
            // 
            this.ProgressPanel.Controls.Add(this.TraceNum);
            this.ProgressPanel.Controls.Add(this.OperationName);
            this.ProgressPanel.Controls.Add(this.Bar);
            this.ProgressPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProgressPanel.Location = new System.Drawing.Point(0, 0);
            this.ProgressPanel.Name = "ProgressPanel";
            this.ProgressPanel.Size = new System.Drawing.Size(622, 120);
            this.ProgressPanel.TabIndex = 0;
            // 
            // TraceNum
            // 
            this.TraceNum.AutoSize = true;
            this.TraceNum.Location = new System.Drawing.Point(533, 81);
            this.TraceNum.Name = "TraceNum";
            this.TraceNum.Size = new System.Drawing.Size(78, 13);
            this.TraceNum.TabIndex = 5;
            this.TraceNum.Text = "Номер: 1 из Х";
            this.TraceNum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // OperationName
            // 
            this.OperationName.AutoSize = true;
            this.OperationName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.OperationName.Location = new System.Drawing.Point(10, 24);
            this.OperationName.Name = "OperationName";
            this.OperationName.Size = new System.Drawing.Size(75, 17);
            this.OperationName.TabIndex = 4;
            this.OperationName.Text = "Операция";
            // 
            // Bar
            // 
            this.Bar.Location = new System.Drawing.Point(13, 44);
            this.Bar.Name = "Bar";
            this.Bar.Size = new System.Drawing.Size(598, 34);
            this.Bar.TabIndex = 3;
            // 
            // BackgroundWorker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 120);
            this.Controls.Add(this.ProgressPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "BackgroundWorker";
            this.Text = "Пожалуйста ожидайте";
            this.Load += new System.EventHandler(this.BackgroundWorker_Load);
            this.ProgressPanel.ResumeLayout(false);
            this.ProgressPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ProgressPanel;
        private System.Windows.Forms.Label TraceNum;
        private System.Windows.Forms.Label OperationName;
        private System.Windows.Forms.ProgressBar Bar;
    }
}