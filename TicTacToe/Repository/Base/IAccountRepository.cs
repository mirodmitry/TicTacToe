using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Entities;

namespace TicTacToe.Repository.Base
{
    public interface IAccountRepository
    {
        void Create(Account account);
        void Update(Account account);
        void Delete(string username);
        List<Account> GetAll();
        Account GetByUserName(string username);
    }
}
