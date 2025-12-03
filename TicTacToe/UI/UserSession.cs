using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Entities;

namespace TicTacToe.UI
{
    public static class UserSession
    {
        public static Account CurrentUser { get; set; }
        public static bool IsLoggedIn()
        {
            return CurrentUser != null;
        }
    }
}
