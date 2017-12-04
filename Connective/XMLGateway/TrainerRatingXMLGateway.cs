using Connective.Abstract.Interface;
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
    public class TrainerRatingXMLGateway<T> : TrainerRatingGatewayInterface<T>
        where T : TrainerRating
    {
        private static TrainerRatingXMLGateway<TrainerRating> instance;
        private TrainerRatingXMLGateway() { }

        public static TrainerRatingXMLGateway<TrainerRating> Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TrainerRatingXMLGateway<TrainerRating>();
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

        public XElement Insert(TrainerRating rating)
        {
            XElement result = new XElement("TrainerRating",
                new XAttribute("Id", rating.RecordId),
                new XAttribute("Text", rating.Text),
                new XAttribute("RatingNumber", rating.RatingNumber.ToString()),
                new XAttribute("ClientId", rating.ClientId),
                new XAttribute("TrainerId", rating.TrainerId));

            return result;
        }

        public Collection<T> Select()
        {
            XDocument xDoc = XDocument.Load(Paths.FilePath);

            List<XElement> elements = xDoc.Descendants("TrainerRatings").Descendants("TrainerRating").ToList();
            Collection<T> ratings = new Collection<T>();

            foreach (var element in elements)
            {
                TrainerRating rating = new TrainerRating()
                {
                    ClientId = int.Parse(element.Attribute("ClientId").Value),
                    TrainerId = int.Parse(element.Attribute("TrainerId").Value),
                    RatingNumber = decimal.Parse(element.Attribute("RatingNumber").Value),
                    Text = element.Attribute("Text").Value
                };
                ratings.Add((T)rating);
            }

            return ratings;
        }

        public int Update(T t)
        {
            throw new NotImplementedException();
        }
    }
}
