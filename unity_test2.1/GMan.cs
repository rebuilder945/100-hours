using System;
using System.Collections.Generic;
using System.Text;

namespace unity_test2._1
{
    class GMan//AI的话语库类
    {
        string[] Words = new string[24]
        {
            "多赚些钱吧!",
            "和你的某个朋友谈一场风花雪月的恋爱吧!",
            "求婚是要有资本的噢",
            "赚够了钱就去买点啥吧,比如车,房...一只牙膏?",
            "虽然我更愿意买牙膏一些",
            "结婚对象摇一摇~",
            "欢迎来到这个世界",
            "生命有时候并没有那么重要",
            "一切皆有可能",
            "去赌场的话最好小心些噢~你死了我会心疼的",
            "赌场有无限可能,所以多去赌场转转",
            "交朋友有好有坏，不信你试试看~",
            "多来问我问题噢~",
            "遇到什么困难~也不要怕~",
            "微笑着面对他!",
            "奥里给!!!",
            "你要喜爱你自己的价值",
            "君子赠人以言,庶人赠人以财",
            "原谅敌人要比原谅朋友容易",
            "今天天气很好",                                    
            "人的本质是孤独呢,别问我咋知道的",
            "hallo!我是AI,有啥问题可以问我哟~",            
            "人家还是单身呢",
            "天不总是在你头上的噫",           
        };
        public void Questions(story Story,int i)
        {
            if(i==1) Story.AnyPrint(Words[new Random().Next(0, 10)],1);
            else Story.AnyPrint(Words[new Random().Next(10, 20)],1);
        }
    }
}
