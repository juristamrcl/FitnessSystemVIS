using Connective.Abstract;

namespace Connective.Tables
{
    public class Locker: DBRecord
    {
        public override int RecordId { get; set; }
        public string ToGender { get; set; }
        public string Status { get; set; }

        public override string ToString()
        {
            return ToGender + ": " + RecordId;
        }
    }
}
