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
             *  Пожелания:
             *  - таблица рекордов
             *  - сохранение размеров Змейки при переходе к новому уровню
            */
            // Game Sittings
            int indentForAdditionalField = 3;
            int windowWidth = 80;
            int windowHeight = 25 + indentForAdditionalField;
            int finalScore = 0;
            int scoreDifficaltyLimit = 100;


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

            Console.SetCursorPosition(28, 25);
            Console.Write("PRESS ANY KEY TO CONTINUE");

            Console.ReadKey();
            
            #endregion
            
            #region Экран Управления

            Console.Clear();
            Console.SetCursorPosition(39, 6);
            Console.Write("use");

            Console.SetCursorPosition(35, 8);
            Console.Write("UP and DOWN,");

            Console.SetCursorPosition(34, 9);
            Console.Write("RIGHT and LEFT");

            Console.SetCursorPosition(33, 10);
            Console.Write("to CONTROL Snake");

            Console.SetCursorPosition(34, 12);
            Console.Write("SPACE to PAUSE");

            Console.SetCursorPosition(25, 17);
            Console.Write("choose difficulty: EASY / HARD");

            Thread.Sleep(TreadOfStartScreen);
            Console.SetCursorPosition(34, 22);
            Console.Write("PRESS E / H");

            ConsoleKeyInfo keyDifficulty;
            do
            {
                keyDifficulty = Console.ReadKey();
                if (keyDifficulty.Key == ConsoleKey.E)
                    scoreDifficaltyLimit = 1000;
                else if (keyDifficulty.Key == ConsoleKey.H)
                    scoreDifficaltyLimit = 2500;
            } while (keyDifficulty.Key != ConsoleKey.E && keyDifficulty.Key != ConsoleKey.H);
            

            //Thread.Sleep(TreadOfStartScreen);
            Console.Clear();

            #endregion

            bool flag = true;
            while (flag)
            {
                #region Создание списка Дополнительных препятствий
                
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
                    AdditionalBarrierCreator additionalBarrierCreator1 = new AdditionalBarrierCreator(windowWidth, windowHeight, '#', indentForAdditionalField);
                    Figure additioanlBarrier = additionalBarrierCreator1.CreateAdditionalBarrier(level, snake.pList);
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

                            if (score / level == scoreDifficaltyLimit)
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
                ConsoleKeyInfo keyExit;
                do
                {
                    keyExit = Console.ReadKey();

                    if (keyExit.Key == ConsoleKey.Y)
                        flag = true;
                    else if (keyExit.Key == ConsoleKey.N)
                        flag = false;
                } while (keyExit.Key != ConsoleKey.Y && keyExit.Key != ConsoleKey.N);
                
                #endregion 
            }
        }
    }
}
