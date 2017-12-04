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
    public class DiscountXMLGateway<T> : DiscountGatewayInterface<T>
        where T : DiscountCard
    {
        private static DiscountXMLGateway<DiscountCard> instance;
        private DiscountXMLGateway() { }

        public static DiscountXMLGateway<DiscountCard> Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DiscountXMLGateway<DiscountCard>();
                }
                return instance;
            }
        }

        public XElement Insert(DiscountCard card)
        {
            XElement result = new XElement("DiscountCard",
                new XAttribute("Id", card.RecordId),
                new XAttribute("ClientId", (card.ClientId == null) ? "null" : card.ClientId.ToString()),
                new XAttribute("Credit", (card.Credit == null) ? "null" : card.Credit.ToString()));

            return result;
        }

        public Collection<T> Select()
        {
            XDocument xDoc = XDocument.Load(Paths.FilePath);

            List<XElement> elements = xDoc.Descendants("DiscountCards").Descendants("DiscountCard").ToList();
            Collection<T> cards = new Collection<T>(); 

            foreach (var element in elements)
            {
                var res = 0;
                var dec = 0.0M;
                DiscountCard card = new DiscountCard()
                {
                    Credit = decimal.TryParse(element.Attribute("ClientId").Value, out dec) == true ? dec : 0.0M,
                    ClientId = int.TryParse(element.Attribute("ClientId").Value, out res) == true ? res : 0
                };
                if (card.Credit == 0.0M)
                {
                    card.Credit = null;
                }
                if (card.ClientId == 0)
                {
                    card.ClientId = null;
                }
                cards.Add((T)card);
            }

            return cards;
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
