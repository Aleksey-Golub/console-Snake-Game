using System;
using System.Collections.Generic;
using System.Text;

namespace My_own_console_Snake
{
    class Border
    {
        List<Figure> pLines = new List<Figure>();

        public Border(int windowWidth, int windowHeight, char sym)
        {
            HorizontalLine upperLine = new HorizontalLine(0, windowWidth - 2, 0, sym);
            HorizontalLine downLine = new HorizontalLine(0, windowWidth - 2, windowHeight - 1, sym);
            VerticalLine leftLine = new VerticalLine(0, 0, windowHeight - 1, sym);
            VerticalLine rightLine = new VerticalLine(windowWidth - 2, 0, windowHeight - 1, sym);

            pLines.Add(upperLine);
            pLines.Add(downLine);
            pLines.Add(leftLine);
            pLines.Add(rightLine);
        }

        internal void Draw()
        {
            foreach (var l in pLines)
                l.Draw();
        }
    }
}
