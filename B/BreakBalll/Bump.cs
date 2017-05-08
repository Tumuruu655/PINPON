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
        private ConsoleKeyInfo key = new ConsoleKeyInfo();
        private int[] move = new int[2];
        private int HEIGHT, WIDTH;
        private int blockNum = 0;
        public Bump(String start)
        {
            map = new Map();
            HEIGHT = map.BODY.GetLength(0);
            WIDTH = map.BODY.GetLength(1);
            blockNum = map.Block.BlockNum;
            ball = new Ball(WIDTH, HEIGHT);
            table = new Table(WIDTH , HEIGHT, WIDTH);
            dis = new Display();
            dis.drawMap(map.BODY);
            for (int i = 0; i < table.BODY.Length; i++)
            {
                map.BODY[table.YPOS, i + table.XPOS] = table.BODY[i];
            }
            map.BODY[ball.Ypos, ball.Xpos] = ball.Body;
            dis.drawTable(table.XPOS, table.YPOS);
            dis.drawBall(ball.Xpos, ball.Ypos, ball.Body);
            move[0] = 1;
            move[1] = -1;
            ehleh();
            Console.ReadKey();
        }

        public void ehleh()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.LeftArrow:
                            if (table.Move(-1))
                            {
                                map.BODY[table.YPOS, table.XPOS + 6] = ' ';
                                dis.clear(table.XPOS + 6, table.YPOS);
                                map.BODY[table.YPOS, table.XPOS] = '#';
                                dis.drawBall(table.XPOS, table.YPOS, table.BODY[0]);
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (table.Move(1))
                            {
                                map.BODY[table.YPOS, table.XPOS-1] = ' ';
                                dis.clear(table.XPOS-1, table.YPOS);
                                map.BODY[table.YPOS, table.XPOS + 5] = '#';
                                dis.drawBall(table.XPOS + 5, table.YPOS, table.BODY[0]);
                            }
                            break;
                        case ConsoleKey.Escape:
                            Console.WriteLine("pause");
                            Console.ReadKey(true);
                            break;
                    }
                }
                move = cbump(move, map.BODY, ball.Xpos, ball.Ypos);
                dis.clear(ball.OLDLOC[0], ball.OLDLOC[1]);
                ball.Move(move[0], move[1]);
                map.BallMove(ball.OLDLOC[0], ball.OLDLOC[1], ball.Xpos, ball.Ypos, ball.Body);
                Thread.Sleep(100);
                dis.drawBall(ball.Xpos, ball.Ypos, ball.Body);
            }
        }
        public int[] cbump(int[] move, char[,] map, int posX, int posY)
        {
            if (blockNum==0)
            {
                Console.ReadKey();
            }
            if (posY == map.GetLength(1) - 2 && posX > 0 && posX < map.GetLength(0) - 2)
            {
                Console.ReadKey(true);
                int[] a = new int[2];
                return a;
            }
            if (map[posY, posX + move[0]] != ' ')
            {
                map = checkBump(map, posX + move[0], posY);
                move[0] = -1 * move[0];
                if (map[posY + move[1], posX] != ' ')
                {
                    map = checkBump(map, posX, posY + move[1]);
                    move[1] = -1 * move[1];
                }
            }
            else if (map[posY + move[1], posX] != ' ')
            {
                map = checkBump(map, posX, posY + move[1]);
                move[1] = -1 * move[1];
                if (map[posY, posX + move[0]] != ' ')
                {
                    map = checkBump(map, posX + move[0], posY);
                    move[1] = -1 * move[1];
                }
            }
            else if (map[posY + move[1], posX + move[0]] != ' ')
            {
                map = checkBump(map, posX + move[0], posY + move[1]);
                move[0] = -1 * move[0];
                move[1] = -1 * move[1];
            }
            return move;
        }
        private char[,] checkBump(char[,] map1, int posX, int posY)
        {
            if (map1[posY, posX] == '=')
            {
                map1[posY, posX] = ' ';
                map.Block.deletBlock(posX, posY);
                dis.clear(posX, posY);
                return map1;
            }
            else if (map1[posY, posX] == '*')
            {
                return map1;
            }
            else
                return map1;
        }
    }
}
