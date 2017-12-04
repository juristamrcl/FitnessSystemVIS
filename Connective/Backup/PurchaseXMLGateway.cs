using Connective.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Connective.Backup
{
    public class PurchaseXMLGateway
    {
        public static XElement Insert(Purchase purchase)
        {
            XElement result = new XElement("Purchase",
                new XAttribute("Id", purchase.RecordId),
                new XAttribute("Date", purchase.Date),
                new XAttribute("TicketId", purchase.TicketId),
                new XAttribute("CardId", purchase.CardId));

            return result;
        }

        public static List<XElement> Select()
        {
            XDocument xDoc = XDocument.Load(Paths.FilePath);

            List<XElement> elementy = xDoc.Descendants("Purchases").Descendants("Purchase").ToList();

            return elementy;
        }
    }
}
