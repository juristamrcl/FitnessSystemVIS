using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using Connective.Tables;
using Connective.Conn;

namespace Connective.TableGateway
{
    public class PurchaseGateway
    {
        public static String SQL_SELECT = "SELECT * FROM Purchase";
        public static String SQL_SELECT_ID = "SELECT * FROM Purchase WHERE purchase_id=@purchase_id";
        public static String SQL_SELECT_LAST = "SELECT TOP 1 * FROM Purchase WHERE card_id = @card_id ORDER BY date DESC;";
        public static String SQL_INSERT = "INSERT INTO Purchase VALUES (@date, @ticket_id, @card_id)";
        public static String SQL_UPDATE = "UPDATE Purchase SET date=@date, ticket_id=@ticket_id, card_id=@card_id WHERE purchase_id=@purchase_id";
        public static String SQL_DELETE_ID = "DELETE FROM Purchase WHERE purchase_id=@purchase_id";
        public static String SQL_DELETE = "DELETE FROM Purchase";

        public static String SQL_DROP = "DROP TABLE Purchase; TRUNCATE TABLE Ticket; " +
                            "CREATE TABLE Purchase(purchase_id INTEGER NOT NULL identity, date DATETIME NOT NULL, ticket_id INTEGER NOT NULL, card_id INTEGER NOT NULL, CONSTRAINT Purchase_PK PRIMARY KEY NONCLUSTERED (purchase_id)" +
                            " WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON)ON \"default\")ON \"default\";" +
                            " ALTER TABLE Purchase ADD CONSTRAINT Relation_7 FOREIGN KEY(card_id) REFERENCES Discount_card(card_id);" +
                            " ALTER TABLE Purchase ADD CONSTRAINT Relation_10 FOREIGN KEY(ticket_id) REFERENCES Ticket(ticket_id);";

        private static void PrepareCommand(SqlCommand command, Purchase purchase)
        {
            command.Parameters.AddWithValue("@date", purchase.Date);
            command.Parameters.AddWithValue("@ticket_id", purchase.TicketId);
            command.Parameters.AddWithValue("@card_id", purchase.CardId);
        }

        private static void PrepareCommandU(SqlCommand command, Purchase purchase)
        {
            command.Parameters.AddWithValue("@purchase_id", purchase.RecordId);
            command.Parameters.AddWithValue("@date", purchase.Date);
            command.Parameters.AddWithValue("@ticket_id", purchase.TicketId);
            command.Parameters.AddWithValue("@card_id", purchase.CardId);
        }

        public static int Insert(Purchase Purchase)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, Purchase);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        public static int Update(Purchase Purchase)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommandU(command, Purchase);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        public static Collection<Purchase> Select()
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<Purchase> Categories = Read(reader);
            
            db.Close();
            return Categories;
        }

        public static Purchase SelectLast(int id)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_LAST);

            command.Parameters.AddWithValue("@card_id", id);
            SqlDataReader reader = db.Select(command);

            Collection<Purchase> purchases = Read(reader);
            Purchase purchase = null;
            if (purchases.Count == 1)
            {
                purchase = purchases[0];
            }

            db.Close();
            return purchase;
        }

        public static Purchase Select(int id)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_ID);

            command.Parameters.AddWithValue("@purchase_id", id);
            SqlDataReader reader = db.Select(command);

            Collection<Purchase> purchases = Read(reader);
            Purchase purchase = null;
            if (purchases.Count == 1)
            {
                purchase = purchases[0];
            }

            db.Close();
            return purchase;
        }

        public static int Delete(int id)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_DELETE_ID);

            command.Parameters.AddWithValue("@purchase_id", id);
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

            command = db.CreateCommand(SQL_DROP);
            ret = db.ExecuteNonQuery(command);

            db.Close();
            return ret;
        }

        private static Collection<Purchase> Read(SqlDataReader reader)
        {
            Collection<Purchase> purchases = new Collection<Purchase>();

            while (reader.Read())
            {
                Purchase purchase = new Purchase();
                int i = -1;
                purchase.RecordId = reader.GetInt32(++i);
                purchase.Date = reader.GetDateTime(++i);
                purchase.TicketId = reader.GetInt32(++i);
                if (!reader.IsDBNull(++i))
                {
                    purchase.CardId = reader.GetInt32(i);
                }

                purchases.Add(purchase);
            }
            return purchases;
        }
    }
}
