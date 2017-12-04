using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Forms;
using Connective.TableGateway;
using Connective.Tables;
using Connective.Factory;

namespace FitnessForms.Forms
{
    public partial class FormClientGrid : Templates.FormGrid
    {
        public FormClientGrid()
        {
            InitializeComponent();
        }

        private void FormClientGrid_Load(object sender, EventArgs e)
        {

        }
        protected override void RefreshData()
        {
            ClientFactory clientFactory = new ClientFactory();
            ClientGateway<Client> cg = (ClientGateway<Client>)clientFactory.GetClient();
            Collection<ExtendedClient> clients = cg.SelectAll();
            BindingList<ExtendedClient> bindingList = new BindingList<ExtendedClient>(clients);
            clientsGrid.AutoGenerateColumns = false;
            clientsGrid.DataSource = bindingList;
        }

        private ExtendedClient GetSelectedClient()
        {
            if (clientsGrid.SelectedRows.Count == 1)
            {
                ExtendedClient client = clientsGrid.SelectedRows[0].DataBoundItem as ExtendedClient;
                return client;
            }
            else
            {
                return null;
            }
        }

        protected override void NewRecord()
        {

            FormClientDetail form = new FormClientDetail();
            if (form.OpenRecord(null))
            {
                form.ShowDialog();
                RefreshData();
            }
        }

        protected override void EditRecord()
        {
            ExtendedClient selectedClient = GetSelectedClient();
            if (selectedClient != null)
            {
                FormClientDetail form = new FormClientDetail();
                if (form.OpenRecord(selectedClient.ClientId))
                {
                    form.ShowDialog();
                    RefreshData();
                }
            }
        }

        private void clientsGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditRecord();
        }
        // training start
        private void button1_Click(object sender, EventArgs e)
        {
            Forms.TrainingStart form = new Forms.TrainingStart();
            form.ShowDialog();
        }
        //training end
        private void button2_Click(object sender, EventArgs e)
        {
            Forms.TrainingEnd form = new Forms.TrainingEnd();
            form.ShowDialog();
        }
    }
}
