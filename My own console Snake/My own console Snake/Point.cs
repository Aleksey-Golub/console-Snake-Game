using System;
using System.Collections.Generic;
using System.Text;

namespace My_own_console_Snake
{
    class Point
    {
        int x;
        int y;
        char sym;
        public Point(int x, int y, char sym)
        {
            this.x = x;
            this.y = y;
            this.sym = sym;
        }

        internal void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
        }
    }
}
