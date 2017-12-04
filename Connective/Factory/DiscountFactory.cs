using Connective.Abstract.Interface;
using Connective.Backup;
using Connective.TableGateway;
using Connective.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connective.Factory
{
    public class DiscountFactory
    {
        public DiscountGatewayInterface<DiscountCard> GetCard()
        {
            if (Configure.DISCOUNTREAD == 0)
            {
                return DiscountGateway<DiscountCard>.Instance;
            }
            else
            {
                return DiscountXMLGateway<DiscountCard>.Instance;
            }

        }
    }
}
