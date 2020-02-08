using System;
using System.Collections.Generic;
using System.Text;

namespace My_own_console_Snake
{
    class AdditionalBarrierCreator
    {
        private int windowWidth;
        private int windowHeight;
        private char sym;
        private int indentForAdditionalField;
        Random random = new Random();

        public AdditionalBarrierCreator(int windowWidth, int windowHeight, char sym, int indentForAdditionalField)
        {
            this.windowWidth = windowWidth;
            this.windowHeight = windowHeight;
            this.sym = sym;
            this.indentForAdditionalField = indentForAdditionalField;
        }

        internal Figure CreateAdditionalBarrier(int level, List<Point> snakePList)
        {

            /*List<Figure> fList = new List<Figure>() { new Figure(), new Figure()}; // creation of 2 parts of AdditionalBarrier
            int length = 5;

            for(int i = 0; i < fList.Count; i++)
            {
                bool flag = true;
                while (flag)
                {
                    int x = random.Next(2, windowWidth - 2);
                    int y = random.Next(2 + indentForAdditionalField, windowHeight - 1);
                    Point p = new Point(x, y, sym);

                    for (int j = 0; j < length; j++)
                    {
                        fList[i].pList.Add(new Point(x + j, y, '#'));
                    }

                    for (int j = 0; i <= pListSnake.Count - 1; i++)
                    {
                        if (fList[i].pList[j] .IsHit(food))
                        {
                            flagSnake = true;
                            break;
                        }
                        else
                            flagSnake = false;
                    }
                }
                
            }*/
            Figure additionalBarrier = new Figure();

            if (level == 1)
            {
                // Создание дополнительного препятствия для Уровня 1
                additionalBarrier.pList.Add(new Point(0, indentForAdditionalField, sym));
            }
            else if (level == 2)
            {
                // Создание дополнительного препятствия для Уровня 2
                for (int i = windowWidth / 8 * 3; i <= windowWidth / 8 * 5; i++)
                {
                    additionalBarrier.pList.Add(new Point(i, 7 + indentForAdditionalField, sym));
                }
                for (int i = windowWidth / 8 * 3; i <= windowWidth / 8 * 5; i++)
                {
                    additionalBarrier.pList.Add(new Point(i, windowHeight - 8, sym));
                }
            }
            else if(level > 2)
            {
                // Создание дополнительного препятствия для Уровня 3 и далее
                //additionalBarrier.pList.Add(new Point(10, 10, sym));          // заглушка

                for(int i = 0; i < 10;)
                {
                    int x = random.Next(2, windowWidth - 2);
                    int y = random.Next(2 + indentForAdditionalField, windowHeight - 1);
                    Point newPoint = new Point(x, y, sym);
                    if (x != 4)
                    {
                        additionalBarrier.pList.Add(newPoint);
                        i++;
                    }
                }
            }
            return additionalBarrier;
        }
    }
}
