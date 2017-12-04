using FitnessForms.Templates;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Connective.TableGateway;
using Connective.Tables;
using Connective.Factory;

namespace FitnessForms.Forms
{
    public partial class FormTicketGridAll : FormGrid
    {
        public FormTicketGridAll()
        {
            InitializeComponent();
        }
        protected override void RefreshData()
        {
            TicketFactory ticketFactory = new TicketFactory();
            TicketGateway<Ticket> ticketg = (TicketGateway<Ticket>)ticketFactory.GetTicket();

            Collection<Ticket> tickets = ticketg.Select();
            BindingList<Ticket> bindingList = new BindingList<Ticket>(tickets);
            ticketsGrid.AutoGenerateColumns = false;
            ticketsGrid.DataSource = bindingList;
        }

        private Ticket GetSelectedTicket()
        {
            if (ticketsGrid.SelectedRows.Count == 1)
            {
                Ticket ticket = ticketsGrid.SelectedRows[0].DataBoundItem as Ticket;
                return ticket;
            }
            else
            {
                return null;
            }
        }

        protected override void NewRecord()
        {

            FormTicketDetail form = new FormTicketDetail();
            if (form.OpenRecord(null))
            {
                form.ShowDialog();
                RefreshData();
            }
        }

        protected override void EditRecord()
        {
            Ticket selectedTicket = GetSelectedTicket();
            if (selectedTicket != null)
            {
                FormTicketDetail form = new FormTicketDetail();
                if (form.OpenRecord(selectedTicket.RecordId))
                {
                    form.ShowDialog();
                    RefreshData();
                }
            }
        }

        private void ticketsGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditRecord();
        }
    }

}
