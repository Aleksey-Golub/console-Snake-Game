using System;
using System.Collections.Generic;
using System.Text;

namespace My_own_console_Snake
{
    class Barriers : Figure
    {
        
        public Barriers(int windowWidth, int windowHeight, char sym, int indentForAdditionalField)
        {
            // 3 - size of border for SCORE. If 0 - border will disappear
            HorizontalLine upperLine = new HorizontalLine(0, windowWidth - 2, indentForAdditionalField, sym);
            HorizontalLine downLine = new HorizontalLine(0, windowWidth - 2, windowHeight - 1, sym);
            VerticalLine leftLine = new VerticalLine(0, indentForAdditionalField, windowHeight - 1, sym);
            VerticalLine rightLine = new VerticalLine(windowWidth - 2, indentForAdditionalField, windowHeight - 1, sym);

            pList = new List<Point>();

            pList.AddRange(upperLine.pList);
            pList.AddRange(downLine.pList);
            pList.AddRange(leftLine.pList);
            pList.AddRange(rightLine.pList);
        }

        public override void Draw()
        {
            foreach (var p in pList)
                p.Draw();
        }
    }
}
