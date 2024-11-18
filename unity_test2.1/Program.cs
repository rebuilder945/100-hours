using System;

namespace unity_test2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "100小时!";            
            while(true)
            {
                manager M = new manager();
                M.InitProcess();
                M.start();            
                M.process();
                M.End();
            }
        }
    }
}
