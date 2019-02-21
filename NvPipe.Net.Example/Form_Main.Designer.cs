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
            this.Lbl_ErrorMessage = new System.Windows.Forms.Label();
            this.Pnl_Info.SuspendLayout();
            this.SuspendLayout();
            // 
            // Pnl_Info
            // 
            this.Pnl_Info.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Pnl_Info.Controls.Add(this.Lbl_ErrorMessage);
            this.Pnl_Info.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Pnl_Info.Location = new System.Drawing.Point(0, 406);
            this.Pnl_Info.Name = "Pnl_Info";
            this.Pnl_Info.Size = new System.Drawing.Size(800, 44);
            this.Pnl_Info.TabIndex = 0;
            // 
            // Lbl_ErrorMessage
            // 
            this.Lbl_ErrorMessage.AutoSize = true;
            this.Lbl_ErrorMessage.Location = new System.Drawing.Point(12, 15);
            this.Lbl_ErrorMessage.Name = "Lbl_ErrorMessage";
            this.Lbl_ErrorMessage.Size = new System.Drawing.Size(37, 13);
            this.Lbl_ErrorMessage.TabIndex = 0;
            this.Lbl_ErrorMessage.Text = "- Info -";
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Pnl_Info);
            this.Name = "Form_Main";
            this.Text = "NvPipe Example";
            this.Pnl_Info.ResumeLayout(false);
            this.Pnl_Info.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Pnl_Info;
        private System.Windows.Forms.Label Lbl_ErrorMessage;
    }
}

