using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BreakBalll
{
    class Block
    {
        private char[,] blocks;
        private int blockNum = 0;
        public Block(StreamReader file)
        {
            String line;
            line = file.ReadLine();
            int counter = 0;
            String[] sizes = new String[2];
            sizes = line.Split(',');
            blocks = new char[Int32.Parse(sizes[0]), Int32.Parse(sizes[1])];
            char[] temp = new char[Int32.Parse(sizes[1])];
            while ((line = file.ReadLine()) != null)
            {
                temp = line.ToCharArray();
                for (int i = 0; i < blocks.GetLength(1); i++)
                {
                    if (temp[i] == '=')
                        blockNum++;
                    blocks[counter, i] = temp[i];
                }
                counter++;
            }
        }
        public void deletBlock(int xPos, int yPos)
        {
            blocks[yPos-1, xPos-1] = ' ';
            blockNum--;
        }
        public char[,] Blocks
        {
            get { return blocks; }
            set { this.blocks = value; }
        }
        public int BlockNum
        {
            get { return blockNum; }
            set { this.blockNum = value; }
        }
    }
}
