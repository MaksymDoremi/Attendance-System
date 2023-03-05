namespace PSS_Final.Forms.UserDashboardForms
{
    partial class UserAttendanceForm
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
            this.attendanceFlowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // attendanceFlowLayout
            // 
            this.attendanceFlowLayout.AutoScroll = true;
            this.attendanceFlowLayout.BackColor = System.Drawing.SystemColors.Control;
            this.attendanceFlowLayout.Location = new System.Drawing.Point(12, 89);
            this.attendanceFlowLayout.Name = "attendanceFlowLayout";
            this.attendanceFlowLayout.Size = new System.Drawing.Size(1164, 592);
            this.attendanceFlowLayout.TabIndex = 0;
            // 
            // AttendanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1188, 684);
            this.Controls.Add(this.attendanceFlowLayout);
            this.Name = "AttendanceForm";
            this.Text = "AttendanceForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel attendanceFlowLayout;
    }
}