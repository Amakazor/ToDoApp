
namespace WinFormsClient
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Connect_button = new System.Windows.Forms.Button();
            this.Ip_address = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Port = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Status_Info = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Connect_button
            // 
            this.Connect_button.Location = new System.Drawing.Point(22, 157);
            this.Connect_button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Connect_button.Name = "Connect_button";
            this.Connect_button.Size = new System.Drawing.Size(250, 31);
            this.Connect_button.TabIndex = 0;
            this.Connect_button.Text = "Connect";
            this.Connect_button.UseVisualStyleBackColor = true;
            this.Connect_button.Click += new System.EventHandler(this.Connect_button_Click);
            // 
            // Ip_address
            // 
            this.Ip_address.Location = new System.Drawing.Point(109, 19);
            this.Ip_address.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Ip_address.Name = "Ip_address";
            this.Ip_address.Size = new System.Drawing.Size(163, 27);
            this.Ip_address.TabIndex = 1;
            this.Ip_address.TextChanged += new System.EventHandler(this.Ip_address_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP Address:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port:";
            // 
            // Port
            // 
            this.Port.Location = new System.Drawing.Point(109, 67);
            this.Port.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(53, 27);
            this.Port.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Status:";
            // 
            // Status_Info
            // 
            this.Status_Info.AutoSize = true;
            this.Status_Info.Location = new System.Drawing.Point(109, 120);
            this.Status_Info.Name = "Status_Info";
            this.Status_Info.Size = new System.Drawing.Size(15, 20);
            this.Status_Info.TabIndex = 6;
            this.Status_Info.Text = "_";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 205);
            this.Controls.Add(this.Status_Info);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Port);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Ip_address);
            this.Controls.Add(this.Connect_button);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Login User";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Connect_button;
        private System.Windows.Forms.TextBox Ip_address;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Port;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Status_Info;
    }
}

