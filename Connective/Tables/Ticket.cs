using Connective.Abstract;

namespace Connective.Tables
{
    public class Ticket: DBRecord
    {
        public override int RecordId { get; set; }
        public string Type { get; set; }
        public int? Validity { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
    }
}
