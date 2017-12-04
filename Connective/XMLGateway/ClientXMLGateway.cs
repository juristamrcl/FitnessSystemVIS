using Connective.Abstract;
using Connective.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Collections.ObjectModel;
using Connective.TableGateway;

namespace Connective.Backup
{
    public class ClientXMLGateway<T> : ClientGatewayInterface<T>
        where T: Client
    {
        private static ClientXMLGateway<Client> instance;
        private ClientXMLGateway() { }

        public static ClientXMLGateway<Client> Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ClientXMLGateway<Client>();
                }
                return instance;
            }
        }

        public XElement Insert(Client client)
        {
            XElement result = new XElement("Client",
                new XAttribute("Id", client.RecordId),
                new XAttribute("Name", client.Name),
                new XAttribute("Surname", client.Surname),
                new XAttribute("Mail", client.Mail),
                new XAttribute("Gender", client.Gender),
                new XAttribute("CardId", (client.CardId == null) ? "null" : client.CardId.ToString()));

            return result;
        }

        Collection<T> Gateway<T>.Select()
        {
            XDocument xDoc = XDocument.Load(Paths.FilePath);
            Collection<T> clients = new Collection<T>();

            List<XElement> elements = xDoc.Descendants("Clients").Descendants("Client").ToList();
            foreach (var element in elements)
            {
                var res = 0;
                Client client = new Client()
                {
                    Name = element.Attribute("Name").Value,
                    Surname = element.Attribute("Surname").Value,
                    Mail = element.Attribute("Mail").Value,
                    Gender = element.Attribute("Gender").Value,
                    CardId = int.TryParse(element.Attribute("CardId").Value, out res) == true ? res : 0
                };
                if (client.CardId == 0)
                    client.CardId = null;
                clients.Add((T)client);
            }

            return clients;
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
