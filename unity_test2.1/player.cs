using System;
using System.Collections.Generic;
using System.Text;

namespace unity_test2._1
{
    public class Connections//人脉
    {
        string Name;
        string Sex;
        string Relation="普通朋友";
        public Connections(string x, string y)
        {
            Sex = x;
            Name = y;
        }
        public string GetName()
        {
            return Name;
        }
        public void RelationChange(string x)
        {
            Relation = x;
        }
        public void Display()
        {
            Console.WriteLine(Name + ' ' + Sex+' '+Relation);
        }
    }
    public class good//物品 父类
    {
        protected string name;
        protected int num=0;
        protected int order;
        public good() { }
        public void NumPlus(int x)
        {
            num += x;
        }
        public string GetName()
        {
            return name;
        }
        public good(string x,int y,int z)
        {
            name = x;
            num = y;
            order = z;
        }
        public bool Num()
        {
            return num != 0;
        }
        public virtual void Use(player A,story S){
        }
        public void display()
        {
            Console.WriteLine(order+" "+name + " x" + num);
        }        
    }
    //////////物品 派生类
    public class InstantNoodles : good
    {
        public InstantNoodles(string x, int y, int z)
        {
            name = x;
            num = y;
            order = z;
        }
        public override void Use(player A,story S)
        {
            if ((A.GetHp() + 40) <= 100)
            {
                S.AnyPrint(A.GetName() + ": 吃了泡面,现在你精神倍增!", 1);
                A.HpChange(50, 1);
                num--;
            }
            else
            {
                A.HpChange(10, 1);
                S.AnyPrint("体力超上限100啦!!", 1);
            }
        }
    }
    public class Car : good
    {
        public Car(string x, int y, int z)
        {
            name = x;
            num = y;
            order = z;
        }
        public override void Use(player A,story S)
        {
            S.AnyPrint("确定要卖掉一辆车吗?",1);
            S.AnyPrint("1.卖掉(成交价50000) 2.还是算了吧", 2);            
            ConsoleKeyInfo cki = Console.ReadKey();
            Console.WriteLine();
            if (cki.Key != ConsoleKey.D1 && cki.Key != ConsoleKey.D2)
            {
                S.AnyPrint("输入不规范呢~请重新输入",4);                
            }
            else if (cki.Key == ConsoleKey.D1)
            {
                num--;
                int money = new Random().Next(10000, 50000);
                A.MoneyChange(money, 1);
                S.AnyPrint(A.GetName() + ": 你卖掉了你的一辆车,共收回"+money+"元",4);
                S.AnyPrint("买卖中介: 欢迎下次再来噢~嘿嘿", 6);
            }          
            else S.AnyPrint("买卖中介: 欢迎下次再来噢~嘿嘿", 4);
        }
    }
    public class House : good
    {
        public House(string x, int y, int z)
        {
            name = x;
            num = y;
            order = z;
        }        
        public override void Use(player A,story S)
        {
            S.AnyPrint("确定要卖掉一套房吗?", 1);
            S.AnyPrint("1.卖掉(成交价500000) 2.还是算了吧", 2);
            ConsoleKeyInfo cki = Console.ReadKey();
            Console.WriteLine();
            if (cki.Key != ConsoleKey.D1 && cki.Key != ConsoleKey.D2)
            {
                S.AnyPrint("输入不规范呢~请重新输入", 4);
            }
            else if (cki.Key == ConsoleKey.D1)
            {
                num--;
                int money = new Random().Next(100000, 500000);
                A.MoneyChange(money, 1);
                S.AnyPrint(A.GetName() + ": 你卖掉了你的一套房,共收回"+money+"元", 4);
                S.AnyPrint("买卖中介: 欢迎下次再来噢~嘿嘿", 6);
            }
            else S.AnyPrint("买卖中介: 欢迎下次再来噢~嘿嘿", 4);
        }
    }
    public class ToothPaste : good
    {
        public ToothPaste(string x, int y, int z)
        {
            name = x;
            num = y;
            order = z;
        }
        public override void Use(player A,story S)
        {
            num--;
            S.AnyPrint(A.GetName() + ": 使用了牙膏,你感到很愉悦!",1);
        }
    }
    public class Tip : good
    {
        string[] Tips = new string[6]
        {
            "2019/12/2 EDW购买了泡面x2",
            "2019/11/28 购买了车x1",
            "2019/11/27 CQC购买了泡面x10",
            "打破这个循环，我就会回到现实",
            "但我不愿那样做...",
            "快回来！"
        };
        int i = 0;
        public Tip(string x, int y, int z)
        {
            name = x;
            num = y;
            order = z;
        }
        public override void Use(player A,story S)
        {            
            if (i < 6)
            {
                S.AnyPrint("上面写着:"+'"'+Tips[i]+'"',1);
                ++i;
            }
            else
            {
                i = 0;
                S.AnyPrint("上面写着:"+ '"' + Tips[i] + '"',1);
            }
        }  
    }
    public class Bycicle : good
    {
        public Bycicle(string x, int y, int z)
        {
            name = x;
            num = y;
            order = z;
        }
        public override void Use(player A, story S)
        {           
            S.AnyPrint(A.GetName() + ": 你在公路上狂飙~风人——就是你了!", 1);
        }
    }
    public class AutoMoney : good
    {
        public AutoMoney(string x, int y, int z)
        {
            name = x;
            num = y;
            order = z;
        }
        public override void Use(player A, story S)
        {            
            S.AnyPrint(A.GetName() + ": 你的 自动赚钱机 正努力赚钱呢", 1);
        }
    }
    public class player//玩家
    {
        public List<Connections> connections = new List<Connections>();
        int ConnectionsNum = 0;
        string[] Sex = new string[2] { "女", "男" };
        string[] ManName = new string[10] { "轩", "俊", "博", "逸", "煊", "明", "刚", "欧", "晨", "宇" };
        string[] FemaleName = new string[10] { "芹", "荷", "听", "之", "丹", "雅", "珍", "白", "莲", "芝" };
        private string name;
        private bool Single = true;
        private int TaNum;
        private int hp = 100;
        private double Time = 0;
        private string sex;        
        private int AutoNum=0;
        private bool Greened=false;
        private bool Divorced = false;
        private long money = 3000;
        private int i = 0;//物品编号变量

        public int GetAutoMoney()
        {
            return AutoNum;
        }
        public void AutoMoneyChange(int x)
        {
            AutoNum+=x;          
        }
        public void Green()
        {
            Greened = true;
        }
        public bool GetGreen()
        {
            return Greened;
        }
        public void Divorce()
        {
            Divorced = true;
        }
        public bool GetDivorce()
        {
            return Divorced;
        }
        public void TaNumChange(int x)
        {
            TaNum = x;
        }
        public int GetTaNum()
        {
            return TaNum;
        }
        public int GetConnectionsNum()
        {
            return ConnectionsNum;
        }
        public int GetHp()
        {
            return hp;
        }
        public void HpChange(int x, int y)
        {
            if (y == 1) hp += x;
            else hp -= x;
        }
        public int GetI()
        {
            return i;
        }
        public double GetTime()
        {
            return Time;
        }
        public void TimePlus()
        {
            Time+=0.5;
        }
        public bool GetSingle()
        {
            return Single;
        }
        public string GetSex()
        {
            return sex;
        }
        public string GetName()
        {
            return name;
        }
        public long GetMoney()
        {
            return money;
        }
        public void MoneyChange(int x,int y)
        {
            if (y == -1) money -= x;
            else money += x;
        }
        public bool CarFind()
        {
            for(int j=1;j<=i;j++)
            {
                if (goods[j].GetName() == "车"&&goods[j].Num()) return true;
            }
            return false;
        }
        public bool HouseFind()
        {
            for (int j = 1; j <= i; j++)
            {
                if (goods[j].GetName() == "房" && goods[j].Num()) return true;
            }
            return false;
        }
        public bool ToothPasteFind()
        {
            for (int j = 1; j <= i; j++)
            {
                if (goods[j].GetName() == "牙膏" && goods[j].Num()) return true;
            }
            return false; 
        }
        public void SingleChange(int x,int y)
        {
            if(y==1)
            {
                Single = false;
                connections[x].RelationChange("夫妻");   
            }
            else
            {
                Single = true;
                connections[x].RelationChange("前任");
            }
                       
        }

        public List<good> goods = new List<good>();//商品数组  
        
        public player() 
        {
            goods.Add(new good());//垫底一个无意义的物品，使得物品从1开始编号
        }
        public void PlayerInit(string x, int y)
        {
            name = x;
            if (y == 1) sex = "男";
            else sex = "女";
        }
        public void ConnectionsPlus(player A, story S)//最好能实现随机名字随机
        {
            if (Sex[new Random().Next(0, 2)] == "男")
            {
                connections.Add(new Connections("男", ManName[new Random().Next(0, 10)]));
            }
            else
            {
                connections.Add(new Connections("女", FemaleName[new Random().Next(0, 10)]));
            }
            int flag = new Random().Next(1, 1000);
            //string name = connections[ConnectionsNum];
            if (flag<500)
            {
                A.MoneyChange(300, -1);
                S.AnyPrint("你被刚交的朋友 "+ connections[ConnectionsNum].GetName()+" 骗了300元呜",1);
            }
            else
            {
                A.MoneyChange(500, 1);
                S.AnyPrint("你的好朋友 "+ connections[ConnectionsNum].GetName() + " 使你赚了500元耶",1);
            }
            ++ConnectionsNum;
        }
        public void display(player A)//角色属性打印
        {
            int width = Console.WindowWidth;
            int height = Console.WindowHeight;
            int left =1;
            int left1=(int)(width * 0.25);
            Console.SetCursorPosition(left1, 2);
            Console.WriteLine("人脉：");
            Console.SetCursorPosition(left, 2);       
            Console.WriteLine("昵称：{0}", name);            
            Console.SetCursorPosition(left, 4);
            Console.WriteLine("性别: {0}", sex);
            Console.SetCursorPosition(left, 6);
            Console.WriteLine("体力: {0}", hp);            
            Console.SetCursorPosition(left, 8);
            Console.WriteLine("金币: {0}", money);
            Console.SetCursorPosition(left, 10);
            string x = (Single == true ? "是" : "否");
            Console.WriteLine("单身：{0}", x);
            Console.SetCursorPosition(left, 12);
            Console.WriteLine("时间: {0} h", Time);
            Console.SetCursorPosition(left, 14);
            Console.Write("物品：");
            int top = 14;
            if (i == 0)
            {
                Console.Write("无");
            }
            else
                for (int j = 1; j <=i; j++)
                {
                    Console.SetCursorPosition(7, ++top);
                    goods[j].display();
                }
            int top1 = 4;            
            for(int j=0;j<ConnectionsNum;j++)
            {
                Console.SetCursorPosition(left1, top1++);
                if (j>15)
                {
                    Console.WriteLine("...");
                    break;
                }                
                Console.Write(j+" ");
                connections[j].Display();
            }
        }
        public void equip(string x,int y)//装备时要判断该物品是否存在
        {
            int j = goods.FindIndex(t => t.GetName() == x);          
            if (j != -1) goods[i].NumPlus(y);
            else
            {
                i++;
                switch (x)
                {
                    case "泡面":goods.Add(new InstantNoodles(x, y, i));break;
                    case "车":goods.Add(new Car(x, y, i));break;
                    case "房":goods.Add(new House(x, y, i));break;
                    case "牙膏":goods.Add(new ToothPaste(x, y, i));break;
                    case "纸条": goods.Add(new Tip(x, y, i)); break;
                    case "自行车":goods.Add(new Bycicle(x, y, i));break;
                    case "自动赚钱机": goods.Add(new AutoMoney(x, y, i)); break;
                }
                }             
        }
        public void EquipmentUse(int x,player A,story S)//装备使用
        {
            int top = Console.CursorTop;
            int width = Console.WindowWidth;
            int height = Console.WindowHeight;
            if (x > i) S.AnyPrint("你还没买这个东西呢~",1);            
            else if (!goods[x].Num()) S.AnyPrint("这个东西好像用光了呢~快去买一些吧~", 1);            
            else goods[x].Use(A,S);                            
        }
        
       
    }
}
