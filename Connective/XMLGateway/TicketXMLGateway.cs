using Connective.Abstract;
using Connective.Tables;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Connective.Backup
{
    public class TicketXMLGateway<T> : TicketGatewayInterface<T>
        where T : Ticket
    {
        private static TicketXMLGateway<Ticket> instance;
        private TicketXMLGateway() { }

        public static TicketXMLGateway<Ticket> Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TicketXMLGateway<Ticket>();
                }
                return instance;
            }
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(T t)
        {
            throw new NotImplementedException();
        }

        public XElement Insert(Ticket ticket)
        {
            XElement result = new XElement("Ticket",
                new XAttribute("Id", ticket.RecordId),
                new XAttribute("Type", ticket.Type),
                new XAttribute("Validity", (ticket.Validity == null) ? "null" : ticket.Validity.ToString()),
                new XAttribute("Cost", ticket.Cost.ToString()),
                new XAttribute("Description", ticket.Description));

            return result;
        }

        public Collection<T> Select()
        {
            XDocument xDoc = XDocument.Load(Paths.FilePath);

            List<XElement> elements = xDoc.Descendants("Tickets").Descendants("Ticket").ToList();
            Collection<T> tickets = new Collection<T>();

            foreach (var element in elements)
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
                tickets.Add((T)ticket);
            }

            return tickets;
        }

        public int Update(T t)
        {
            throw new NotImplementedException();
        }
    }
}
