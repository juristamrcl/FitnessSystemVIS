using System.Collections.ObjectModel;
using System.Windows.Forms;
using Connective.TableGateway;
using Connective.Tables;
using System;
using Connective.Factory;

namespace FitnessForms.Forms
{
    public partial class TrainingEnd : Form
    {
        private Collection<Client> clients;

        public TrainingEnd()
        {
            InitializeComponent();
            firstInitialize();
        }

        public void firstInitialize()
        {
            ClientFactory clientFactory = new ClientFactory();
            ClientGateway<Client> cg = (ClientGateway<Client>)clientFactory.GetClient();
            clients = cg.SelectForTrainingStartEnd(false);

            Collection<string> clientNames = new Collection<string>();
            foreach (Client c in clients)
            {
                clientNames.Add(c.ToString());
            }
            comboClient.DataSource = clientNames;
        }

        private void acceptButton_Click(object sender, System.EventArgs e)   
        {
            TrainingFactory trainingFactory = new TrainingFactory();
            TrainingGateway<Training> tg = (TrainingGateway<Training>)trainingFactory.GetTraining();
            Training tr = tg.SelectLast(clients[comboClient.SelectedIndex].RecordId);
            tr.TimeTo = DateTime.Now;

            tg.Update(tr);
            MessageBox.Show("Training was ended Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Dispose();
        }
    }
}
