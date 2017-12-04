using Connective.Abstract;
using System;

namespace Connective.Tables
{
    public class Purchase: DBRecord
    {
        public override int RecordId { get; set; }
        public DateTime Date { get; set; }
        public int TicketId { get; set; }
        public int CardId { get; set; }
    }
}
