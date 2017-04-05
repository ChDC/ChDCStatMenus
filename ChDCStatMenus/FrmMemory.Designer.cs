namespace ChDCStatMenus
{
    partial class FrmMemory
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
            this.components = new System.ComponentModel.Container();
            this.timerProcesses = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.listProcessUsage = new System.Windows.Forms.ListView();
            this.columnProcessName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnUsage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerProcesses
            // 
            this.timerProcesses.Enabled = true;
            this.timerProcesses.Interval = 3000;
            this.timerProcesses.Tick += new System.EventHandler(this.timerProcesses_Tick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.listProcessUsage, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(256, 307);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(250, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "PROCESSES";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listProcessUsage
            // 
            this.listProcessUsage.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnProcessName,
            this.columnUsage});
            this.listProcessUsage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listProcessUsage.Location = new System.Drawing.Point(3, 23);
            this.listProcessUsage.Name = "listProcessUsage";
            this.listProcessUsage.Size = new System.Drawing.Size(250, 281);
            this.listProcessUsage.TabIndex = 12;
            this.listProcessUsage.UseCompatibleStateImageBehavior = false;
            this.listProcessUsage.View = System.Windows.Forms.View.Details;
            // 
            // columnProcessName
            // 
            this.columnProcessName.Text = "ProcessName";
            this.columnProcessName.Width = 125;
            // 
            // columnUsage
            // 
            this.columnUsage.Text = "Working Set";
            this.columnUsage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnUsage.Width = 103;
            // 
            // FrmMemory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 307);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmMemory";
            this.Text = "FrmMemory";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timerProcesses;
        private System.Windows.Forms.ListView listProcessUsage;
        private System.Windows.Forms.ColumnHeader columnProcessName;
        private System.Windows.Forms.ColumnHeader columnUsage;
    }
}