using Connective.Backup;
using Connective.TableGateway;
using Connective.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Connective.Abstract;

namespace Connective.Factory
{
    public class LockerFactory
    {
        public LockerGatewayInterface<Locker> GetLocker()
        {
            if (Configure.LOCKERREAD == 0)
            {
                return LockerGateway<Locker>.Instance;
            }
            else
            {
                return LockerXMLGateway<Locker>.Instance;
            }

        }
    }
}
