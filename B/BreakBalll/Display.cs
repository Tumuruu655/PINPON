using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakBalll
{
    class Display
    {
        public Display()
        {
            Console.CursorVisible = false;
        }
        public void drawMap(Char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }
        public void drawBall(int xPos, int yPos, char temd)
        {
            Console.SetCursorPosition(xPos, yPos);
            Console.Write(temd);
        }
        public void clear(int xPos, int yPos)
        {
            Console.SetCursorPosition(xPos, yPos);
            Console.Write(' ');
        }
        public void drawTable(int xPos, int yPos)
        {
            Console.SetCursorPosition(xPos, yPos);
            Console.Write("######");
        }
    }
}
