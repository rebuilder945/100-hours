using System;
using System.Collections.Generic;
using System.Text;

namespace unity_test2._1
{
    public class story//剧情类
    {      
        public void display()
        {
            int width = Console.WindowWidth;
            int height = Console.WindowHeight;
            Console.SetCursorPosition((int)(width * 0.7), (int)(height * 0.55)-1);
            Console.WriteLine("对话：");
        }
        public void DisplayStory(player A)//打印开头剧情
        {
            int width = Console.WindowWidth;
            int height = Console.WindowHeight;
            double Time = A.GetTime();
            int W = (int)(width * 0.3);
            double M = 0.2;
            if (Time == 0)
            {                
                Console.SetCursorPosition(W, (int)(height *M )+1);                
                Console.WriteLine("你站在大街上,头晕眼花");
                Console.SetCursorPosition(W, (int)(height * M) + 3);
                Console.WriteLine("仿佛昨天有100个小时");
                Console.SetCursorPosition(W, (int)(height * M) + 5);
                Console.WriteLine("周围都是人,下着小雨...");
                System.Threading.Thread.Sleep(1000*2);
                Console.SetCursorPosition(W, (int)(height * M) + 7);
                Console.WriteLine("你知道你在做梦，但你还不想醒来");
                Console.SetCursorPosition(W, (int)(height * M) + 9);
                Console.WriteLine("你身上有一些钱,会是谁留下的呢...");               
                Console.SetCursorPosition(W, (int)(height * M) + 11);
                Console.WriteLine("或许可以用它来买点什么");
                System.Threading.Thread.Sleep(1000*2);
                Console.SetCursorPosition(W, (int)(height * M) + 13);
                Console.WriteLine("在接下来的最多100小时里");
                Console.SetCursorPosition(W, (int)(height * M) + 15);
                Console.WriteLine("你的每一步操作将花费半小时与10点体力噢∑( 口 ||");
                Console.SetCursorPosition(W, (int)(height * M) + 17);
                Console.WriteLine("步步惊心说的就是这儿呢");
                Console.SetCursorPosition(W, (int)(height * M) + 19);
                Console.WriteLine("所以——准备好了开始了吗？");
                Console.SetCursorPosition(W, (int)(height * M) + 21);                
            }
            if (Time == 18)
            {
                Console.SetCursorPosition(W, (int)(height * M) + 1);
                Console.WriteLine("18小时这个点好特别耶...");
                Console.SetCursorPosition(W, (int)(height * M) + 3);                
            }
            if (Time == 25)
            {
                Console.SetCursorPosition(W, (int)(height * M) + 1);
                if (A.GetSingle()) Console.WriteLine("该结婚了耶");
                else Console.WriteLine("快生个孩子吧");
                Console.SetCursorPosition(W, (int)(height * M) + 3);                
            }
        }       
        public void AnyPrint(string x,int y)//在剧情框任意位置打印任意内容
        {
            int top = Console.CursorTop;
            int width = Console.WindowWidth;
            int height = Console.WindowHeight;
            Console.SetCursorPosition((int)(width * 0.5) + 1, (int)(height * 0.55) + y);
            Console.WriteLine(x);
            Console.SetCursorPosition(0, top);
        }
    }
}
