namespace PSS_Final.Controls
{
    partial class UsersControl
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
            this.userImage = new System.Windows.Forms.PictureBox();
            this.userName = new System.Windows.Forms.Label();
            this.userRole = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.userImage)).BeginInit();
            this.SuspendLayout();
            // 
            // userImage
            // 
            this.userImage.Location = new System.Drawing.Point(12, 12);
            this.userImage.Name = "userImage";
            this.userImage.Size = new System.Drawing.Size(100, 100);
            this.userImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.userImage.TabIndex = 0;
            this.userImage.TabStop = false;
            this.userImage.Click += new System.EventHandler(this.UsersControl_OnClick);
            // 
            // userName
            // 
            this.userName.AutoSize = true;
            this.userName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.userName.Location = new System.Drawing.Point(154, 12);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(92, 32);
            this.userName.TabIndex = 1;
            this.userName.Text = "label1";
            this.userName.Click += new System.EventHandler(this.UsersControl_OnClick);
            // 
            // userRole
            // 
            this.userRole.AutoSize = true;
            this.userRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.userRole.Location = new System.Drawing.Point(154, 80);
            this.userRole.Name = "userRole";
            this.userRole.Size = new System.Drawing.Size(92, 32);
            this.userRole.TabIndex = 2;
            this.userRole.Text = "label2";
            this.userRole.Click += new System.EventHandler(this.UsersControl_OnClick);
            // 
            // UsersControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.userRole);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.userImage);
            this.Name = "UsersControl";
            this.Size = new System.Drawing.Size(495, 123);
            this.Click += new System.EventHandler(this.UsersControl_OnClick);
            ((System.ComponentModel.ISupportInitialize)(this.userImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox userImage;
        private System.Windows.Forms.Label userName;
        private System.Windows.Forms.Label userRole;
    }
}
