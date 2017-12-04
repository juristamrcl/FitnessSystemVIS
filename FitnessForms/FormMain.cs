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
            // Backup button

            XDocument xDoc = new XDocument();
            XElement xRoot = new XElement("Database");

            ClientFactory clientFactory = new ClientFactory();
            ClientGateway<Client> cg = (ClientGateway<Client>)clientFactory.GetClient();
            Collection<Client> clients = cg.Select();
            XElement xClients = new XElement("Clients");

            foreach (var client in clients)
            {
                xClients.Add(ClientXMLGateway.Insert(client));
            }

            Collection<DiscountCard> cards = DiscountCardGateway.Select();
            XElement xCards = new XElement("Cards");

            foreach (var card in cards)
            {
                xCards.Add(DiscountXMLGateway.Insert(card));
            }

            Collection<Locker> lockers = LockerGateway.Select();
            XElement xLockers = new XElement("Lockers");

            foreach (var locker in lockers)
            {
                xLockers.Add(LockerXMLGateway.Insert(locker));
            }

            Collection<Purchase> purchases = PurchaseGateway.Select();
            XElement xPurchases = new XElement("Purchases");

            foreach (var purchase in purchases)
            {
                xPurchases.Add(PurchaseXMLGateway.Insert(purchase));
            }

            Collection<Ticket> tickets = TicketGateway.Select();
            XElement xTickets = new XElement("Tickets");

            foreach (var ticket in tickets)
            {
                xTickets.Add(TicketXMLGateway.Insert(ticket));
            }

            Collection<TrainerRating> ratings = TrainerRatingGateway.Select();
            XElement xRatings = new XElement("TrainerRatings");

            foreach (var rating in ratings)
            {
                xRatings.Add(TrainerRatingXMLGateway.Insert(rating));
            }

            Collection<Trainer> trainers = TrainerGateway.Select();
            XElement xTrainers = new XElement("Trainers");

            foreach (var trainer in trainers)
            {
                xTrainers.Add(TrainerXMLGateway.Insert(trainer));
            }
            
            Collection<Training> trainings = TrainingGateway.Select();
            XElement xTrainings = new XElement("Trainings");

            foreach (var training in trainings)
            {
                xTrainings.Add(TrainingXMLGateway.Insert(training));
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
                TrainingGateway.Delete();
                PurchaseGateway.Delete();
                TrainerRatingGateway.Delete();
                TrainerGateway.Delete();
                LockerGateway.Delete();
                TicketGateway.Delete();

                
                foreach (var element in LockerXMLGateway.Select())
                {
                    Locker locker = new Locker()
                    {
                        Status = element.Attribute("Status").Value,
                        ToGender = element.Attribute("ToGender").Value,
                        RecordId = int.Parse(element.Attribute("Id").Value)
                    };

                    LockerGateway.Insert(locker);
                }

                foreach (var element in TicketXMLGateway.Select())
                {
                    var res = 0;
                    var dec = 0M;
                    Ticket ticket = new Ticket()
                    {
                        Cost = decimal.TryParse(element.Attribute("Cost").Value, out dec) == true ? dec : 0M,
                        Description = element.Attribute("Description").Value,
                        Type = element.Attribute("Type").Value,
                        Validity = int.TryParse(element.Attribute("Validity").Value, out res) == true ? res : 0
                    };

                    if (ticket.Validity == 0)
                    {
                        ticket.Validity = null;
                    }
                    TicketGateway.Insert(ticket);
                }
                
                foreach (var element in TrainerXMLGateway.Select())
                {
                    Trainer trainer = new Trainer()
                    {
                        Name = element.Attribute("Name").Value,
                        Surname = element.Attribute("Surname").Value,
                        Mail = element.Attribute("Mail").Value,
                        Specialization = element.Attribute("Specialization").Value,
                        License = element.Attribute("License").Value,
                    };
                    if (trainer.License == "null")
                    {
                        trainer.License = null;
                    }

                    TrainerGateway.Insert(trainer);
                }
                
                /*foreach (var element in ClientXMLGateway.Select())
                {
                    var res = 0;
                    Client client = new Client()
                    {
                        Name = element.Attribute("Name").Value,
                        Surname = element.Attribute("Surname").Value,
                        Mail = element.Attribute("Mail").Value,
                        Gender = element.Attribute("Gender").Value,
                        CardId = int.TryParse(element.Attribute("CardId").Value, out res) == true ? res : 0
                    };
                    if (client.CardId == 0)
                        client.CardId = null;

                    ClientGateway.Insert(client);
                }*/

                foreach (var element in PurchaseXMLGateway.Select())
                {
                    Purchase purchase = new Purchase()
                    {
                        TicketId = int.Parse(element.Attribute("TicketId").Value),
                        CardId = int.Parse(element.Attribute("CardId").Value),
                        Date = DateTime.Parse(element.Attribute("Date").Value)
                    };

                    PurchaseGateway.Insert(purchase);
                }
                
                foreach (var element in TrainingXMLGateway.Select())
                {
                    var res = 0;
                    var dateTime = DateTime.Now;
                    Training training = new Training()
                    {
                        ClientId = int.TryParse(element.Attribute("ClientId").Value, out res) == true ? res : 0,
                        LockerId = int.TryParse(element.Attribute("LockerId").Value, out res) == true ? res : 0,
                        TimeFrom = DateTime.TryParse(element.Attribute("TimeFrom").Value, out dateTime) ? dateTime : DateTime.Now,
                        ToGender = element.Attribute("ToGender").Value,
                    };
                    if (DateTime.TryParse(element.Attribute("TimeTo").Value, out dateTime))
                    {
                        training.TimeTo = dateTime;
                    }
                    else
                    {
                        training.TimeTo = null;
                    }
                    if (int.TryParse(element.Attribute("TrainerId").Value, out res))
                    {
                        training.TrainerId = res;
                    }
                    else
                    {
                        training.TrainerId = 1;
                    }

                    TrainingGateway.Insert(training);
                }
                
                /*foreach (var element in DiscountXMLGateway.Select())
                {
                    var res = 0;
                    var dec = 0.0M;
                    DiscountCard card = new DiscountCard()
                    {
                        Credit = decimal.TryParse(element.Attribute("ClientId").Value, out dec) == true ? dec : 0.0M,
                        ClientId = int.TryParse(element.Attribute("ClientId").Value, out res) == true ? res : 0
                    };
                    if (card.Credit == 0.0M)
                    {
                        card.Credit = null;
                    }
                    if (card.ClientId == 0)
                    {
                        card.ClientId = null;
                    }

                    DiscountCardGateway.Insert(card);
                }*/
                
                foreach (var element in TrainerRatingXMLGateway.Select())
                {
                    TrainerRating rating = new TrainerRating()
                    {
                        ClientId = int.Parse(element.Attribute("ClientId").Value),
                        TrainerId = int.Parse(element.Attribute("TrainerId").Value),
                        RatingNumber = decimal.Parse(element.Attribute("RatingNumber").Value),
                        Text = element.Attribute("Text").Value
                    };

                    TrainerRatingGateway.Insert(rating);
                }

                MessageBox.Show("Data restored!");
            }
            
        }
    }
}
