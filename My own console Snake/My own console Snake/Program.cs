using System;
using System.Threading;
using System.Collections.Generic;

namespace My_own_console_Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            /*  Осталось Исправить
             * 1. Вернуть ((score == 2500 && level == 1) || (score == 5000 && level == 2))
             * 2. Создание и отрисовка препятствия Level 3 with 2 random Figure consist of 5 connected Points 
             * 3. TO DO   AdditionalBarrierCreator.CreateAdditionalBarrier()
             * 4. Экран после стартового: Управление + Выбор уровня сложности после старта: EASY/HARD (scoreForLevelUp = 1000/2500)
            */
            // Game Sittings
            int indentForAdditionalField = 3;
            int windowWidth = 80;
            int windowHeight = 25 + indentForAdditionalField;
            int finalScore = 0;


            Console.SetWindowSize(1, 1);
            Console.SetBufferSize(windowWidth, windowHeight);
            Console.SetWindowSize(windowWidth, windowHeight);


            #region Стартовый Экран
            int TreadOfStartScreen = 400;
            Console.CursorVisible = false;
            
            Console.SetCursorPosition(37, 7);
            Console.Write("WELCOME");
            Thread.Sleep(TreadOfStartScreen);

            Console.SetCursorPosition(39, 8);
            Console.Write("TO");
            Thread.Sleep(TreadOfStartScreen);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(37, 10);
            Console.Write("CONSOLE");
            Thread.Sleep(TreadOfStartScreen);

            Console.SetCursorPosition(38, 18);
            Console.Write("GAME");
            Thread.Sleep(TreadOfStartScreen);
            Console.ForegroundColor = ConsoleColor.Gray;

            // SNAKE
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(30, 12);
            Console.Write("*** *  * *** *  * ***");
            Thread.Sleep(TreadOfStartScreen);
            Console.SetCursorPosition(30, 13);
            Console.Write("*   ** * * * * *  *  ");
            Thread.Sleep(TreadOfStartScreen);
            Console.SetCursorPosition(30, 14);
            Console.Write("*** * ** *** **   ***");
            Thread.Sleep(TreadOfStartScreen);
            Console.SetCursorPosition(30, 15);
            Console.Write("  * *  * * * * *  *  ");
            Thread.Sleep(TreadOfStartScreen);
            Console.SetCursorPosition(30, 16);
            Console.Write("*** *  * * * *  * ***");
            Thread.Sleep(TreadOfStartScreen);
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.SetCursorPosition(68, 26);
            Console.Write("by G.A.S.");
            Thread.Sleep(TreadOfStartScreen * 3);

            Console.SetCursorPosition(30, 25);
            Console.Write("PRESS ANY KEY TO START");

            Console.ReadKey();

            #endregion

            bool flag = true;
            while (flag)
            {
                #region Создание списка Дополнительных препятствий
                // Создание дополнительного препятствия для Уровня 1
                Figure barrierForLevel1 = new Figure();
                barrierForLevel1.pList.Add(new Point(0, indentForAdditionalField, '#'));

                // Создание дополнительного препятствия для Уровня 2
                Figure barrierForLevel2 = new Figure();
                for (int i = windowWidth / 8 * 3; i <= windowWidth / 8 * 5; i++)
                {
                    barrierForLevel2.pList.Add(new Point(i, 7 + indentForAdditionalField, '#'));
                }
                for (int i = windowWidth / 8 * 3; i <= windowWidth / 8 * 5; i++)
                {
                    barrierForLevel2.pList.Add(new Point(i, windowHeight - 8, '#'));
                }

                // Создание дополнительного препятствия для Уровня 3
                Point pStart = new Point(4, 5, '*');
                Snake snakeStart = new Snake(pStart, 4, Direction.right);
                AdditionalBarrierCreator additionalBarrierCreator = new AdditionalBarrierCreator(windowWidth, windowHeight, '#', indentForAdditionalField);
                Figure barrierForLevel3 = additionalBarrierCreator.CreateAdditionalBarrier(snakeStart.pList);


                // Создание списка Дополнительных препятствий
                List<Figure> listOfBarrier = new List<Figure> { barrierForLevel1, barrierForLevel2, barrierForLevel3 };
                #endregion

                #region Первичная инициализация объектов
                // Первичная однократная отрисовка объектов до основного цикла игры

                //int score = 0;
                //int level = 1;

                for (int score = 0, level = 1; true; )
                { 
                    // Отрисовка Счета
                    Console.Clear();
                    Console.SetCursorPosition(1, 1);
                    Console.Write("SCORE:");
                    Console.SetCursorPosition(8, 1);
                    Console.Write(score);

                    // Отрисовка Уровня
                    Console.SetCursorPosition(windowWidth - 11, 1);
                    Console.Write("LEVEL:");
                    Console.SetCursorPosition(windowWidth - 4, 1);
                    Console.Write(level);


                    // Создание и отрисовка границы поля
                    Barriers barrier = new Barriers(windowWidth, windowHeight, '#', indentForAdditionalField);
                    barrier.Draw();

                    // Создание и отрисовка Змейки
                    int ThreadSleep = 150;
                    Point p = new Point(4, 5, '*');
                    Snake snake = new Snake(p, 4, Direction.right);
                    snake.Draw();
                    

                    // Создание и отрисовка препятствий на поле
                    // to do                
                    Figure additioanlBarrier = listOfBarrier[level - 1];
                    additioanlBarrier.Draw();

                    // Создание и отрисовка еды
                    FoodCreator foodCreator = new FoodCreator(windowWidth, windowHeight, '@', indentForAdditionalField);
                    Point food = foodCreator.CreateFood(snake.pList, additioanlBarrier.pList);
                    Console.ForegroundColor = ConsoleColor.Red;
                    food.Draw();
                    Console.ForegroundColor = ConsoleColor.Gray;
                    #endregion

                    #region Основной цикл игры
                    // Основной цикл игры 
                    while (true)
                    {
                        if (snake.IsHit(barrier) || snake.IsHitBody() || snake.IsHit(additioanlBarrier)) 
                        {
                            break;
                        }
                        
                       
                        if (snake.Eat(food))
                        {
                            score += 100;
                            Console.SetCursorPosition(8, 1);
                            Console.Write(score);

                            if ((score == 300 && level == 1) || (score == 500 && level == 2))
                            {
                                level++;
                                break;
                            }

                            food = foodCreator.CreateFood(snake.pList, additioanlBarrier.pList);
                            Console.ForegroundColor = ConsoleColor.Red;
                            food.Draw();
                            Console.ForegroundColor = ConsoleColor.Gray;

                            if (ThreadSleep > 50)
                                ThreadSleep -= 7;
                        }
                        else
                        {
                            snake.Move();
                        }


                        Thread.Sleep(ThreadSleep);

                        if (Console.KeyAvailable)
                        {
                            ConsoleKeyInfo key = Console.ReadKey();
                            snake.HandleKey(key.Key);
                        }
                    }
                    #endregion
                    if (snake.IsHit(barrier) || snake.IsHitBody() || snake.IsHit(additioanlBarrier))
                    {
                        finalScore = score;
                        break;
                    }
                }

                // Game Over Window
                #region Game Over Window
                Console.Clear();
                Console.SetCursorPosition(35, 10);
                Console.WriteLine("GAME OVER\n\n");
                Console.SetCursorPosition(34, 13);
                Console.WriteLine($"SCORE: {finalScore}");
                Console.SetCursorPosition(28, 15);
                Console.WriteLine("DO YOU WANT TO RESTART ?");
                Console.SetCursorPosition(33, 18);
                Console.Write("PRESS Y or N");
                Console.SetCursorPosition(40, 20);
                
                flag = false;

                ConsoleKeyInfo key1 = Console.ReadKey();
                if (key1.Key == ConsoleKey.Y)
                        flag = true;
                #endregion 
            }
        }
    }
}
