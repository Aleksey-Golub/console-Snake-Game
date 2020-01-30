using System;
using System.Collections.Generic;
using System.Text;

namespace My_own_console_Snake
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Symbol { get; set; }
        public Point(int x, int y, char sym)
        {
            X = x;
            Y = y;
            Symbol = sym;
        }

        internal void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.WriteLine(Symbol);
        }
    }
}
