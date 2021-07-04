using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace TelegramBotApp.Models.DataBase
{
    public class AdminDB
    {
        public static SQLiteConnection cursor;
        public AdminDB()
        {
            cursor = new SQLiteConnection(DB.pathDB); 
            cursor.Open();
        }
        public async Task DeleteAdmin(string userId, string adminId)
        {
            if (userId == "650663893")
            {
                string stm = $"SELECT * FROM admins WHERE user_id = {adminId}";
                var cmd = new SQLiteCommand(stm, cursor);

                if (cmd.ExecuteScalar() != null)
                {
                    string stm_n = $"DELETE FROM admins WHERE user_id = {adminId}";
                    var cmd_n = new SQLiteCommand(stm_n, cursor);
                    cmd_n.ExecuteNonQuery();
                }
            }
        }

        public List<string> getAdmins()
        {
            string stm = "SELECT * FROM admins";
            var cmd = new SQLiteCommand(stm, cursor);
            SQLiteDataReader rdr = cmd.ExecuteReader();

            List<string> admins = new List<string>();

            while (rdr.Read())
            {
                admins.Add(rdr.GetString(1));
            }
            return admins;
        }
        public List<string> GetUsersId()
        {
            string stm = "SELECT * FROM subscriptions";
            var cmd = new SQLiteCommand(stm, cursor);
            SQLiteDataReader rdr = cmd.ExecuteReader();

            List<string> users = new List<string>();

            while (rdr.Read())
            {
                users.Add(rdr.GetString(1));
            }
            return users;
        }
        public string SendAdmins()
        {
            string stm = "SELECT * FROM admins";
            var cmd = new SQLiteCommand(stm, cursor);
            SQLiteDataReader rdr = cmd.ExecuteReader();

            string admins = "";

            while (rdr.Read())
            {
                admins += rdr.GetInt32(0).ToString() + ' ' + rdr.GetString(1) + ' ' + rdr.GetString(2) + '\n';
            }
            return admins;
        }
        public async Task AddAdmin(string user_id, string name)
        {
            var cmd = new SQLiteCommand(cursor);
            cmd.CommandText = "INSERT INTO admins(user_id, name) VALUES(@user_id, @name)";
            cmd.Parameters.AddWithValue("@user_id", user_id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}
