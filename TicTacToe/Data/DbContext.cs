using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Entities;

namespace TicTacToe.Data
{
    public class DbContext
    {
        public List<Account> Accounts { get; set; }
        public List<Game> Games { get; set; }

        public DbContext()
        {
            Accounts = new List<Account>();
            Games = new List<Game>();
        }
    }
}
