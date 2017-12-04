using Connective.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Connective.Backup
{
    public class ClientXMLGateway
    {
        public static XElement Insert(Client client)
        {
            XElement result = new XElement("Client",
                new XAttribute("Id", client.RecordId),
                new XAttribute("Name", client.Name),
                new XAttribute("Surname", client.Surname),
                new XAttribute("Mail", client.Mail),
                new XAttribute("Gender", client.Gender),
                new XAttribute("CardId", (client.CardId == null) ? "null" : client.CardId.ToString()));

            return result;
        }

        public static List<XElement> Select()
        {
            XDocument xDoc = XDocument.Load(Paths.FilePath);

            List<XElement> elementy = xDoc.Descendants("Clients").Descendants("Client").ToList();

            return elementy;
        }
    }
}
