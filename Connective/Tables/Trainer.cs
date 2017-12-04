using Connective.Abstract;

namespace Connective.Tables
{
    public class Trainer: DBRecord
    {
        public override int RecordId { get; set; }
        public string Specialization { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string License { get; set; }

        public override string ToString()
        {
            return Name + " " + Surname;
        }
    }
}
