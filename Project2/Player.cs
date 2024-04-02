using System;

namespace FourInARow
{
    class Player
    {
        public string m_Name { get; }
        public char m_Symbol { get; }
        public int m_Points { get; private set; }

        public Player(string name, char symbol)
        {
            m_Name = name;
            m_Symbol = symbol;
            m_Points = 0;
        }

        public void AddPoint()
        {
            m_Points++;
        }

        public void ResetPoints()
        {
            m_Points = 0;
        }
    }
}
