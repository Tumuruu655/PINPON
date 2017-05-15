using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakBalll
{
    class Table
    {
        private char[] body = new char[6];
        public Keyboard key = new Keyboard();
        private Display dis = new Display();
        private int rightMax;
        private int xpos, ypos;
        public Table(int posX, int posY, int mapWid)
        {
            for (int i = 0; i < body.Length; i++)
            {
                body[i] = '#';
            }
            rightMax = mapWid - 2;
            this.xpos = posX / 2 - 3;
            this.ypos = posY - 2;
        }
        public void Move()
        {
            key.check();
            if (key.direction == "left")
            {
                if (xpos > 1)
                {
                    dis.clearTable(xpos, ypos);
                    xpos--;
                    Map.body[ypos, xpos + 6] = ' ';
                    Map.body[ypos, xpos] = body[0];
                    dis.drawTable(xpos, ypos);
                }
            }
            else if (key.direction == "right")
            {
                if (xpos <= rightMax - body.Length)
                {
                    dis.clearTable(xpos, ypos);
                    xpos++;
                    Map.body[ypos, xpos - 1] = ' ';
                    Map.body[ypos, xpos + 5] = '#';
                    dis.drawTable(xpos, ypos);
                }
            }

        }
        public int XPOS
        {
            get { return xpos; }
            set { this.xpos = value; }
        }
        public int YPOS
        {
            get { return ypos; }
            set { this.ypos = value; }
        }
        public char[] BODY
        {
            get { return body; }
            set { this.body = value; }
        }
    }
}
