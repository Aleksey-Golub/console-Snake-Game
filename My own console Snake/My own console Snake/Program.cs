using System;
using System.Threading;

namespace My_own_console_Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            /*  Осталось Исправить
             * 1. Оформить "экран смерти"
             * 1.2 Дать выбор: рестарт или выход
             * 2. Добавить счет, увеличив экран игры
             * 3. Добавить ускорение при съедении пищи
             * 4. Раскрасить игру: Змея - зеленая, еда - красная
            */

            Console.CursorVisible = false;

            int windowWidth = 80;
            int windowHeight = 25;
            

            Console.SetWindowSize(1, 1);
            Console.SetBufferSize(windowWidth, windowHeight);
            Console.SetWindowSize(windowWidth, windowHeight);

            // Создание и отрисовка границы поля
            Barriers barrier = new Barriers(windowWidth, windowHeight, '#');
            barrier.Draw();

            // Создание и отрисовка Змейки
            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.right);
            snake.Draw();

            // Создание и отрисовка еды
            FoodCreator foodCreator = new FoodCreator(windowWidth, windowHeight, '@');
            Point food = foodCreator.CreateFood(snake.pList);
            food.Draw();

            while (true)
            {
                if (snake.IsHit(barrier) || snake.IsHitBody())
                    break;

                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood(snake.pList);
                    food.Draw();
                }
                else
                    snake.Move();


                Thread.Sleep(150);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
            }
        }
    }
}
