using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.UI
{
    public class LogoutCommand : ICommand
    {
        public string Name => "Вийти з акаунту";
        public void Execute()
        {
            UserSession.CurrentUser = null;
            Console.WriteLine("Ви вийшли з акаунту");
        }
        public bool IsEnabled()
        {
            return UserSession.IsLoggedIn(); 
        }
    }
}
