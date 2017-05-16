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
        public void drawMap()
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < Map.body.GetLength(0); i++)
            {
                for (int j = 0; j < Map.body.GetLength(1); j++)
                {
                    Console.Write(Map.body[i, j]);
                }
                Console.WriteLine();
            }
        }
        public void showLife(int life)
        {
            Console.SetCursorPosition(Map.body.GetLength(1)+5, 1);
            Console.Write("Life: "+life);
        }
        public void showScore(int score)
        {
            Console.SetCursorPosition(Map.body.GetLength(1) +5, 4);
            Console.Write("Score: " + score);
        }
        public void drawBall(int xPos, int yPos, char temd)
        {
            Console.SetCursorPosition(xPos, yPos);
            Console.Write(temd);
        }
        public void won() {
            Console.SetCursorPosition(Map.body.GetLength(1) / 2, Map.body.GetLength(0) + 2);
            Console.WriteLine("Ta hojloo");
        }
        public void clearBall(int xPos, int yPos)
        {
            Map.body[yPos,xPos]=' ';
            Console.SetCursorPosition(xPos, yPos);
            Console.Write(' ');
        }
        public void drawTable(int xPos, int yPos)
        {
            Console.SetCursorPosition(xPos, yPos);
            Console.Write("######");
        }
        public void clearTable(int xPos, int yPos)
        {
            Console.SetCursorPosition(xPos, yPos);
            Console.Write("      ");
        }
        public void pauseWrite()
        {
            Console.SetCursorPosition(Map.body.GetLength(1) / 2 - 5, Map.body.GetLength(0)+1);
            Console.Write("pause");
        }
        public void pauseClear()
        {
            Console.SetCursorPosition(Map.body.GetLength(1) / 2 - 5, Map.body.GetLength(0)+1);
            Console.Write("     ");
        }
        public void gameover(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("gameover");
        }
    }
}
