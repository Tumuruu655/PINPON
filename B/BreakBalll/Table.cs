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
        private int rightMax;
        private int xpos, ypos;
        public Table(int posX, int posY, int mapWid)
        {
            for (int i = 0; i < body.Length; i++)
            {
                body[i] = '#';
            }
            rightMax = mapWid-2;
            this.xpos = posX/2-3;
            this.ypos = posY-2;
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
        public Boolean Move(int move)
        {
            if (move == -1)
            {
                if (xpos > 1)
                {
                    xpos--;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (move == 1)
            {
                if (xpos <= rightMax - body.Length)
                {
                    xpos++;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
                return false;
        }
    }
}