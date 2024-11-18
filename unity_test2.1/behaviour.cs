using System;
using System.Collections.Generic;
using System.Text;

namespace unity_test2._1
{
    class behaviour//操作类
    {       
        public void display()
        {
            int width = Console.WindowWidth;
            int height = Console.WindowHeight;
            Console.SetCursorPosition((int)(width * 0.2), (int)(height * 0.55)-1);
            Console.WriteLine("行动：");
            Console.SetCursorPosition((int)(width * 0.2) - 8, (int)(height * 0.55) + 1);
            Console.WriteLine("(输入行动编号以进行)");
            Console.SetCursorPosition((int)(width * 0.2) - 1, (int)(height * 0.55)+2);
            Console.WriteLine("0 交易");
            Console.SetCursorPosition((int)(width * 0.2) - 1, (int)(height * 0.55) + 3);
            Console.WriteLine("1 使用物品");
            Console.SetCursorPosition((int)(width * 0.2) - 1, (int)(height * 0.55) + 4);
            Console.WriteLine("2 结识朋友");
            Console.SetCursorPosition((int)(width * 0.2) - 1, (int)(height * 0.55) + 5);
            Console.WriteLine("3 赌场");
            Console.SetCursorPosition((int)(width * 0.2) - 1, (int)(height * 0.55) + 6);
            Console.WriteLine("4 询问");
            Console.SetCursorPosition((int)(width * 0.2) - 1, (int)(height * 0.55) + 7);
            Console.WriteLine("5 向Ta求婚");
        }
    }
}
