using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connective.Abstract
{
    public abstract class DBRecord
    {
        public abstract int RecordId { get; set; }
    }
}
