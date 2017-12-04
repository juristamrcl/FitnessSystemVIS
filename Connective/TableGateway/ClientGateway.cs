using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using Connective.Tables;
using Connective.Conn;
using Connective.Abstract;

namespace Connective.TableGateway
{
    public class ClientGateway <T> : ClientGatewayInterface<T>
        where T: Client
    {
        private static ClientGateway<Client> instance;
        private ClientGateway() { }

        public static ClientGateway<Client> Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ClientGateway<Client>();
                }
                return instance;
            }
        }

        public static String SQL_CHECK_LOGIN = "SELECT DISTINCT * FROM Client WHERE mail=@mail AND password=@password";
        public String SQL_SELECT = "SELECT * FROM Client";
        public String SQL_SELECT_ID = "SELECT * FROM Client WHERE client_id=@client_id";
        public String SQL_SELECT_LOCKER = "SELECT COUNT(client_id) FROM client WHERE favourite_locker = @favourite_locker;";
        public String SQL_SELECT_TRAININGS = "SELECT t.training_id, t.time_from, t.time_to, t.locker_id, tr.name, tr.surname FROM training t JOIN trainer tr ON tr.trainer_id = t.trainer_id AND t.client_id = @client_id";
        public String SQL_INSERT = "INSERT INTO Client VALUES (@name, @surname, @mail, @gender, @card_id, @favourite_locker, @password)";
        public String SQL_UPDATE = "UPDATE Client SET name=@name, surname=@surname, mail=@mail, gender=@gender, card_id=@card_id, favourite_locker=@favourite_locker, password=@password WHERE client_id=@client_id";
        public String SQL_DELETE_ID = "DELETE FROM Client WHERE client_id=@client_id";
        public String SQL_DROP_CONST = "ALTER TABLE client DROP CONSTRAINT Relation_6;";
        public String SQL_DELETE = "DELETE FROM Client";

        public static String SQL_SELECT_ALL = "SELECT c.client_id, c.name, c.surname, c.mail, c.gender, c.card_id, COUNT (t.client_id) AS Trainings, " +
            "ISNULL((SELECT MAX(minutes_trained) FROM(SELECT DATEDIFF(MINUTE, time_from, time_to) AS minutes_trained FROM Training t1 " +
            "WHERE  t1.client_id = c.client_id AND t1.trainer_id IS NOT NULL AND t1.time_to IS NOT NULL) AS temp), 0) AS max_minutes_trained " +
            "FROM Client c LEFT JOIN Training t ON t.client_id = c.client_id GROUP BY c.client_id, c.name, c.surname, c.mail, c.gender, c.card_id";

        public static string SQL_SELECT_START_TRAINING = "SELECT * FROM Client c WHERE NOT EXISTS (SELECT TOP 1 * FROM Training t WHERE t.client_id = c.client_id AND t.time_from IS NOT NULL AND t.time_to IS NULL ORDER BY t.time_from)";
        public static string SQL_SELECT_END_TRAINING = "SELECT * FROM Client c WHERE EXISTS (SELECT TOP 1 * FROM Training t WHERE t.client_id = c.client_id AND t.time_from IS NOT NULL AND t.time_to IS NULL ORDER BY t.time_from)";

        private static void PrepareCommand(SqlCommand command, Client client)
        {
            command.Parameters.AddWithValue("@name", client.Name);
            command.Parameters.AddWithValue("@surname", client.Surname);
            command.Parameters.AddWithValue("@mail", client.Mail == null ? DBNull.Value : (object)client.Mail);
            command.Parameters.AddWithValue("@gender", client.Gender);
            command.Parameters.AddWithValue("@card_id", client.CardId.HasValue ? (object)client.CardId.Value : DBNull.Value);
            command.Parameters.AddWithValue("@favourite_locker", client.Favourite_locker.HasValue ? (object)client.Favourite_locker.Value : DBNull.Value);
            command.Parameters.AddWithValue("@password", client.Password);
        }
        private static void PrepareCommandU(SqlCommand command, Client client)
        {
            command.Parameters.AddWithValue("@client_id", client.RecordId);
            command.Parameters.AddWithValue("@name", client.Name);
            command.Parameters.AddWithValue("@surname", client.Surname);
            command.Parameters.AddWithValue("@mail", client.Mail == null ? DBNull.Value : (object)client.Mail);
            command.Parameters.AddWithValue("@gender", client.Gender);
            command.Parameters.AddWithValue("@card_id", client.CardId.HasValue ? (object)client.CardId.Value : DBNull.Value);
            command.Parameters.AddWithValue("@favourite_locker", client.Favourite_locker.HasValue ? (object)client.Favourite_locker.Value : DBNull.Value);
            command.Parameters.AddWithValue("@password", client.Password);
        }

        public int Insert(T t)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, (Client)t);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        public int Update(T t)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommandU(command, (Client)t);
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

        public T Select(int idClient)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_ID);

            command.Parameters.AddWithValue("@client_id", idClient);
            SqlDataReader reader = db.Select(command);

            Collection<T> clients = Read(reader);
            Client client = null;
            if (clients.Count == 1)
            {
                client = clients[0];
            }

            db.Close();
            return (T)client;
        }

        public int SelectLockerNumb(int favourite_locker)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_LOCKER);

            command.Parameters.AddWithValue("@favourite_locker", favourite_locker);
            SqlDataReader reader = db.Select(command);

            int count = 0;
            count = ReadLocker(reader);
            
            db.Close();
            return count;
        }

        public Collection<T> SelectForTrainingStartEnd(Boolean start)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command;
            if (start)
            {
                command = db.CreateCommand(SQL_SELECT_START_TRAINING);
            }
            else
            {
                command = db.CreateCommand(SQL_SELECT_END_TRAINING);
            }
            
            SqlDataReader reader = db.Select(command);

            Collection<T> clients = Read(reader);

            db.Close();
            return clients;
        }

        public Collection<ClientTraining> SelectTrainings(int id)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_TRAININGS);
            command.Parameters.AddWithValue("@client_id", id);

            SqlDataReader reader = db.Select(command);

            Collection<ClientTraining> clients = ReadTrainings(reader);

            db.Close();
            return clients;
        }

        public int Delete(int id)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_DELETE_ID);

            command.Parameters.AddWithValue("@client_id", id);
            int ret = db.ExecuteNonQuery(command);

            db.Close();
            return ret;
        }

        public int Delete()
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_DROP_CONST);
            int ret = db.ExecuteNonQuery(command);

            command = db.CreateCommand(SQL_DELETE);
            ret = db.ExecuteNonQuery(command);

            db.Close();
            return ret;
        }

        private Collection<T> Read(SqlDataReader reader)
        {
            Collection<T> clients = new Collection<T>();

            while (reader.Read())
            {
                Client client = new Client();
                int i = -1;
                client.RecordId = reader.GetInt32(++i);
                client.Name = reader.GetString(++i);
                client.Surname = reader.GetString(++i);
                if (!reader.IsDBNull(++i))
                {
                    client.Mail = reader.GetString(i);
                }
                client.Gender = reader.GetString(++i);
                if (!reader.IsDBNull(++i))
                {
                    client.CardId = reader.GetInt32(i);
                }
                if (!reader.IsDBNull(++i))
                {
                    client.Favourite_locker = reader.GetInt32(i);
                }
                client.Password = reader.GetString(++i);
                clients.Add((T)client);
            }
            return clients;
        }

        private int ReadLocker(SqlDataReader reader)
        {
            int result = 0;
            while (reader.Read())
            {
                int i = -1;
                result = reader.GetInt32(++i);
            }
            return result;
        }

        private Collection<ExtendedClient> ReadExtended(SqlDataReader reader)
        {
            Collection<ExtendedClient> clients = new Collection<ExtendedClient>();

            while (reader.Read())
            {
                ExtendedClient client = new ExtendedClient();
                int i = -1;
                client.ClientId = reader.GetInt32(++i);
                client.Name = reader.GetString(++i);
                client.Surname = reader.GetString(++i);
                if (!reader.IsDBNull(++i))
                {
                    client.Mail = reader.GetString(i);
                }
                client.Gender = reader.GetString(++i);
                client.CardId = reader.GetInt32(++i);
                client.Trainings = reader.GetInt32(++i);
                client.MaxMinutes = reader.GetInt32(++i);

                clients.Add(client);
            }
            return clients;
        }

        private Collection<ClientTraining> ReadTrainings(SqlDataReader reader)
        {
            Collection<ClientTraining> clients = new Collection<ClientTraining>();

            while (reader.Read())
            {
                ClientTraining client = new ClientTraining();
                int i = -1;
                client.TrainingId = reader.GetInt32(++i);
                client.TimeFrom = reader.GetDateTime(++i);
                if (!reader.IsDBNull(++i))
                {
                    client.TimeTo = reader.GetDateTime(i);
                }
                if (!reader.IsDBNull(++i))
                {
                    client.LockerId = reader.GetInt32(i);
                }
                client.TrainerName = reader.GetString(++i);
                client.TrainerSurname = reader.GetString(++i);

                clients.Add(client);
            }
            return clients;
        }

        public Collection<ExtendedClient> SelectAll()
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_ALL);

            SqlDataReader reader = db.Select(command);

            Collection<ExtendedClient> clients = ReadExtended(reader);

            db.Close();
            return clients;
        }

        public Client CheckPassword(Client client)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_CHECK_LOGIN);
            command.Parameters.AddWithValue("@mail", client.Mail == null ? DBNull.Value : (object)client.Mail);
            command.Parameters.AddWithValue("@password", client.Password);

            SqlDataReader reader = db.Select(command);

            Collection<T> clients = Read(reader);
            db.Close();

            if (clients.Count > 0)
            {
                return clients[0];
            }
            return null;
        }
    }

    public class ExtendedClient
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string Gender { get; set; }
        public int CardId { get; set; }
        public int Trainings { get; set; }
        public int MaxMinutes { get; set; }
    }
    public class ClientTraining
    {
        public int TrainingId { get; set; }
        public DateTime TimeFrom { get; set; }
        public DateTime? TimeTo { get; set; }
        public int? LockerId { get; set; }
        public string TrainerName { get; set; }
        public string TrainerSurname { get; set; }
    }
}
