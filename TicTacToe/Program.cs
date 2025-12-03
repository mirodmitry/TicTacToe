using System;
using System.Text;
using System.Threading;
using TicTacToe.Repository;
using TicTacToe.Repository.Base;
using TicTacToe.Service;
using TicTacToe.UI;
using TicTacToe.Data;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            DbContext dbContext = new DbContext();

            IAccountRepository accountRepository = new AccountRepository(dbContext);
            IGameRepository gameRepository = new GameRepository(dbContext);
            IAccountService accountService = new AccountService(accountRepository);
            IGameService gameService = new GameService(gameRepository, accountRepository);
            CommandManager manager = new CommandManager();

            manager.Register(new RegisterCommand(accountService));
            manager.Register(new LoginCommand(accountService));
            manager.Register(new RatingCommand(accountService));

            manager.Register(new PlayGameCommand(accountService, gameService));
            manager.Register(new HistoryCommand(gameService));
            manager.Register(new LogoutCommand());

            manager.Register(new ExitCommand());
            manager.Run();
        }
    }
}