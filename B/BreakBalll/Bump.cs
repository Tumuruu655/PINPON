using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BreakBalll
{
    class Bump
    {
        private Keyboard keyboard=new Keyboard();
        private Map map;
        private Ball ball;
        private Table table;
        private Display dis;
        private int HEIGHT, WIDTH;
        private int blockNum = 0;
        private int heart=2;
        public Bump(String start)
        {   
            map = new Map();
            HEIGHT = Map.body.GetLength(0);
            WIDTH = Map.body.GetLength(1);
            blockNum = map.Block.BlockNum;
            ball = new Ball(WIDTH, HEIGHT);
            table = new Table(WIDTH, HEIGHT, WIDTH);
            dis = new Display();
            dis.drawMap();
            for (int i = 0; i < table.BODY.Length; i++)
            {
                Map.body[table.YPOS, i + table.XPOS] = table.BODY[i];
            }
            Map.body[ball.Ypos, ball.Xpos] = ball.Body;
            dis.drawTable(table.XPOS, table.YPOS);
            Thread.Sleep(100);
            dis.showLife(heart);
            dis.showScore(0);
           // blockNum = 2;
            ehleh();
            for (int i=heart ; 0 < i; i--)
            {
                //Console.ReadKey(true);
                keyboard.ReadKey();
                ball.Xpos = table.XPOS + 2;
                ball.Ypos = table.YPOS - 1;
                ehleh();
            }
            dis.gameover(WIDTH/3, HEIGHT/2);
            keyboard.ReadKey();
            Console.WriteLine();
            for (int i = 0; i < Map.body.GetLength(0); i++)
            {
                for (int j = 0; j < Map.body.GetLength(1); j++)
                {
                    Console.Write(Map.body[i,j]);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
                
        }

        private void ehleh()
        {
            Boolean dead = false;
            while (dead != true)
            {
                checkBump();
                table.Move();
                Thread.Sleep(50);
                table.Move();
                ball.Move();
                Thread.Sleep(50);
                table.Move();
                dead = ball.dead();
                if (map.Block.BlockNum < 0)
                {
                    dis.clearBall(ball.Xpos, ball.Ypos);
                    livelWon();
                    
                }
            }
            heart--;
            dis.showLife(heart);
        }
        public void livelWon()
        {
            map.setBlock();
            dis.drawMap();
            keyboard.ReadKey();
            ball.Xpos = table.XPOS + 2;
            ball.Ypos = table.YPOS - 1;
        }
        public void checkBump()
        {
            if (blockNum == 0)
            {
                Console.ReadKey();
            }
            if (checkDirection('X'))
            {
                ball.MoveDirectionX = -1 * ball.MoveDirectionX;
                if (checkDirection('Y'))
                    ball.MoveDirectionY = -1 * ball.MoveDirectionY;
            }
            else if (checkDirection('Y'))
            {
                ball.MoveDirectionY = -1 * ball.MoveDirectionY;
                if (checkDirection('X'))
                    ball.MoveDirectionX = -1 * ball.MoveDirectionX;
            }
            else if (Map.body[ball.Ypos + ball.MoveDirectionY, ball.Xpos + ball.MoveDirectionX] != ' ')
            {
                checkBlockBump(ball.Xpos + ball.MoveDirectionX, ball.Ypos + ball.MoveDirectionY);
                ball.MoveDirectionX = -1 * ball.MoveDirectionX;
                ball.MoveDirectionY = -1 * ball.MoveDirectionY;
            }
        }
        private bool checkDirection(char Direction)
        {
            if (Direction == 'X')
            {
                if(Map.body[ball.Ypos, ball.Xpos + ball.MoveDirectionX] != ' ')
                {
                    checkBlockBump(ball.Xpos + ball.MoveDirectionX, ball.Ypos);
                    return true;
                }
            }
            else if (Direction == 'Y')
            {
                if (Map.body[ball.Ypos + ball.MoveDirectionY, ball.Xpos] != ' ')
                {
                    checkBlockBump(ball.Xpos, ball.Ypos + ball.MoveDirectionY);
                    return true;
                }   
            }
            return false;
        }
        private void checkBlockBump(int posX, int posY)
        {
            if (Map.body[posY, posX] == map.Block.body)
            {
                Map.body[posY, posX] = ' ';
                map.Block.deletBlock(posX, posY);
              //  dis.showScore(map.Block.Score);
            }
        }

    }
}

