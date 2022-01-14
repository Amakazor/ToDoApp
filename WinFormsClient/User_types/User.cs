using System;
using System.ComponentModel;
using System.Windows.Forms;
using Common.Communication.Requests;
using Microsoft.VisualBasic;

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
            checkedListBox1.Visible = false;
            label7.Visible = false;
            SocketClient client = new(Form1.ip_address, Form1.port);
            client.SendRequest(new TasklistGetRequest(Users.login,Users.password));
            /*
            for (int i = 0; i < SocketClient.tab.Length; i++)
            {
                if (SocketClient.tab[i,0] != null)
                    checkedListBox1.Items.Insert(0, SocketClient.tab[i,0]);
            }*/
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
                    checkedListBox1.Visible = true;
                    label7.Visible = true;

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
                    checkedListBox1.Visible = false;
                    label7.Visible = false;

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
                    checkedListBox1.Visible = false;
                    label7.Visible = false;

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
            
            Fname.Text = SocketClient.First_name.ToString();
            Lname.Text = SocketClient.Last_name.ToString();
            Uname.Text = SocketClient.User_name.ToString();
            Pass.Text = SocketClient.User_password.ToString();
            Show(1);
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show(2);
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int iSelectedIndex = checkedListBox1.SelectedIndex;
            if (iSelectedIndex == -1)
                return;
            for (int iIndex = 0; iIndex < checkedListBox1.Items.Count; iIndex++)
                checkedListBox1.SetItemCheckState(iIndex, CheckState.Unchecked);
            checkedListBox1.SetItemCheckState(iSelectedIndex, CheckState.Checked);
        }

        private void Createtask_Click(object sender, EventArgs e)
        {
            string a = "";
            for (int x = 0; x < checkedListBox1.CheckedItems.Count; x++)
            {
                a = checkedListBox1.CheckedItems[x].ToString();
            }
            if (textBox1.Text == "")
            {
                string input = Interaction.InputBox("Enter title", "Wrong title, try again.", "default title", 10, 10);
                textBox1.Text = input;
            }
            else if (richTextBox1.Text == "")
            {
                string input = Interaction.InputBox("Enter description", "Wrong description, try again.", "default description", 10, 10);
                richTextBox1.Text = input;
            }
            else if(a == "")
            {
                MessageBox.Show("Enter item in taks list");
            }
            else
            {

            }
        }
    }
}
