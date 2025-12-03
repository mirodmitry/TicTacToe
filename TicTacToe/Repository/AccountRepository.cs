using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Data;
using TicTacToe.Entities;
using TicTacToe.Repository.Base;

namespace TicTacToe.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private DbContext _context;
        public AccountRepository(DbContext context)
        {
            _context = context;
        }

        public void Create(Account account)
        {
            int NewId;
            if(_context.Accounts.Count > 0)
            {
                NewId = _context.Accounts.Max(x => x.ID) + 1;
            }
            else
            {
                NewId = 1;
            }
             account.ID = NewId;
            _context.Accounts.Add(account);
        }

        public void Update(Account account)
        {
            var existingAccount = _context.Accounts.FirstOrDefault(x => x.ID == account.ID);
            if (existingAccount != null)
            {
                existingAccount.User_Name = account.User_Name;
                existingAccount.Password = account.Password;
                existingAccount.Rating = account.Rating;
                existingAccount.Games_Count = account.Games_Count;
            }
        }

        public Account GetByUserName(string username)
        {
            return _context.Accounts.FirstOrDefault(x => x.User_Name == username);
        }

        public Account GetById(int Id)
        {
            return _context.Accounts.FirstOrDefault(x => x.ID == Id);
        }

        public List<Account> GetAll()
        {
            return _context.Accounts;
        }
        public void Delete(string username)
        {
            var account = GetByUserName(username);
            if (account != null)
            {
                _context.Accounts.Remove(account);
            }
        }
    }
}
