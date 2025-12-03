using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Entities;

namespace TicTacToe.Factories
{
    public static class GameFactory
    {
        public static Game CreateGame(string type, Account player1, Account player2, int rating)
        {
            switch (type.ToLower())
            {
                case "classic":
                    return new ClassicGame(player1, player2, rating);
                case "training":
                    return new TrainingGame(player1, player2, rating);
                case "highstakes":
                    return new HighStakesGame(player1, player2, rating);
                default:
                    return new ClassicGame(player1, player2, rating);
            }
        }
    }
}
