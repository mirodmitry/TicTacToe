using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Entities
{
    public class WinStreakAccount : Account
    {
        public int WinStreakCount { get; set; }
        public WinStreakAccount(string username, string password) : base(username, password)
        {
            WinStreakCount = 0;
        }

        public override void WinGame(int ratingStake)
        {
            WinStreakCount++;
            Rating += ratingStake + WinStreakCount;
            Games_Count++;
        }

        public override void LoseGame(int ratingStake)
        {
            WinStreakCount = 0;
            Rating -= ratingStake;
            Games_Count++;
        }
    }
}
