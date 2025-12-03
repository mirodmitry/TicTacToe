using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Service;

namespace TicTacToe.UI
{
    public class LoginCommand : ICommand
    {
        private IAccountService _accountService;
        public string Name => "Увійти";
        public LoginCommand(IAccountService service)
        {
            _accountService = service;
        }
        public bool IsEnabled()
        {
            return !UserSession.IsLoggedIn();
        }

        public void Execute()
        {
            Console.WriteLine("Вхід");
            Console.Write("Логін: ");
            string username = Console.ReadLine();
            Console.Write("Пароль: ");
            string password = Console.ReadLine();
            try
            {
                var user = _accountService.LoginPlayer(username, password);
                UserSession.CurrentUser = user;
                Console.WriteLine($"Вітаємо, {user.User_Name} :)");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
        }
    }
}
