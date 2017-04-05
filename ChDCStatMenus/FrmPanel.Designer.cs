namespace ChDCStatMenus
{
    partial class FrmPanel
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
            this.timerCloseAll = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timerCloseAll
            // 
            this.timerCloseAll.Interval = 1000;
            this.timerCloseAll.Tick += new System.EventHandler(this.timerCloseAll_Tick);
            // 
            // FrmPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 274);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmPanel";
            this.ShowInTaskbar = false;
            this.Text = "FrmParent";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerCloseAll;
    }
}