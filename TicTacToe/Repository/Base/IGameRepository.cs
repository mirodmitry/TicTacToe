using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Entities;

namespace TicTacToe.Repository.Base
{
    public interface IGameRepository
    {
        void Create(Game game);
        List<Game> GetAll();
    }
}
