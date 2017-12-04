using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using Connective.Tables;
using Connective.Conn;

namespace Connective.TableGateway
{
    public class TrainerGateway
    {
        public static String SQL_SELECT = "SELECT * FROM Trainer";
        public static String SQL_SELECT_ID = "SELECT * FROM Trainer WHERE trainer_id=@trainer_id";
        public static String SQL_SELECT_AVG = "SELECT SUM(tr.rating_number) / COUNT(tr.rating_number), COUNT(t.trainer_id) FROM trainer t JOIN trainer_rating tr ON t.trainer_id = tr.trainer_id WHERE t.trainer_id = @trainer_id;";
        public static String SQL_INSERT = "INSERT INTO Trainer VALUES (@specialization, @name, @surname, @mail, @license)";
        public static String SQL_UPDATE = "UPDATE Trainer SET specialization=@specialization, name=@name, surname=@surname, mail=@mail, license=@license WHERE trainer_id=@trainer_id";
        public static String SQL_DELETE_ID = "DELETE FROM Trainer WHERE trainer_id=@trainer_id";
        public static String SQL_DELETE = "DELETE FROM Trainer";

        private static void PrepareCommand(SqlCommand command, Trainer trainer)
        {
            command.Parameters.AddWithValue("@specialization", trainer.Specialization);
            command.Parameters.AddWithValue("@name", trainer.Name);
            command.Parameters.AddWithValue("@surname", trainer.Surname);
            command.Parameters.AddWithValue("@mail", trainer.Mail == null ? DBNull.Value : (object)trainer.Mail);
            command.Parameters.AddWithValue("@license", trainer.License == null ? DBNull.Value : (object)trainer.License);
        }
        private static void PrepareCommandU(SqlCommand command, Trainer trainer)
        {
            command.Parameters.AddWithValue("@trainer_id", trainer.RecordId);
            command.Parameters.AddWithValue("@specialization", trainer.Specialization);
            command.Parameters.AddWithValue("@name", trainer.Name);
            command.Parameters.AddWithValue("@surname", trainer.Surname);
            command.Parameters.AddWithValue("@mail", trainer.Mail == null ? DBNull.Value : (object)trainer.Mail);
            command.Parameters.AddWithValue("@license", trainer.License == null ? DBNull.Value : (object)trainer.License);
        }

        public static int Insert(Trainer Trainer)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, Trainer);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        public static int Update(Trainer Trainer)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommandU(command, Trainer);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        public static Collection<Trainer> Select()
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<Trainer> Categories = Read(reader);

            db.Close();
            return Categories;
        }

        public static Trainer Select(int id)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_ID);

            command.Parameters.AddWithValue("@trainer_id", id);
            SqlDataReader reader = db.Select(command);

            Collection<Trainer> trainers = Read(reader);
            Trainer trainer = null;
            if (trainers.Count == 1)
            {
                trainer = trainers[0];
            }

            db.Close();
            return trainer;
        }

        public static decimal[] SelectAVG(int id)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_AVG);

            command.Parameters.AddWithValue("@trainer_id", id);
            SqlDataReader reader = db.Select(command);

            decimal [] answ = ReadAvg(reader);

            db.Close();
            return answ;
        }

        public static int Delete(int id)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_DELETE_ID);

            command.Parameters.AddWithValue("@trainer_id", id);
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

        private static Collection<Trainer> Read(SqlDataReader reader)
        {
            Collection<Trainer> trainers = new Collection<Trainer>();

            while (reader.Read())
            {
                Trainer trainer = new Trainer();
                int i = -1;
                trainer.RecordId = reader.GetInt32(++i);
                trainer.Specialization = reader.GetString(++i);
                trainer.Name = reader.GetString(++i);
                trainer.Surname = reader.GetString(++i);
                if (!reader.IsDBNull(++i))
                {
                    trainer.Mail = reader.GetString(i);
                }

                if (!reader.IsDBNull(++i))
                {
                    trainer.License = reader.GetString(i);
                }
                trainers.Add(trainer);
            }
            return trainers;
        }

        private static decimal[] ReadAvg(SqlDataReader reader)
        {
            decimal[] answ = { 0M, 0M };
            int i = -1;

            while (reader.Read())
            {
                if (!reader.IsDBNull(++i))
                {
                    answ[0] = reader.GetDecimal(i);
                }
                if (!reader.IsDBNull(++i))
                {
                    answ[1] = decimal.Parse(reader.GetInt32(i).ToString());
                }
            }
            return answ;
        }
    }
}
