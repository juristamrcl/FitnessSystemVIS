using Connective.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Connective.Backup
{
    public class TrainerXMLGateway
    {
        public static XElement Insert(Trainer trainer )
        {
            XElement result = new XElement("Trainer",
                new XAttribute("Id", trainer.RecordId),
                new XAttribute("Specialization", trainer.Specialization),
                new XAttribute("Name", trainer.Name),
                new XAttribute("Surname", trainer.Surname),
                new XAttribute("Mail", trainer.Mail),
                new XAttribute("License", (trainer.License == null) ? "null" : trainer.License));
            return result;
        }

        public static List<XElement> Select()
        {
            XDocument xDoc = XDocument.Load(Paths.FilePath);

            List<XElement> elementy = xDoc.Descendants("Trainers").Descendants("Trainer").ToList();

            return elementy;
        }
    }
}
