using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Entities;

namespace TicTacToe.Service
{
    public interface IGameService
    {
        void FinishGame(Game game, Account winner, Account loser);
        List<Game> GetAllGames();
        List<Game> GetPlayerHistory(string username);
    }
}
