namespace PSS_Final.Controls
{
    partial class AttendanceControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.nameLabel = new System.Windows.Forms.Label();
            this.dateTimeLabel = new System.Windows.Forms.Label();
            this.comeOrLeaveLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nameLabel.Location = new System.Drawing.Point(26, 24);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(64, 25);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "label1";
            // 
            // dateTimeLabel
            // 
            this.dateTimeLabel.AutoSize = true;
            this.dateTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dateTimeLabel.Location = new System.Drawing.Point(617, 24);
            this.dateTimeLabel.Name = "dateTimeLabel";
            this.dateTimeLabel.Size = new System.Drawing.Size(64, 25);
            this.dateTimeLabel.TabIndex = 2;
            this.dateTimeLabel.Text = "label1";
            // 
            // comeOrLeaveLabel
            // 
            this.comeOrLeaveLabel.AutoSize = true;
            this.comeOrLeaveLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comeOrLeaveLabel.Location = new System.Drawing.Point(973, 24);
            this.comeOrLeaveLabel.Name = "comeOrLeaveLabel";
            this.comeOrLeaveLabel.Size = new System.Drawing.Size(64, 25);
            this.comeOrLeaveLabel.TabIndex = 3;
            this.comeOrLeaveLabel.Text = "label1";
            // 
            // AttendanceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.comeOrLeaveLabel);
            this.Controls.Add(this.dateTimeLabel);
            this.Controls.Add(this.nameLabel);
            this.Name = "AttendanceControl";
            this.Size = new System.Drawing.Size(1119, 69);
            this.MouseLeave += new System.EventHandler(this.AttendanceControl_MouseLeave);
            this.MouseHover += new System.EventHandler(this.AttendanceControl_MouseHover);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label dateTimeLabel;
        private System.Windows.Forms.Label comeOrLeaveLabel;
    }
}
