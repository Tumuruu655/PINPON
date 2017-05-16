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
        public string keyInfo;
        private const string RIGHT = "right", LEFT = "left";
        private Display display;
        public Keyboard()
        {
              key = new ConsoleKeyInfo();
              display = new Display(); 
        }
        public void ReadKey()
        {
            bool isEnter = false;
            while (!isEnter)
            {
                if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    display.pauseClear();
                    isEnter = true;
                }
            }
        }
        public void check()
        {
            if (Console.KeyAvailable)
            {
                key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        keyInfo = "left";
                        break;
                    case ConsoleKey.RightArrow:
                        keyInfo = "right";
                        break;
                    
                    case ConsoleKey.Escape:
                        display.pauseWrite();
                        bool isEscape=false;
                        while (!isEscape)
                        {
                            if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                            {
                                display.pauseClear();
                                isEscape=true;
                            }
                        }
                        break;
                }
            }
            else
            {
                keyInfo = "null";
            }
        }
    }
}
