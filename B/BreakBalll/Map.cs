using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BreakBalll
{
    class Map
    {
        private const int HEIGHT=20, WIDTH = 24;
        public static char[,] body = new char[HEIGHT, WIDTH];
        private Block[] blocks = new Block[2];
        private Block block;
        private Display ds = new Display();
        private int blockNumber=-1;
        private int[] change=new int[2];
        public Map()
        {
            readBlocks();
            for (int i = 0; i < HEIGHT; i++)
            {
                for (int j = 0; j < WIDTH; j++)
                {
                    if (i == 0 || j == 0 || i == HEIGHT - 1 || j == WIDTH - 1)
                    {
                        body[i, j] = '1';// 1 - saad, hana
                    }
                    else
                        body[i, j] = ' ';
                }
            }
            setBlock();
        }
        private void readBlocks()
        {
            for (int i = 0; i < blocks.Length; i++)
            {
                StreamReader file1 = new StreamReader(@"C:\Users\Nandinbayr-pc\Documents\GitHub\PINPON\B\Blocks\block" + i + ".txt");
                blocks[i] = new Block(file1);
            }
        }
        public void setBlock()
        {
            try
            {
                blockNumber++;
                block = blocks[blockNumber];
                for (int i = 0; i < block.Blocks.GetLength(0); i++)
                {
                    for (int j = 0; j < block.Blocks.GetLength(1); j++)
                    {
                        body[i + 1, j + 1] = block.Blocks[i, j];
                    }
                }
            }
            catch(IndexOutOfRangeException ex){
                ds.won();
            }
        }
        public Block Block
        {
            get { return block; }
            set { this.block = value; }
        }
    }
}

