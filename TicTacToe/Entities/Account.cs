using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Entities
{
     public abstract class Account
    {
        public int ID { get; set; }
        public string User_Name { get; set; }
        public string Password { get; set; }
        public int Games_Count { get; set; }

        protected int _rating;
        public int Rating
        {
            get
            {
                return _rating;
            }
            set
            {
                if(value < 0)
                {
                    _rating = 0;
                }
                else
                {
                    _rating = value;
                }
            }
        }

        public Account (string username, string password)
        {
            User_Name = username;
            Password = password;
            Rating = 100;
            Games_Count = 0;
        }

        public abstract void WinGame (int ratingStake);
        public abstract void LoseGame(int ratingStake);
    }
}
