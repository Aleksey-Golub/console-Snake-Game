using System;
using System.Collections.Generic;
using System.Text;

namespace My_own_console_Snake
{
    class Figure
    {
        public List<Point> pList = new List<Point>();
        public virtual void Draw()
        {
            foreach(var p in pList)
                p.Draw();
        }
    }
}
