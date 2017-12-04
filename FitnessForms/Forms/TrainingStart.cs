using System;
using Connective.Tables;
using Connective.TableGateway;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using Connective.Factory;

namespace FitnessForms.Forms
{
    public partial class TrainingStart : Form
    {
        private Collection<Client> clients;
        private Collection<Trainer> trainers;
        private Collection<Locker> lockers;


        public TrainingStart()
        {
            InitializeComponent();
            firstInitialize();
        }

        public void firstInitialize()
        {
            ClientFactory clientFactory = new ClientFactory();
            ClientGateway<Client> cg = (ClientGateway<Client>)clientFactory.GetClient();
            TrainerFactory trainerFactory = new TrainerFactory();
            TrainerGateway<Trainer> trainerg = (TrainerGateway<Trainer>)trainerFactory.GetTrainer();
            LockerFactory lockerFactory = new LockerFactory();
            LockerGateway<Locker> lg = (LockerGateway<Locker>)lockerFactory.GetLocker();

            clients = cg.SelectForTrainingStartEnd(true);
            trainers = trainerg.Select();
            lockers = lg.Select();

            Collection<string> clientNames = new Collection<string>();
            foreach (Client c in clients)
            {
                clientNames.Add(c.ToString());
            }
            comboClient.DataSource = clientNames;

            Collection<Locker> filteredLockers = new Collection<Locker>();
            Collection<string> lockerNames = new Collection<string>();

            foreach (Locker l in lockers)
            {
                if (l.Status != "taken")
                {
                    filteredLockers.Add(l);
                }
            }
            foreach (Locker l in filteredLockers)
            {
                lockerNames.Add(l.ToString());
            }
            comboLocker.DataSource = lockerNames;

            Collection<string> trainerNames = new Collection<string>();
            foreach (Trainer t in trainers)
            {
                trainerNames.Add(t.ToString());
            }
            comboTrainer.DataSource = trainerNames;

        }
        private void acceptButton_Click(object sender, EventArgs e)
        {
            Training t = new Training();
            t.LockerId = lockers[comboLocker.SelectedIndex].RecordId;
            t.ClientId = clients[comboClient.SelectedIndex].RecordId;
            t.TrainerId = trainers[comboTrainer.SelectedIndex].RecordId;
            t.ToGender = clients[comboClient.SelectedIndex].Gender;
            t.TimeFrom = DateTime.Now;

            ClientFactory clientFactory = new ClientFactory();
            ClientGateway<Client> cg = (ClientGateway<Client>)clientFactory.GetClient();
            Client c = cg.Select(t.ClientId);

            DiscountFactory discountFactory = new DiscountFactory();
            DiscountGateway<DiscountCard> dg = (DiscountGateway<DiscountCard>)discountFactory.GetCard();

            DiscountCard card = new DiscountCard();
            if (c.CardId != null)
            {
                int toSetId = c.CardId ?? 0;
                card = dg.Select(toSetId);
            }
            TrainingFactory trainingFactory = new TrainingFactory();
            TrainingGateway<Training> tg = (TrainingGateway<Training>)trainingFactory.GetTraining();

            tg.Insert(t);

            if (card != null && card.Credit > 0)
            {
                Forms.ChangeCredit form = new Forms.ChangeCredit();
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Training was added successfully but client " + c.Name + " " + c.Surname + " has no credit on card!", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            this.Dispose();
        }
    }
}
