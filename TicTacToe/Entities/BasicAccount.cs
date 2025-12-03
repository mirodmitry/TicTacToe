using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Entities
{
    public class BasicAccount : Account
    {
        public BasicAccount(string username, string password) : base(username, password)
        {

        }

        public override void WinGame(int ratingStake)
        {
            Rating += ratingStake;
            Games_Count++;
        }

        public override void LoseGame(int ratingStake)
        {
            Rating-= ratingStake;
            Games_Count++;
        }
    }
}
