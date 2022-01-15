using Common.Communication.Requests;
using Common.Models;
using Common.Models.Enums;
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
    public partial class Helpdesk : Form
    {
        public Helpdesk()
        {
            DataStore.Instance.TicketsChanged += Instance_TicketsChanged;
            InitializeComponent();

            SocketClient client = new(Form1.ip_address, Form1.port);
            client.SendRequest(new HelpdeskTicketGetAllRequest(Users.login, Users.password));

            StatusBox.Items.Clear();

            foreach (string ticketStatus in Enum.GetNames(typeof(TicketStatus)).OrderByDescending(s => s))
            {
                StatusBox.Items.Insert(0, ticketStatus);
            }
        }

        private void Instance_TicketsChanged(object sender, TicketsChangedEventArgs e)
        {
            TicketsBox.Items.Clear();

            foreach (Ticket ticket in e.Tickets.OrderByDescending(t => t.TicketId))
            {
                TicketsBox.Items.Insert(0, ticket.Name);
            }
        }

        private void TicketsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TicketsBox.SelectedIndex == -1) return;
            for (int iIndex = 0; iIndex < TicketsBox.Items.Count; iIndex++)
            {
                TicketsBox.SetItemCheckState(iIndex, CheckState.Unchecked);
            }
            TicketsBox.SetItemCheckState(TicketsBox.SelectedIndex, CheckState.Checked);

            Ticket ticket = DataStore.Instance.AllTickets.OrderBy(t => t.TicketId).ToList()[TicketsBox.SelectedIndex];

            NameBox.Text = ticket.Name;
            DescBox.Text = ticket.Description;

            NoteBox.Text = ticket.Note;

            StatusBox.SelectedIndex = Enum.GetNames(typeof(TicketStatus)).OrderBy(s => s).ToList().FindIndex(s => s == ticket.Status.ToString());
        }

        private void StatusBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (StatusBox.SelectedIndex == -1) return;
            for (int iIndex = 0; iIndex < StatusBox.Items.Count; iIndex++)
            {
                StatusBox.SetItemCheckState(iIndex, CheckState.Unchecked);
            }
            StatusBox.SetItemCheckState(StatusBox.SelectedIndex, CheckState.Checked);
        }

        private void Save_Click(object sender, EventArgs e)
        {
            DataStore.Instance.SocketClient.SendRequest(new HelpdeskTicketUpdateRequest(DataStore.Instance.UserData.Username, DataStore.Instance.UserData.Password, new Ticket(NameBox.Text, DescBox.Text, NoteBox.Text, DataStore.Instance.UserData, (TicketStatus)Enum.Parse(typeof(TicketStatus), StatusBox.SelectedItem.ToString())) { TicketId = DataStore.Instance.AllTickets.OrderBy(t => t.TicketId).ToList()[TicketsBox.SelectedIndex].TicketId}));
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
