using System;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace TelegramBotApp.Models.DataBase
{
    public class UsersDB 
    {
        public SQLiteConnection cursor;
        public UsersDB()
        {
            cursor = new SQLiteConnection(DB.pathDB);
            cursor.Open();
        }
        public bool SubscriberExists(string userId)
        {
            string stm = $"SELECT * FROM subscriptions WHERE user_id = {userId}";
            var cmd = new SQLiteCommand(stm, cursor);
            if (cmd.ExecuteScalar() != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public async Task AddSubscriber(string chatId, string name)
        {
            if (name != null)
            {
                var cmd = new SQLiteCommand(cursor);
                cmd.CommandText = "INSERT INTO subscriptions(user_id, name) VALUES(@user_id, @name)";
                cmd.Parameters.AddWithValue("@user_id", chatId);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Prepare();
                cmd.ExecuteNonQuery();
            }
            else
            {
                var cmd = new SQLiteCommand(cursor);
                cmd.CommandText = "INSERT INTO subscriptions(user_id) VALUES(@user_id)";
                cmd.Parameters.AddWithValue("@user_id", chatId);
                cmd.Prepare();
                cmd.ExecuteNonQuery();
            }
        }

        public void GetSubscriptions()
        {
            string stm = "SELECT * FROM subscriptions";
            var cmd = new SQLiteCommand(stm, cursor);
            SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                //TODO: return send userds
                Console.WriteLine($"{rdr.GetInt32(0)} {rdr.GetString(1)} {rdr.GetBoolean(2)}");
            }
        }
    }
}
