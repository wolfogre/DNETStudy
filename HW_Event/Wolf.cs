﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW_Event
{
    public class MyCheckInput : EventArgs  //包含事件数据的类定义--开始
    {
        public string position;
        public string result;

        public MyCheckInput(string position, string result)
        {
            this.position = position;
            this.result = result;
        }
       
    }//包含事件数据的类定义--结束

    public delegate void CheckInputEventHandle(object sender, MyCheckInput e); //定义匹配的委托

    class CheckEventOccurDealt //定义事件类【包含事件触发、事件处理】--开始
    {
        public event CheckInputEventHandle MyEvent;//事件
        public CheckInputEventHandle MyDelegate; //委托
        public string cause;
        public string result;

        public CheckEventOccurDealt() //构造函数
        {
            cause = "";
            result = "";

            MyDelegate = new CheckInputEventHandle(EventProcess);   //构造指代【委托】
            MyDelegate += new CheckInputEventHandle(EventAdd);      //指代【委托】多播【组合】

            MyEvent += MyDelegate;   //事件注册
        }

        public void MakeItOccur(MyCheckInput e) //事件触发
        {
            if (e.position.Equals("她不想上课") == true)
                MyEvent(this, e);
        }

        public void EventProcess(object sender, MyCheckInput e)
        {
            cause = "事件原因为：" + e.position;
            result = "事件结果为：" + e.result;
        }

        public void EventAdd(object sender, MyCheckInput e)
        {
            cause += "！大家有麻烦了v_v";
            result += "！大家快逃^-^";
            MessageBox.Show("!!!!!!!!!!!!!!");
        }
    }

    /*public class WolfComing : EventArgs
    {
        public static String status = new String('a', 1);
        //string alem = "Wolf is coming!";
    }
    public delegate void CheckInputEventHandle(object sender, WolfComing e);
    class CheckBeast
    {
        public event CheckInputEventHandle MyEvent;
        public CheckInputEventHandle MyDelegate;

        public CheckBeast()
        {
            MyDelegate = new CheckInputEventHandle(EventProcess);
            MyEvent += MyDelegate;
        }

        public void MakeItOccur(CheckBeast e)
        {
            if (WolfComing.status == "wolf")
                MyEvent();
        }

        public void EventProcess(object sender, WolfComing e)
        {

        }
    }*/
}
