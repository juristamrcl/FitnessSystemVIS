using Connective.Tables;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Connective.Abstract;

namespace Connective.Backup
{
    public class LockerXMLGateway<T> : LockerGatewayInterface<T>
        where T: Locker
    {
        private static LockerXMLGateway<Locker> instance;
        private LockerXMLGateway() { }

        public static LockerXMLGateway<Locker> Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LockerXMLGateway<Locker>();
                }
                return instance;
            }
        }

        public XElement Insert(Locker locker)
        {
            XElement result = new XElement("Locker",
                new XAttribute("Id", locker.RecordId),
                new XAttribute("ToGender", locker.ToGender),
                new XAttribute("Status", locker.Status));
            return result;
        }

        public int Update(T t)
        {
            throw new NotImplementedException();
        }

        public Collection<T> Select()
        {
            XDocument xDoc = XDocument.Load(Paths.FilePath);
            Collection<T> lockers = new Collection<T>();

            List<XElement> elements = xDoc.Descendants("Lockers").Descendants("Locker").ToList();

            foreach (var element in elements)
            {
                Locker locker = new Locker()
                {
                    Status = element.Attribute("Status").Value,
                    ToGender = element.Attribute("ToGender").Value,
                    RecordId = int.Parse(element.Attribute("Id").Value)
                };
                lockers.Add((T)locker);
            }
            return lockers;
        }

        public Collection<T> Select(string toGender)
        {
            XDocument xDoc = XDocument.Load(Paths.FilePath);
            Collection<T> lockers = new Collection<T>();

            List<XElement> elements = xDoc.Descendants("Lockers").Descendants("Locker").ToList();

            foreach (var element in elements)
            {
                Locker locker = new Locker()
                {
                    Status = element.Attribute("Status").Value,
                    ToGender = element.Attribute("ToGender").Value,
                    RecordId = int.Parse(element.Attribute("Id").Value)
                };
                if (toGender == locker.ToGender)
                    lockers.Add((T)locker);
            }
            return lockers;
        }

        public T Select(int id, string toGender)
        {
            XDocument xDoc = XDocument.Load(Paths.FilePath);

            List<XElement> elements = xDoc.Descendants("Lockers").Descendants("Locker").ToList();
            Locker locker = new Locker();

            foreach (var element in elements)
            {
                locker.Status = element.Attribute("Status").Value;
                locker.ToGender = element.Attribute("ToGender").Value;
                locker.RecordId = int.Parse(element.Attribute("Id").Value);

                if (toGender == locker.ToGender && id == locker.RecordId)
                    return (T)locker;
            }
            return (T)locker;
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(T t)
        {
            throw new NotImplementedException();
        }
    }
}
