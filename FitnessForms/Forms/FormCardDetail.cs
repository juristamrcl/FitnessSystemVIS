using Connective.Tables;
using Connective.TableGateway;
using System;
using System.Data;
using System.Linq;
using Connective.Factory;

namespace FitnessForms.Forms
{
    public partial class FormCardDetail : Templates.FormDetail
    {
        private DiscountCard card;
        private bool newRecord;

        public FormCardDetail()
        {
            InitializeComponent();
        }

        public override bool OpenRecord(object primaryKey)
        {
            DiscountFactory discountFactory = new DiscountFactory();
            DiscountGateway<DiscountCard> dg = (DiscountGateway<DiscountCard>)discountFactory.GetCard();

            if (primaryKey != null)
            {
                int idCard = (int)primaryKey;
                card = dg.Select(idCard);
                newRecord = false;
            }
            else
            {
                card = new DiscountCard();
                newRecord = true;
            }
            BindData();
            return true;
        }

        private void BindData()
        {
            textClientId.Text = card.ClientId.ToString();
            textCardId.Text = card.RecordId.ToString();
            textCredit.Text = card.Credit.ToString();
        }

        private bool GetData()
        {
            bool ret = true;

            errorProvider.Clear();

            int j, h;
            decimal k;
            if (Int32.TryParse(textClientId.Text, out j))
            {
                card.ClientId = j;
            }
            else
            {
                ret = false;
                errorProvider.SetError(textClientId, "Invalid client number.");
            }

            if (Int32.TryParse(textCardId.Text, out h))
            {
                card.RecordId = h;
            }
            else
            {
                ret = false;
                errorProvider.SetError(textClientId, "Invalid card number.");
            }

            if (Decimal.TryParse(textCredit.Text, out k))
            {
                card.Credit = k;
            }
            else
            {
                ret = false;
                errorProvider.SetError(textClientId, "Invalid credit.");
            }

            return ret;
        }

        protected override bool SaveRecord()
        {
            DiscountFactory discountFactory = new DiscountFactory();
            DiscountGateway<DiscountCard> dg = (DiscountGateway<DiscountCard>)discountFactory.GetCard();

            if (GetData())
            {
                if (newRecord)
                {
                    dg.Insert(card);
                }
                else
                {
                    dg.Update(card);
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
            dg.Delete(card.RecordId);
            return true;
        }
    }
}
