using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsClient.User_types
{
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
            label1.Visible = false;
            textBox1.Visible = false;
            label2.Visible = false;
            richTextBox1.Visible = false;
            Createtask.Visible = false;
            label3.Visible = false;
            Fname.Visible = false;
            label4.Visible = false;
            Lname.Visible = false;
            label5.Visible = false;
            Uname.Visible = false;
            label6.Visible = false;
            Pass.Visible = false;
        }
        private void Show (int i)
        {
            switch (i)
            {
                case 0:
                    label1.Visible = true;
                    textBox1.Visible = true;
                    label2.Visible = true;
                    richTextBox1.Visible = true;
                    Createtask.Visible = true;

                    label3.Visible = false;
                    Fname.Visible = false;
                    label4.Visible = false;
                    Lname.Visible = false;
                    label5.Visible = false;
                    Uname.Visible = false;
                    label6.Visible = false;
                    Pass.Visible = false;
                    break;
                case 1:
                    label1.Visible = false;
                    textBox1.Visible = false;
                    label2.Visible = false;
                    richTextBox1.Visible = false;
                    Createtask.Visible = false;

                    label3.Visible = true;
                    Fname.Visible = true;
                    label4.Visible = true;
                    Lname.Visible = true;
                    label5.Visible = true;
                    Uname.Visible = true;
                    label6.Visible = true;
                    Pass.Visible = true;
                    break;
                case 2:
                    label1.Visible = false;
                    textBox1.Visible = false;
                    label2.Visible = false;
                    richTextBox1.Visible = false;
                    Createtask.Visible = false;

                    label3.Visible = false;
                    Fname.Visible = false;
                    label4.Visible = false;
                    Lname.Visible = false;
                    label5.Visible = false;
                    Uname.Visible = false;
                    label6.Visible = false;
                    Pass.Visible = false;
                    break;
                default:
                    break;

            }              
                
        }
        private void User_Load(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void newTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show(0);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show(1);
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show(2);
            this.Close();
        }
    }
}
