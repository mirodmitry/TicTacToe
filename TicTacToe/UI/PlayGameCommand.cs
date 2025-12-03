using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Entities;
using TicTacToe.Factories;
using TicTacToe.Service;
using TicTacToe.GameEngine;

namespace TicTacToe.UI
{
    public class PlayGameCommand : ICommand
    {
        private IAccountService _accountService;
        private IGameService _gameService;

        public string Name => "Почати гру";
        public PlayGameCommand(IAccountService accService, IGameService gameService)
        {
            _accountService = accService;
            _gameService = gameService;
        }

        public bool IsEnabled()
        {
            return UserSession.IsLoggedIn();
        }
        public void Execute()
        {
            Account player1 = UserSession.CurrentUser;
            Account player2;
            string gameType = "standard";
            int stake = 10;
            Console.WriteLine("Оберіть режим гри:");
            Console.WriteLine("1. Стандартна гра");
            Console.WriteLine("2. Гра з великими ставками");
            Console.WriteLine("3. Тренувальна гра");
            Console.WriteLine("Ваш вибір:");
            string typeChoice = Console.ReadLine();

            if(typeChoice == "2")
            {
                gameType = "highstakes";
                stake = 50;
            }
            else if (typeChoice == "3")
            {
                gameType = "training";
                stake = 0;
            }
            Console.WriteLine("Оберіть проти кого будете грати:");
            Console.WriteLine("1. Грати проти Бота");
            Console.WriteLine("2. Грати проти іншого гравця");
            Console.WriteLine("Ваш вибір:");
            string opponentChoice = Console.ReadLine();

            if(opponentChoice == "2")
            {
                player2 = GetOpponentFromUser(player1);
            }
            else
            {
                player2 = _accountService.BotAccount();
            }
            Game game = GameFactory.CreateGame(gameType, player1, player2, stake);  
            RunGame(game, player1, player2);
        }

        private Account GetOpponentFromUser(Account player1)
        {
            Account opponent = null;
            while(opponent == null)
            {
                Console.WriteLine("Введіть ім'я опонента");
                string opponentName = Console.ReadLine();

                if (opponentName.Equals(player1.User_Name, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Не можна грати проти себе! Граємо з Ботом.");
                    continue;
                }
                opponent = _accountService.GetAllPlayers().FirstOrDefault(a => a.User_Name.Equals(opponentName, StringComparison.OrdinalIgnoreCase));
                if (opponent == null)
                {
                    Console.WriteLine("Опонента не знайдено");
                }
            }
            return opponent;
        } 

        private void RunGame(Game game, Account p1, Account p2)
        {
            char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            bool Player1Turn = true;
            bool gameRunning = true;
            bool isBotGame = p2.User_Name == "Bot";
            Account winner = null;
            Account loser = null;

            Console.Clear();
            Console.WriteLine($"\nПочаток гри {p1.User_Name} X vs {(isBotGame ? "Бот O" : p2.User_Name + " O")}");
            while (gameRunning)
            {
                DrawBoard(board);
                Account currentPlayer;
                char currentSymbol;
                if (Player1Turn)
                {
                    currentPlayer = p1;
                    currentSymbol = 'X';
                }
                else
                {
                    currentPlayer = p2;
                    currentSymbol = 'O';
                }
                int moveIndex = -1;
                bool validMove = false;

                if (isBotGame && !Player1Turn)
                {
                    Console.WriteLine("Хід Бота");
                    Thread.Sleep(1500);
                    moveIndex = GameEngine.GameLogic.BotMove(board);
                    validMove = moveIndex != -1;
                    if (validMove) Console.WriteLine(moveIndex + 1);
                }
                else
                {
                    moveIndex = GetPlayerMove(board, currentPlayer, currentSymbol);
                    validMove = moveIndex != -1;
                }
                if (validMove)
                {
                    board[moveIndex] = currentSymbol;
                    if (GameEngine.GameLogic.CheckWin(board))
                    {
                        DrawBoard(board);
                        Console.WriteLine($"\nВиграв {currentPlayer.User_Name} ({currentSymbol})!");
                        winner = currentPlayer;
                        loser = (currentPlayer == p1) ? p2 : p1;
                        gameRunning = false;
                    }
                    else if( board.All(c => c == 'X' || c == 'O'))
                    {
                        DrawBoard(board);
                        Console.WriteLine("\nНічия");
                        gameRunning = false;
                    }
                    else
                    {
                        Player1Turn = !Player1Turn;
                    }
                }
                else if(!isBotGame || Player1Turn)
                {
                    Console.WriteLine("Невірний хід! Клітинка зайнята або не існує.");
                    Thread.Sleep(1000);
                }
            }
            Console.WriteLine("Збереження рейтингу");
            _gameService.FinishGame(game, winner, loser);
        }

        private int GetPlayerMove(char[] board, Account currentPlayer, char currentSymbol)
        {
            int moveIndex = -1;
            bool valid = false;

            while (!valid)
            {
                Console.Write($"\nХід {currentPlayer.User_Name} {currentSymbol}. Введіть номер клітинки (1-9): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int choice) && choice >= 1 && choice <= 9)
                {
                    moveIndex = choice - 1;
                    if (GameEngine.GameLogic.IsValidMove(board, moveIndex))
                    {
                        valid = true;
                    }
                    else
                    {
                        Console.WriteLine("Клітинка вже зайнята.");
                    }
                }
                else
                {
                    Console.WriteLine("Введіть число від 1 до 9.");
                }
            }
            return moveIndex;
        }

        private void DrawBoard(char[] board)
        {
            Console.WriteLine("\n Ігрове поле");
            Console.WriteLine($" {board[0]} | {board[1]} | {board[2]} ");
            Console.WriteLine("---|---|---");
            Console.WriteLine($" {board[3]} | {board[4]} | {board[5]} ");
            Console.WriteLine("---|---|---");
            Console.WriteLine($" {board[6]} | {board[7]} | {board[8]} ");
        }
    }
    
}
