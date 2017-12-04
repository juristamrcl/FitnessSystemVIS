using Connective.Tables;
using Connective.TableGateway;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Connective.Factory;

namespace FitnessForms.Forms
{
    public partial class FormCardGrid : Templates.FormGrid
    {
        public FormCardGrid()
        {
            InitializeComponent();
        }

        protected override void RefreshData()
        {
            Collection<DiscountCard> cards = DiscountCardGateway.Select();
            Collection<ExtendedCard> ecards = new Collection<ExtendedCard>();

            foreach(DiscountCard dc in cards)
            {
                ExtendedCard ec = new ExtendedCard();
                ec.CardId = dc.RecordId;
                ec.Credit = dc.Credit;
                if (dc.ClientId != null)
                {
                    ClientFactory clientFactory = new ClientFactory();
                    ClientGateway<Client> cg = (ClientGateway<Client>)clientFactory.GetClient();
                    Client c = cg.Select((int)dc.ClientId);
                    ec.Name = c.Name + " " + c.Surname;
                    ec.ClientId = (int)dc.ClientId;
                }
                ecards.Add(ec);
            }
            BindingList<ExtendedCard> bindingList = new BindingList<ExtendedCard>(ecards);
            cardsGrid.AutoGenerateColumns = false;
            cardsGrid.DataSource = bindingList;
        }

        private DiscountCard GetSelectedCard()
        {
            if (cardsGrid.SelectedRows.Count == 1)
            {
                ExtendedCard ecard = cardsGrid.SelectedRows[0].DataBoundItem as ExtendedCard;
                DiscountCard card = new DiscountCard();
                card.RecordId = ecard.CardId;
                card.Credit = ecard.Credit;
                card.ClientId = ecard.ClientId;
                return card;
            }
            else
            {
                return null;
            }
        }

        protected override void NewRecord()
        {

            FormCardDetail form = new FormCardDetail();
            if (form.OpenRecord(null))
            {
                form.ShowDialog();
                RefreshData();
            }
        }

        protected override void EditRecord()
        {
            Console.Write("Done");
            DiscountCard selectedCard = GetSelectedCard();
            if (selectedCard != null)
            {
                FormCardDetail form = new FormCardDetail();
                if (form.OpenRecord(selectedCard.RecordId))
                {
                    form.ShowDialog();
                    RefreshData();
                }
            }
        }

        private void cardsGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditRecord();
        }
    }

    class ExtendedCard
    {
        public int CardId { get; set; }
        public int? ClientId { get; set; }
        public string Name { get; set; }
        public decimal? Credit { get; set; }
    }
}
