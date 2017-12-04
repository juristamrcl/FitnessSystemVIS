using System;
using Connective.Abstract;

namespace Connective.Tables
{
    public class Training: DBRecord
    {
        public override int RecordId { get; set; }
        public DateTime TimeFrom { get; set; }
        public DateTime? TimeTo { get; set; }
        public int ClientId { get; set; }
        public int LockerId { get; set; }
        public int? TrainerId { get; set; }
        public string ToGender { get; set; }
    }
}
