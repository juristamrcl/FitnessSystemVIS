using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Forms;
using Connective.TableGateway;
using Connective.Tables;
using Connective.Factory;

namespace FitnessForms.Forms
{
    public partial class FormTicketGridTop : Form
    {
        public FormTicketGridTop()
        {
            InitializeComponent();
            RefreshData();
        }

        protected void RefreshData()
        {
            TicketFactory ticketFactory = new TicketFactory();
            TicketGateway<Ticket> ticketg = (TicketGateway<Ticket>)ticketFactory.GetTicket();

            Collection<TopTicket> tickets = ticketg.SelectTOP5();
            BindingList<TopTicket> bindingList = new BindingList<TopTicket>(tickets);
            ticketsGrid.AutoGenerateColumns = false;
            ticketsGrid.DataSource = bindingList;
        }
    }
}
