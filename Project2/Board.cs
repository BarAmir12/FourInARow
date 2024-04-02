using System;

namespace FourInARow
{
    class Board
    {
        private char[,] m_Grid;
        public int m_Rows { get; }
        public int m_Cols { get; }
        public int m_CurrentPlayer { get; private set; }
        private Player m_Player1;
        private Player m_Player2;

        public Board(int rows, int cols, Player p1, Player p2)
        {
            m_Rows = rows;
            m_Cols = cols;
            m_Grid = new char[m_Rows, m_Cols];
            m_CurrentPlayer = 1;
            m_Player1 = p1;
            m_Player2 = p2;
        }

        public void PlaceChip(int i_Col, char i_Symbol)
        {
            for (int row = m_Rows - 1; row >= 0; row--)
            {
                if (m_Grid[row, i_Col] == '\0')
                {
                    m_Grid[row, i_Col] = i_Symbol;
                    break;
                }
            }
            m_CurrentPlayer = m_CurrentPlayer == 1 ? 2 : 1;
        }

        public bool IsValidMove(int i_Col)
        {
            return m_Grid[0, i_Col] == '\0';
        }

        public bool IsGameOver()
        {
            return IsBoardFull() || CheckWinner() != '\0';
        }

        private bool IsBoardFull()
        {
            bool returnedValue = true;

            for (int row = 0; row < m_Rows; row++)
            {
                for (int col = 0; col < m_Cols; col++)
                {
                    if (m_Grid[row, col] == '\0')
                    {
                        returnedValue = false;
                    }
                }
            }

            return returnedValue;
        }

        private char CheckWinner()
        {
            for (int row = 0; row < m_Rows; row++)
            {
                for (int col = 0; col <= m_Cols - 4; col++)
                {
                    char first = m_Grid[row, col];
                    if (first != '\0' && first == m_Grid[row, col + 1] && first == m_Grid[row, col + 2] && first == m_Grid[row, col + 3])
                    {
                        return first;
                    }
                }
            }
            for (int col = 0; col < m_Cols; col++)
            {
                for (int row = 0; row <= m_Rows - 4; row++)
                {
                    char first = m_Grid[row, col];
                    if (first != '\0' && first == m_Grid[row + 1, col] && first == m_Grid[row + 2, col] && first == m_Grid[row + 3, col])
                    {
                        return first;
                    }
                }
            }
            for (int row = 0; row <= m_Rows - 4; row++)
            {
                for (int col = 0; col <= m_Cols - 4; col++)
                {
                    char first = m_Grid[row, col];
                    if (first != '\0' && first == m_Grid[row + 1, col + 1] && first == m_Grid[row + 2, col + 2] && first == m_Grid[row + 3, col + 3])
                    {
                        return first;
                    }
                }
            }
            for (int row = m_Rows - 1; row >= 3; row--)
            {
                for (int col = 0; col <= m_Cols - 4; col++)
                {
                    char first = m_Grid[row, col];
                    if (first != '\0' && first == m_Grid[row - 1, col + 1] && first == m_Grid[row - 2, col + 2] && first == m_Grid[row - 3, col + 3])
                    {
                        return first;
                    }
                }
            }

            return '\0';
        }

        public string GetGameResult()
        {
            char winner = CheckWinner();
            string result = "";
            const string winMessage = "We have a winner!";
            const string drawMessage = "Draw";

            if (winner != '\0')
            {
                result = winMessage;
            }
            else if (IsBoardFull())
            {
                result = drawMessage;
            }

            return result;
        }

        public Player GetOpponent(Player player)
        {
            Player returnedPlayer = null;

            if (player == null)
            {
                returnedPlayer = null;
            }

            if (m_CurrentPlayer == 1)
            {
                returnedPlayer = (player == m_Player1 ? m_Player2 : m_Player1);
            }
            else
            {
                returnedPlayer = player;
            }

            return returnedPlayer;
        }

        public void Print()
        {
            Console.WriteLine("Current board:");
            Console.Write("  ");
            for (int col = 1; col <= m_Cols; col++)
            {
                Console.Write($"{col}   ");
            }
            Console.WriteLine();

            for (int row = 0; row < m_Rows; row++)
            {
                Console.Write($"|");
                for (int col = 0; col < m_Cols; col++)
                {
                    Console.Write(m_Grid[row, col] == '\0' ? "   |" : $" {m_Grid[row, col]} |");
                }
                Console.WriteLine();
                Console.Write($"=");
                for (int col = 0; col < m_Cols; col++)
                {
                    Console.Write($"====");
                }
                Console.WriteLine();
            }
        }

        public bool CheckForWin(char i_Symbol)
        {
            for (int row = 0; row < m_Rows; row++)
            {
                for (int col = 0; col <= m_Cols - 4; col++)
                {
                    if (m_Grid[row, col] == i_Symbol &&
                        m_Grid[row, col + 1] == i_Symbol &&
                        m_Grid[row, col + 2] == i_Symbol &&
                        m_Grid[row, col + 3] == i_Symbol)
                    {
                        return true;
                    }
                }
            }

            for (int row = 0; row <= m_Rows - 4; row++)
            {
                for (int col = 0; col < m_Cols; col++)
                {
                    if (m_Grid[row, col] == i_Symbol &&
                        m_Grid[row + 1, col] == i_Symbol &&
                        m_Grid[row + 2, col] == i_Symbol &&
                        m_Grid[row + 3, col] == i_Symbol)
                    {
                        return true;
                    }
                }
            }

            for (int row = 0; row <= m_Rows - 4; row++)
            {
                for (int col = 0; col <= m_Cols - 4; col++)
                {
                    if (m_Grid[row, col] == i_Symbol &&
                        m_Grid[row + 1, col + 1] == i_Symbol &&
                        m_Grid[row + 2, col + 2] == i_Symbol &&
                        m_Grid[row + 3, col + 3] == i_Symbol)
                    {
                        return true;
                    }
                }
            }

            for (int row = m_Rows - 1; row >= 3; row--)
            {
                for (int col = 0; col <= m_Cols - 4; col++)
                {
                    if (m_Grid[row, col] == i_Symbol &&
                        m_Grid[row - 1, col + 1] == i_Symbol &&
                        m_Grid[row - 2, col + 2] == i_Symbol &&
                        m_Grid[row - 3, col + 3] == i_Symbol)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public void MakeComputerMove()
        {
            int bestScore = int.MinValue;
            int bestCol = 0;

            for (int col = 0; col < m_Cols; col++)
            {
                if (!IsValidMove(col))
                {
                    continue;
                }

                Board copiedBoard = new Board(m_Rows, m_Cols, m_Player1, m_Player2);
                Array.Copy(m_Grid, copiedBoard.m_Grid, m_Grid.Length);

                copiedBoard.PlaceChip(col, m_Player2.m_Symbol);

                if (copiedBoard.CheckForWin(m_Player2.m_Symbol))
                {
                    PlaceChip(col, m_Player2.m_Symbol);

                    return;
                }

                int score = Minimax(copiedBoard, 3, false);

                if (score > bestScore)
                {
                    bestScore = score;
                    bestCol = col;
                }
            }
            PlaceChip(bestCol, m_Player2.m_Symbol);
        }

        private int Minimax(Board i_Board, int i_Depth, bool i_IsMaximizingPlayer)
        {
            if (i_Depth == 0 || i_Board.IsGameOver())
            {
                return Evaluate(i_Board);
            }

            if (i_IsMaximizingPlayer)
            {
                int bestScore = int.MinValue;

                for (int col = 0; col < i_Board.m_Cols; col++)
                {
                    if (!i_Board.IsValidMove(col))
                    {
                        continue;
                    }
                    Board copiedBoard = new Board(i_Board.m_Rows, i_Board.m_Cols, i_Board.m_Player1, i_Board.m_Player2);
                    Array.Copy(i_Board.m_Grid, copiedBoard.m_Grid, i_Board.m_Grid.Length);
                    copiedBoard.PlaceChip(col, i_Board.m_Player2.m_Symbol);

                    int score = Minimax(copiedBoard, i_Depth - 1, false);
                    bestScore = Math.Max(score, bestScore);
                }

                return bestScore;
            }
            else
            {
                int bestScore = int.MaxValue;

                for (int col = 0; col < i_Board.m_Cols; col++)
                {
                    if (!i_Board.IsValidMove(col))
                    {
                        continue;
                    }
                    Board copiedBoard = new Board(i_Board.m_Rows, i_Board.m_Cols, i_Board.m_Player1, i_Board.m_Player2);
                    Array.Copy(i_Board.m_Grid, copiedBoard.m_Grid, i_Board.m_Grid.Length);
                    copiedBoard.PlaceChip(col, i_Board.m_Player1.m_Symbol);

                    int score = Minimax(copiedBoard, i_Depth - 1, true);
                    bestScore = Math.Min(score, bestScore);
                }

                return bestScore;
            }
        }

        private int Evaluate(Board i_Board)
        {
            int score = 0;

            for (int row = 0; row < i_Board.m_Rows; row++)
            {
                for (int col = 0; col < i_Board.m_Cols; col++)
                {
                    if (i_Board.m_Grid[row, col] == i_Board.m_Player2.m_Symbol)
                    {
                        if (col + 3 < i_Board.m_Cols &&
                            i_Board.m_Grid[row, col + 1] == i_Board.m_Player2.m_Symbol &&
                            i_Board.m_Grid[row, col + 2] == i_Board.m_Player2.m_Symbol &&
                            i_Board.m_Grid[row, col + 3] == i_Board.m_Player2.m_Symbol)
                        {
                            score += 1000;
                        }

                        if (row + 3 < i_Board.m_Rows &&
                            i_Board.m_Grid[row + 1, col] == i_Board.m_Player2.m_Symbol &&
                            i_Board.m_Grid[row + 2, col] == i_Board.m_Player2.m_Symbol &&
                            i_Board.m_Grid[row + 3, col] == i_Board.m_Player2.m_Symbol)
                        {
                            score += 1000;
                        }

                        if (row + 3 < i_Board.m_Rows && col + 3 < i_Board.m_Cols &&
                            i_Board.m_Grid[row + 1, col + 1] == i_Board.m_Player2.m_Symbol &&
                            i_Board.m_Grid[row + 2, col + 2] == i_Board.m_Player2.m_Symbol &&
                            i_Board.m_Grid[row + 3, col + 3] == i_Board.m_Player2.m_Symbol)
                        {
                            score += 1000;
                        }

                        if (row - 3 >= 0 && col + 3 < i_Board.m_Cols &&
                            i_Board.m_Grid[row - 1, col + 1] == i_Board.m_Player2.m_Symbol &&
                            i_Board.m_Grid[row - 2, col + 2] == i_Board.m_Player2.m_Symbol &&
                            i_Board.m_Grid[row - 3, col + 3] == i_Board.m_Player2.m_Symbol)
                        {
                            score += 1000;
                        }
                    }
                }
            }

            for (int row = 0; row < i_Board.m_Rows; row++)
            {
                for (int col = 0; col < i_Board.m_Cols; col++)
                {
                    if (i_Board.m_Grid[row, col] == i_Board.m_Player1.m_Symbol)
                    {
                        if (col + 3 < i_Board.m_Cols &&
                            i_Board.m_Grid[row, col + 1] == i_Board.m_Player1.m_Symbol &&
                            i_Board.m_Grid[row, col + 2] == i_Board.m_Player1.m_Symbol &&
                            i_Board.m_Grid[row, col + 3] == i_Board.m_Player1.m_Symbol)
                        {
                            score -= 1000;
                        }

                        if (row + 3 < i_Board.m_Rows &&
                            i_Board.m_Grid[row + 1, col] == i_Board.m_Player1.m_Symbol &&
                            i_Board.m_Grid[row + 2, col] == i_Board.m_Player1.m_Symbol &&
                            i_Board.m_Grid[row + 3, col] == i_Board.m_Player1.m_Symbol)
                        {
                            score -= 1000;
                        }

                        if (row + 3 < i_Board.m_Rows && col + 3 < i_Board.m_Cols &&
                            i_Board.m_Grid[row + 1, col + 1] == i_Board.m_Player1.m_Symbol &&
                            i_Board.m_Grid[row + 2, col + 2] == i_Board.m_Player1.m_Symbol &&
                            i_Board.m_Grid[row + 3, col + 3] == i_Board.m_Player1.m_Symbol)
                        {
                            score -= 1000;
                        }

                        if (row - 3 >= 0 && col + 3 < i_Board.m_Cols &&
                            i_Board.m_Grid[row - 1, col + 1] == i_Board.m_Player1.m_Symbol &&
                            i_Board.m_Grid[row - 2, col + 2] == i_Board.m_Player1.m_Symbol &&
                            i_Board.m_Grid[row - 3, col + 3] == i_Board.m_Player1.m_Symbol)
                        {
                            score -= 1000;
                        }
                    }
                }
            }

            return score;
        }
    }
}
