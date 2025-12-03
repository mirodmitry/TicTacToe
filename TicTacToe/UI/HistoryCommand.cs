using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Service;

namespace TicTacToe.UI
{
    public class HistoryCommand : ICommand
    {
        private IGameService _gameService;
        public string Name => "Переглянути історію ігор";
        public HistoryCommand(IGameService service)
        {
            _gameService = service;
        }
        public bool IsEnabled()
        {
            return UserSession.IsLoggedIn();
        }

        public void Execute()
        {
            Console.WriteLine($"Історія гравця {UserSession.CurrentUser.User_Name}");
            var history = _gameService.GetPlayerHistory(UserSession.CurrentUser.User_Name);

            if (!history.Any())
            {
                Console.WriteLine("Історія порожня. Зіграйте свою першу гру!");
                return;
            }
            int index = 1;
            foreach (var game in history)
            {
                string result;
                if(game.Winner == null)
                {
                    result = "Нічия";
                }
                else
                {
                    if(game.Winner.User_Name == UserSession.CurrentUser.User_Name)
                    {
                        result = "Перемога";
                    }
                    else
                    {
                        result = "Поразка";
                    }
                }
                string opponentName;
                if(game.Player1.ID == UserSession.CurrentUser.ID)
                {
                    opponentName = game.Player2.User_Name;
                }
                else
                {
                    opponentName = game.Player1.User_Name;
                }
                Console.WriteLine($"{index}. ID: {game.ID} Опонент: {opponentName} Ставка: {game.GetRating()} Результат: {result} Тип: {game.GetType().Name}");
                index++;
            }
        }
    }
}
