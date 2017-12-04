using System;
using Connective.Conn;
using System.Data.SqlClient;
using Connective.Tables;
using System.Collections.ObjectModel;

namespace Connective.TableGateway
{
    public class TrainerRatingGateway
    {
        public static String SQL_SELECT = "SELECT * FROM Trainer_rating";
        public static String SQL_SELECT_ID = "SELECT * FROM Trainer_rating WHERE rating_id=@rating_id";
        public static String SQL_INSERT = "INSERT INTO Trainer_rating VALUES (@text, @rating_number, @client_id, @trainer_id)";
        public static String SQL_UPDATE = "UPDATE Trainer_rating SET text=@text, rating_number=@rating_number, client_id=@client_id, trainer_id=@trainer_id WHERE rating_id=@rating_id";
        public static String SQL_DELETE_ID = "DELETE FROM Trainer_rating WHERE rating_id=@rating_id";
        public static String SQL_DELETE = "DELETE FROM Trainer_rating";

        private static void PrepareCommand(SqlCommand command, TrainerRating rating)
        {
            command.Parameters.AddWithValue("@text", rating.Text);
            command.Parameters.AddWithValue("@rating_number", rating.RatingNumber);
            command.Parameters.AddWithValue("@client_id", rating.ClientId);
            command.Parameters.AddWithValue("@trainer_id", rating.TrainerId);
        }
        private static void PrepareCommandU(SqlCommand command, TrainerRating rating)
        {
            command.Parameters.AddWithValue("@rating_id", rating.RecordId);
            command.Parameters.AddWithValue("@text", rating.Text);
            command.Parameters.AddWithValue("@rating_number", rating.RatingNumber);
            command.Parameters.AddWithValue("@client_id", rating.ClientId);
            command.Parameters.AddWithValue("@trainer_id", rating.TrainerId);
        }

        public static int Insert(TrainerRating rating)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, rating);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        public static int Update(TrainerRating rating)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommandU(command, rating);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        public static Collection<TrainerRating> Select()
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<TrainerRating> ratings = Read(reader);

            db.Close();
            return ratings;
        }

        public static TrainerRating Select(int id)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_ID);

            command.Parameters.AddWithValue("@rating_id", id);
            SqlDataReader reader = db.Select(command);

            Collection<TrainerRating> ratings = Read(reader);
            TrainerRating rating = null;
            if (ratings.Count == 1)
            {
                rating = ratings[0];
            }

            db.Close();
            return rating;
        }

        public static int Delete(int id)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_DELETE_ID);

            command.Parameters.AddWithValue("@rating_id", id);
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

        private static Collection<TrainerRating> Read(SqlDataReader reader)
        {
            Collection<TrainerRating> ratings = new Collection<TrainerRating>();

            while (reader.Read())
            {
                TrainerRating rating = new TrainerRating();
                int i = -1;
                rating.RecordId = reader.GetInt32(++i);
                rating.Text = reader.GetString(++i);
                rating.RatingNumber = reader.GetDecimal(++i);
                rating.ClientId = reader.GetInt32(++i);
                rating.TrainerId = reader.GetInt32(++i);

                ratings.Add(rating);
            }
            return ratings;
        }
    }
}
