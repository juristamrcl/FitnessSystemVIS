using Connective.Tables;
using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using Connective.Conn;


namespace Connective.TableGateway
{
    public class DiscountCardGateway
    {
        public static String SQL_SELECT = "SELECT * FROM Discount_card";
        public static String SQL_SELECT_ID = "SELECT * FROM Discount_card WHERE card_id=@card_id";
        public static String SQL_INSERT = "INSERT INTO Discount_card VALUES (@client_id, @credit)";
        public static String SQL_UPDATE = "UPDATE Discount_card SET client_id=@client_id, credit=@credit WHERE card_id=@card_id";
        public static String SQL_DELETE_ID = "DELETE FROM Discount_card WHERE card_id=@card_id";
        public static String SQL_DELETE = "DELETE FROM Discount_card";

        private static void PrepareCommand(SqlCommand command, DiscountCard discountCard)
        {
            command.Parameters.AddWithValue("@client_id", discountCard.ClientId);
            command.Parameters.AddWithValue("@credit", discountCard.Credit.HasValue ? (object)discountCard.Credit.Value : DBNull.Value);
        }
        private static void PrepareCommandU(SqlCommand command, DiscountCard discountCard)
        {
            command.Parameters.AddWithValue("@card_id", discountCard.RecordId);
            command.Parameters.AddWithValue("@client_id", discountCard.ClientId.HasValue ? (object)discountCard.ClientId.Value : DBNull.Value);
            command.Parameters.AddWithValue("@credit", discountCard.Credit.HasValue ? (object)discountCard.Credit.Value : DBNull.Value);
        }

        public static int Insert(DiscountCard DiscountCard)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, DiscountCard);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        public static int Update(DiscountCard DiscountCard)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommandU(command, DiscountCard);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        public static Collection<DiscountCard> Select()
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<DiscountCard> Categorys = Read(reader);

            db.Close();
            return Categorys;
        }

        public static DiscountCard Select(int id)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_ID);

            command.Parameters.AddWithValue("@card_id", id);
            SqlDataReader reader = db.Select(command);

            Collection<DiscountCard> cards = Read(reader);
            DiscountCard card = null;
            if (cards.Count == 1)
            {
                card = cards[0];
            }

            db.Close();
            return card;
        }

        public static int Delete(int id)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_DELETE_ID);

            command.Parameters.AddWithValue("@card_id", id);
            int ret = db.ExecuteNonQuery(command);

            db.Close();
            return ret;
        }

        public static int Delete()
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_DELETE);

            int ret = db.ExecuteNonQuery(command);

            db.Close();
            return ret;
        }
        private static Collection<DiscountCard> Read(SqlDataReader reader)
        {
            Collection<DiscountCard> cards = new Collection<DiscountCard>();

            while (reader.Read())
            {
                DiscountCard card = new DiscountCard();
                int i = -1;
                card.RecordId = reader.GetInt32(++i);
                
                if (!reader.IsDBNull(++i))
                {
                    card.ClientId = reader.GetInt32(i);
                }
                if (!reader.IsDBNull(++i))
                {
                    card.Credit = reader.GetDecimal(i);
                }

                cards.Add(card);
            }
            return cards;
        }
    }
}
