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
    public class LockerXMLGateway
    {
        public static XElement Insert(Locker locker)
        {
            XElement result = new XElement("Locker",
                new XAttribute("Id", locker.RecordId),
                new XAttribute("ToGender", locker.ToGender),
                new XAttribute("Status", locker.Status));

            return result;
        }

        public static List<XElement> Select()
        {
            XDocument xDoc = XDocument.Load(Paths.FilePath);

            List<XElement> elementy = xDoc.Descendants("Lockers").Descendants("Locker").ToList();

            return elementy;
        }

        public static Collection<Locker> SelectToObject()
        {
            XDocument xDoc = XDocument.Load(Paths.FilePath);

            List<XElement> elementy = xDoc.Descendants("Lockers").Descendants("Locker").ToList();
            Collection<Locker> lockers = new Collection<Locker>();

            foreach (var el in elementy)
            {
                Locker l = new Locker();
                l.Status = el.Attribute("Status").Value;
                l.ToGender = el.Attribute("ToGender").Value;
                l.RecordId = int.Parse(el.Attribute("Id").Value);
                lockers.Add(l);
            }
            return lockers;
        }
    }
}
