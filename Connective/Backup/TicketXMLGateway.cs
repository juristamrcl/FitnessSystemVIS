using Connective.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Connective.Backup
{
    public class TicketXMLGateway
    {
        public static XElement Insert(Ticket ticket)
        {
            XElement result = new XElement("Ticket",
                new XAttribute("Id", ticket.RecordId),
                new XAttribute("Type", ticket.Type),
                new XAttribute("Validity", (ticket.Validity == null) ? "null" : ticket.Validity.ToString()),
                new XAttribute("Cost", ticket.Cost.ToString()),
                new XAttribute("Description", ticket.Description));

            return result;
        }

        public static List<XElement> Select()
        {
            XDocument xDoc = XDocument.Load(Paths.FilePath);

            List<XElement> elementy = xDoc.Descendants("Tickets").Descendants("Ticket").ToList();

            return elementy;
        }
    }
}
