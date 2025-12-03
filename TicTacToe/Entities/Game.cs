using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Entities
{
    public abstract class Game
    {
        public int ID { get; set; }
        public Account Player1 { get; set; }
        public Account Player2 { get; set; }
        public Account Winner { get; set; }
        public Account Loser { get; set; }

        protected int _ratingStake;

        public Game (Account player1, Account player2, int rating)
        {
            Player1 = player1;
            Player2 = player2;
            _ratingStake = rating;
        }

        public abstract int GetRating();
    }

}
