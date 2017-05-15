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
        private Map map;
        private Ball ball;
        private Table table;
        private Display dis;
        private int HEIGHT, WIDTH;
        private int blockNum = 0;
        private int heart=3;
        public Bump(String start)
        {   
            map = new Map();
            HEIGHT = Map.body.GetLength(0);
            WIDTH = Map.body.GetLength(1);
            blockNum = map.Block.BlockNum;
            ball = new Ball(WIDTH, HEIGHT);
            table = new Table(WIDTH, HEIGHT, WIDTH);
            dis = new Display();
            dis.drawMap(Map.body);
            for (int i = 0; i < table.BODY.Length; i++)
            {
                Map.body[table.YPOS, i + table.XPOS] = table.BODY[i];
            }
            Map.body[ball.Ypos, ball.Xpos] = ball.Body;
            dis.drawTable(table.XPOS, table.YPOS);
            Thread.Sleep(100);
            ehleh();
            for (int i=heart ; 0 < i; i--)
            {
                Console.ReadKey();
                map.BallMove(ball.Xpos, ball.Ypos, table.XPOS + 2, table.YPOS - 1, ball.Body);
                ball.Xpos = table.XPOS + 2;
                ball.Ypos = table.YPOS - 1;
                ehleh();
            }
            dis.gameover(WIDTH/3, HEIGHT/2);

                Console.ReadKey();
        }

        private void ehleh()
        {
            Boolean dead = false;
            while (dead != true)
            {
                checkBump();
                table.Move();
                ball.Move();
                Thread.Sleep(100);
                dead = ball.dead();
            }
            heart--;
        }
        public void checkBump()
        {
            if (blockNum == 0)
            {
                Console.ReadKey();
            }
            if (Map.body[ball.Ypos, ball.Xpos + ball.MoveDirectionX] != ' ')
            {
                checkBlockBump(ball.Xpos + ball.MoveDirectionX, ball.Ypos);
                ball.MoveDirectionX = -1 * ball.MoveDirectionX;
                if (Map.body[ball.Ypos + ball.MoveDirectionY, ball.Xpos] != ' ')
                {
                    checkBlockBump(ball.Xpos, ball.Ypos + ball.MoveDirectionY);
                    ball.MoveDirectionY = -1 * ball.MoveDirectionY;
                }
            }
            else if (Map.body[ball.Ypos + ball.MoveDirectionY, ball.Xpos] != ' ')
            {
                checkBlockBump(ball.Xpos, ball.Ypos + ball.MoveDirectionY);
                ball.MoveDirectionY = -1 * ball.MoveDirectionY;
                if (Map.body[ball.Ypos, ball.Xpos + ball.MoveDirectionX] != ' ')
                {
                    checkBlockBump(ball.Xpos + ball.MoveDirectionX, ball.Ypos);
                    ball.MoveDirectionY = -1 * ball.MoveDirectionY;
                }
            }
            else if (Map.body[ball.Ypos + ball.MoveDirectionY, ball.Xpos + ball.MoveDirectionX] != ' ')
            {
                checkBlockBump(ball.Xpos + ball.MoveDirectionX, ball.Ypos + ball.MoveDirectionY);
                ball.MoveDirectionX = -1 * ball.MoveDirectionX;
                ball.MoveDirectionY = -1 * ball.MoveDirectionY;
            }
        }
        private void checkBlockBump(int posX, int posY)
        {
            if (Map.body[posY, posX] == '=')
            {
                Map.body[posY, posX] = ' ';
                map.Block.deletBlock(posX, posY);
            }
        }

    }
}
