using Connective.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Connective.Backup
{
    public class DiscountXMLGateway
    {
        public static XElement Insert(DiscountCard card)
        {
            XElement result = new XElement("DiscountCard",
                new XAttribute("Id", card.RecordId),
                new XAttribute("ClientId", (card.ClientId == null) ? "null" : card.ClientId.ToString()),
                new XAttribute("Credit", (card.Credit == null) ? "null" : card.Credit.ToString()));

            return result;
        }

        public static List<XElement> Select()
        {
            XDocument xDoc = XDocument.Load(Paths.FilePath);

            List<XElement> elementy = xDoc.Descendants("DiscountCards").Descendants("DiscountCard").ToList();

            return elementy;
        }
    }
}
