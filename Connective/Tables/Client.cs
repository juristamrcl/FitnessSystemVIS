using Connective.Abstract;
using System;

namespace Connective.Tables
{
    public class Client : DBRecord
    {
        public override int RecordId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string Gender { get; set; }
        public int? CardId { get; set; }
        public int? Favourite_locker { get; set; }
        public string Password { get; set; }
        public override string ToString()
        {
            return Name + " " + Surname;
        }
    }
}
