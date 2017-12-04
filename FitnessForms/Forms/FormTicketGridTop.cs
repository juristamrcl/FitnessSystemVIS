using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Forms;
using Connective.TableGateway;
using Connective.Tables;

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
            Collection<TopTicket> tickets = TicketGateway.SelectTOP5();
            BindingList<TopTicket> bindingList = new BindingList<TopTicket>(tickets);
            ticketsGrid.AutoGenerateColumns = false;
            ticketsGrid.DataSource = bindingList;
        }
    }
}
