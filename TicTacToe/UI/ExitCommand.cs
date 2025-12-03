using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.UI
{
    public class ExitCommand : ICommand
    {
        public string Name => "Вихід з програми";
        public void Execute()
        {
            Console.WriteLine("До зустрічі :)");
            Environment.Exit(0);
        }
        public bool IsEnabled()
        {
            return true;
        }
    }
}
