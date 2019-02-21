namespace NvPipe.Net.Example
{
    partial class Form_Main
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
            this.Pnl_Info = new System.Windows.Forms.Panel();
            this.Lbl_Info = new System.Windows.Forms.Label();
            this.GLControl = new OpenTK.GLControl();
            this.Pnl_Info.SuspendLayout();
            this.SuspendLayout();
            // 
            // Pnl_Info
            // 
            this.Pnl_Info.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.Pnl_Info.Controls.Add(this.Lbl_Info);
            this.Pnl_Info.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Pnl_Info.Location = new System.Drawing.Point(0, 406);
            this.Pnl_Info.Name = "Pnl_Info";
            this.Pnl_Info.Size = new System.Drawing.Size(800, 44);
            this.Pnl_Info.TabIndex = 0;
            // 
            // Lbl_Info
            // 
            this.Lbl_Info.AutoSize = true;
            this.Lbl_Info.Location = new System.Drawing.Point(12, 15);
            this.Lbl_Info.Name = "Lbl_Info";
            this.Lbl_Info.Size = new System.Drawing.Size(37, 13);
            this.Lbl_Info.TabIndex = 0;
            this.Lbl_Info.Text = "- Info -";
            // 
            // GLControl
            // 
            this.GLControl.BackColor = System.Drawing.Color.Black;
            this.GLControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.GLControl.Location = new System.Drawing.Point(0, 0);
            this.GLControl.Name = "GLControl";
            this.GLControl.Size = new System.Drawing.Size(800, 379);
            this.GLControl.TabIndex = 1;
            this.GLControl.VSync = false;
            this.GLControl.Load += new System.EventHandler(this.GLControl_Load);
            this.GLControl.Paint += new System.Windows.Forms.PaintEventHandler(this.GLControl_Paint);
            this.GLControl.Resize += new System.EventHandler(this.GLControl_Resize);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GLControl);
            this.Controls.Add(this.Pnl_Info);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NvPipe Example";
            this.Pnl_Info.ResumeLayout(false);
            this.Pnl_Info.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Pnl_Info;
        private System.Windows.Forms.Label Lbl_Info;
        private OpenTK.GLControl GLControl;
    }
}

