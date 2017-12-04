using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using Connective.Tables;
using Connective.Conn;
using Connective.Abstract;

namespace Connective.TableGateway
{
    public class LockerGateway<T> : LockerGatewayInterface<T>
        where T: Locker
    {
        private static LockerGateway<Locker> instance;
        private LockerGateway() { }

        public static LockerGateway<Locker> Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LockerGateway<Locker>();
                }
                return instance;
            }
        }

        public String SQL_SELECT = "SELECT * FROM Locker ORDER BY to_gender, locker_id";
        public String SQL_SELECT_ID = "SELECT * FROM Locker WHERE locker_id=@locker_id AND to_gender=@to_gender";
        public String SQL_SELECT_GENDER = "SELECT * FROM Locker WHERE to_gender=@to_gender ORDER BY to_gender, locker_id";
        public String SQL_INSERT = "INSERT INTO Locker VALUES (@locker_id, @to_gender, @status)";
        public String SQL_UPDATE = "UPDATE Locker SET status=@status WHERE locker_id=@locker_id AND to_gender=@to_gender";
        public String SQL_DELETE_ID = "DELETE FROM Locker WHERE locker_id=@locker_id AND to_gender=@to_gender";
        public String SQL_DELETE = "DELETE FROM Locker";

        private static void PrepareCommand(SqlCommand command, Locker locker)
        {
            command.Parameters.AddWithValue("@locker_id", locker.RecordId);
            command.Parameters.AddWithValue("@to_gender", locker.ToGender);
            command.Parameters.AddWithValue("@status", locker.Status);
        }

        public int Insert(T Locker)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, Locker);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        public int Update(T Locker)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, Locker);
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

            Collection<T> lockers = Read(reader);

            db.Close();
            return lockers;
        }

        public Collection<T> Select(string to_gender)
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT_GENDER);
            command.Parameters.AddWithValue("@to_gender", to_gender);

            SqlDataReader reader = db.Select(command);

            Collection<T> lockers = Read(reader);

            db.Close();
            return lockers;
        }

        public T Select(int id, string gender)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_ID);

            command.Parameters.AddWithValue("@locker_id", id);
            command.Parameters.AddWithValue("@to_gender", gender);
            SqlDataReader reader = db.Select(command);

            Collection<T> lockers = Read(reader);
            T locker = null;
            if (lockers.Count == 1)
            {
                locker = lockers[0];
            }

            db.Close();
            return locker;
        }

        public int Delete(int id)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_DELETE_ID);

            command.Parameters.AddWithValue("@locker_id", id);
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
            Collection<T> lockers = new Collection<T>();

            while (reader.Read())
            {
                Locker locker = new Locker();
                int i = -1;
                locker.RecordId = reader.GetInt32(++i);
                locker.ToGender = reader.GetString(++i);
                locker.Status = reader.GetString(++i);

                lockers.Add((T)locker);
            }
            return lockers;
        }
    }
}
