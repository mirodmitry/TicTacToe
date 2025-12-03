using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Service;

namespace TicTacToe.UI
{
    public class RatingCommand : ICommand
    {
        private IAccountService _accountService;
        public string Name => "Список лідерів";
        public RatingCommand(IAccountService service)
        {
            _accountService = service;
        }
        public bool IsEnabled()
        {
            return true;
        }
        public void Execute()
        {
            Console.WriteLine(" Список лідерів");
            var players = _accountService.GetAllPlayers().OrderByDescending(a => a.Rating).ToList();

            if (!players.Any())
            {
                Console.WriteLine("Немає зареєстрованих гравців.");
                return;
            }

            int rank = 1;
            foreach (var player in players)
            {
                if (player.User_Name == "Bot") continue;
                Console.WriteLine($"{rank}. Ім'я: {player.User_Name} Рейтинг: {player.Rating} Тип: {player.GetType().Name}");
                rank++; 
            }

        }
    }
}
