using System;

namespace FourInARow
{
    class UserInput
    {
        public static int GetValidBoardSize(string i_Dimension)
        {
            int size;

            while (true)
            {
                Console.Write($"Enter number of {i_Dimension}: ");
                if (int.TryParse(Console.ReadLine(), out size) && size >= 4 && size <= 8)
                {
                    return size;
                }
                else
                {
                    Console.WriteLine($"Invalid input! {i_Dimension} must be an integer between 4 and 8.");
                }
            }
        }
        public static bool MakePlayerMove(Board i_Board, Player i_Player)
        {
            while (true)
            {
                UI.GetColumnPrompt(i_Player.m_Name);
                string input = Console.ReadLine();

                if (input.ToUpper() == "Q")
                {
                    UI.GetQuitMessage(i_Player.m_Name, i_Board.GetOpponent(i_Player).m_Name);
                    i_Board.GetOpponent(i_Player).AddPoint();
                    return false;
                }
                else if (int.TryParse(input, out int col) && col >= 1 && col <= i_Board.m_Cols)
                {
                    if (i_Board.IsValidMove(col - 1))
                    {
                        i_Board.PlaceChip(col - 1, i_Player.m_Symbol);
                        return true;
                    }
                    else
                    {
                        UI.GetInvalidMoveMessage();
                    }
                }
                else
                {
                    UI.GetInvalidInputMessage();
                }
            }
        }

        public static void PlayNewGame()
        {
            bool isRunning = true;

            while (isRunning)
            {
                UI.DisplayNewGamePrompt();
                string newGame = Console.ReadLine().ToUpper();

                if (newGame == "Y")
                {
                    Program.RunGame();
                }
                else if (newGame == "N")
                {
                    System.Environment.Exit(0);
                }
                else
                {
                    UI.DisplayInvalidInputMessage();
                }
            }
        }
    }
}
