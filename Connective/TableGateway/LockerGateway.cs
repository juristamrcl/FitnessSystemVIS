using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using Connective.Tables;
using Connective.Conn;

namespace Connective.TableGateway
{
    public class LockerGateway
    {
        public static String SQL_SELECT = "SELECT * FROM Locker ORDER BY to_gender, locker_id";
        public static String SQL_SELECT_ID = "SELECT * FROM Locker WHERE locker_id=@locker_id AND to_gender=@to_gender";
        public static String SQL_SELECT_GENDER = "SELECT * FROM Locker WHERE to_gender=@to_gender ORDER BY to_gender, locker_id";
        public static String SQL_INSERT = "INSERT INTO Locker VALUES (@locker_id, @to_gender, @status)";
        public static String SQL_UPDATE = "UPDATE Locker SET status=@status WHERE locker_id=@locker_id AND to_gender=@to_gender";
        public static String SQL_DELETE_ID = "DELETE FROM Locker WHERE locker_id=@locker_id AND to_gender=@to_gender";
        public static String SQL_DELETE = "DELETE FROM Locker";

        private static void PrepareCommand(SqlCommand command, Locker locker)
        {
            command.Parameters.AddWithValue("@locker_id", locker.RecordId);
            command.Parameters.AddWithValue("@to_gender", locker.ToGender);
            command.Parameters.AddWithValue("@status", locker.Status);
        }

        public static int Insert(Locker Locker)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, Locker);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        public static int Update(Locker Locker)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, Locker);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        public static Collection<Locker> Select()
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<Locker> lockers = Read(reader);

            db.Close();
            return lockers;
        }

        public static Collection<Locker> Select(string to_gender)
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT_GENDER);
            command.Parameters.AddWithValue("@to_gender", to_gender);

            SqlDataReader reader = db.Select(command);

            Collection<Locker> lockers = Read(reader);

            db.Close();
            return lockers;
        }

        public static Locker Select(int id, string gender)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_ID);

            command.Parameters.AddWithValue("@locker_id", id);
            command.Parameters.AddWithValue("@to_gender", gender);
            SqlDataReader reader = db.Select(command);

            Collection<Locker> lockers = Read(reader);
            Locker locker = null;
            if (lockers.Count == 1)
            {
                locker = lockers[0];
            }

            db.Close();
            return locker;
        }

        public static int Delete(int id)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_DELETE_ID);

            command.Parameters.AddWithValue("@locker_id", id);
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

        private static Collection<Locker> Read(SqlDataReader reader)
        {
            Collection<Locker> lockers = new Collection<Locker>();

            while (reader.Read())
            {
                Locker locker = new Locker();
                int i = -1;
                locker.RecordId = reader.GetInt32(++i);
                locker.ToGender = reader.GetString(++i);
                locker.Status = reader.GetString(++i);

                lockers.Add(locker);
            }
            return lockers;
        }
    }
}
