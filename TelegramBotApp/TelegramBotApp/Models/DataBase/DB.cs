using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace TelegramBotApp.Models
{

    public class DB     
    {    
        public static string pathDB { get; set; } = $"URI=file:{AppSettings.PathResources}DataBaseUsers.db";
        
    }
}
