using System;

namespace My_own_console_Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int windowWidth = 80;
            int windowHeight = 25;
            Console.SetWindowSize(1, 1);
            Console.SetBufferSize(windowWidth, windowHeight);
            Console.SetWindowSize(windowWidth, windowHeight);

            Border border = new Border(windowWidth, windowHeight, '#');
            border.Draw();
            

            Console.ReadLine();
        }
    }
}
