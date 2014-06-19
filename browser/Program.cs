using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using mshtml;

namespace browser
{
    class Program
    {
        static void Main(string[] args)
        {
            SHDocVw.ShellWindows shellWindows = new SHDocVw.ShellWindowsClass(); //创建Microsoft Internet Controls对象
            string filename;

            string IeTitle = "Google";//IE窗口标题，自己设定


            foreach (SHDocVw.InternetExplorer ie in shellWindows) //遍历IE游览器和文件游览器窗口
            {

                filename = Path.GetFileNameWithoutExtension(ie.FullName).ToLower();//提取游览器程序的文件名，并转化为小写
                if (filename.Equals("iexplore") && IeTitle.Equals(ie.LocationName)) //如果文件名等于IE AND 窗口标题是 IeTitle 则提取出网页内容
                {
                    Console.WriteLine("网址: {0}", ie.LocationURL);
                    mshtml.IHTMLDocument2 htmlDoc = ie.Document as mshtml.IHTMLDocument2; //提取出网页内容

                    mshtml.IHTMLElement input = (mshtml.IHTMLElement)htmlDoc.all.item("q", 0); //找到页面的中输入框
                    mshtml.IHTMLElement input2 = (mshtml.IHTMLElement)htmlDoc.all.item("btnG", 0); //找到页面中的提交按钮

                    input.title = "请在此输入你想要搜索的内容"; //给他们增加提示
                    input2.title = "这个提交按钮，点此开始搜索";

                    Console.WriteLine("网页内容: {0}", ((htmlDoc != null) ? htmlDoc.body.outerHTML : "***Failed***")); //输出代码

                }

            }
            Console.ReadKey();
        }
    }
}
