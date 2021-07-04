using System;
using System.Collections.Generic;
using System.Text;
using TelegramBotApp.Models.DataBase;

namespace TelegramBotApp.Models.Commands.Admin
{
    class AdminSettings
    {
        public static List<string> adminId;
        AdminDB dataAdmin;
        public AdminSettings()
        {
            dataAdmin = new AdminDB();
            adminId = dataAdmin.getAdmins();          
        }
        public bool IsAdmin(string chatId)
        {
            foreach (var item in adminId)
            {
                if (item == chatId)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
