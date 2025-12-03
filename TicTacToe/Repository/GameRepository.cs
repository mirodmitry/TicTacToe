using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Data;
using TicTacToe.Repository.Base;
using TicTacToe.Entities;

namespace TicTacToe.Repository
{
    public class GameRepository : IGameRepository
    {
        private DbContext _context;
        public GameRepository(DbContext context)
        {
            _context = context;
        }

        public void Create(Game game)
        {
            int NewId;
            if(_context.Games.Count > 0)
            {
                NewId = _context.Games.Max(x => x.ID) + 1;
            }
            else
            {
                NewId = 1;
            }
            game.ID = NewId;
            _context.Games.Add(game);
        }

        public List<Game> GetAll()
        {
            return _context.Games;
        }

        public Game GetByID(int Id)
        {
            return _context.Games.FirstOrDefault(g => g.ID == Id);
        }
    }
}
