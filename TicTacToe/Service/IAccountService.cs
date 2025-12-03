using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Entities;

namespace TicTacToe.Service
{
    public interface IAccountService
    {
        void RegisterPlayer(string username, string password, string type);
        Account LoginPlayer(string username, string password);
        List<Account> GetAllPlayers();
        Account BotAccount();
    }
}
