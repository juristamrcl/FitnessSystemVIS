using Connective.Abstract;
using Connective.Abstract.Interface;
using Connective.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Collections.ObjectModel;

namespace Connective.Backup
{
    public class TrainingXMLGateway<T> : TrainingGatewayInterface<T>
        where T : Training
    {
        private static TrainingXMLGateway<Training> instance;
        private TrainingXMLGateway() { }

        public static TrainingXMLGateway<Training> Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TrainingXMLGateway<Training>();
                }
                return instance;
            }
        }

        public XElement Insert(Training training)
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

        public Collection<T> Select()
        {
            XDocument xDoc = XDocument.Load(Paths.FilePath);

            List<XElement> elements = xDoc.Descendants("Trainings").Descendants("Training").ToList();
            Collection<T> trainings = new Collection<T>();
            foreach (var element in elements)
            {
                var res = 0;
                var dateTime = DateTime.Now;
                Training training = new Training()
                {
                    ClientId = int.TryParse(element.Attribute("ClientId").Value, out res) == true ? res : 0,
                    LockerId = int.TryParse(element.Attribute("LockerId").Value, out res) == true ? res : 0,
                    TimeFrom = DateTime.TryParse(element.Attribute("TimeFrom").Value, out dateTime) ? dateTime : DateTime.Now,
                    ToGender = element.Attribute("ToGender").Value,
                };
                if (DateTime.TryParse(element.Attribute("TimeTo").Value, out dateTime))
                {
                    training.TimeTo = dateTime;
                }
                else
                {
                    training.TimeTo = null;
                }
                if (int.TryParse(element.Attribute("TrainerId").Value, out res))
                {
                    training.TrainerId = res;
                }
                else
                {
                    training.TrainerId = 1;
                }
                trainings.Add((T)training);
            }

            return trainings;
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(T t)
        {
            throw new NotImplementedException();
        }

        public int Update(T t)
        {
            throw new NotImplementedException();
        }
    }
}
