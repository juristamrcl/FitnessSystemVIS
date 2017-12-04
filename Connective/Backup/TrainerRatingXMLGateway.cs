using Connective.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Connective.Backup
{
    public class TrainerRatingXMLGateway
    {
        public static XElement Insert(TrainerRating rating)
        {
            XElement result = new XElement("TrainerRating",
                new XAttribute("Id", rating.RecordId),
                new XAttribute("Text", rating.Text),
                new XAttribute("RatingNumber", rating.RatingNumber.ToString()),
                new XAttribute("ClientId", rating.ClientId),
                new XAttribute("TrainerId", rating.TrainerId));

            return result;
        }

        public static List<XElement> Select()
        {
            XDocument xDoc = XDocument.Load(Paths.FilePath);

            List<XElement> elementy = xDoc.Descendants("TrainerRatings").Descendants("TrainerRating").ToList();

            return elementy;
        }
    }
}
