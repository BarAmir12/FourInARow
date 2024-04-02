using FourInARow;
using System;

namespace FourInARow
{
    class Program
    {
        static void Main(string[] args)
        {
            RunGame();
        }

        public static void RunGame()
        {
            bool isRunning = true;

            UI.DisplayClearScreen();
            UI.DisplayWelcomeMessage();
            UI.DisplayBoardSizePrompt();
            int rows = UserInput.GetValidBoardSize("rows");
            int cols = UserInput.GetValidBoardSize("columns");

            Player player1 = new Player("Player 1", 'X');
            Player player2 = new Player("Player 2", 'O');

            while (isRunning)
            {
                GameLogic.PlayRound(rows, cols, player1, player2);
                GameLogic.ResetOrLeave(player1, player2);
            }
        }
    }
}