using System.Windows.Forms;
using Connective.TableGateway;
using Connective.Tables;
using Connective.Factory;

namespace FitnessForms.Forms
{
    public partial class ChangeCredit : Form
    {

        private DiscountCard card = new DiscountCard();
        public ChangeCredit()
        {
            InitializeComponent();
            firstInitialize();
        }

        public void firstInitialize()
        {
            ClientFactory clientFactory = new ClientFactory();
            ClientGateway<Client> cg = (ClientGateway<Client>)clientFactory.GetClient();
            TrainingFactory trainingFactory = new TrainingFactory();
            TrainingGateway<Training> tg = (TrainingGateway<Training>)trainingFactory.GetTraining();
            DiscountFactory discountFactory = new DiscountFactory();
            DiscountGateway<DiscountCard> dg = (DiscountGateway<DiscountCard>)discountFactory.GetCard();
            PurchaseFactory purchaseFactory = new PurchaseFactory();
            PurchaseGateway<Purchase> pg = (PurchaseGateway<Purchase>)purchaseFactory.GetPurchase();
            TicketFactory ticketFactory = new TicketFactory();
            TicketGateway<Ticket> ticketg = (TicketGateway<Ticket>)ticketFactory.GetTicket();


            Client client = cg.Select(tg.SelectLast().ClientId);


            clientName.Text = client.ToString();
            
            if (client.CardId != null)
            {
                int toSetId = client.CardId ?? default(int);
                card = dg.Select(toSetId);
            }
            Ticket t = ticketg.Select(pg.SelectLast(card.RecordId).TicketId);

            ticketType.Text = t.Type;
            credit.Text = card.Credit.ToString();
        }

        private void acceptButton_Click(object sender, System.EventArgs e)
        {
            DiscountFactory discountFactory = new DiscountFactory();
            DiscountGateway<DiscountCard> dg = (DiscountGateway<DiscountCard>)discountFactory.GetCard();

            decimal result;
            if (decimal.TryParse(toSubstract.Text, out result))
            {
                if (result < card.Credit)
                {
                    card.Credit -= result;
                    dg.Update(card);
                    MessageBox.Show("Credit was updated succesfully!", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Client does not have enought credit!", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                this.Dispose();
            }
        }
    }
}
