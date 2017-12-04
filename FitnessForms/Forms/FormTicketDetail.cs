using FitnessForms.Templates;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using Connective.Tables;
using Connective.TableGateway;

namespace FitnessForms.Forms
{
    public partial class FormTicketDetail : FormDetail
    {
        private Ticket ticket;
        private bool newRecord;

        public FormTicketDetail()
        {
            InitializeComponent();
        }
        public override bool OpenRecord(object primaryKey)
        {
            if (primaryKey != null)
            {
                int idTicket = (int)primaryKey;
                ticket = TicketGateway.Select(idTicket);
                newRecord = false;
            }
            else
            {
                ticket = new Ticket();
                newRecord = true;
            }
            BindData();
            return true;
        }
        private void BindData()
        {
            Collection<string> types = new Collection<string>();
            types.Add("period");
            types.Add("credit");

            comboType.DataSource = types;

            textValidity.Text = ticket.Validity.ToString();
            textCost.Text = ticket.Cost.ToString();
            textDescription.Text = ticket.Description;
            comboType.Text = ticket.Type;
        }
        private bool GetData()
        {
            bool ret = true;

            errorProvider.Clear();

            ticket.Type = comboType.Text;
            ticket.Description = textDescription.Text;
            int j;
            decimal h;
            if (Int32.TryParse(textValidity.Text, out j))
            {
                ticket.Validity = j;
            }
            else
            {
                ret = false;
                errorProvider.SetError(textValidity, "Invalid number.");
            }
            if (Decimal.TryParse(textCost.Text, out h))
            {
                ticket.Cost = h;
            }
            else
            {
                ret = false;
                errorProvider.SetError(textCost, "Invalid number.");
            }

           
            if (ticket.Type == "credit" || ticket.Type == "period")
            {

            }
            else
            {
                ret = false;
                errorProvider.SetError(comboType, "Invalid type.");
            }

            return ret;
        }

        protected override bool SaveRecord()
        {

            if (GetData())
            {
                if (newRecord)
                {
                    TicketGateway.Insert(ticket);
                }
                else
                {
                    TicketGateway.Update(ticket);
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
            TicketGateway.Delete(ticket.RecordId);
            return true;
        }
    }
}
