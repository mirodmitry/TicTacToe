using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.UI
{
    public class CommandManager
    {
        private List<ICommand> _commands;
        public CommandManager()
        {
            _commands = new List<ICommand>();
        }

        public void Register(ICommand command)
        {
            _commands.Add(command);
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Гра Хрестики-Нулики");
                if (UserSession.IsLoggedIn())
                {
                    Console.WriteLine($"Гравець: {UserSession.CurrentUser.User_Name}");
                    Console.WriteLine($"Рейтинг: {UserSession.CurrentUser.Rating}");
                }
                else
                {
                    Console.WriteLine("Для того щоб мати доступ до гри потрібно залогінитись");
                }

                List<ICommand> availableCommands = new List<ICommand>();
                foreach (ICommand command in _commands)
                {
                    if (command.IsEnabled())
                    {
                        availableCommands.Add(command);
                    }
                }

                for(int i = 0; i < availableCommands.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {availableCommands[i].Name}");
                }
                Console.WriteLine("\nОберіть опцію:");
                string input = Console.ReadLine();

                if(int.TryParse(input, out int choice) && choice > 0 && choice <= availableCommands.Count)
                {
                    Console.Clear();
                    availableCommands[choice - 1].Execute();
                    Console.WriteLine("\nНатисність Enter щоб продовжити");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Невірний вибір!");
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
