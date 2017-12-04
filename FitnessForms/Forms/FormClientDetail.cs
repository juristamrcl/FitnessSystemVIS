using Connective.Tables;
using Connective.TableGateway;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using Connective.Factory;

namespace FitnessForms.Forms
{
    public partial class FormClientDetail : Templates.FormDetail
    {
        private Client client;
        private bool newRecord;

        public FormClientDetail()
        {
            InitializeComponent();
        }

        public override bool OpenRecord(object primaryKey)
        {
            if (primaryKey != null)
            {
                int idClient = (int)primaryKey;
                ClientFactory clientFactory = new ClientFactory();
                ClientGateway<Client> cg = (ClientGateway<Client>)clientFactory.GetClient();
                client = cg.Select(idClient);
                newRecord = false;
            }
            else
            {
                client = new Client();
                newRecord = true;
            }
            BindData();
            return true;
        }

        private void BindData()
        {
            Collection<string> genders = new Collection<string>();
            genders.Add("male");
            genders.Add("female");

            comboGender.DataSource = genders;

            textName.Text = client.Name;
            textSurname.Text = client.Surname;
            textMail.Text = client.Mail != null ? client.Mail : string.Empty;
            textCard.Text = client.CardId.ToString();
            comboGender.Text = client.Gender;
        }

        private bool GetData()
        {
            bool ret = true;

            errorProvider.Clear();

            client.Name = textName.Text;
            client.Surname = textSurname.Text;
            client.Mail = textMail.Text;
            client.Gender = comboGender.Text;
            int j;
            if (textName.Text == "")
            {
                errorProvider.SetError(textName, "Insert name!");
            }
            if (textSurname.Text == "")
            {
                errorProvider.SetError(textSurname, "Insert surname!");
            }
            if (Int32.TryParse(textCard.Text, out j))
            {
                client.CardId = j;
            }
            else
            {
                ret = false;
                errorProvider.SetError(textCard, "Invalid card number.");
            }

            if (!client.Mail.Contains("@") || !client.Mail.Contains("."))
            {
                ret = false;
                errorProvider.SetError(textMail, "Invalid mail format.");
            }
            if (client.Gender == "male" || client.Gender == "female")
            {
                
            }
            else
            {
                ret = false;
                errorProvider.SetError(comboGender, "Invalid gender.");
            }

            return ret;
        }

        protected override bool SaveRecord()
        {
            ClientFactory clientFactory = new ClientFactory();
            ClientGateway<Client> cg = (ClientGateway<Client>)clientFactory.GetClient();

            if (GetData())
            {
                if (newRecord)
                {
                    cg.Insert(client);
                }
                else
                {
                    cg.Update(client);
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        protected override bool DeleteRecord()
        {
            DiscountFactory discountFactory = new DiscountFactory();
            DiscountGateway<DiscountCard> dg = (DiscountGateway<DiscountCard>)discountFactory.GetCard();

            DiscountCard c = dg.Select((int)client.CardId);
            c.ClientId = null;
            dg.Update(c);
            ClientFactory clientFactory = new ClientFactory();
            ClientGateway<Client> cg = (ClientGateway<Client>)clientFactory.GetClient();
            cg.Delete(client.RecordId);
            return true;
        }
    }
}
