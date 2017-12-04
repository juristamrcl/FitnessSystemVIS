using Connective.TableGateway;
using Connective.Tables;
using Connective.Backup;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;
using Connective.Factory;

namespace FitnessForms
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            Forms.Login form = new Forms.Login();
            form.ShowDialog();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            
        }

        private void clientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FormClientGrid form = new Forms.FormClientGrid();
            form.ShowDialog();
        }

        private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FormTicketGridAll form = new Forms.FormTicketGridAll();
            form.ShowDialog();
        }

        private void top5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FormTicketGridTop form = new Forms.FormTicketGridTop();
            form.ShowDialog();
        }

        private void showToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Forms.FormTrainingGrid form = new Forms.FormTrainingGrid();
            form.ShowDialog();
        }

        private void lockersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Forms.FormLockerGrid form = new Forms.FormLockerGrid();
            form.ShowDialog();
        }

        private void cardsToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Forms.FormCardGrid form = new Forms.FormCardGrid();
            form.ShowDialog();
        }

        private void backupToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LockerFactory lockerFactory = new LockerFactory();
            LockerXMLGateway<Locker> lg = (LockerXMLGateway<Locker>)lockerFactory.GetLocker();
            TrainingFactory trainingFactory = new TrainingFactory();
            TrainingGateway<Training> tg = (TrainingGateway<Training>)trainingFactory.GetTraining();
            PurchaseFactory purchaseFactory = new PurchaseFactory();
            PurchaseGateway<Purchase> pg = (PurchaseGateway<Purchase>)purchaseFactory.GetPurchase();
            TrainerFactory trainerFactory = new TrainerFactory();
            TrainerGateway<Trainer> trainerg = (TrainerGateway<Trainer>)trainerFactory.GetTrainer();
            TrainerRatingFactory trainerRatingFactory = new TrainerRatingFactory();
            TrainerRatingGateway<TrainerRating> tr = (TrainerRatingGateway<TrainerRating>)trainerRatingFactory.GetTrainerRating();
            TicketFactory ticketFactory = new TicketFactory();
            TicketGateway<Ticket> ticketg = (TicketGateway<Ticket>)ticketFactory.GetTicket();

            // Backup button

            XDocument xDoc = new XDocument();
            XElement xRoot = new XElement("Database");

            ClientFactory clientFactory = new ClientFactory();
            ClientGateway<Client> cg = (ClientGateway<Client>)clientFactory.GetClient();

            Collection<Client> clients = cg.Select();
            XElement xClients = new XElement("Clients");

            foreach (var client in clients)
            {
                xClients.Add(ClientXMLGateway<Client>.Instance.Insert(client));
            }

            DiscountFactory discountFactory = new DiscountFactory();
            DiscountGateway<DiscountCard> dg = (DiscountGateway<DiscountCard>)discountFactory.GetCard();

            Collection<DiscountCard> cards = dg.Select();

            XElement xCards = new XElement("Cards");

            foreach (var card in cards)
            {
                xCards.Add(DiscountXMLGateway<DiscountCard>.Instance.Insert(card));
            }

            Collection<Locker> lockers = lg.Select();

            XElement xLockers = new XElement("Lockers");

            foreach (var locker in lockers)
            {
                xLockers.Add(LockerXMLGateway<Locker>.Instance.Insert(locker));
            }

            Collection<Purchase> purchases = pg.Select();
            XElement xPurchases = new XElement("Purchases");

            foreach (var purchase in purchases)
            {
                xPurchases.Add(PurchaseXMLGateway<Purchase>.Instance.Insert(purchase));
            }

            Collection<Ticket> tickets = ticketg.Select();
            XElement xTickets = new XElement("Tickets");

            foreach (var ticket in tickets)
            {
                xTickets.Add(TicketXMLGateway<Ticket>.Instance.Insert(ticket));
            }

            Collection<TrainerRating> ratings = tr.Select();
            XElement xRatings = new XElement("TrainerRatings");

            foreach (var rating in ratings)
            {
                xRatings.Add(TrainerRatingXMLGateway<TrainerRating>.Instance.Insert(rating));
            }

            Collection<Trainer> trainers = trainerg.Select();
            XElement xTrainers = new XElement("Trainers");

            foreach (var trainer in trainers)
            {
                xTrainers.Add(TrainerXMLGateway<Trainer>.Instance.Insert(trainer));
            }

            Collection<Training> trainings = tg.Select();
            XElement xTrainings = new XElement("Trainings");

            foreach (var training in trainings)
            {
                xTrainings.Add(TrainingXMLGateway<Training>.Instance.Insert(training));
            }

            xRoot.Add(xClients);
            xRoot.Add(xCards);
            xRoot.Add(xLockers);
            xRoot.Add(xPurchases);
            xRoot.Add(xTickets);
            xRoot.Add(xRatings);
            xRoot.Add(xTrainers);
            xRoot.Add(xTrainings);

            xDoc.Add(xRoot);

            if (!Directory.Exists(Connective.Backup.Paths.FolderPath))
            {
                Directory.CreateDirectory(Connective.Backup.Paths.FolderPath);
            }

            using (StreamWriter sw = new StreamWriter(Connective.Backup.Paths.FilePath))
            {
                sw.Write(xDoc.ToString());
            }

            MessageBox.Show("Backed up!");
        }

        //Restore button
        private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to restore data from XML? Almost all online data will be lost.", "Restore",
                   MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                LockerFactory lockerFactory = new LockerFactory();
                LockerGateway<Locker> lg = (LockerGateway<Locker>)lockerFactory.GetLocker();
                TrainingFactory trainingFactory = new TrainingFactory();
                TrainingGateway<Training> tg = (TrainingGateway<Training>)trainingFactory.GetTraining();
                PurchaseFactory purchaseFactory = new PurchaseFactory();
                PurchaseGateway<Purchase> pg = (PurchaseGateway<Purchase>)purchaseFactory.GetPurchase();
                TrainerFactory trainerFactory = new TrainerFactory();
                TrainerGateway<Trainer> trainerg = (TrainerGateway<Trainer>)trainerFactory.GetTrainer();
                TrainerRatingFactory trainerRatingFactory = new TrainerRatingFactory();
                TrainerRatingGateway<TrainerRating> tr = (TrainerRatingGateway<TrainerRating>)trainerRatingFactory.GetTrainerRating();
                TicketFactory ticketFactory = new TicketFactory();
                TicketGateway<Ticket> ticketg = (TicketGateway<Ticket>)ticketFactory.GetTicket();

                tg.Delete();
                pg.Delete();
                tr.Delete();
                trainerg.Delete();
                lg.Delete();
                ticketg.Delete();

                
                foreach (var locker in lg.Select())
                {
                    lg.Insert(locker);
                }

                foreach (var ticket in TicketXMLGateway<Ticket>.Instance.Select())
                {
                    TicketXMLGateway<Ticket>.Instance.Insert(ticket);
                }
                
                foreach (var trainer in TrainerXMLGateway<Trainer>.Instance.Select())
                {
                    TrainerXMLGateway<Trainer>.Instance.Insert(trainer);
                }
                
                foreach (var purchase in PurchaseXMLGateway<Purchase>.Instance.Select())
                {
                    PurchaseXMLGateway<Purchase>.Instance.Insert(purchase);
                }

                foreach (var training in TrainingXMLGateway<Training>.Instance.Select())
                {
                    TrainingXMLGateway<Training>.Instance.Insert(training);
                }
               
                foreach (var rating in TrainerRatingXMLGateway<TrainerRating>.Instance.Select())
                {
                    TrainerRatingXMLGateway<TrainerRating>.Instance.Insert(rating);
                }

                MessageBox.Show("Data restored!");
            }
            
        }
    }
}
