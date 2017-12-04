using Connective.Abstract.Interface;
using Connective.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Connective.Backup;
using Connective.TableGateway;

namespace Connective.Factory
{
    public class PurchaseFactory
    {
        public PurchaseGatewayInterface<Purchase> GetPurchase()
        {
            if (Configure.TRAININGREAD == 0)
            {
                return PurchaseGateway<Purchase>.Instance;
            }
            else
            {
                return PurchaseXMLGateway<Purchase>.Instance;
            }

        }
    }
}
