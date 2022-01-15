using System;
using System.Windows.Forms;
using WinFormsClient.User_types;
using Common.Communication.Requests;

namespace WinFormsClient
{
    public partial class Users : Form
    {
        public static string login,password;

        

        public Users()
        {
            InitializeComponent();
            label2.Visible = false;
            textBox1.Visible = false;
            label3.Visible = false;
            textBox2.Visible = false;
            button1.Visible = false;

            label7.Visible = false;
            textBox6.Visible = false;
            label6.Visible = false;
            textBox5.Visible = false;
            button2.Visible = false;
            label5.Visible = false;
            textBox4.Visible = false;
            label4.Visible = false;
            textBox3.Visible = false;
            label8.Visible = false;
            textBox7.Visible = false;
            label9.Visible = false;
        }

        private void User_Click(object sender, EventArgs e)
        {
            User form = new User();
            form.Show();
        }

        private void Admin_Click(object sender, EventArgs e)
        {
            Admin form = new Admin();
            form.Show();
        }

        private void Helpdesk_Click(object sender, EventArgs e)
        {
            Helpdesk form = new Helpdesk();
            form.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void logInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label2.Visible = true;
            textBox1.Visible = true;
            label3.Visible = true;
            textBox2.Visible = true;
            button1.Visible = true;

            label7.Visible = false;
            textBox6.Visible = false;
            label6.Visible = false;
            textBox5.Visible = false;
            button2.Visible = false;
            label5.Visible = false;
            textBox4.Visible = false;
            label4.Visible = false;
            textBox3.Visible = false;
            label8.Visible = false;
            textBox7.Visible = false;
            label9.Visible = false;

        }

        private void registrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            textBox1.Visible = false;
            label3.Visible = false;
            textBox2.Visible = false;
            button1.Visible = false;

            label7.Visible = true;
            textBox6.Visible = true;
            label6.Visible = true;
            textBox5.Visible = true;
            button2.Visible = true;
            label5.Visible = true;
            textBox4.Visible = true;
            label4.Visible = true;
            textBox3.Visible = true;
            label8.Visible = true;
            textBox7.Visible = true;
            label9.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
            {
                MessageBox.Show("Enter First Name");
            }
            else if (textBox5.Text == "")
            {
                MessageBox.Show("Enter Last Name");
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("Enter User Name");
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("Enter Password");
            }
            
            else
            {
                SocketClient client = new(Form1.ip_address, Form1.port);
                client.SendRequest(new UserRegisterRequest(new(textBox6.Text, textBox5.Text, textBox4.Text, textBox3.Text, Common.Models.Enums.UserType.USER, Common.Models.Enums.UserStatus.ACTIVE)));
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if ((textBox7.Text != textBox3.Text) || (textBox7.Text == "") || (textBox3.Text == ""))
            {
                textBox7.BackColor = System.Drawing.Color.Red;
                textBox3.BackColor = System.Drawing.Color.Red;
                label9.Text = "Passwords are different";
            }
            else
            {
                textBox7.BackColor = System.Drawing.Color.Green;
                textBox3.BackColor = System.Drawing.Color.Green;
                label9.Text = "Passwords are correct";
            }
        }

        private void Users_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if ((textBox7.Text != textBox3.Text) || (textBox7.Text == "") || (textBox3.Text == ""))
            {
                textBox7.BackColor = System.Drawing.Color.Red;
                textBox3.BackColor = System.Drawing.Color.Red;
                label9.Text = "Passwords are different";
            }
            else
            {
                textBox7.BackColor = System.Drawing.Color.Green;
                textBox3.BackColor = System.Drawing.Color.Green;
                label9.Text = "Passwords are correct";
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            login = textBox1.Text;
            password = textBox2.Text;

            DataStore.Instance.UserData = new Common.Models.User(login, password);

            if (textBox1.Text == "")
                MessageBox.Show("Enter login");
            else if (textBox2.Text == "")
                MessageBox.Show("Enter password");
            else
            {
                SocketClient client = new(Form1.ip_address, Form1.port);
                client.SendRequest(new UserLoginRequest(new(login, password)));
            }
        }
    }
}
