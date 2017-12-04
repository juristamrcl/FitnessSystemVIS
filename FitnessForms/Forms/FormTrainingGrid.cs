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
            Collection<Training> trainings = TrainingGateway.Select();
            Collection<TrainGrid> trainGrid = new Collection<TrainGrid>();

            foreach(Training t in trainings)
            {
                TrainGrid tg = new TrainGrid();
                tg.LockerId = t.LockerId;
                tg.ToGender = t.ToGender;
                tg.Start = t.TimeFrom;
                tg.End = t.TimeTo;
                // using factory to get data
                ClientFactory clientFactory = new ClientFactory();
                ClientGateway<Client> cg = (ClientGateway<Client>)clientFactory.GetClient();
                Client c = cg.Select(t.ClientId);
                tg.ClientName = c.Name + " " + c.Surname;
                int tempId;
                if (t.TrainerId.HasValue)
                {
                    tempId = t.TrainerId.Value;
                    Trainer tr = TrainerGateway.Select(tempId);
                    tg.TrainerName = tr.Name + " " + tr.Surname;
                }
                else
                {
                    tg.TrainerName = "";
                }
                trainGrid.Add(tg);
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