using Connective.Abstract;

namespace Connective.Tables
{
    public class DiscountCard: DBRecord
    {
        public override int RecordId { get; set; }
        public int? ClientId { get; set; }
        public decimal? Credit { get; set; }
    }
}
