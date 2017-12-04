using Connective.Abstract;
using Connective.TableGateway;
using Connective.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connective.Factory
{
    public class ClientFactory
    {
        public Gateway<Client> GetClient() {
            if (Configure.CLIENTREAD == 0)
            {
                return ClientGateway<Client>.Instance;
            }
            else
            {
                return ClientGateway<Client>.Instance;
            }
            
        }
        
    }
}
