using System;
using System.Collections.Generic;
using System.Text;

namespace My_own_console_Snake
{
    abstract class Figure
    {
        protected List<Point> pList;
        public void Draw()
        {
            foreach(var p in pList)
                p.Draw();
        }
    }
}
