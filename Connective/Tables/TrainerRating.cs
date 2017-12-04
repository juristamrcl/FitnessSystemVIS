using Connective.Abstract;

namespace Connective.Tables
{
    public class TrainerRating: DBRecord
    {
        public override int RecordId { get; set; }
        public string Text { get; set; }
        public decimal RatingNumber { get; set; }
        public int ClientId { get; set; }
        public int TrainerId { get; set; }
    }
}
