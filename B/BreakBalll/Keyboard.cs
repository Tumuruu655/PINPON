using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakBalll
{
    class Keyboard
    {
        private ConsoleKeyInfo key;
        public string direction;
        public Keyboard()
        {
              key = new ConsoleKeyInfo();
        }
        public void check()
        {
            if (Console.KeyAvailable)
            {
                key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        direction = "left";
                        break;
                    case ConsoleKey.RightArrow:
                        direction = "right";
                        break;
                    case ConsoleKey.Escape:
                        Console.WriteLine("pause");
                        Console.ReadKey(true);
                        break;
                }
            }
            else
            {
                direction = "null";
            }
        }
    }
}
