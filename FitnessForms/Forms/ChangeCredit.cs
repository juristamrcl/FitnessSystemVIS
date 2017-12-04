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
            Client client = cg.Select(TrainingGateway.SelectLast().ClientId);
            clientName.Text = client.ToString();
            
            if (client.CardId != null)
            {
                int toSetId = client.CardId ?? default(int);
                card = DiscountCardGateway.Select(toSetId);
            }
            Ticket t = TicketGateway.Select(PurchaseGateway.SelectLast(card.RecordId).TicketId);

            ticketType.Text = t.Type;
            credit.Text = card.Credit.ToString();
        }

        private void acceptButton_Click(object sender, System.EventArgs e)
        {
            decimal result;
            if (decimal.TryParse(toSubstract.Text, out result))
            {
                if (result < card.Credit)
                {
                    card.Credit -= result;
                    DiscountCardGateway.Update(card);
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
