using System;
using System.Collections.Generic;
using System.Text;

namespace unity_test2._1
{
    public class common//本来想写个通用类 但后来弃用了
    {
        public void print(int left0, int top0, int to, string z, int flag)//按行或按列指定位置打印分界线
        {
            int i, left, top;
            if (flag == 1)
            {
                left = i = left0;
                top = top0;
            }
            else
            {
                top = i = top0;
                left = left0;
            }
            while (i < to)
            {
                Console.SetCursorPosition(flag == 1 ? i : left, flag == 0 ? i : top);
                Console.Write(z);
                i++;
            }
        }      
    }

    class text//图形页面框架类
    {
        
        common Common = new common();
        public void print_structure()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BufferWidth = 150;
            Console.WindowWidth = 80;
            Console.WindowHeight = 50;
            int width = Console.WindowWidth;
            int height = Console.WindowHeight;
            Common.print(0, 0,width,"=", 1);
            Common.print(width/2-1, 1, height-1, "||", 0);
            Common.print(0, height/2-1, width, "=", 1);
            Common.print(0, height-1, width, "=", 1);
        }
    }
}
