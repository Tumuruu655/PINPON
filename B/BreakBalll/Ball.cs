using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakBalll
{
    class Ball
    {
        private char body;
        private Display display;
        private int xpos, ypos, deadY;
        private int moveDirectionX, moveDirectionY; 
        private int[] oldLoc = new int[2];
        public Ball(int x, int y)
        {
            display = new Display();
            moveDirectionX = 1;
            moveDirectionY = -1;
            deadY = y - 2;
            body = '*';
            this.xpos = x / 2;
            this.ypos = y - 3;
            oldLoc[0] = xpos;
            oldLoc[1] = ypos;
            Map.body[ypos, xpos] = '#';
        }
        public void Move()
        {
            oldLoc[0] = xpos;
            oldLoc[1] = ypos;
            display.clearBall(xpos, ypos);
            Map.body[oldLoc[1], oldLoc[0]] = ' ';
            xpos = xpos + moveDirectionX;
            ypos = ypos + moveDirectionY;
            Map.body[ypos, xpos] = body;
            display.drawBall(Xpos, ypos, body);
        }
        public Boolean dead()
        {
            if (ypos >= deadY)
            {
                display.clearBall(xpos, ypos);

                Map.body[ypos, xpos] = ' ';
                return true;
            }
            else
            {
                return false;
            }
        }
        public int[] OLDLOC
        {
            get { return oldLoc; }
            set { this.oldLoc = value; }
        }
        public int Xpos
        {
            get { return xpos; }
            set { this.xpos = value; }
        }
        public int Ypos
        {
            get { return ypos; }
            set { this.ypos = value; }
        }
        public char Body
        {
            get { return body; }
            set { this.body = value; }
        }
        public int MoveDirectionX
        {
            get { return moveDirectionX; }
            set { this.moveDirectionX = value; }
        }
        public int MoveDirectionY
        {
            get { return moveDirectionY; }
            set { this.moveDirectionY = value; }
        }
    }
}
