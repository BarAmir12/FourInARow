using System;

namespace FourInARow
{
    class GameLogic
    {
        public static void ResetOrLeave(Player player1, Player player2)
        {
            bool isRunning = true;

            while (isRunning)
            {
                UI.DisplayNewGamePrompt();
                string newGame = Console.ReadLine().ToUpper();

                if (newGame == "Y")
                {
                    player1.ResetPoints();
                    player2.ResetPoints();
                    break;
                }
                else if (newGame == "N")
                {
                    return;
                }
                else
                {
                   UI.DisplayInvalidInputMessage();
                }
            }
        }
        public static void PlayRound(int i_Rows, int i_Cols, Player i_Player1, Player i_Player2, bool i_VsComputer = false, bool i_NotPlayAgain = true)
        {
            bool isRunning = true;

            while (isRunning)
            {
                Board board = InitializeBoard(i_Rows, i_Cols, i_Player1, i_Player2);

                if (i_NotPlayAgain)
                {
                    i_VsComputer = PlayAgainstWho(i_VsComputer);
                }

                while (isRunning)
                {
                    UI.DisplayClearScreen();
                    board.Print();
                    Player currentPlayer = board.m_CurrentPlayer == 1 ? i_Player1 : i_Player2;

                    MakeMove(currentPlayer, i_Rows, i_Cols, board, i_Player1, i_Player2, i_VsComputer, i_NotPlayAgain);

                    if (board.IsGameOver())
                    {
                        GameResult(board, currentPlayer, i_Player1, i_Player2);
                        PlayAnotherRound(i_Rows, i_Cols, i_Player1, i_Player2, i_VsComputer, i_NotPlayAgain);
                    }
                }
            }
        }
        public static void GameResult(Board board, Player currentPlayer, Player i_Player1, Player i_Player2)
        {
            UI.DisplayClearScreen();
            UI.DisplayBoard(board);
            string gameResult = board.GetGameResult();

            UI.DisplayGameResult(gameResult, currentPlayer, i_Player1, i_Player2);
        }

        public static void MakeMove(Player i_CurrentPlayer, int i_Rows, int i_Cols, Board board, Player i_Player1, Player i_Player2, bool i_VsComputer = false, bool i_NotPlayAgain = true)
        {
            if (i_NotPlayAgain == false && i_VsComputer == true && (i_CurrentPlayer == i_Player2))
            {
                board.MakeComputerMove();
            }
            else if (i_NotPlayAgain == false && i_VsComputer == false)
            {
                if (!UserInput.MakePlayerMove(board, i_CurrentPlayer))
                {
                    PlayAnotherRound(i_Rows, i_Cols, i_Player1, i_Player2, i_VsComputer, i_NotPlayAgain);
                }
            }
            else if (i_VsComputer && (i_CurrentPlayer == i_Player2))
            {
                board.MakeComputerMove();
            }
            else
            {
                if (!UserInput.MakePlayerMove(board, i_CurrentPlayer))
                {
                    PlayAnotherRound(i_Rows, i_Cols, i_Player1, i_Player2, i_VsComputer, i_NotPlayAgain);
                }
            }
        }

        public static bool PlayAgainstWho(bool i_VsComputer)
        {
            bool validInput = false;

            while (!validInput)
            {
                UI.DisplayPlayAgainstComputerPrompt();
                string input = Console.ReadLine().ToUpper();

                if (input == "Y")
                {
                    i_VsComputer = true;
                    validInput = true;
                }
                else if (input == "N")
                {
                    i_VsComputer = false;
                    validInput = true;
                }
                else
                {
                    UI.DisplayInvalidInputMessage();
                }
            }

            return i_VsComputer;
        }

        public static void PlayAnotherRound(int i_Rows, int i_Cols, Player i_Player1, Player i_Player2, bool i_VsComputer = false, bool i_NotPlayAgain = true)
        {
            bool isRunning = true;

            while (isRunning)
            {
                UI.DisplayPlayAgainPrompt();
                string playAgain = Console.ReadLine().ToUpper();

                if (playAgain == "Y")
                {
                    i_NotPlayAgain = false;
                    PlayRound(i_Rows, i_Cols, i_Player1, i_Player2, i_VsComputer, i_NotPlayAgain);
                    break;
                }
                else if (playAgain == "N")
                {
                    UserInput.PlayNewGame();
                    break;
                }
                else
                {
                    UI.DisplayInvalidInputMessage();
                }
            }
        }

        public static Board InitializeBoard(int i_Rows, int i_Cols, Player i_Player1, Player i_Player2)
        {
            return new Board(i_Rows, i_Cols, i_Player1, i_Player2);
        }
    }
}
