namespace WinFormsClient.User_types
{
    partial class Helpdesk
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
            this.TicketsBox = new System.Windows.Forms.CheckedListBox();
            this.TicketsLabel = new System.Windows.Forms.Label();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.DescBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.NoteBox = new System.Windows.Forms.TextBox();
            this.StatusBox = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Save = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TicketsBox
            // 
            this.TicketsBox.FormattingEnabled = true;
            this.TicketsBox.Location = new System.Drawing.Point(12, 59);
            this.TicketsBox.Name = "TicketsBox";
            this.TicketsBox.Size = new System.Drawing.Size(162, 310);
            this.TicketsBox.TabIndex = 2;
            this.TicketsBox.SelectedIndexChanged += new System.EventHandler(this.TicketsBox_SelectedIndexChanged);
            // 
            // TicketsLabel
            // 
            this.TicketsLabel.AutoSize = true;
            this.TicketsLabel.Location = new System.Drawing.Point(12, 33);
            this.TicketsLabel.Name = "TicketsLabel";
            this.TicketsLabel.Size = new System.Drawing.Size(46, 15);
            this.TicketsLabel.TabIndex = 3;
            this.TicketsLabel.Text = "Tickets:";
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(180, 59);
            this.NameBox.Multiline = true;
            this.NameBox.Name = "NameBox";
            this.NameBox.ReadOnly = true;
            this.NameBox.Size = new System.Drawing.Size(211, 49);
            this.NameBox.TabIndex = 4;
            // 
            // DescBox
            // 
            this.DescBox.Location = new System.Drawing.Point(180, 149);
            this.DescBox.Multiline = true;
            this.DescBox.Name = "DescBox";
            this.DescBox.ReadOnly = true;
            this.DescBox.Size = new System.Drawing.Size(211, 220);
            this.DescBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(180, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(180, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Description:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(397, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Note:";
            // 
            // NoteBox
            // 
            this.NoteBox.Location = new System.Drawing.Point(397, 59);
            this.NoteBox.Multiline = true;
            this.NoteBox.Name = "NoteBox";
            this.NoteBox.Size = new System.Drawing.Size(211, 310);
            this.NoteBox.TabIndex = 9;
            // 
            // StatusBox
            // 
            this.StatusBox.FormattingEnabled = true;
            this.StatusBox.Location = new System.Drawing.Point(614, 59);
            this.StatusBox.Name = "StatusBox";
            this.StatusBox.Size = new System.Drawing.Size(162, 310);
            this.StatusBox.TabIndex = 10;
            this.StatusBox.SelectedIndexChanged += new System.EventHandler(this.StatusBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(614, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Status";
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(12, 375);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(764, 23);
            this.Save.TabIndex = 12;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logOutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.logOutToolStripMenuItem.Text = "Log out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // Helpdesk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 515);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.StatusBox);
            this.Controls.Add(this.NoteBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DescBox);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.TicketsLabel);
            this.Controls.Add(this.TicketsBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(800, 400);
            this.Name = "Helpdesk";
            this.Text = "Helpdesk";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox TicketsBox;
        private System.Windows.Forms.Label TicketsLabel;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.TextBox DescBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox NoteBox;
        private System.Windows.Forms.CheckedListBox StatusBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
    }
}