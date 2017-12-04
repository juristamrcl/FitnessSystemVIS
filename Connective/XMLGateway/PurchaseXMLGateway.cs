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
    public class PurchaseXMLGateway<T> : PurchaseGatewayInterface<T>
        where T : Purchase
    {
        private static PurchaseXMLGateway<Purchase> instance;
        private PurchaseXMLGateway() { }

        public static PurchaseXMLGateway<Purchase> Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PurchaseXMLGateway<Purchase>();
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

        public XElement Insert(Purchase purchase)
        {
            XElement result = new XElement("Purchase",
                new XAttribute("Id", purchase.RecordId),
                new XAttribute("Date", purchase.Date),
                new XAttribute("TicketId", purchase.TicketId),
                new XAttribute("CardId", purchase.CardId));

            return result;
        }

        public Collection<T> Select()
        {
            XDocument xDoc = XDocument.Load(Paths.FilePath);

            List<XElement> elements = xDoc.Descendants("Purchases").Descendants("Purchase").ToList();
            Collection<T> purchases = new Collection<T>();

            foreach (var element in elements)
            {
                Purchase purchase = new Purchase()
                {
                    TicketId = int.Parse(element.Attribute("TicketId").Value),
                    CardId = int.Parse(element.Attribute("CardId").Value),
                    Date = DateTime.Parse(element.Attribute("Date").Value)
                };

                purchases.Add((T)purchase);
            }

            return purchases;
        }

        public int Update(T t)
        {
            throw new NotImplementedException();
        }
    }
}
