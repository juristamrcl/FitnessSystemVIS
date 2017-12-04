using Connective.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Connective.Backup
{
    public class TrainingXMLGateway
    {
        public static XElement Insert(Training training)
        {
            XElement result = new XElement("Training",
                new XAttribute("Id", training.RecordId),
                new XAttribute("TimeFrom", training.TimeFrom),
                new XAttribute("TimeTo", (training.TimeTo == null) ? "null" : training.TimeTo.ToString()),
                new XAttribute("ClientId", training.ClientId),
                new XAttribute("LockerId", training.LockerId),
                new XAttribute("TrainerId", (training.TrainerId == null) ? "null" : training.TrainerId.ToString()),
                new XAttribute("ToGender", training.ToGender));

            return result;
        }

        public static List<XElement> Select()
        {
            XDocument xDoc = XDocument.Load(Paths.FilePath);

            List<XElement> elementy = xDoc.Descendants("Trainings").Descendants("Training").ToList();

            return elementy;
        }
    }
}
