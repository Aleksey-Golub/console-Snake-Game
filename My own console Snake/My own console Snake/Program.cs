using System;
using System.Threading;

namespace My_own_console_Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            /*  Исправить
             *  Дописать snake.IsHit(border)
             * 1. Убрать спавн пищи в теле Змейки
             * 2. Оформить "экран смерти"
             * 2.2 Дать выбор: рестарт или выход
             * 3. Добавить счет, увеличив экран игры
             * 4. Добавить ускорение при съедении пищи
             * 6. Исключить возможность поворота в себя
             * 7. Исправить System.ArgumentOutOfRangeException при выходе за границу поля
            */

            Console.CursorVisible = false;

            int windowWidth = 80;
            int windowHeight = 25;
            

            Console.SetWindowSize(1, 1);
            Console.SetBufferSize(windowWidth, windowHeight);
            Console.SetWindowSize(windowWidth, windowHeight);

            // Создание и отрисовка границы поля
            Border border = new Border(windowWidth, windowHeight, '#');
            border.Draw();

            // Создание и отрисовка Змейки
            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.right);
            snake.Draw();

            // Создание и отрисовка еды
            FoodCreator foodCreator = new FoodCreator(windowWidth, windowHeight, '@');
            Point food = foodCreator.CreateFood();
            food.Draw();

            while (true)
            {
                if(snake.IsHitBody()) // (snake.IsHit(border) || snake.IsHitBody())
                    break;

                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    food.Draw();
                }
                else
                    snake.Move();


                Thread.Sleep(100);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
            }
        }
    }
}
