using Connective.Tables;
using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using Connective.Conn;
using Connective.Abstract.Interface;

namespace Connective.TableGateway
{
    public class DiscountGateway<T> : DiscountGatewayInterface<T>
        where T : DiscountCard
    {
        private static DiscountGateway<DiscountCard> instance;
        private DiscountGateway() { }

        public static DiscountGateway<DiscountCard> Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DiscountGateway<DiscountCard>();
                }
                return instance;
            }
        }

        public String SQL_SELECT = "SELECT * FROM Discount_card";
        public String SQL_SELECT_ID = "SELECT * FROM Discount_card WHERE card_id=@card_id";
        public String SQL_INSERT = "INSERT INTO Discount_card VALUES (@client_id, @credit)";
        public String SQL_UPDATE = "UPDATE Discount_card SET client_id=@client_id, credit=@credit WHERE card_id=@card_id";
        public String SQL_DELETE_ID = "DELETE FROM Discount_card WHERE card_id=@card_id";
        public String SQL_DELETE = "DELETE FROM Discount_card";

        private void PrepareCommand(SqlCommand command, DiscountCard discountCard)
        {
            command.Parameters.AddWithValue("@client_id", discountCard.ClientId);
            command.Parameters.AddWithValue("@credit", discountCard.Credit.HasValue ? (object)discountCard.Credit.Value : DBNull.Value);
        }
        private void PrepareCommandU(SqlCommand command, DiscountCard discountCard)
        {
            command.Parameters.AddWithValue("@card_id", discountCard.RecordId);
            command.Parameters.AddWithValue("@client_id", discountCard.ClientId.HasValue ? (object)discountCard.ClientId.Value : DBNull.Value);
            command.Parameters.AddWithValue("@credit", discountCard.Credit.HasValue ? (object)discountCard.Credit.Value : DBNull.Value);
        }

        public int Insert(T DiscountCard)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, DiscountCard);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        public int Update(T DiscountCard)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommandU(command, DiscountCard);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        public Collection<T> Select()
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<T> Categorys = Read(reader);

            db.Close();
            return Categorys;
        }

        public T Select(int id)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_ID);

            command.Parameters.AddWithValue("@card_id", id);
            SqlDataReader reader = db.Select(command);

            Collection<T> cards = Read(reader);
            T card = null;
            if (cards.Count == 1)
            {
                card = cards[0];
            }

            db.Close();
            return card;
        }

        public int Delete(int id)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_DELETE_ID);

            command.Parameters.AddWithValue("@card_id", id);
            int ret = db.ExecuteNonQuery(command);

            db.Close();
            return ret;
        }

        public int Delete()
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_DELETE);

            int ret = db.ExecuteNonQuery(command);

            db.Close();
            return ret;
        }
        private Collection<T> Read(SqlDataReader reader)
        {
            Collection<T> cards = new Collection<T>();

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

                cards.Add((T)card);
            }
            return cards;
        }
    }
}
