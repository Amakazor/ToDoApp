using System;
using System.Linq;
using System.ComponentModel;
using System.Windows.Forms;
using Common.Communication.Requests;
using Microsoft.VisualBasic;

namespace WinFormsClient.User_types
{
    public partial class User : Form
    {
            SocketClient client = new(Form1.ip_address, Form1.port);

        private int index = -1;
        public User()
        {
            InitializeComponent();
            DataStore.Instance.TakListsChanged += Instance_TakListsChanged;

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
            checkedListBox2.Visible = false;
            checkedListBox3.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            checkedListBox4.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            label9.Visible = false;
            textBox4.Visible = false;
            label8.Visible = false;
            richTextBox2.Visible = false;
            button4.Visible = false;
            client.SendRequest(new TasklistGetRequest(Users.login,Users.password));





            /*
            for (int i = 0; i < SocketClient.tab.Length; i++)
            {
                if (SocketClient.tab[i,0] != null)
                    checkedListBox1.Items.Insert(0, SocketClient.tab[i,0]);
            }*/
        }

        private void Instance_TakListsChanged(object sender, TasklistsChangedEventArgs e)
        {
            checkedListBox1.Items.Clear();
            checkedListBox2.Items.Clear();
            checkedListBox3.Items.Clear();
            checkedListBox4.Items.Clear();
            //throw new NotImplementedException();OrderByDescending(t => t.TaskId).ToList()
            foreach (Common.Models.Tasklist i in e.Tasklists.OrderByDescending(t => t.TaskListID).ToList())
            {
                //i.Name
                checkedListBox1.Items.Insert(0, i.Name);
                checkedListBox2.Items.Insert(0, i.Name);               
            }
            
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

                    checkedListBox2.Visible = false;
                    checkedListBox3.Visible = false;
                    textBox2.Visible = false;
                    textBox3.Visible = false;
                    checkedListBox4.Visible = false;
                    button1.Visible = false;
                    button2.Visible = false;
                    button3.Visible = false;

                    label9.Visible = false;
                    textBox4.Visible = false;
                    label8.Visible = false;
                    richTextBox2.Visible = false;
                    button4.Visible = false;
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

                    checkedListBox2.Visible = false;
                    checkedListBox3.Visible = false;
                    textBox2.Visible = false;
                    textBox3.Visible = false;
                    checkedListBox4.Visible = false;
                    button1.Visible = false;
                    button2.Visible = false;
                    button3.Visible = false;

                    label9.Visible = false;
                    textBox4.Visible = false;
                    label8.Visible = false;
                    richTextBox2.Visible = false;
                    button4.Visible = false;
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

                    checkedListBox2.Visible = false;
                    checkedListBox3.Visible = false;
                    textBox2.Visible = false;
                    textBox3.Visible = false;
                    checkedListBox4.Visible = false;
                    button1.Visible = false;
                    button2.Visible = false;
                    button3.Visible = false;

                    label9.Visible = false;
                    textBox4.Visible = false;
                    label8.Visible = false;
                    richTextBox2.Visible = false;
                    button4.Visible = false;
                    break;
                case 3:
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

                    checkedListBox2.Visible = true;
                    checkedListBox3.Visible = true;
                    textBox2.Visible = true;
                    textBox3.Visible = true;
                    checkedListBox4.Visible = true;
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;

                    label9.Visible = false;
                    textBox4.Visible = false;
                    label8.Visible = false;
                    richTextBox2.Visible = false;
                    button4.Visible = false;
                    break;
                    case 4:
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

                    checkedListBox2.Visible = false;
                    checkedListBox3.Visible = false;
                    textBox2.Visible = false;
                    textBox3.Visible = false;
                    checkedListBox4.Visible = false;
                    button1.Visible = false;
                    button2.Visible = false;
                    button3.Visible = false;

                    label9.Visible = true;
                    textBox4.Visible = true;
                    label8.Visible = true;
                    richTextBox2.Visible = true;
                    button4.Visible = true;
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
                //public TaskAddRequest(string username, string password, Task task, Tasklist tasklist)
                client.SendRequest(new TaskAddRequest(Users.login, Users.password, new Common.Models.Task(textBox1.Text, richTextBox1.Text, new Common.Models.User(SocketClient.User_name, SocketClient.User_password) { UserID = SocketClient.Id}, DataStore.Instance.AllTasklists [checkedListBox1.SelectedIndex].TaskStatuses.First()), DataStore.Instance.AllTasklists[checkedListBox1.SelectedIndex]));
            }
        }

        private void editTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show(3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //client.SendRequest(new TaskAddRequest(Users.login, Users.password, new Common.Models.Task(textBox1.Text, richTextBox1.Text, new Common.Models.User(SocketClient.User_name, SocketClient.User_password) { UserID = SocketClient.Id }, DataStore.Instance.AllTasklists[checkedListBox1.SelectedIndex].TaskStatuses.First()), DataStore.Instance.AllTasklists[checkedListBox1.SelectedIndex]));
            client.SendRequest(new TaskUpdateRequest(Users.login, Users.password, new Common.Models.Task(textBox2.Text, textBox3.Text, new Common.Models.User(SocketClient.User_name, SocketClient.User_password ) { UserID = SocketClient.Id}, DataStore.Instance.AllTasklists[checkedListBox2.SelectedIndex].TaskStatuses.OrderBy(t => t.TaskStatusID).ToList()[checkedListBox4.SelectedIndex]) { TaskId = DataStore.Instance.AllTasklists[checkedListBox2.SelectedIndex].Tasks.OrderBy(t => t.TaskId).ToList()[checkedListBox3.SelectedIndex].TaskId}, DataStore.Instance.AllTasklists[checkedListBox2.SelectedIndex]));
            index = -1;
        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int iSelectedIndex = checkedListBox2.SelectedIndex;
            if (iSelectedIndex == -1)
                return;
            for (int iIndex = 0; iIndex < checkedListBox2.Items.Count; iIndex++)
                checkedListBox2.SetItemCheckState(iIndex, CheckState.Unchecked);
            checkedListBox2.SetItemCheckState(iSelectedIndex, CheckState.Checked);

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (checkedListBox2.SelectedIndex != -1)
            {
                if (index != checkedListBox2.SelectedIndex)
                {
                    index = checkedListBox2.SelectedIndex;
                    checkedListBox4.Items.Clear();
                    checkedListBox3.Items.Clear();

                    foreach (Common.Models.Task i in DataStore.Instance.AllTasklists[checkedListBox2.SelectedIndex].Tasks.OrderByDescending(t => t.TaskId).ToList())
                    {
                        checkedListBox3.Items.Insert(0, i.Name);
                    }
                    foreach (Common.Models.TaskStatus i in DataStore.Instance.AllTasklists[checkedListBox2.SelectedIndex].TaskStatuses.OrderByDescending(t => t.TaskStatusID).ToList())
                    {
                        checkedListBox4.Items.Insert(0, i.Name);

                    }
                }
                    if ((checkedListBox3.SelectedIndex != -1) && (checkedListBox4.SelectedIndex != -1))
                    {
                        Common.Models.Task I = DataStore.Instance.AllTasklists[checkedListBox2.SelectedIndex].Tasks.OrderBy(t => t.TaskId).ToList()[checkedListBox3.SelectedIndex];
                        textBox2.Text = I.Name;
                        textBox3.Text = I.Description;
                        //I.Name = textBox2.Text;
                        //I.Description = textBox3.Text;
                    }
                /*
                    foreach (Common.Models.Task i in DataStore.Instance.AllTasklists[checkedListBox3.SelectedIndex].Tasks)
                
                    textBox2.Text = i.Name;
                    textBox3.Text = i.Description;*/
                
            }
            else
            {
                MessageBox.Show("Select Task list");
            }
        }

        private void checkedListBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

            int iSelectedIndex = checkedListBox3.SelectedIndex;
            if (iSelectedIndex == -1)
                return;
            for (int iIndex = 0; iIndex < checkedListBox3.Items.Count; iIndex++)
                checkedListBox3.SetItemCheckState(iIndex, CheckState.Unchecked);
            checkedListBox3.SetItemCheckState(iSelectedIndex, CheckState.Checked);
        }

        private void checkedListBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            int iSelectedIndex = checkedListBox4.SelectedIndex;
            if (iSelectedIndex == -1)
                return;
            for (int iIndex = 0; iIndex < checkedListBox4.Items.Count; iIndex++)
                checkedListBox4.SetItemCheckState(iIndex, CheckState.Unchecked);
            checkedListBox4.SetItemCheckState(iSelectedIndex, CheckState.Checked);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            client.SendRequest(new TaskDeleteRequest(Users.login, Users.password, new Common.Models.Task(textBox2.Text, textBox3.Text, new Common.Models.User(SocketClient.User_name, SocketClient.User_password) { UserID = SocketClient.Id }, DataStore.Instance.AllTasklists[checkedListBox2.SelectedIndex].TaskStatuses.OrderBy(t => t.TaskStatusID).ToList()[checkedListBox4.SelectedIndex]) { TaskId = DataStore.Instance.AllTasklists[checkedListBox2.SelectedIndex].Tasks.OrderBy(t => t.TaskId).ToList()[checkedListBox3.SelectedIndex].TaskId }, DataStore.Instance.AllTasklists[checkedListBox2.SelectedIndex]));           
            index = -1;
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void sendTicketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show(4);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            client.SendRequest(new TickedAddRequest(Users.login, Users.password, new Common.Models.Ticket(textBox4.Text, richTextBox2.Text, new Common.Models.User(Users.login, Users.password), Common.Models.Enums.TicketStatus.INACTIVE)));
        }
    }
}
