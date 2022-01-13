using System;
using System.Windows.Forms;
using WinFormsClient.User_types;

namespace WinFormsClient
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
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
    }
}
