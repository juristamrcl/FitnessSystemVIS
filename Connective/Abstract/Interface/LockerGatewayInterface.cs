using Connective.Tables;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connective.Abstract
{
    public interface LockerGatewayInterface<T> : Gateway<T>
        where T : Locker
    {
        T Select(int id, string toGender);
        Collection<T> Select(string togender);
    }
}
