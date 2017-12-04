using System;
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
    public partial class FormTrainingGrid : Form
    {
        public FormTrainingGrid()
        {
            InitializeComponent();
            RefreshData();
        }

        protected void RefreshData()
        {
            TrainingFactory trainingFactory = new TrainingFactory();
            TrainingGateway<Training> tg = (TrainingGateway<Training>)trainingFactory.GetTraining();
            TicketFactory ticketFactory = new TicketFactory();
            TicketGateway<Ticket> ticketg = (TicketGateway<Ticket>)ticketFactory.GetTicket();
            ClientFactory clientFactory = new ClientFactory();
            ClientGateway<Client> cg = (ClientGateway<Client>)clientFactory.GetClient();
            TrainerFactory trainerFactory = new TrainerFactory();
            TrainerGateway<Trainer> trainerg = (TrainerGateway<Trainer>)trainerFactory.GetTrainer();

            Collection<Training> trainings = tg.Select();
            Collection<TrainGrid> trainGrid = new Collection<TrainGrid>();

            foreach(Training t in trainings)
            {
                TrainGrid tgrid = new TrainGrid();
                tgrid.LockerId = t.LockerId;
                tgrid.ToGender = t.ToGender;
                tgrid.Start = t.TimeFrom;
                tgrid.End = t.TimeTo;
                // using factory to get data

                Client c = cg.Select(t.ClientId);
                tgrid.ClientName = c.Name + " " + c.Surname;
                int tempId;
                if (t.TrainerId.HasValue)
                {
                    tempId = t.TrainerId.Value;
                    Trainer tr = trainerg.Select(tempId);
                    tgrid.TrainerName = tr.Name + " " + tr.Surname;
                }
                else
                {
                    tgrid.TrainerName = "";
                }
                trainGrid.Add(tgrid);
            }

            BindingList<TrainGrid> bindingList = new BindingList<TrainGrid>(trainGrid);
            trainingsGrid.AutoGenerateColumns = false;
            trainingsGrid.DataSource = bindingList;
        }

        private Training GetSelectedTraining()
        {
            if (trainingsGrid.SelectedRows.Count == 1)
            {
                TrainGrid trainGrid = trainingsGrid.SelectedRows[0].DataBoundItem as TrainGrid;
                Training trn = new Training();
                trn.LockerId = trainGrid.LockerId;
                trn.ToGender = trainGrid.ToGender;
                trn.TimeFrom = trainGrid.Start;
                trn.TimeTo = trainGrid.End;
                return trn;
            }
            else
            {
                return null;
            }
        }

        private void trainingsGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            RefreshData();
        }
    }
    public class TrainGrid
    {
        public string ClientName { get; set; }
        public string TrainerName { get; set; }
        public int LockerId { get; set; }
        public string ToGender { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
    }
}