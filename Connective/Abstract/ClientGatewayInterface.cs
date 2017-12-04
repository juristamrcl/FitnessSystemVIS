using Connective.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connective.Abstract
{
    interface ClientGatewayInterface<T> : Gateway<T>
        where T: Client
    {
    }
}
