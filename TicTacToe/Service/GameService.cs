using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Entities;
using TicTacToe.Repository.Base;

namespace TicTacToe.Service
{
    public class GameService : IGameService
    {
        private IGameRepository _gamerepository;
        private IAccountRepository _accountrepository;
        public GameService(IGameRepository gameRepo, IAccountRepository accountRepo)
        {
            _gamerepository = gameRepo;
            _accountrepository = accountRepo;
        }

        public void FinishGame(Game game, Account winner, Account loser)
        {
            int points = game.GetRating();
            if(winner != null)
            {
                winner.WinGame(points);
                loser.LoseGame(points);
                game.Winner = winner;
                game.Loser = loser;
                _accountrepository.Update(winner);
                _accountrepository.Update(loser);
            }
            else
            {
                game.Winner = null;
                game.Loser = null;
            }
            _gamerepository.Create(game);
        }

        public List<Game> GetPlayerHistory(string username)
        {
            var player = _accountrepository.GetByUserName(username);
            if(player == null)
            {
                throw new Exception("Гравця не знайдено");
            }
            var allGames = _gamerepository.GetAll();
            List<Game> history = new List<Game>();
            foreach(var g in allGames)
            {
                if(g.Player1.ID ==  player.ID || g.Player2.ID == player.ID)
                {
                    history.Add(g);
                }
            }
            return history;
        }

        public List<Game> GetAllGames()
        {
            return _gamerepository.GetAll();
        }
    }
}
