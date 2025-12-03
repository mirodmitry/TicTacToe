using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Entities;

namespace TicTacToe.Factories
{
    public static class AccountFactory
    {
        public static Account CreateAccount(string type, string username, string password)
        {
            switch (type.ToLower())
            {
                case "basic":
                    return new BasicAccount(username, password);
                case "winstreak":
                    return new WinStreakAccount(username, password);
                default:
                    return new BasicAccount(username, password);
            }
        }
    }
}
