using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Entities
{
    public class ClassicGame : Game
    {
        public ClassicGame(Account player1, Account player2, int rating) : base(player1, player2, rating)
        {

        }

        public override int GetRating()
        {
            return _ratingStake;
        }
    }
}
