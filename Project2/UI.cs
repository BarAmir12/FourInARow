using System;
using Ex02.ConsoleUtils;

namespace FourInARow
{
    class UI
    {
        public static void DisplayWelcomeMessage()
        {
            Console.WriteLine("Welcome to Four in a Row!");
        }

        public static void DisplayBoardSizePrompt()
        {
            Console.WriteLine("Enter the size of the board (not less than 4x4, not more than 8x8):");
        }

        public static void DisplayNewGamePrompt()
        {
            Console.WriteLine("Do you want to start a new game? (Y/N):");
        }

        public static void DisplayInvalidInputMessage()
        {
            Console.WriteLine("Invalid input. Please enter Y or N.");
        }

        public static void DisplayPlayAgainPrompt()
        {
            Console.WriteLine("Do you want to play another round? (Y/N):");
        }

        public static void DisplayPlayAgainstComputerPrompt()
        {
            Console.WriteLine("Do you want to play against the computer? (Y/N):");
        }

        public static void DisplayPlayNewGameMessage()
        {
            UserInput.PlayNewGame();
        }

        public static void DisplayClearScreen()
        {
            Screen.Clear();
        }

        public static void DisplayBoard(Board board)
        {
            board.Print();
        }

        public static void GetColumnPrompt(string playerName)
        {
            Console.WriteLine($"{playerName}, enter the column to place your chip (or 'Q' to quit): ");
        }

        public static void GetQuitMessage(string playerName, string opponentName)
        {
            Console.WriteLine($"{playerName} quits. {opponentName} receives a point.");
        }

        public static void GetInvalidMoveMessage()
        {
            Console.WriteLine("Invalid move! Column is full.");
        }

        public static void GetInvalidInputMessage()
        {
            Console.WriteLine("Invalid input! Please enter a valid column number.");
        }

        public static void DisplayGameResult(string gameResult, Player currentPlayer, Player player1, Player player2)
        {
            Console.WriteLine(gameResult);
            if (gameResult != "Draw")
            {
                Console.WriteLine($"{currentPlayer.m_Name} wins!");
                currentPlayer.AddPoint();
            }
            else
            {
                Console.WriteLine("It's a draw!");
            }
            Console.WriteLine($"Points:\n{player1.m_Name}: {player1.m_Points}\n{player2.m_Name}: {player2.m_Points}");
        }
    }
}