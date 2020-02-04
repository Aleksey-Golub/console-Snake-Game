using System;
using System.Collections.Generic;

namespace My_own_console_Snake
{
    internal class FoodCreator
    {
        private int windowWidth;
        private int windowHeight;
        private char sym;
        private int indentForAdditionalField;
        Random random = new Random();

        public FoodCreator(int windowWidth, int windowHeight, char sym, int indentForAdditionalField)
        {
            this.windowWidth = windowWidth;
            this.windowHeight = windowHeight;
            this.sym = sym;
            this.indentForAdditionalField = indentForAdditionalField;
        }

        internal Point CreateFood(List<Point> pListSnake, List<Point> pListAdditioanlBarrier)
        {
            Point food = new Point(1, 1, '@');
            bool flagSnake = true;
            bool flagAdditioanlBarrier = true;
            while (flagSnake || flagAdditioanlBarrier)
            {
                int x = random.Next(2, windowWidth - 3);
                int y = random.Next(2 + indentForAdditionalField, windowHeight - 2);
                food = new Point(x, y, sym);

                for (int i = 0; i <= pListSnake.Count - 1; i++)
                {
                    if (pListSnake[i].IsHit(food))
                    {
                        flagSnake = true;
                        break;
                    }
                    else
                        flagSnake = false;
                }

                for (int i = 0; i <= pListAdditioanlBarrier.Count - 1; i++)
                {
                    if (pListAdditioanlBarrier[i].IsHit(food))
                    {
                        flagAdditioanlBarrier = true;
                        break;
                    }
                    else
                        flagAdditioanlBarrier = false;
                }
            }
            return food;
        }
    }
}