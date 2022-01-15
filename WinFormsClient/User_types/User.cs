using System;
using System.Linq;
using System.ComponentModel;
using System.Windows.Forms;
using Common.Communication.Requests;
using Microsoft.VisualBasic;
using Common.Models;
using System.Drawing;
using Common.Models.Enums;

namespace WinFormsClient.User_types
{
    public partial class User : Form
    {
        SocketClient client = new(Form1.ip_address, Form1.port);

        private int index1 = -1;
        private int index2 = -1;
        private int index3 = -1;
        private int index6 = -1;
        private int index7 = -1;
        public User()
        {
            InitializeComponent();
            DataStore.Instance.TakListsChanged += Instance_TakListsChanged;
            HideAll();
            client.SendRequest(new TasklistGetRequest(Users.login, Users.password));

            Fname.Text = SocketClient.First_name.ToString();
            Lname.Text = SocketClient.Last_name.ToString();
            Uname.Text = SocketClient.User_name.ToString();
            Pass.Text = SocketClient.User_password.ToString();

            label3.Visible = true;
            Fname.Visible = true;
            label4.Visible = true;
            Lname.Visible = true;
            label5.Visible = true;
            Uname.Visible = true;
            label6.Visible = true;
            Pass.Visible = true;

        }

        private void HideAll()
        {
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
            label22.Visible = false;
            CreateStatusButton.Visible = false;
            label9.Visible = false;
            textBox4.Visible = false;
            label8.Visible = false;
            richTextBox2.Visible = false;
            button4.Visible = false;
            checkedListBox5.Visible = false;
            button6.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            button7.Visible = false;
            button5.Visible = false;
            label10.Visible = false;
            textBox5.Visible = false;
            ColorButton.Visible = false;
            ColorPanel.Visible = false;
            CreateStatusButton.Visible = false;
            CreateStatusTakListBox.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            StatusEditStatusBox.Visible = false;
            StatusEditTasklistBox.Visible = false;
            StatusEditName.Visible = false;
            StatusEditColorButton.Visible = false;
            StatusEditColorPanel.Visible = false;
            StatusSave.Visible = false;
            StatusDelete.Visible = false;
            button5.Visible = false;
            button9.Visible = false;
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
            label9.Visible = false;
            textBox4.Visible = false;
            label8.Visible = false;
            richTextBox2.Visible = false;
            button4.Visible = false;
            checkedListBox5.Visible = false;
            button6.Visible = false;
            textBox5.Visible = false;
            button7.Visible = false;
            button5.Visible = false;
            label15.Visible = false;
            label16.Visible = false;
            label17.Visible = false;
            label18.Visible = false;
            label19.Visible = false;
            label20.Visible = false;
            label21.Visible = false;
            checkedListBox6.Visible = false;
            label23.Visible = false;
        }

        private void ResetIndices()
        {
            index1 = -1;
            index2 = -1;
            index3 = -1;
            index6 = -1;
            index7 = -1;
        }

        private void Instance_TakListsChanged(object sender, TasklistsChangedEventArgs e)
        {
            checkedListBox1.Items.Clear();
            checkedListBox2.Items.Clear();
            checkedListBox3.Items.Clear();
            checkedListBox4.Items.Clear();
            CreateStatusTakListBox.Items.Clear();
            StatusEditTasklistBox.Items.Clear();
            StatusEditStatusBox.Items.Clear();

            foreach (Tasklist i in e.Tasklists.OrderByDescending(t => t.TaskListID).ToList())
            checkedListBox5.Items.Clear();
            foreach (Common.Models.Tasklist i in e.Tasklists.OrderByDescending(t => t.TaskListID).ToList())
            {
                checkedListBox1.Items.Insert(0, i.Name);
                checkedListBox2.Items.Insert(0, i.Name);               
                CreateStatusTakListBox.Items.Insert(0, i.Name);               
                StatusEditTasklistBox.Items.Insert(0, i.Name);               
                checkedListBox5.Items.Insert(0, i.Name);               
            }
        }

        private void Show (int i)
        {
            HideAll();
            ResetIndices();

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
                    checkedListBox6.Visible = true;
                    label23.Visible = true;
                    break;
                case 1:
                    label3.Visible = true;
                    Fname.Visible = true;
                    label4.Visible = true;
                    Lname.Visible = true;
                    label5.Visible = true;
                    Uname.Visible = true;
                    label6.Visible = true;
                    Pass.Visible = true;
                    break;
                case 3:
                    checkedListBox2.Visible = true;
                    checkedListBox3.Visible = true;
                    textBox2.Visible = true;
                    textBox3.Visible = true;
                    checkedListBox4.Visible = true;
                    button1.Visible = true;
                    button5.Visible = true;
                    label15.Visible = true;
                    label16.Visible = true;
                    label17.Visible = true;
                    label18.Visible = true;
                    label19.Visible = true;
                    break;
                case 4:
                    label9.Visible = true;
                    label8.Visible = true;
                    richTextBox2.Visible = true;
                    button4.Visible = true;
                    textBox5.Visible = true;
                    break;
                case 5:
                    checkedListBox5.Visible = true;
                    button6.Visible = true;
                    button7.Visible = true;
                    label22.Visible = true;
                    button9.Visible = true;
                    textBox7.Visible = true;
                    label21.Visible = true;
                    break;
                case 31:
                    label10.Visible = true;
                    ColorButton.Visible = true;
                    ColorPanel.Visible = true;
                    CreateStatusButton.Visible = true;
                    textBox4.Visible = true;
                    CreateStatusTakListBox.Visible = true;
                    break;
                case 32:
                    label11.Visible = true;
                    label12.Visible = true;
                    label20.Visible = true;
                    StatusEditStatusBox.Visible = true;
                    StatusEditTasklistBox.Visible = true;
                    StatusEditName.Visible = true;
                    StatusEditColorButton.Visible = true;
                    StatusEditColorPanel.Visible = true;
                    StatusSave.Visible = true;
                    break;
                case 33:
                    label11.Visible = true;
                    label12.Visible = true;
                    StatusEditStatusBox.Visible = true;
                    StatusEditTasklistBox.Visible = true;
                    StatusDelete.Visible = true;
                    break;
                default:
                    break;
            }              
                
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
            Close();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int iSelectedIndex = checkedListBox1.SelectedIndex;
            if (iSelectedIndex == -1)
                return;
            for (int iIndex = 0; iIndex < checkedListBox1.Items.Count; iIndex++)
                checkedListBox1.SetItemCheckState(iIndex, CheckState.Unchecked);
            checkedListBox1.SetItemCheckState(iSelectedIndex, CheckState.Checked);

            if (iSelectedIndex != -1)
            {
                if (index1 != iSelectedIndex)
                {
                    index1 = iSelectedIndex;
                    checkedListBox6.Items.Clear();

                    foreach (TaskStatus i in DataStore.Instance.AllTasklists[checkedListBox1.SelectedIndex].TaskStatuses.OrderByDescending(t => t.TaskStatusID).ToList())
                    {
                        checkedListBox6.Items.Insert(0, i.Name);
                    }
                }
            } 
            else
            {
                checkedListBox6.Items.Clear();
            }
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
                MessageBox.Show("Select item in taks list");
            }
            else if (checkedListBox6.SelectedIndex == -1)
            {
                MessageBox.Show("Celect item in the status list");
            }
            else
            {
                client.SendRequest(new TaskAddRequest(Users.login, Users.password, new Task(textBox1.Text, richTextBox1.Text, new Common.Models.User(SocketClient.User_name, SocketClient.User_password) { UserID = SocketClient.Id}, DataStore.Instance.AllTasklists [checkedListBox1.SelectedIndex].TaskStatuses.First()), DataStore.Instance.AllTasklists[checkedListBox1.SelectedIndex]));
                checkedListBox6.Items.Clear();
                ResetIndices();
            }
        }

        private void editTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show(3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
            client.SendRequest(new TaskUpdateRequest(Users.login, Users.password, new Common.Models.Task(textBox2.Text, textBox3.Text, new Common.Models.User(SocketClient.User_name, SocketClient.User_password ) { UserID = SocketClient.Id}, DataStore.Instance.AllTasklists[checkedListBox2.SelectedIndex].TaskStatuses.OrderBy(t => t.TaskStatusID).ToList()[checkedListBox4.SelectedIndex]) { TaskId = DataStore.Instance.AllTasklists[checkedListBox2.SelectedIndex].Tasks.OrderBy(t => t.TaskId).ToList()[checkedListBox3.SelectedIndex].TaskId}, DataStore.Instance.AllTasklists[checkedListBox2.SelectedIndex]));
            ResetIndices();
            }
            catch (Exception)
            {
                MessageBox.Show("Not all data available");
            }
        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int iSelectedIndex = checkedListBox2.SelectedIndex;
            if (iSelectedIndex == -1)
                return;
            for (int iIndex = 0; iIndex < checkedListBox2.Items.Count; iIndex++)
                checkedListBox2.SetItemCheckState(iIndex, CheckState.Unchecked);
            checkedListBox2.SetItemCheckState(iSelectedIndex, CheckState.Checked);


            if (iSelectedIndex != -1)
            {
                if(index2 != checkedListBox2.SelectedIndex)
                {
                    index2 = checkedListBox2.SelectedIndex;
                    checkedListBox4.Items.Clear();
                    checkedListBox3.Items.Clear();

                    foreach (Task i in DataStore.Instance.AllTasklists[checkedListBox2.SelectedIndex].Tasks.OrderByDescending(t => t.TaskId).ToList())
                    {
                        checkedListBox3.Items.Insert(0, i.Name);
                    }
                    foreach (TaskStatus i in DataStore.Instance.AllTasklists[checkedListBox2.SelectedIndex].TaskStatuses.OrderByDescending(t => t.TaskStatusID).ToList())
                    {
                        checkedListBox4.Items.Insert(0, i.Name);

                    }
                }
            }
        }

        private void checkedListBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

            int iSelectedIndex = checkedListBox3.SelectedIndex;
            if (iSelectedIndex == -1) return;
            for (int iIndex = 0; iIndex < checkedListBox3.Items.Count; iIndex++)
            {
                checkedListBox3.SetItemCheckState(iIndex, CheckState.Unchecked);
            }
            checkedListBox3.SetItemCheckState(iSelectedIndex, CheckState.Checked);

            if (iSelectedIndex != -1)
            {
                if (index3 != iSelectedIndex)
                {
                    index3 = iSelectedIndex;
                    Task task = DataStore.Instance.AllTasklists[checkedListBox2.SelectedIndex].Tasks.OrderBy(t => t.TaskId).ToList()[checkedListBox3.SelectedIndex];
                    textBox2.Text = task.Name;
                    textBox3.Text = task.Description;

                    if (checkedListBox4.Items.Count > 0)
                    {

                        checkedListBox4.SelectedIndex = DataStore.Instance.AllTasklists[checkedListBox2.SelectedIndex].TaskStatuses.OrderBy(t => t.TaskStatusID).ToList().FindIndex(t => t.TaskStatusID == task.Status.TaskStatusID);
                    }
                }
            }
        }

        private void checkedListBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            int iSelectedIndex = checkedListBox4.SelectedIndex;
            if (iSelectedIndex == -1) return;
            for (int iIndex = 0; iIndex < checkedListBox4.Items.Count; iIndex++)
            {
                checkedListBox4.SetItemCheckState(iIndex, CheckState.Unchecked);
            }
            checkedListBox4.SetItemCheckState(iSelectedIndex, CheckState.Checked);
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void ColorButton_Click(object sender, EventArgs e)
        {
            DialogResult result = ColorDialog.ShowDialog();

            if (result is DialogResult.OK)
            {
                ColorPanel.BackColor = ColorDialog.Color;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                MessageBox.Show("Enter task status name");
            }
            else if (CreateStatusTakListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Select tasklist from list");
            }
            else
            {
                try
                {
                ResetIndices();
                client.SendRequest(new TaskstatusAddRequest(Users.login, Users.password, new(textBox4.Text, ColorDialog.Color.ToArgb().ToString()), DataStore.Instance.AllTasklists.OrderBy(t => t.TaskListID).ToList()[CreateStatusTakListBox.SelectedIndex]));
                }
                catch (Exception)
                {
                    MessageBox.Show("Not all data available");
                }
            }
        }

        private void CreateStatusTakListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int iSelectedIndex = CreateStatusTakListBox.SelectedIndex;
            if (iSelectedIndex == -1) return;
            for (int iIndex = 0; iIndex < CreateStatusTakListBox.Items.Count; iIndex++)
            {
                CreateStatusTakListBox.SetItemCheckState(iIndex, CheckState.Unchecked);
            }
            CreateStatusTakListBox.SetItemCheckState(iSelectedIndex, CheckState.Checked);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
            client.SendRequest(new TaskDeleteRequest(Users.login, Users.password, new Task(textBox2.Text, textBox3.Text, new Common.Models.User(SocketClient.User_name, SocketClient.User_password) { UserID = SocketClient.Id }, DataStore.Instance.AllTasklists[checkedListBox2.SelectedIndex].TaskStatuses.OrderBy(t => t.TaskStatusID).ToList()[checkedListBox4.SelectedIndex]) { TaskId = DataStore.Instance.AllTasklists[checkedListBox2.SelectedIndex].Tasks.OrderBy(t => t.TaskId).ToList()[checkedListBox3.SelectedIndex].TaskId }, DataStore.Instance.AllTasklists[checkedListBox2.SelectedIndex]));
            ResetIndices();
            textBox2.Text = "";
            textBox3.Text = "";
            }
            catch (Exception)
            {
                MessageBox.Show("Not all data available");
            }
        }

        private void sendTicketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show(4);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if ((textBox5.Text != "") && (richTextBox2.Text != ""))
            {
                try
                {
                    client.SendRequest(new TickedAddRequest(Users.login, Users.password, new Ticket(textBox5.Text, richTextBox2.Text, "", new Common.Models.User(Users.login, Users.password), TicketStatus.INACTIVE)));
                    MessageBox.Show("Ticket sent");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Fill in your application details");
            }
        }

        private void editTaskListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show(5);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox7.Text != "")
            {
            client.SendRequest(new TasklistAddRequest(Users.login, Users.password, new(textBox7.Text, new(Users.login, Users.password))));
                textBox7.Text = "";
            }
            else
            {
                MessageBox.Show("Enter Task List Name");
            }
        }

        private void checkedListBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            int iSelectedIndex = checkedListBox5.SelectedIndex;
            if (iSelectedIndex == -1)
                return;
            for (int iIndex = 0; iIndex < checkedListBox5.Items.Count; iIndex++)
                checkedListBox5.SetItemCheckState(iIndex, CheckState.Unchecked);
            checkedListBox5.SetItemCheckState(iSelectedIndex, CheckState.Checked);

            if (iSelectedIndex != -1)
            {
                textBox7.Text = DataStore.Instance.AllTasklists.OrderBy(t => t.TaskListID).ToList()[checkedListBox5.SelectedIndex].Name;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox7.Text != "")
            {
                client.SendRequest(new TasklistUpdateRequest(Users.login, Users.password, new Tasklist(textBox7.Text, new Common.Models.User(Users.login, Users.password)) { TaskListID = DataStore.Instance.AllTasklists.OrderBy(t => t.TaskListID).ToList()[checkedListBox5.SelectedIndex].TaskListID }));
                ResetIndices();
                textBox7.Text = "";
            }
            else
            {
                MessageBox.Show("Enter Task List Name");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (checkedListBox5.SelectedIndex != -1)
            {
                ResetIndices();
                client.SendRequest(new TasklistDeleteRequest(Users.login, Users.password, new Tasklist(null, new Common.Models.User(Users.login, Users.password)) { TaskListID = DataStore.Instance.AllTasklists.OrderBy(t => t.TaskListID).ToList()[checkedListBox5.SelectedIndex].TaskListID }));
            }
            else
            {
                MessageBox.Show("Select Task List from the list");
            }
        }

        private void checkedListBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            int iSelectedIndex = StatusEditTasklistBox.SelectedIndex;
            if (iSelectedIndex == -1) return;
            for (int iIndex = 0; iIndex < StatusEditTasklistBox.Items.Count; iIndex++)
            {
                StatusEditTasklistBox.SetItemCheckState(iIndex, CheckState.Unchecked);
            }
            StatusEditTasklistBox.SetItemCheckState(iSelectedIndex, CheckState.Checked);

            if (iSelectedIndex != -1)
            {
                if (index6 != iSelectedIndex)
                {
                    index6 = iSelectedIndex;

                    StatusEditStatusBox.Items.Clear();
                    foreach (TaskStatus taskstatus in DataStore.Instance.AllTasklists.OrderBy(t => t.TaskListID).ToList()[index6].TaskStatuses.OrderByDescending(t => t.TaskStatusID).ToList())
                    {
                        StatusEditStatusBox.Items.Insert(0, taskstatus.Name);
                    }
                }
            }
        }

        private void checkedListBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            int iSelectedIndex = StatusEditStatusBox.SelectedIndex;
            if (iSelectedIndex == -1) return;
            for (int iIndex = 0; iIndex < StatusEditStatusBox.Items.Count; iIndex++)
            {
                StatusEditStatusBox.SetItemCheckState(iIndex, CheckState.Unchecked);
            }
            StatusEditStatusBox.SetItemCheckState(iSelectedIndex, CheckState.Checked);

            MessageBox.Show(Color.Red.ToArgb().ToString());

            if (iSelectedIndex != -1)
            {
                if (index7 != iSelectedIndex)
                {
                    index7 = iSelectedIndex;

                    TaskStatus taskStatus = DataStore.Instance.AllTasklists.OrderBy(t => t.TaskListID).ToList()[index6].TaskStatuses.OrderBy(t => t.TaskStatusID).ToList()[index7];
                    StatusEditName.Text = taskStatus.Name;
                    StatusEditColorPanel.BackColor = Color.FromArgb(int.Parse(taskStatus.Color));
                }
            }
        }

        private void StatusEditColorButton_Click(object sender, EventArgs e)
        {
            DialogResult result = ColorDialog.ShowDialog();

            if (result is DialogResult.OK)
            {
                StatusEditColorPanel.BackColor = ColorDialog.Color;
            }
        }

        private void StatusSave_Click(object sender, EventArgs e)
        {
            if(StatusEditName.Text == "")
            {
                MessageBox.Show("Enter task status name");
            }
            else if (StatusEditTasklistBox.SelectedIndex == -1)
            {
                MessageBox.Show("Select tasklist from list");
            }
            else if (StatusEditStatusBox.SelectedIndex == -1)
            {
                MessageBox.Show("Select status from list");
            }
            else
            {
                client.SendRequest(new TaskstatusUpdateRequest(Users.login, Users.password, new(StatusEditName.Text, ColorDialog.Color.ToArgb().ToString()) { TaskStatusID = DataStore.Instance.AllTasklists.OrderBy(t => t.TaskListID).ToList()[StatusEditTasklistBox.SelectedIndex].TaskStatuses.OrderBy(t => t.TaskStatusID).ToList()[StatusEditStatusBox.SelectedIndex].TaskStatusID }, DataStore.Instance.AllTasklists.OrderBy(t => t.TaskListID).ToList()[StatusEditTasklistBox.SelectedIndex]));
                index6 = -1;
                index7 = -1;
                StatusEditName.Text = "";
            }
        }

        private void StatusDelete_Click(object sender, EventArgs e)
        {
            if (StatusEditTasklistBox.SelectedIndex == -1)
            {
                MessageBox.Show("Select tasklist from list");
            }
            else if (StatusEditStatusBox.SelectedIndex == -1)
            {
                MessageBox.Show("Select status from list");
            }
            else
            {
                client.SendRequest(new TaskstatusDeleteRequest(Users.login, Users.password, new(null, null) { TaskStatusID = DataStore.Instance.AllTasklists.OrderBy(t => t.TaskListID).ToList()[StatusEditTasklistBox.SelectedIndex].TaskStatuses.OrderBy(t => t.TaskStatusID).ToList()[StatusEditStatusBox.SelectedIndex].TaskStatusID }, DataStore.Instance.AllTasklists.OrderBy(t => t.TaskListID).ToList()[StatusEditTasklistBox.SelectedIndex]));
                index6 = -1;
                index7 = -1;
            }
        }

        private void newStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show(31);
        }

        private void editStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show(32);
        }

        private void deleteStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show(33);
        }

        private void showTasksToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox6_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int iSelectedIndex = checkedListBox6.SelectedIndex;
            if (iSelectedIndex == -1) return;
            for (int iIndex = 0; iIndex < checkedListBox6.Items.Count; iIndex++)
            {
                checkedListBox6.SetItemCheckState(iIndex, CheckState.Unchecked);
            }
            checkedListBox6.SetItemCheckState(iSelectedIndex, CheckState.Checked);
        }
    }
}
