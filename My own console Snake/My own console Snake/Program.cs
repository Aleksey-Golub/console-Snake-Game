using System;
using System.Threading;

namespace My_own_console_Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            /*  Осталось Исправить
             * 1. Оформить стартовый экран
            */
            // Game Sittings
            int windowWidth = 80;
            int windowHeight = 25 + 3;
            int ThreadSleep = 150;

            Console.SetWindowSize(1, 1);
            Console.SetBufferSize(windowWidth, windowHeight);
            Console.SetWindowSize(windowWidth, windowHeight);
            Console.CursorVisible = false;

            #region Стартовый Экран

            Console.SetCursorPosition(1,1);
            Console.WriteLine("WELLCOME TO CONSOLE SNAKE GAME PRESS ANY KEY TO START");

            Console.ReadKey();

            #endregion

            bool flag = true;
            while (flag)
            {
                Console.Clear();
                Console.CursorVisible = false;
                Console.SetCursorPosition(1, 1);
                Console.Write("SCORE: ");
                int score = 0;
                Console.SetCursorPosition(8, 1);
                Console.Write(score);


                // Создание и отрисовка границы поля
                Barriers barrier = new Barriers(windowWidth, windowHeight, '#');
                barrier.Draw();

                // Создание и отрисовка Змейки
                Point p = new Point(4, 5, '*');
                Snake snake = new Snake(p, 4, Direction.right);
                Console.ForegroundColor = ConsoleColor.Green;
                snake.Draw();
                Console.ForegroundColor = ConsoleColor.Gray;


                // Создание и отрисовка еды
                FoodCreator foodCreator = new FoodCreator(windowWidth, windowHeight, '@');
                Point food = foodCreator.CreateFood(snake.pList);
                Console.ForegroundColor = ConsoleColor.Red;
                food.Draw();
                Console.ForegroundColor = ConsoleColor.Gray;


                while (true)
                {
                    if (snake.IsHit(barrier) || snake.IsHitBody())
                        break;

                    Console.ForegroundColor = ConsoleColor.Green;

                    if (snake.Eat(food))
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        score += 100;
                        Console.SetCursorPosition(8, 1);
                        Console.Write(score);

                        food = foodCreator.CreateFood(snake.pList);
                        Console.ForegroundColor = ConsoleColor.Red;
                        food.Draw();
                        Console.ForegroundColor = ConsoleColor.Gray;

                        if (ThreadSleep > 60)
                            ThreadSleep -= 7;
                    }
                    else
                    {
                        snake.Move();
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }


                    Thread.Sleep(ThreadSleep);

                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo key = Console.ReadKey();
                        snake.HandleKey(key.Key);
                    }
                }

                // Game Over Window
                #region Game Over Window
                Console.Clear();
                Console.SetCursorPosition(35, 10);
                Console.WriteLine("GAME OVER\n\n");
                Console.SetCursorPosition(28, 13);
                Console.WriteLine("DO YOU WANT TO REPEAT ?");
                Console.SetCursorPosition(34, 16);
                Console.Write("PRESS Y or N");
                Console.SetCursorPosition(40, 18);
                Console.CursorVisible = true;
                
                flag = false;

                string answer = Console.ReadLine();
                if (answer == "y" || answer == "Y")
                    flag = true;
                #endregion 
            }
        }
    }
}
