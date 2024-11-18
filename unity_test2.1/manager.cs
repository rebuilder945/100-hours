using System;
using System.Collections.Generic;
using System.Text;

namespace unity_test2._1
{
    class manager//管理类
    {
        player A = new player();
        shop Shop = new shop();
        story Story = new story();
        behaviour Behaviour = new behaviour();
        GMan gman = new GMan();
        common Common = new common();
        double Efficiency;
        bool Kill=false;
        bool EndFlag = false;
       public void End()//结束界面
        {
            int width = Console.WindowWidth;
            int height = Console.WindowHeight;            
            while(true)
            {
                Console.Clear();
                Console.SetCursorPosition((int)(width * 0.45), (int)(height * 0.4));
                Console.WriteLine("游戏结束");
                Console.SetCursorPosition((int)(width * 0.4) - 1, (int)(height * 0.4) + 2);
                Console.WriteLine("1.再玩一次 2.退出");
                Console.SetCursorPosition((int)(width * 0.4) - 1, (int)(height * 0.4) + 3);
                ConsoleKeyInfo cki = Console.ReadKey();
                Console.WriteLine();
                if (cki.Key != ConsoleKey.D1 && cki.Key != ConsoleKey.D2)
                {
                    Efficiency += 0.5;
                    Console.SetCursorPosition((int)(width * 0.4) - 2, (int)(height * 0.4) + 4);
                    Console.WriteLine("输入不规范呢~请重新输入");
                    ConsoleKeyInfo cki1 = Console.ReadKey();
                    Console.WriteLine();
                }
                else if (cki.Key == ConsoleKey.D1)
                {
                    EndFlag = false;
                    Console.Clear();
                    break;
                }
                else Environment.Exit(0);
            }
            System.Threading.Thread.Sleep(1000 * 1);
        }
        public void InitProcess()//角色建立初始化
        {
            int width = Console.WindowWidth;
            int height = Console.WindowHeight;
                      
            while(true)
            {
                Console.SetCursorPosition((int)(width * 0.45), (int)(height * 0.4));
                Console.WriteLine("100小时!");
                Console.SetCursorPosition((int)(width * 0.4) - 2, (int)(height * 0.4) + 2);
                Console.WriteLine("请输入昵称...(以回车结束)");
                Console.SetCursorPosition((int)(width * 0.4) - 2, (int)(height * 0.4) + 3);
                string name = Console.ReadLine();
                Console.SetCursorPosition((int)(width * 0.4)-2, (int)(height * 0.4)+4);
                Console.WriteLine("请输入性别:1、男 2、女 (请用大写进行输入编号)");
                Console.SetCursorPosition((int)(width * 0.4)-2, (int)(height * 0.4)+5);
                ConsoleKeyInfo sex = Console.ReadKey();
                Console.WriteLine();
                Console.SetCursorPosition((int)(width * 0.4)-2, (int)(height * 0.4)+6);
                if (sex.Key != ConsoleKey.D1 && sex.Key != ConsoleKey.D2)
                {
                    Efficiency+=0.5;
                    Console.WriteLine("输入不规范噢~请重新输入(看看是不是大写的问题呢~)");
                }
                else
                {
                    A.PlayerInit(name,sex.Key==ConsoleKey.D1?1:2);
                    Console.SetCursorPosition((int)(width * 0.4)-2, (int)(height * 0.4)+7);
                    Console.WriteLine("游戏即将开始！");
                    Console.SetCursorPosition((int)(width * 0.4) - 2, (int)(height * 0.4) + 8);
                    Console.WriteLine("加载中...(进入游戏后不要改变窗口大小噢！！！)");
                    Console.SetCursorPosition((int)(width * 0.4) - 2, (int)(height * 0.4) + 9);
                    System.Threading.Thread.Sleep(1000 * 2);
                    Console.Clear();
                    break;
                }
                Console.SetCursorPosition((int)(width * 0.4) - 2, (int)(height * 0.4) + 7);
                Console.ReadKey();               
                Console.Clear();
            }  
        }
        public void End1()//结束剧情界面
        {
            int width = Console.WindowWidth;
            int height = Console.WindowHeight;
            EndFlag = true;
            Console.Clear();
            Console.SetCursorPosition(0,0);
            Console.WriteLine("你从床上醒来,时间过去{0}小时,但却像过去一百年了...\n",A.GetTime());
            Console.WriteLine("在这{0}小时里:\n",A.GetTime());           
            if (A.GetHp() <= 0) Console.WriteLine("万万没想到...你居然饿死啦 (/ﾟДﾟ)/ \n");
            else if (Kill) Console.WriteLine("你被误杀了，真可怜 ╮(0_0)╭\n");
            if (A.GetMoney() >= 100000) Console.WriteLine("你赚了很多钱,这些钱足以买{0}支牙膏\n", A.GetMoney() / 100);
            else if (A.GetMoney() >= 10000 && A.GetMoney() < 500000) Console.WriteLine("你的钱足以维持你的生活\n");
            else if (A.GetMoney() < 0) Console.WriteLine("你没钱,甚至欠了一屁股债...\n");
            else Console.WriteLine("你没有钱,甚至买一包泡面都须再三斟酌\n");           
            if (A.GetConnectionsNum()>3) Console.WriteLine("你结识了很多朋友,但其中不乏虚情假意\n");
            else Console.WriteLine("你朋友很少\n");
            if (!A.GetSingle() && !A.GetGreen() && !A.GetDivorce()) Console.WriteLine("你与另一个人成为了夫妻,感情很好\n");
            else if (!A.GetSingle() && A.GetGreen()) Console.WriteLine("你被绿了,但这并没有让你从此消沉,你和你现在的Ta过得很好!\n");
            else if (!A.GetSingle() && A.GetDivorce()) Console.WriteLine("你离过婚,但这并没有让你从此低落,你和你现在的Ta过得很好!\n");
            else if (A.GetGreen() && A.GetDivorce()) Console.WriteLine("你经历人生的大起大落,离婚,被绿..你从前的那个Ta现在正躺在别人怀里呢~\n");
            else Console.WriteLine("不幸的人呀，你似乎经历过某些伤痛...\n");
            if (A.HouseFind() && A.GetSingle()) Console.WriteLine("你有自己的房,但是偌大的房子里只你一人\n");
            else if (A.HouseFind() && !A.GetSingle()) Console.WriteLine("你有自己的家,因为有人陪你睡在一起\n");
            else if (!A.HouseFind() && !A.GetSingle()) Console.WriteLine("你没有容身之所,但 " + A.connections[A.GetTaNum()].GetName() + " 愿意和你漂泊天涯!\n");
            else if (!A.HouseFind() && A.GetSingle()) Console.WriteLine("你没有容身之所,而且孑然一身...\n");
            if (A.CarFind())Console.WriteLine("你开着车去了很多地方\n");
            else Console.WriteLine("你甚至没有一辆车\n"); 
            if (A.ToothPasteFind())Console.WriteLine("牙膏让你的牙齿很干净...\n");
            else Console.WriteLine("或许你最大的错误在于没买牙膏...\n");
            Console.WriteLine("另外呢,你浪费了{0}%的时间在错误输入上!!\n", (int)((Efficiency/A.GetTime())*100));
        }
        public void start()//管理初始化数据与界面的总接口
        {                       
            text Text = new text();
            Text.print_structure();
            A.display(A);
            Shop.display();
            Story.display();
            Behaviour.display();
            if (A.GetTime() == 0) Story.AnyPrint("可以从交朋友开始噢",1);
        }
        //商店：Console.SetCursorPosition((int)(width* 0.6), x);
        //玩家：Console.SetCursorPosition((int)(width * 0.1), 7);
        //对话：Console.SetCursorPosition((int)(width * 0.7), (int)(height * 0.55));
        //行动：Console.SetCursorPosition((int)(width * 0.2), (int)(height * 0.55));
        public void Bet(player A)//赌场操作
        {
            int top = Console.CursorTop;
            int width = Console.WindowWidth;
            int height = Console.WindowHeight;
            int x = new Random().Next(0, 1000);         
            int[] bet = new int[1001];
            bet.Initialize();
            for (int i = 0; i < 300; i++)
            {
                bet[new Random().Next(0, 1000)] = -1;
            }
            for (int i=4;i<1000;i+=2)
            {
                if (bet[i] != -1) bet[i] = 1;               
            }
            for(int i=3;i<1000;i+=50)
            {
                if(bet[i]!=-1&&bet[i]!=1) bet[i - 2] = 3;                
            }
            for(int i=0;i<200;i++)
            {
                bet[new Random().Next(0, 1000)] = 4;
            }
            for (int i = 0; i < 10; i++)
            {
                bet[new Random().Next(0, 1000)] = 2;
            }
            int k = 0;
            for(int i=0;i<1000;i++)
            {
                if(bet[i]==0&&k<=100)
                {
                    bet[i] = 6;
                    k++;
                }
                if (k > 100) break;
            }
            for (int i = 0; i < 1000; i++)
            {
                if (bet[i] == 0 && k <= 100)
                {
                    bet[i] = 5;
                    k++;
                }
                if (k > 60) break;
            }
            switch (bet[x])
            {
                case -1:
                    {
                        Story.AnyPrint("没有什么事情发生...",1);//约1/3概率                        
                    }; break;                    
                case 1:
                    {
                        Story.AnyPrint(A.GetName() + "输了10000！Σ(っ °Д °;)っ",1);//约1/4概率
                        A.MoneyChange(10000,-1);   
                    }; break;
                case 2:
                    {
                        Story.AnyPrint(A.GetName() + "赢得一百万!ヘ(￣ω￣ヘ)",1);//1/100概率         
                        A.MoneyChange(1000000, 1);
                    }; break;                    
                case 3:
                    {
                        Story.AnyPrint(A.GetName() + "赢得房1套!ヘ(￣ω￣ヘ)",1);//1/20概率      
                        A.equip("房", 1);
                    };break;
                case 4:
                    {
                        Story.AnyPrint("不知谁给你留了张纸条欸~",1);//1/5概率
                        System.Threading.Thread.Sleep(500);                        
                        A.equip("纸条", 1);
                        Console.WriteLine("现在打开看看吗？1.好的 2.不好");
                        ConsoleKeyInfo num = Console.ReadKey();
                        Console.WriteLine();
                        if (num.Key != ConsoleKey.D1 && num.Key != ConsoleKey.D2 && num.Key != ConsoleKey.D3 && num.Key != ConsoleKey.D4)
                        {
                            Efficiency += 0.5;
                            Console.WriteLine("输入不规范呢~请重新进行");                            
                        }
                        if (num.Key== ConsoleKey.D1) A.EquipmentUse(A.GetI(),A,Story);
                    };break;
                case 5:
                    {
                        Story.AnyPrint(A.GetName() + "赢得5000！Σ(っ °Д °;)っ",1);//约1/18概率
                        A.MoneyChange(5000, 1);
                    };break;
                case 6:
                    {
                        if(!A.GetSingle())
                        {
                            A.Green();
                            int num = A.GetTaNum();
                            A.SingleChange(num, -1);
                            Story.AnyPrint(A.GetName() + "很不幸:"+A.connections[num].GetName()+ "和别人跑啦,并带走了你的10000元（╯#-皿-)╯",1);//约1/18概率
                            Console.BackgroundColor = ConsoleColor.Green;
                            A.MoneyChange(1000, -1);
                        }
                        else
                        {
                            Story.AnyPrint(A.GetName() + "赢得20000！Σ(っ °Д °;)っ",1);//约1/18概率
                            A.MoneyChange(20000, 1);
                        }
                    };break;
                default:
                    {
                        if(A.GetTime()>18)
                        {
                            Kill = true;
                            Story.AnyPrint(A.GetName() + " :赌场发生了暴乱，你被误杀了..", 1);//约1/8概率
                            Console.WriteLine("按任意键继续...");
                            ConsoleKeyInfo opi = Console.ReadKey();
                            End1();
                        }
                        else
                        {
                            Story.AnyPrint(A.GetName() + "输了1000！Σ(っ °Д °;)っ", 1);//约1/18概率
                            A.MoneyChange(1000, -1);
                        }                                              
                    };break;                    
            }
        }
        public void process()//游戏进程主体
        {
            int width = Console.WindowWidth;
            int height = Console.WindowHeight;
                       
            while (!EndFlag)
            {
                if (A.GetTime() == 100)
                {                    
                    Story.AnyPrint(A.GetName() + " :时间到了额(⊙﹏⊙)你安详的闭上了眼...",1); 
                    Console.WriteLine("按任意键继续...");
                    ConsoleKeyInfo opi = Console.ReadKey();
                    End1();
                }
                else if (A.GetTime() == 0 || A.GetTime() == 18 || A.GetTime() == 25)
                {
                    Console.SetCursorPosition(0, (int)(height * 0.55) + 9);
                    Console.Clear();
                    Story.DisplayStory(A);
                }
                else if(A.GetHp()<=0)
                { 
                    Story.AnyPrint(A.GetName() + " :体力为0,你眼前一黑...",1);                    
                    Console.WriteLine("按任意键继续...");
                    ConsoleKeyInfo opi = Console.ReadKey();
                    End1();
                }
                else
                {
                    
                    if (A.GetAutoMoney() != 0)
                    {
                        A.MoneyChange(1000 * A.GetAutoMoney(), 1);
                        Story.AnyPrint(A.GetName() + ": 即将获得" + 1000 * A.GetAutoMoney() + "元(来自 自动赚钱机)...", 15);
                    }
                    if (A.GetHp() == 20)
                    {
                        Story.AnyPrint(A.GetName() + " :快没体力啦(⊙﹏⊙)赶紧吃点东西吧...", 13);
                    }                    
                    Console.SetCursorPosition(0, (int)(height * 0.55) + 9);
                    Console.WriteLine("请输入行动：(请用大写输入编号)");
                    ConsoleKeyInfo choice = Console.ReadKey();
                    Console.WriteLine();
                    switch (choice.Key)
                    {
                        case ConsoleKey.D0:
                            {
                                Console.WriteLine("请输入要购买的物品编号");
                                ConsoleKeyInfo num = Console.ReadKey();
                                Console.WriteLine();
                                if (num.Key != ConsoleKey.D1 && num.Key != ConsoleKey.D2 && num.Key != ConsoleKey.D3 && num.Key != ConsoleKey.D4 && num.Key != ConsoleKey.D5 && num.Key != ConsoleKey.D6)
                                {
                                    Efficiency+=0.5;
                                    Console.WriteLine("输入不规范呢~请重新输入");
                                    break;
                                }
                                Console.WriteLine("要购买多少呢?(以回车结束输入)");
                                string num0 = Console.ReadLine();//如何对这里进行输入判断呢？？？
                                int num1 = Convert.ToInt32(num0);
                                if (num1 < 0)
                                {
                                    Efficiency+=0.5;
                                    Console.WriteLine("输入不规范呢~请重新输入");
                                    break;
                                }
                                void intext(int x, string s)
                                {
                                    int flag = Shop.buy(x, num1, A);
                                    if (flag == 0) A.equip(s, num1);
                                }
                                switch (num.Key)
                                {

                                    case ConsoleKey.D1:
                                        {
                                            intext(1, "泡面");
                                        }; break;
                                    case ConsoleKey.D2:
                                        {
                                            intext(2, "车");
                                        }; break;
                                    case ConsoleKey.D3:
                                        {
                                            intext(3, "房");
                                        }; break;
                                    case ConsoleKey.D4:
                                        {
                                            intext(4, "牙膏");
                                        }; break;
                                    case ConsoleKey.D5:
                                        {
                                            intext(5, "自行车");
                                        };break;
                                    case ConsoleKey.D6:
                                        {
                                            A.AutoMoneyChange(num1);
                                            intext(6, "自动赚钱机");
                                        };break;
                                }
                            }; break;
                        case ConsoleKey.D1:
                            {
                                Console.WriteLine("请输入要使用的物品编号:");
                                ConsoleKeyInfo cki = Console.ReadKey();
                                Console.WriteLine();
                                if (cki.Key != ConsoleKey.D1 && cki.Key != ConsoleKey.D2 && cki.Key != ConsoleKey.D3 && cki.Key != ConsoleKey.D4 && cki.Key != ConsoleKey.D5 && cki.Key != ConsoleKey.D6)
                                {
                                    Efficiency+=0.5;
                                    Console.WriteLine("输入不规范呢~请重新输入");
                                    break;
                                }
                                switch (cki.Key)
                                {

                                    case ConsoleKey.D1:
                                        {
                                            A.EquipmentUse(1, A,Story);
                                        }; break;
                                    case ConsoleKey.D2:
                                        {
                                            A.EquipmentUse(2, A,Story);
                                        }; break;
                                    case ConsoleKey.D3:
                                        {
                                            A.EquipmentUse(3, A,Story);
                                        }; break;
                                    case ConsoleKey.D4:
                                        {
                                            A.EquipmentUse(4, A,Story);
                                        }; break;
                                    case ConsoleKey.D5:
                                        {
                                            A.EquipmentUse(5, A, Story);
                                        };break;
                                    case ConsoleKey.D6:
                                    {
                                            A.EquipmentUse(6, A, Story);
                                    };break;
                                }
                            }; break;
                        case ConsoleKey.D2:
                            {
                                A.ConnectionsPlus(A, Story);
                            }; break;
                        case ConsoleKey.D3:
                            {
                                Console.WriteLine("稍等...正在摇骰子...");
                                System.Threading.Thread.Sleep(1000 * 1);
                                Bet(A);
                            }; break;
                        case ConsoleKey.D4:
                            {
                                Console.WriteLine("选择问题种类编号:");
                                Console.WriteLine("1.我该做啥 2.闲聊");
                                ConsoleKeyInfo cki = Console.ReadKey();
                                Console.WriteLine();
                                if (cki.Key != ConsoleKey.D1 && cki.Key != ConsoleKey.D2)
                                {
                                    Efficiency+=0.5;
                                    Console.WriteLine("输入不规范呢~请重新输入");
                                    break;
                                }
                                else if (cki.Key == ConsoleKey.D1) gman.Questions(Story, 1);
                                else gman.Questions(Story, 2);
                            }; break;
                        case ConsoleKey.D5:
                            {
                                if (!A.GetSingle())
                                {
                                    Story.AnyPrint("你不是已经有了吗！！\n",1);
                                    Story.AnyPrint("不过你执意如此的话,得先和Ta离婚...",3);
                                    Story.AnyPrint("1.离! 2.还是算了吧",5);
                                    ConsoleKeyInfo cki = Console.ReadKey();
                                    Console.WriteLine();
                                    if (cki.Key != ConsoleKey.D1 && cki.Key != ConsoleKey.D2)
                                    {
                                        Efficiency += 0.5;
                                        Console.WriteLine("输入不规范呢~请重新输入");
                                    }
                                    else if (cki.Key == ConsoleKey.D1)
                                    {
                                        int flag = new Random().Next(1, 3);
                                        int num1 = A.GetTaNum();
                                        if (flag == 1)
                                        {
                                            A.SingleChange(num1, -1);
                                            A.Divorce();
                                            Story.AnyPrint(A.connections[num1].GetName() + "：同意离婚啦!", 7);
                                        }
                                        else Story.AnyPrint(A.connections[num1].GetName() + " 摇了摇头,拒绝了你的提议", 7);
                                    }
                                    else Story.AnyPrint("好的呢~",7);
                                    break;
                                }
                                if (A.GetConnectionsNum() == 0)
                                {
                                    Story.AnyPrint("你还没有认识的人噢",1);
                                    break;
                                }
                                Console.WriteLine("你要向谁求婚呢?(输入编号)");
                                int num = int.Parse(Console.ReadLine());
                                if (num >= A.GetConnectionsNum())
                                {
                                    Efficiency+=0.5;
                                    Console.WriteLine("输入不规范呢~请重新输入");
                                    break;
                                }
                                if (A.GetSex() == "男")
                                {
                                    if ((A.GetMoney() > 100000 && A.HouseFind())||(A.CarFind()&& A.GetMoney() > 100000))
                                    {
                                        A.SingleChange(num,1);
                                        A.TaNumChange(num);
                                        Story.AnyPrint(A.connections[num].GetName() + " 同意了!哼！",1);
                                    }
                                    else Story.AnyPrint(A.connections[num].GetName() + " 认为你还不够资本(房||车)噢~",1);
                                }
                                else
                                {
                                    int x = new Random().Next(1, 3);
                                    if (x == 1)
                                    {
                                        A.SingleChange(num,1);
                                        A.TaNumChange(num);
                                        Story.AnyPrint(A.connections[num].GetName() + " 同意了!哼！",1);
                                    }
                                    else Story.AnyPrint(A.connections[num].GetName() + " 拒绝了你的这个请求噢~",1);
                                }
                            }; break;
                        default:
                            {
                                Efficiency+=0.5;
                                Console.WriteLine("输入错误！(记得大写进行输入哦~)");
                                break;
                            }
                    }
                }
                
                Console.WriteLine("按任意键继续...");  
                ConsoleKeyInfo any = Console.ReadKey();               
                Console.Clear();
                A.HpChange(10, -1);
                A.TimePlus();
                start();
            }

        }
    }
}
