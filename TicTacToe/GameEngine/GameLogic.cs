using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.GameEngine
{
    public static class GameLogic
    {
        private static Random _random = new Random();
        private static int[,] _winConditions = new int[,]
        {
            {0, 1, 2},  {3, 4, 5},  {6, 7, 8}, {0, 3, 6},
            {1, 4, 7},  {2, 5, 8},  {0, 4, 8}, {2, 4, 6}
        };

        public static char GetWinner(char[] board)
        {
            for (int i = 0; i < 8; i++)
            {
                int a = _winConditions[i, 0];
                int b = _winConditions[i, 1];
                int c = _winConditions[i, 2];

                if (board[a] == board[b] && board[b] == board[c])
                {
                    return board[a];
                }
            }
            return ' ';
        }

        public static bool CheckWin(char[] board)
        {
            return GetWinner(board) != ' ';
        }

        public static bool IsValidMove(char[] board, int index)
        {
            if (index < 0 || index > 8)
                return false;
            return board[index] != 'X' && board[index] != 'O';
        }

        public static int BotMove(char[] board)
        {
            List<int> emptySlots = new List<int>();
            for(int i = 0; i < 9; i++)
            {
                if (board[i] != 'X' && board[i] != 'O')
                {
                    emptySlots.Add(i);
                }
            }
            if (emptySlots.Count == 0)
                return -1;
            return emptySlots[_random.Next(emptySlots.Count)];
        }
    }
}
