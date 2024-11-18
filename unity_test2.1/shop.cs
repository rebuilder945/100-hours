using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace unity_test2._1
{
    public class item//商店物品
    {       
        private int num;
        private int price;
        private int reserve;
        private string name;
        private string description;
        public item() { }
        public item(int o,int x,int y,string z,string p) {
            num = o;
            price = x;
            reserve = y;
            name = z;
            description = p;
        }
        public void display()
        {
            Console.WriteLine(num +"  "+name + ": " + price + ' '+ reserve+' '+description);
        }
        public int buy(int n,player A)
        {
            int width = Console.WindowWidth;
            int height = Console.WindowHeight;
            int top = Console.CursorTop;
            long money = A.GetMoney();
            if (money-n*price<0)
            {
                Console.WriteLine("金币不足！");
                return 1;
            }            
            if (reserve - n < 0)
            {
                Console.WriteLine("库存不足！");
                return 1;
            }
            else
            {
                reserve -= n;
                A.MoneyChange(n * price,-1);
                Console.SetCursorPosition((int)(width * 0.5)+1, (int)(height * 0.55) + 1);
                Console.WriteLine(DateTime.Now.ToString()+"{0}购买了{1}x{2}", A.GetName(), this.name, n);              
                Console.SetCursorPosition(0, top);
                return 0;
            }          
        }
        public void store_in()
        {

        }
    }
    public class shop//商店类
    {        
        public List<item> items = new List<item>();
       
        public shop()
        {
            items.Add(new item());//垫底一个无意义的物品，使得物品从1开始编号
            items.Add(new item(1, 50, 100, "泡面","能让你活下去!"));
            items.Add(new item(2, 100000, 100, "车","走得更快!"));
            items.Add(new item(3, 1000000, 100, "房","有个温馨的家?"));
            items.Add(new item(4, 100, 100,"牙膏", "清洁牙齿"));
            items.Add(new item(5, 3000, 100, "自行车", "载着自己去兜风~"));
            items.Add(new item(6, 10000, 100, "自动赚钱机", "1000元/0.5h~"));
        }
        public int buy(int s,int n,player A)
        {
            return items[s].buy(n,A);
        }
        public void display()
        {
            int width = Console.WindowWidth;
            int height = Console.WindowHeight;
            Console.SetCursorPosition((int)(width * 0.7),2);
            Console.WriteLine("交易：");
            Console.WriteLine();
            Console.SetCursorPosition((int)(width * 0.59), 5);
            Console.WriteLine("编号 物品 价格 库存 描述");
            int n = items.Count;
            int x = 5;
            for(int i=1;i<n;i++)
            {
                Console.SetCursorPosition((int)(width * 0.55), x+=2);
                items[i].display();
            }      
        }        
    }

    


}
