namespace PSS_Final.Forms
{
    partial class UserForm
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
            this.childFormPanel = new System.Windows.Forms.Panel();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.logOutBtn = new System.Windows.Forms.Button();
            this.logoPanel = new System.Windows.Forms.Panel();
            this.logoHomeBtn = new System.Windows.Forms.PictureBox();
            this.attendanceBtn = new FontAwesome.Sharp.IconButton();
            this.accountInfoBtn = new FontAwesome.Sharp.IconButton();
            this.upPanel = new System.Windows.Forms.Panel();
            this.homePageUsernameLabel = new System.Windows.Forms.Label();
            this.smallAvatar = new System.Windows.Forms.PictureBox();
            this.dateTime = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.leftPanel.SuspendLayout();
            this.logoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoHomeBtn)).BeginInit();
            this.upPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smallAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // childFormPanel
            // 
            this.childFormPanel.Location = new System.Drawing.Point(271, 95);
            this.childFormPanel.Name = "childFormPanel";
            this.childFormPanel.Size = new System.Drawing.Size(1185, 684);
            this.childFormPanel.TabIndex = 5;
            // 
            // leftPanel
            // 
            this.leftPanel.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.leftPanel.Controls.Add(this.logOutBtn);
            this.leftPanel.Controls.Add(this.logoPanel);
            this.leftPanel.Controls.Add(this.attendanceBtn);
            this.leftPanel.Controls.Add(this.accountInfoBtn);
            this.leftPanel.Location = new System.Drawing.Point(0, 0);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(271, 779);
            this.leftPanel.TabIndex = 3;
            // 
            // logOutBtn
            // 
            this.logOutBtn.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.logOutBtn.Location = new System.Drawing.Point(12, 728);
            this.logOutBtn.Name = "logOutBtn";
            this.logOutBtn.Size = new System.Drawing.Size(115, 38);
            this.logOutBtn.TabIndex = 4;
            this.logOutBtn.Text = "Log Out";
            this.logOutBtn.UseVisualStyleBackColor = true;
            this.logOutBtn.Click += new System.EventHandler(this.logOutBtn_Click_1);
            // 
            // logoPanel
            // 
            this.logoPanel.Controls.Add(this.logoHomeBtn);
            this.logoPanel.Location = new System.Drawing.Point(0, 0);
            this.logoPanel.Name = "logoPanel";
            this.logoPanel.Size = new System.Drawing.Size(271, 141);
            this.logoPanel.TabIndex = 3;
            this.logoPanel.Click += new System.EventHandler(this.logoHomeBtn_Click);
            // 
            // logoHomeBtn
            // 
            this.logoHomeBtn.ImageLocation = "C:\\Users\\kinto\\C#Dev\\PSS_Final\\img\\spse.png";
            this.logoHomeBtn.InitialImage = null;
            this.logoHomeBtn.Location = new System.Drawing.Point(65, 0);
            this.logoHomeBtn.Name = "logoHomeBtn";
            this.logoHomeBtn.Size = new System.Drawing.Size(141, 141);
            this.logoHomeBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoHomeBtn.TabIndex = 0;
            this.logoHomeBtn.TabStop = false;
            this.logoHomeBtn.Click += new System.EventHandler(this.logoHomeBtn_Click);
            // 
            // attendanceBtn
            // 
            this.attendanceBtn.FlatAppearance.BorderSize = 0;
            this.attendanceBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.attendanceBtn.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.attendanceBtn.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attendanceBtn.IconChar = FontAwesome.Sharp.IconChar.CalendarAlt;
            this.attendanceBtn.IconColor = System.Drawing.Color.Black;
            this.attendanceBtn.IconSize = 30;
            this.attendanceBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.attendanceBtn.Location = new System.Drawing.Point(0, 226);
            this.attendanceBtn.Name = "attendanceBtn";
            this.attendanceBtn.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.attendanceBtn.Rotation = 0D;
            this.attendanceBtn.Size = new System.Drawing.Size(271, 57);
            this.attendanceBtn.TabIndex = 2;
            this.attendanceBtn.Text = "Attendance";
            this.attendanceBtn.UseVisualStyleBackColor = true;
            this.attendanceBtn.Click += new System.EventHandler(this.attendanceBtn_Click);
            // 
            // accountInfoBtn
            // 
            this.accountInfoBtn.FlatAppearance.BorderSize = 0;
            this.accountInfoBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.accountInfoBtn.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.accountInfoBtn.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountInfoBtn.IconChar = FontAwesome.Sharp.IconChar.User;
            this.accountInfoBtn.IconColor = System.Drawing.Color.Black;
            this.accountInfoBtn.IconSize = 30;
            this.accountInfoBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.accountInfoBtn.Location = new System.Drawing.Point(0, 163);
            this.accountInfoBtn.Name = "accountInfoBtn";
            this.accountInfoBtn.Padding = new System.Windows.Forms.Padding(20, 0, 10, 0);
            this.accountInfoBtn.Rotation = 0D;
            this.accountInfoBtn.Size = new System.Drawing.Size(271, 57);
            this.accountInfoBtn.TabIndex = 0;
            this.accountInfoBtn.Text = "Account Information";
            this.accountInfoBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.accountInfoBtn.UseVisualStyleBackColor = true;
            this.accountInfoBtn.Click += new System.EventHandler(this.accountInfoBtn_Click);
            // 
            // upPanel
            // 
            this.upPanel.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.upPanel.Controls.Add(this.homePageUsernameLabel);
            this.upPanel.Controls.Add(this.smallAvatar);
            this.upPanel.Controls.Add(this.dateTime);
            this.upPanel.Location = new System.Drawing.Point(271, 0);
            this.upPanel.Name = "upPanel";
            this.upPanel.Size = new System.Drawing.Size(1185, 95);
            this.upPanel.TabIndex = 4;
            // 
            // homePageUsernameLabel
            // 
            this.homePageUsernameLabel.AutoSize = true;
            this.homePageUsernameLabel.Font = new System.Drawing.Font("Segoe UI Symbol", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.homePageUsernameLabel.Location = new System.Drawing.Point(810, 23);
            this.homePageUsernameLabel.Name = "homePageUsernameLabel";
            this.homePageUsernameLabel.Size = new System.Drawing.Size(120, 50);
            this.homePageUsernameLabel.TabIndex = 2;
            this.homePageUsernameLabel.Text = "label1";
            // 
            // smallAvatar
            // 
            this.smallAvatar.Location = new System.Drawing.Point(704, 12);
            this.smallAvatar.Name = "smallAvatar";
            this.smallAvatar.Size = new System.Drawing.Size(100, 77);
            this.smallAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.smallAvatar.TabIndex = 1;
            this.smallAvatar.TabStop = false;
            // 
            // dateTime
            // 
            this.dateTime.AutoSize = true;
            this.dateTime.Font = new System.Drawing.Font("Segoe UI Symbol", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTime.Location = new System.Drawing.Point(6, 23);
            this.dateTime.Name = "dateTime";
            this.dateTime.Size = new System.Drawing.Size(107, 45);
            this.dateTime.TabIndex = 0;
            this.dateTime.Text = "label1";
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1456, 778);
            this.Controls.Add(this.childFormPanel);
            this.Controls.Add(this.leftPanel);
            this.Controls.Add(this.upPanel);
            this.Name = "UserForm";
            this.Text = "User GUI";
            this.leftPanel.ResumeLayout(false);
            this.logoPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logoHomeBtn)).EndInit();
            this.upPanel.ResumeLayout(false);
            this.upPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smallAvatar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel childFormPanel;
        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Button logOutBtn;
        private System.Windows.Forms.Panel logoPanel;
        private System.Windows.Forms.PictureBox logoHomeBtn;
        private FontAwesome.Sharp.IconButton attendanceBtn;
        private FontAwesome.Sharp.IconButton accountInfoBtn;
        private System.Windows.Forms.Panel upPanel;
        private System.Windows.Forms.Label homePageUsernameLabel;
        private System.Windows.Forms.PictureBox smallAvatar;
        private System.Windows.Forms.Label dateTime;
        private System.Windows.Forms.Timer timer;
    }
}