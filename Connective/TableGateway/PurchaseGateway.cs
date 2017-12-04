using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using Connective.Tables;
using Connective.Conn;
using Connective.Abstract.Interface;

namespace Connective.TableGateway
{
    public class PurchaseGateway<T> : PurchaseGatewayInterface<T>
        where T : Purchase
    {
        private static PurchaseGateway<Purchase> instance;
        private PurchaseGateway() { }

        public static PurchaseGateway<Purchase> Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PurchaseGateway<Purchase>();
                }
                return instance;
            }
        }

        public String SQL_SELECT = "SELECT * FROM Purchase";
        public String SQL_SELECT_ID = "SELECT * FROM Purchase WHERE purchase_id=@purchase_id";
        public String SQL_SELECT_LAST = "SELECT TOP 1 * FROM Purchase WHERE card_id = @card_id ORDER BY date DESC;";
        public String SQL_INSERT = "INSERT INTO Purchase VALUES (@date, @ticket_id, @card_id)";
        public String SQL_UPDATE = "UPDATE Purchase SET date=@date, ticket_id=@ticket_id, card_id=@card_id WHERE purchase_id=@purchase_id";
        public String SQL_DELETE_ID = "DELETE FROM Purchase WHERE purchase_id=@purchase_id";
        public String SQL_DELETE = "DELETE FROM Purchase";

        public String SQL_DROP = "DROP TABLE Purchase; TRUNCATE TABLE Ticket; " +
                            "CREATE TABLE Purchase(purchase_id INTEGER NOT NULL identity, date DATETIME NOT NULL, ticket_id INTEGER NOT NULL, card_id INTEGER NOT NULL, CONSTRAINT Purchase_PK PRIMARY KEY NONCLUSTERED (purchase_id)" +
                            " WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON)ON \"default\")ON \"default\";" +
                            " ALTER TABLE Purchase ADD CONSTRAINT Relation_7 FOREIGN KEY(card_id) REFERENCES Discount_card(card_id);" +
                            " ALTER TABLE Purchase ADD CONSTRAINT Relation_10 FOREIGN KEY(ticket_id) REFERENCES Ticket(ticket_id);";

        private void PrepareCommand(SqlCommand command, Purchase purchase)
        {
            command.Parameters.AddWithValue("@date", purchase.Date);
            command.Parameters.AddWithValue("@ticket_id", purchase.TicketId);
            command.Parameters.AddWithValue("@card_id", purchase.CardId);
        }

        private void PrepareCommandU(SqlCommand command, Purchase purchase)
        {
            command.Parameters.AddWithValue("@purchase_id", purchase.RecordId);
            command.Parameters.AddWithValue("@date", purchase.Date);
            command.Parameters.AddWithValue("@ticket_id", purchase.TicketId);
            command.Parameters.AddWithValue("@card_id", purchase.CardId);
        }

        public int Insert(T Purchase)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, Purchase);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        public int Update(T Purchase)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommandU(command, Purchase);
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

            Collection<T> Categories = Read(reader);
            
            db.Close();
            return Categories;
        }

        public T SelectLast(int id)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_LAST);

            command.Parameters.AddWithValue("@card_id", id);
            SqlDataReader reader = db.Select(command);

            Collection<T> purchases = Read(reader);
            T purchase = null;
            if (purchases.Count == 1)
            {
                purchase = purchases[0];
            }

            db.Close();
            return purchase;
        }

        public T Select(int id)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_ID);

            command.Parameters.AddWithValue("@purchase_id", id);
            SqlDataReader reader = db.Select(command);

            Collection<T> purchases = Read(reader);
            T purchase = null;
            if (purchases.Count == 1)
            {
                purchase = purchases[0];
            }

            db.Close();
            return purchase;
        }

        public int Delete(int id)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_DELETE_ID);

            command.Parameters.AddWithValue("@purchase_id", id);
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

            command = db.CreateCommand(SQL_DROP);
            ret = db.ExecuteNonQuery(command);

            db.Close();
            return ret;
        }

        private Collection<T> Read(SqlDataReader reader)
        {
            Collection<T> purchases = new Collection<T>();

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

                purchases.Add((T)purchase);
            }
            return purchases;
        }
    }
}
