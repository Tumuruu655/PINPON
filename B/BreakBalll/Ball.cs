using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakBalll
{
    class Ball
    {
        private char body ;
        private int xpos, ypos;
        private int[] oldLoc=new int [2];
        public Ball()
        { body = '*'; }
        public Ball(int x, int y)
        {
            body = '*';
            this.xpos = x/2;
            this.ypos = y-3;
            oldLoc[0] = xpos;
            oldLoc[1] = ypos;
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
        public void Move(int xmove, int ymove)
        {
            oldLoc[0] = xpos;
            oldLoc[1] = ypos;
            xpos = xpos + xmove;
            ypos = ypos + ymove;
        }
    }
}
