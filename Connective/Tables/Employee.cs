using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Connective.Abstract;

namespace Connective.Tables
{
    public class Employee: DBRecord
    {
        public override int RecordId { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }

        public Employee()
        {

        }

        public Employee(int RecordId, string Mail, string Password)
        {
            this.Mail = Mail;
            this.Password = Password;
            this.RecordId = RecordId;
        }
    }
}
