using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using Connective.Tables;
using Connective.Conn;

namespace Connective.TableGateway
{
    public class TrainingGateway
    {
        public static String SQL_SELECT = "SELECT * FROM Training";
        public static String SQL_SELECT_LAST = "SELECT TOP 1 * FROM Training ORDER BY time_from DESC;";
        public static String SQL_SELECT_LAST_WITH_ID = "SELECT TOP 1 * FROM Training WHERE client_id = @client_id ORDER BY time_from DESC;";
        public static String SQL_SELECT_ID = "SELECT * FROM Training WHERE training_id=@training_id";
        public static String SQL_SELECT_CLIENT_ID = "SELECT * FROM Training WHERE client_id=@client_id";
        public static String SQL_INSERT = "INSERT INTO Training VALUES (@time_from, @time_to, @client_id, @locker_id, @trainer_id, @to_gender)";
        public static String SQL_UPDATE = "UPDATE Training SET time_from=@time_from, time_to=@time_to, client_id=@client_id, locker_id=@locker_id," +
            " trainer_id=@trainer_id, to_gender=@to_gender WHERE training_id=@training_id";
        public static String SQL_DELETE_ID = "DELETE FROM Training WHERE training_id=@training_id";
        public static String SQL_DELETE = "DELETE FROM Training";

        public static String SQL_DROP = "DROP TABLE Training; DROP TABLE Trainer_rating; TRUNCATE TABLE Trainer; " +
                "CREATE TABLE Training(training_id INTEGER NOT NULL identity, time_from DATETIME NOT NULL, time_to DATETIME, client_id INTEGER NOT NULL, locker_id INTEGER NOT NULL, trainer_id INTEGER, to_gender VARCHAR (6) NOT NULL, CONSTRAINT Training_PK PRIMARY KEY NONCLUSTERED(training_id) WITH(ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON) ON \"default\" )ON \"default\" ;" +
                "CREATE TABLE TRAINER_RATING(rating_id INTEGER NOT NULL identity, text VARCHAR (400) NOT NULL, rating_number DECIMAL NOT NULL, client_id INTEGER NOT NULL, trainer_id INTEGER NOT NULL, CONSTRAINT TRAINER_RATING_PK PRIMARY KEY NONCLUSTERED(rating_id) WITH(ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON) ON \"default\")ON \"default\"; " +
                "ALTER TABLE Training ADD CONSTRAINT Relation_1 FOREIGN KEY(client_id) REFERENCES Client(client_id ); " +
                "ALTER TABLE Training ADD CONSTRAINT Relation_11 FOREIGN KEY(trainer_id) REFERENCES Trainer(trainer_id) ;" +
                "ALTER TABLE Training ADD CONSTRAINT Relation_8 FOREIGN KEY(locker_id, to_gender) REFERENCES Locker(locker_id , to_gender ) ;" +
                "ALTER TABLE TRAINER_RATING ADD CONSTRAINT Relation_12 FOREIGN KEY(trainer_id) REFERENCES Trainer(trainer_id ) ;" +
                "ALTER TABLE TRAINER_RATING ADD CONSTRAINT Relation_9 FOREIGN KEY(client_id) REFERENCES Client(client_id );";

        private static void PrepareCommand(SqlCommand command, Training training)
        {
            command.Parameters.AddWithValue("@time_from", training.TimeFrom);
            command.Parameters.AddWithValue("@time_to", training.TimeTo == null ? DBNull.Value : (object)training.TimeTo);
            command.Parameters.AddWithValue("@client_id", training.ClientId);
            command.Parameters.AddWithValue("@locker_id", training.LockerId);
            command.Parameters.AddWithValue("@trainer_id", training.TrainerId.HasValue ? (object)training.TrainerId.Value : DBNull.Value);
            command.Parameters.AddWithValue("@to_gender", training.ToGender);
        }
        private static void PrepareCommandU(SqlCommand command, Training training)
        {
            command.Parameters.AddWithValue("@training_id", training.RecordId);
            command.Parameters.AddWithValue("@time_from", training.TimeFrom);
            command.Parameters.AddWithValue("@time_to", training.TimeTo == null ? DBNull.Value : (object)training.TimeTo);
            command.Parameters.AddWithValue("@client_id", training.ClientId);
            command.Parameters.AddWithValue("@locker_id", training.LockerId);
            command.Parameters.AddWithValue("@trainer_id", training.TrainerId.HasValue ? (object)training.TrainerId.Value : DBNull.Value);
            command.Parameters.AddWithValue("@to_gender", training.ToGender);
        }

        public static int Insert(Training Training)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, Training);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        public static int Update(Training Training)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommandU(command, Training);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        public static Collection<Training> Select()
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<Training> Categories = Read(reader);

            db.Close();
            return Categories;
        }

        public static Training Select(int id)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_ID);

            command.Parameters.AddWithValue("@training_id", id);
            SqlDataReader reader = db.Select(command);

            Collection<Training> trainings = Read(reader);
            Training training = null;
            if (trainings.Count == 1)
            {
                training = trainings[0];
            }

            db.Close();
            return training;
        }
        public static Collection<Training> SelectClient(int id)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_CLIENT_ID);

            command.Parameters.AddWithValue("@client_id", id);
            SqlDataReader reader = db.Select(command);

            Collection<Training> trainings = Read(reader);

            db.Close();
            return trainings;
        }

        public static Training SelectLast(int id)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_LAST_WITH_ID);

            command.Parameters.AddWithValue("@client_id", id);
            SqlDataReader reader = db.Select(command);

            Collection<Training> trainings = Read(reader);
            Training training = null;
            if (trainings.Count == 1)
            {
                training = trainings[0];
            }

            db.Close();
            return training;
        }

        public static Training SelectLast()
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_LAST);

            SqlDataReader reader = db.Select(command);

            Collection<Training> trainings = Read(reader);
            Training training = null;
            if (trainings.Count == 1)
            {
                training = trainings[0];
            }

            db.Close();
            return training;
        }

        public static int Delete(int id)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_DELETE_ID);

            command.Parameters.AddWithValue("@training_id", id);
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


        private static Collection<Training> Read(SqlDataReader reader)
        {
            Collection<Training> trainings = new Collection<Training>();

            while (reader.Read())
            {
                Training training = new Training();
                int i = -1;
                training.RecordId = reader.GetInt32(++i);
                training.TimeFrom = reader.GetDateTime(++i);
                if (!reader.IsDBNull(++i))
                {
                    training.TimeTo = reader.GetDateTime(i);
                }
                training.ClientId = reader.GetInt32(++i);
                training.LockerId = reader.GetInt32(++i);
                if (!reader.IsDBNull(++i))
                {
                    training.TrainerId = reader.GetInt32(i);
                }
                training.ToGender = reader.GetString(++i);
                trainings.Add(training);
            }
            return trainings;
        }
    }
}
