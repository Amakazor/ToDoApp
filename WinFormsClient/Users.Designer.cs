﻿namespace WinFormsClient
{
    partial class Users
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
            this.label1 = new System.Windows.Forms.Label();
            this.User = new System.Windows.Forms.Button();
            this.Admin = new System.Windows.Forms.Button();
            this.Helpdesk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select user type ";
            // 
            // User
            // 
            this.User.Location = new System.Drawing.Point(19, 49);
            this.User.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.User.Name = "User";
            this.User.Size = new System.Drawing.Size(173, 31);
            this.User.TabIndex = 1;
            this.User.Text = "User";
            this.User.UseVisualStyleBackColor = true;
            this.User.Click += new System.EventHandler(this.User_Click);
            // 
            // Admin
            // 
            this.Admin.Location = new System.Drawing.Point(19, 88);
            this.Admin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Admin.Name = "Admin";
            this.Admin.Size = new System.Drawing.Size(173, 31);
            this.Admin.TabIndex = 2;
            this.Admin.Text = "Admin";
            this.Admin.UseVisualStyleBackColor = true;
            this.Admin.Click += new System.EventHandler(this.Admin_Click);
            // 
            // Helpdesk
            // 
            this.Helpdesk.Location = new System.Drawing.Point(19, 127);
            this.Helpdesk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Helpdesk.Name = "Helpdesk";
            this.Helpdesk.Size = new System.Drawing.Size(173, 31);
            this.Helpdesk.TabIndex = 3;
            this.Helpdesk.Text = "Helpdesk";
            this.Helpdesk.UseVisualStyleBackColor = true;
            this.Helpdesk.Click += new System.EventHandler(this.Helpdesk_Click);
            // 
            // Users
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(221, 182);
            this.Controls.Add(this.Helpdesk);
            this.Controls.Add(this.Admin);
            this.Controls.Add(this.User);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Users";
            this.Text = "Users";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button User;
        private System.Windows.Forms.Button Admin;
        private System.Windows.Forms.Button Helpdesk;
    }
}