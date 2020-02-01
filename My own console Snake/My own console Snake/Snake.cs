using System;
using System.Collections.Generic;
using System.Text;

namespace My_own_console_Snake
{
    class Snake : Figure
    {
        private Direction direction;

        public Snake(Point tail, int length, Direction direction)
        {
            this.direction = direction;
            pList = new List<Point>();
            for (int i = 0; i < length; i++)
            {
                Point p = new Point(tail);
                p.Move(i, direction);
                pList.Add(p);
            }

        }

        internal void Move()
        {
            Point tail = pList[0];
            pList.Remove(tail);
            Point head = GetNextPoint();
            pList.Add(head);

            tail.Clear();
            head.Draw();
        }

        private Point GetNextPoint()
        {
            Point head = pList[pList.Count - 1];
            Point nextPoint = new Point(head);
            nextPoint.Move(1, direction);
            return nextPoint;
        }

        //internal bool IsHit(Border border)
        //{
        //    throw new NotImplementedException();
        //}

        internal bool IsHitBody()
        {
            for(int i = 0; i < pList.Count - 1; i++)
            {
                if (pList[i].IsHit(pList[pList.Count - 1]))
                    return true;
            }
            return false;
        }

        internal bool Eat(Point food)
        {
            Point head = GetNextPoint();
            if (head.IsHit(food))
            {
                food.sym = head.sym;
                food.Draw();
                pList.Add(food);
                return true;
            }
            else
                return false;
        }

        internal void HandleKey(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    direction = Direction.up;
                    break;
                case ConsoleKey.DownArrow:
                    direction = Direction.down;
                    break;
                case ConsoleKey.LeftArrow:
                    direction = Direction.left;
                    break;
                case ConsoleKey.RightArrow:
                    direction = Direction.right;
                    break;
            }
        }
    }
}
