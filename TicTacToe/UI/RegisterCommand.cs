using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Service;

namespace TicTacToe.UI
{
    public class RegisterCommand : ICommand
    {
        private IAccountService _accountService;
        public string Name => "Зареєструватися";
        public RegisterCommand(IAccountService service)
        {
            _accountService = service;
        }
        public bool IsEnabled()
        {
            return !UserSession.IsLoggedIn();
        }
        public void Execute()
        {
            Console.WriteLine("Реєстрація");
            Console.Write("Введіть логін: ");
            string username = Console.ReadLine();

            Console.Write("Введіть пароль: ");
            string password = Console.ReadLine();

            Console.WriteLine("Оберіть тип акаунту:");
            Console.WriteLine("1.Звичайний");
            Console.WriteLine("2. Бонус за серію перемог");
            Console.Write("Ваш вибір: ");
            string choice = Console.ReadLine();

            string type;
            if (choice == "2")
            {
                type = "winstreak";
            }
            else
            {
                type = "basic";
            }
            try
            {
                _accountService.RegisterPlayer(username, password, type);
                Console.WriteLine($" Акаунт {username} створено.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка реєстрації: {ex.Message}");
            }


        }
    }
}
