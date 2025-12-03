using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Factories;
using TicTacToe.Repository.Base;
using TicTacToe.Entities;

namespace TicTacToe.Service
{
    public class AccountService : IAccountService { 
        private IAccountRepository _repository;
        public AccountService(IAccountRepository repository)
        {
            _repository = repository;
        }

        public void RegisterPlayer(string username, string password, string type)
        {
            var existing = _repository.GetByUserName(username);
            if (existing != null)
            {
                throw new Exception("Гравець з таким іменем вже існує");
            }

            Account newAccount = AccountFactory.CreateAccount(type, username, password);
            _repository.Create(newAccount);
        }

        public Account LoginPlayer(string username, string password)
        {
            var account = _repository.GetByUserName(username);
            if (account == null)
            {
                throw new Exception("Користувача не знайдено");
            }

            if(account.Password != password)
            {
                throw new Exception("Невірний пароль");
            }
            return account;
        }

        public List<Account> GetAllPlayers()
        {
            return _repository.GetAll();
        }

        public Account BotAccount()
        {
            var bot = _repository.GetByUserName("Bot");
            if(bot == null)
            {
                bot = new BasicAccount("Bot", "1234");
                _repository.Create(bot);
            }
            return bot;
        }
    }
}
