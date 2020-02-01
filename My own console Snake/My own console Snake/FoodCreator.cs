using System;

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

        internal Point CreateFood()
        {
            int x = random.Next(2, windowWidth - 2);
            int y = random.Next(2, windowHeight - 2);
            return new Point(x, y, sym);
        }
    }
}