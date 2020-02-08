using System;
using System.Collections.Generic;
using System.Text;

namespace My_own_console_Snake
{
    class Point
    {
        int x;
        int y;
        public char sym;

        public Point(Point p)
        {
            this.x = p.x;
            this.y = p.y;
            this.sym = p.sym;
        }

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

        
        internal void Move(int offset, Direction direction)
        {
            switch (direction)
            {
                case Direction.up:
                    y -= offset;
                    break;
                case Direction.down:
                    y += offset;
                    break;
                case Direction.left:
                    x -= offset;
                    break;
                case Direction.right:
                    x += offset;
                    break;
            }
        }

        internal bool IsHit(Point p)
        {
            return p.x == this.x && p.y == this.y;
        }

        internal void Clear()
        {
            sym = ' ';
            Draw();
        }

        internal bool IsHitPointList(List<Point> pList)
        {
            for(int i = 0; i < pList.Count; i++)
            {
                if (this.IsHit(pList[i]))
                    return true;
            }
            return false;
        }
    }
}
