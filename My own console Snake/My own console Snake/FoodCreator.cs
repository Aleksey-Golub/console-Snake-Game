using System;
using System.Collections.Generic;

namespace My_own_console_Snake
{
    internal class FoodCreator
    {
        private int windowWidth;
        private int windowHeight;
        private char sym;
        Random random = new Random();

        public FoodCreator(int windowWidth, int windowHeight, char sym)
        {
            this.windowWidth = windowWidth;
            this.windowHeight = windowHeight;
            this.sym = sym;
        }

        internal Point CreateFood(List<Point> pList)
        {
            Point food = new Point(1, 1, '@');
            bool flag = true;
            while (flag)
            {
                int x = random.Next(2, windowWidth - 2);
                int y = random.Next(5, windowHeight - 2);
                food = new Point(x, y, sym);

                for (int i = 0; i <= pList.Count - 1; i++)
                {
                    if (pList[i].IsHit(food))
                    {
                        flag = true;
                        break;
                    }
                    else
                        flag = false;
                }
            }
            return food;
        }
    }
}