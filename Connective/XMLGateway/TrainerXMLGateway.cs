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
    public class TrainerXMLGateway<T> : TrainerGatewayInterface<T>
        where T : Trainer
    {
        private static TrainerXMLGateway<Trainer> instance;
        private TrainerXMLGateway() { }

        public static TrainerXMLGateway<Trainer> Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TrainerXMLGateway<Trainer>();
                }
                return instance;
            }
        }

        public XElement Insert(Trainer trainer )
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

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(T t)
        {
            throw new NotImplementedException();
        }

        public Collection<T> Select()
        {
            XDocument xDoc = XDocument.Load(Paths.FilePath);

            List<XElement> elements = xDoc.Descendants("Trainers").Descendants("Trainer").ToList();
            Collection<T> trainers = new Collection<T>();

            foreach (var element in elements)
            {
                Trainer trainer = new Trainer()
                {
                    Name = element.Attribute("Name").Value,
                    Surname = element.Attribute("Surname").Value,
                    Mail = element.Attribute("Mail").Value,
                    Specialization = element.Attribute("Specialization").Value,
                    License = element.Attribute("License").Value,
                };
                if (trainer.License == "null")
                {
                    trainer.License = null;
                }
                trainers.Add((T)trainer);
            }

            return trainers;
        }

        public int Update(T t)
        {
            throw new NotImplementedException();
        }
    }
}
