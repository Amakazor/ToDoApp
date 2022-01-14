using System;
using System.Windows.Forms;
using WinFormsClient.User_types;
using WinFormsClient;
using Common.Communication.Requests;

namespace WinFormsClient
{
    public partial class Users : Form
    {
        private string login,password;

        public Users()
        {
            InitializeComponent();
            //login = textBox1.Text;
            //password = textBox2.Text;
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

        private void button1_Click(object sender, EventArgs e)
        {
            login = textBox1.Text;
            password = textBox2.Text;
            SocketClient client = new (Form1.ip_address, Form1.port);
            client.SendRequest(new UserLoginRequest(new(login, password)));
            //MessageBox.Show(Form1.ip_address + Form1.port);
            //SocketClient client = new ();
            //MessageBox.Show(login + password);
        }
    }
}
