namespace PSS_Final.Forms.UserDashboardForms
{
    partial class UserAccountInformationForm
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
            this.nameLabel = new System.Windows.Forms.Label();
            this.surnameLabel = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.phoneLabel = new System.Windows.Forms.Label();
            this.bigAvatarPicture = new System.Windows.Forms.PictureBox();
            this.actualNameFromDB = new System.Windows.Forms.Label();
            this.actualSurnameFromDB = new System.Windows.Forms.Label();
            this.actualEmailFromDB = new System.Windows.Forms.Label();
            this.actualPhoneFromDB = new System.Windows.Forms.Label();
            this.roleLabel = new System.Windows.Forms.Label();
            this.actualRoleFromDB = new System.Windows.Forms.Label();
            this.changePasswordBtn = new System.Windows.Forms.Button();
            this.changeAccountInfoBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bigAvatarPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nameLabel.Location = new System.Drawing.Point(79, 72);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(110, 36);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name: ";
            // 
            // surnameLabel
            // 
            this.surnameLabel.AutoSize = true;
            this.surnameLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.surnameLabel.Location = new System.Drawing.Point(79, 140);
            this.surnameLabel.Name = "surnameLabel";
            this.surnameLabel.Size = new System.Drawing.Size(140, 36);
            this.surnameLabel.TabIndex = 1;
            this.surnameLabel.Text = "Surname:";
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.emailLabel.Location = new System.Drawing.Point(79, 205);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(92, 36);
            this.emailLabel.TabIndex = 2;
            this.emailLabel.Text = "Email:";
            // 
            // phoneLabel
            // 
            this.phoneLabel.AutoSize = true;
            this.phoneLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.phoneLabel.Location = new System.Drawing.Point(79, 268);
            this.phoneLabel.Name = "phoneLabel";
            this.phoneLabel.Size = new System.Drawing.Size(107, 36);
            this.phoneLabel.TabIndex = 3;
            this.phoneLabel.Text = "Phone:";
            // 
            // bigAvatarPicture
            // 
            this.bigAvatarPicture.Location = new System.Drawing.Point(784, 72);
            this.bigAvatarPicture.Name = "bigAvatarPicture";
            this.bigAvatarPicture.Size = new System.Drawing.Size(257, 312);
            this.bigAvatarPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bigAvatarPicture.TabIndex = 4;
            this.bigAvatarPicture.TabStop = false;
            // 
            // actualNameFromDB
            // 
            this.actualNameFromDB.AutoSize = true;
            this.actualNameFromDB.Font = new System.Drawing.Font("Microsoft YaHei UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.actualNameFromDB.Location = new System.Drawing.Point(296, 72);
            this.actualNameFromDB.Name = "actualNameFromDB";
            this.actualNameFromDB.Size = new System.Drawing.Size(0, 36);
            this.actualNameFromDB.TabIndex = 5;
            // 
            // actualSurnameFromDB
            // 
            this.actualSurnameFromDB.AutoSize = true;
            this.actualSurnameFromDB.Font = new System.Drawing.Font("Microsoft YaHei UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.actualSurnameFromDB.Location = new System.Drawing.Point(296, 140);
            this.actualSurnameFromDB.Name = "actualSurnameFromDB";
            this.actualSurnameFromDB.Size = new System.Drawing.Size(0, 36);
            this.actualSurnameFromDB.TabIndex = 6;
            // 
            // actualEmailFromDB
            // 
            this.actualEmailFromDB.AutoSize = true;
            this.actualEmailFromDB.Font = new System.Drawing.Font("Microsoft YaHei UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.actualEmailFromDB.Location = new System.Drawing.Point(296, 205);
            this.actualEmailFromDB.Name = "actualEmailFromDB";
            this.actualEmailFromDB.Size = new System.Drawing.Size(0, 36);
            this.actualEmailFromDB.TabIndex = 7;
            // 
            // actualPhoneFromDB
            // 
            this.actualPhoneFromDB.AutoSize = true;
            this.actualPhoneFromDB.Font = new System.Drawing.Font("Microsoft YaHei UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.actualPhoneFromDB.Location = new System.Drawing.Point(296, 268);
            this.actualPhoneFromDB.Name = "actualPhoneFromDB";
            this.actualPhoneFromDB.Size = new System.Drawing.Size(0, 36);
            this.actualPhoneFromDB.TabIndex = 8;
            // 
            // roleLabel
            // 
            this.roleLabel.AutoSize = true;
            this.roleLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.roleLabel.Location = new System.Drawing.Point(79, 338);
            this.roleLabel.Name = "roleLabel";
            this.roleLabel.Size = new System.Drawing.Size(81, 36);
            this.roleLabel.TabIndex = 9;
            this.roleLabel.Text = "Role:";
            // 
            // actualRoleFromDB
            // 
            this.actualRoleFromDB.AutoSize = true;
            this.actualRoleFromDB.Font = new System.Drawing.Font("Microsoft YaHei UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.actualRoleFromDB.Location = new System.Drawing.Point(296, 338);
            this.actualRoleFromDB.Name = "actualRoleFromDB";
            this.actualRoleFromDB.Size = new System.Drawing.Size(0, 36);
            this.actualRoleFromDB.TabIndex = 10;
            // 
            // changePasswordBtn
            // 
            this.changePasswordBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.changePasswordBtn.Location = new System.Drawing.Point(54, 530);
            this.changePasswordBtn.Name = "changePasswordBtn";
            this.changePasswordBtn.Size = new System.Drawing.Size(165, 77);
            this.changePasswordBtn.TabIndex = 11;
            this.changePasswordBtn.Text = "Change Password";
            this.changePasswordBtn.UseVisualStyleBackColor = true;
            this.changePasswordBtn.Click += new System.EventHandler(this.changePasswordBtn_Click);
            // 
            // changeAccountInfoBtn
            // 
            this.changeAccountInfoBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.changeAccountInfoBtn.Location = new System.Drawing.Point(258, 530);
            this.changeAccountInfoBtn.Name = "changeAccountInfoBtn";
            this.changeAccountInfoBtn.Size = new System.Drawing.Size(165, 77);
            this.changeAccountInfoBtn.TabIndex = 12;
            this.changeAccountInfoBtn.Text = "Change Account Info";
            this.changeAccountInfoBtn.UseVisualStyleBackColor = true;
            this.changeAccountInfoBtn.Click += new System.EventHandler(this.changeAccountInfoBtn_Click);
            // 
            // AccountInformationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1185, 684);
            this.Controls.Add(this.changeAccountInfoBtn);
            this.Controls.Add(this.changePasswordBtn);
            this.Controls.Add(this.actualRoleFromDB);
            this.Controls.Add(this.roleLabel);
            this.Controls.Add(this.actualPhoneFromDB);
            this.Controls.Add(this.actualEmailFromDB);
            this.Controls.Add(this.actualSurnameFromDB);
            this.Controls.Add(this.actualNameFromDB);
            this.Controls.Add(this.bigAvatarPicture);
            this.Controls.Add(this.phoneLabel);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.surnameLabel);
            this.Controls.Add(this.nameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AccountInformationForm";
            this.Text = "AccountInformationForm";

            ((System.ComponentModel.ISupportInitialize)(this.bigAvatarPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label surnameLabel;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Label phoneLabel;
        private System.Windows.Forms.PictureBox bigAvatarPicture;
        private System.Windows.Forms.Label actualNameFromDB;
        private System.Windows.Forms.Label actualSurnameFromDB;
        private System.Windows.Forms.Label actualEmailFromDB;
        private System.Windows.Forms.Label actualPhoneFromDB;
        private System.Windows.Forms.Label roleLabel;
        private System.Windows.Forms.Label actualRoleFromDB;
        private System.Windows.Forms.Button changePasswordBtn;
        private System.Windows.Forms.Button changeAccountInfoBtn;
    }
}