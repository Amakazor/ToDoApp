namespace WinFormsClient.User_types
{
    partial class User
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.newTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Fname = new System.Windows.Forms.Label();
            this.Lname = new System.Windows.Forms.Label();
            this.Uname = new System.Windows.Forms.Label();
            this.Pass = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Createtask = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.editTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newTaskToolStripMenuItem,
            this.editTaskToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.logOutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(719, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // newTaskToolStripMenuItem
            // 
            this.newTaskToolStripMenuItem.Name = "newTaskToolStripMenuItem";
            this.newTaskToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.newTaskToolStripMenuItem.Text = "New Task";
            this.newTaskToolStripMenuItem.Click += new System.EventHandler(this.newTaskToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.logOutToolStripMenuItem.Text = "Log out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(10, 51);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(251, 23);
            this.textBox1.TabIndex = 1;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(10, 91);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(251, 155);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Title:";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Description:";
            // 
            // Fname
            // 
            this.Fname.AutoSize = true;
            this.Fname.Location = new System.Drawing.Point(603, 40);
            this.Fname.Name = "Fname";
            this.Fname.Size = new System.Drawing.Size(59, 15);
            this.Fname.TabIndex = 5;
            this.Fname.Text = "Firstname";
            // 
            // Lname
            // 
            this.Lname.AutoSize = true;
            this.Lname.Location = new System.Drawing.Point(602, 59);
            this.Lname.Name = "Lname";
            this.Lname.Size = new System.Drawing.Size(58, 15);
            this.Lname.TabIndex = 6;
            this.Lname.Text = "Lastname";
            // 
            // Uname
            // 
            this.Uname.AutoSize = true;
            this.Uname.Location = new System.Drawing.Point(603, 80);
            this.Uname.Name = "Uname";
            this.Uname.Size = new System.Drawing.Size(60, 15);
            this.Uname.TabIndex = 7;
            this.Uname.Text = "Username";
            // 
            // Pass
            // 
            this.Pass.AutoSize = true;
            this.Pass.Location = new System.Drawing.Point(625, 97);
            this.Pass.Name = "Pass";
            this.Pass.Size = new System.Drawing.Size(57, 15);
            this.Pass.TabIndex = 8;
            this.Pass.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(531, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Firstname:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(531, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Lastname:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(531, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Username:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(531, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "Password hash:";
            // 
            // Createtask
            // 
            this.Createtask.Location = new System.Drawing.Point(10, 254);
            this.Createtask.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Createtask.Name = "Createtask";
            this.Createtask.Size = new System.Drawing.Size(250, 22);
            this.Createtask.TabIndex = 13;
            this.Createtask.Text = "Create new task";
            this.Createtask.UseVisualStyleBackColor = true;
            this.Createtask.Click += new System.EventHandler(this.Createtask_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(291, 51);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(189, 220);
            this.checkedListBox1.TabIndex = 14;
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(291, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(157, 15);
            this.label7.TabIndex = 15;
            this.label7.Text = "Select one name in task lists:";
            this.label7.Visible = false;
            // 
            // editTaskToolStripMenuItem
            // 
            this.editTaskToolStripMenuItem.Name = "editTaskToolStripMenuItem";
            this.editTaskToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.editTaskToolStripMenuItem.Text = "Edit Task";
            // 
            // User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 675);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.Createtask);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Pass);
            this.Controls.Add(this.Uname);
            this.Controls.Add(this.Lname);
            this.Controls.Add(this.Fname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "User";
            this.Text = "User";
            this.Load += new System.EventHandler(this.User_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newTaskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Fname;
        private System.Windows.Forms.Label Lname;
        private System.Windows.Forms.Label Uname;
        private System.Windows.Forms.Label Pass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button Createtask;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripMenuItem editTaskToolStripMenuItem;
    }
}