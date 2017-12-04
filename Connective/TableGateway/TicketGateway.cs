using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using Connective.Tables;
using Connective.Conn;
using Connective.Abstract;

namespace Connective.TableGateway
{
    public class TicketGateway<T> : TicketGatewayInterface<T>
        where T : Ticket
    {
        private static TicketGateway<Ticket> instance;
        private TicketGateway() { }

        public static TicketGateway<Ticket> Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TicketGateway<Ticket>();
                }
                return instance;
            }
        }
        public String SQL_SELECT = "SELECT * FROM Ticket";
        public String SQL_SELECT_ID = "SELECT * FROM Ticket WHERE ticket_id=@ticket_id";
        public String SQL_INSERT = "INSERT INTO Ticket VALUES (@type, @validity, @cost, @description)";
        public String SQL_UPDATE = "UPDATE Ticket SET type=@type, validity=@validity, cost=@cost, description=@description WHERE ticket_id=@ticket_id";
        public String SQL_DELETE_ID = "DELETE FROM Ticket WHERE ticket_id=@ticket_id";
        public String SQL_DELETE = "DELETE FROM Ticket";

        public String SQL_SELECT_TOP5 = "SELECT TOP 5 t.description, t.type, COUNT(p.purchase_id) as Numb FROM Ticket t " +
                                                "JOIN Purchase p ON p.ticket_id = t.ticket_id WHERE YEAR(p.date) = YEAR(getdate())-1 AND YEAR(p.date) IS NOT NULL " +
                                                "GROUP BY t.description, t.type ORDER BY Numb DESC";

        private void PrepareCommand(SqlCommand command, Ticket ticket)
        {
            command.Parameters.AddWithValue("@type", ticket.Type);
            command.Parameters.AddWithValue("@validity", ticket.Validity.HasValue ? (object)ticket.Validity.Value : DBNull.Value);
            command.Parameters.AddWithValue("@cost", ticket.Cost);
            command.Parameters.AddWithValue("@description", ticket.Description == null ? DBNull.Value : (object)ticket.Description);
        }
        private void PrepareCommandU(SqlCommand command, Ticket ticket)
        {
            command.Parameters.AddWithValue("@ticket_id", ticket.RecordId);
            command.Parameters.AddWithValue("@type", ticket.Type);
            command.Parameters.AddWithValue("@validity", ticket.Validity.HasValue ? (object)ticket.Validity.Value : DBNull.Value);
            command.Parameters.AddWithValue("@cost", ticket.Cost);
            command.Parameters.AddWithValue("@description", ticket.Description == null ? DBNull.Value : (object)ticket.Description);
        }

        public int Insert(T ticket)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, ticket);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        public int Update(T ticket)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommandU(command, ticket);
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

        public T Select(int id)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_ID);

            command.Parameters.AddWithValue("@ticket_id", id);
            SqlDataReader reader = db.Select(command);

            Collection<T> tickets = Read(reader);
            T ticket = null;
            if (tickets.Count == 1)
            {
                ticket = tickets[0];
            }

            db.Close();
            return ticket;
        }

        public Collection<TopTicket> SelectTOP5()
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_TOP5);

            SqlDataReader reader = db.Select(command);

            Collection<TopTicket> tickets = ReadTop(reader);


            db.Close();
            return tickets;
        }

        public int Delete(int id)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_DELETE_ID);

            command.Parameters.AddWithValue("@ticket_id", id);
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
            Collection<T> tickets = new Collection<T>();

            while (reader.Read())
            {
                Ticket ticket = new Ticket();
                int i = -1;
                ticket.RecordId = reader.GetInt32(++i);
                ticket.Type = reader.GetString(++i);
                if (!reader.IsDBNull(++i))
                {
                    ticket.Validity = reader.GetInt32(i);
                }
                ticket.Cost = reader.GetDecimal(++i);
                if (!reader.IsDBNull(++i))
                {
                    ticket.Description = reader.GetString(i);
                }
                tickets.Add((T)ticket);
            }
            return tickets;
        }

        private Collection<TopTicket> ReadTop(SqlDataReader reader)
        {
            Collection<TopTicket> tickets = new Collection<TopTicket>();

            while (reader.Read())
            {
                TopTicket ticket = new TopTicket();
                int i = -1;
                ticket.Description = reader.GetString(++i);
                ticket.Type = reader.GetString(++i);
                ticket.Numb = reader.GetInt32(++i);
                tickets.Add(ticket);
            }
            return tickets;
        }
    }

    public class TopTicket
    {
        public string Description { get; set; }
        public string Type { get; set; }
        public int Numb { get; set; }
    }
}
