﻿using ConApp.Model;
using Microsoft.Web.Administration;
using Microsoft.Win32;
using Net.Tools;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace ConApp
{
    internal class Program
    {
        public const string SqliteFilePath = "sqlitedb.db";

        public delegate void ConPort(int port);

        private delegate void AsycRun();

        public static unsafe void Main(string[] args)
        {
            DateTime d1 = new DateTime(2017,1,1);

            int days=(DateTime.Now - d1).Days;
            Console.WriteLine(days);
            Console.WriteLine(d1);
            Console.ReadKey();

            List<int> xxx = new List<int> { 5987, 5987, 5906, 6045, 5758, 6106, 5995, 5896, 5902, 5953, 5959, 5894, 5898, 5851, 5977, 5871, 5853, 5892, 5985, 5956, 5877, 5801, 5942, 5793, 5876, 5888, 5972, 5876, 6082, 6063, 5887, 5870, 6074, 5915, 6051, 6102, 5922, 5935, 5955, 6007, 5983, 5968, 5904, 5982, 6046, 6003, 5916, 5940, 5945, 5967, 5917, 6050, 5960, 6018, 5978, 5909, 5948, 5974, 5975, 6077, 6107, 6103, 6079, 6110, 6023, 6097, 6094, 6088, 6109, 6096, 6096 };
            IEnumerable<int> ii = xxx.Distinct();
            foreach (int item in ii)
            {
                Console.Write(item + ",");
            }
            Console.ReadKey();
            Console.WriteLine(true ^ false);
            Console.WriteLine(true ^ true);
            Console.WriteLine(false ^ false);
            Console.WriteLine(false ^ true);
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine(true & false);
            Console.WriteLine(true & true);
            Console.WriteLine(false & false);
            Console.WriteLine(false & true);
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine(true | false);
            Console.WriteLine(true | true);
            Console.WriteLine(false | false);
            Console.WriteLine(false | true);
            Console.WriteLine(Environment.NewLine);

            int i = 0;
            if (false & i++ == 1)
            {
                Console.WriteLine("Test.///////////////////////");
            }
            List<int> intlist = new List<int>();
            int a = 1 ^ 1;
            int b = 1 & 1;
            int c = 1 | 1;
            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
            //string name = Assembly.GetExecutingAssembly().GetType().Namespace;

            Console.ReadKey();
        }

        #region 01-foreach原理

        public static void Cus_foreach()
        {
            MyCollection1 myCol = new MyCollection1();
            foreach (var a in myCol)
            {
                Console.WriteLine(a);
            }
            MyCollection2 myCol2 = new MyCollection2();
            foreach (var m in myCol2)
            {
                Console.WriteLine(m);
            }
        }

        #endregion 01-foreach原理

        #region 02-EnumDemo

        /*
         “X”或“x” 以十六进制格式表示 value（不带前导“0x”）。
         “D”或“d” 以十进制形式表示 value。
         “F”或“f” 对于“G”或“g”执行的行为是相同的，只是在 Enum 声明中不需要 FlagsAttribute。

         “G”或“g”
         如果 value 等于某个已命名的枚举常数，则返回该常数的名称；否则返回 value 的等效十进制数。
         例如，假定唯一的枚举常数命名为 Red，其值为 1。如果将 value 指定为 1，则此格式返回“Red”。然而，如果将 value 指定为 2，则此格式返回“2”。
         - 或 -
         如果将 FlagsAttribute 自定义特性应用于枚举，则 value 将被视为位域，该位域包含一个或多个由一位或多位组成的标志。
         如果 value i等于命名枚举常数的组合，则将返回这些常量名的分隔符分隔列表。将在 value 中搜索标志，从具有最大值的标志到具有最小值的标志进行搜索。
         对于与 value 中的位域相对应的每个标志，常数的名称连接到用分隔符分隔的列表。则将不再考虑该标记的值，而继续搜索下一个标志。
         如果 value 不等于已命名的枚举常数的组合，则返回 value 的等效十进制数。
     */

        public static void EnumDemo01()
        {
            Console.WriteLine($"SocialTypeEnum.Facebook={SocialTypeEnum.Facebook}");
            Console.WriteLine($"(int)SocialTypeEnum.Facebook={(int)SocialTypeEnum.Facebook}");

            const int b = (int)SocialTypeEnum.Facebook;
            Console.WriteLine(b);
            Console.WriteLine((SocialTypeEnum)b);

            const SocialTypeEnum s = (SocialTypeEnum)10;
            const int e = (int)s;
            Console.WriteLine(s);
            Console.WriteLine(e);
        }

        public static void EnumDemo02_Parse()
        {
            const string a = "Twitter";
            try
            {
                SocialTypeEnum social = (SocialTypeEnum)(Enum.Parse(typeof(SocialTypeEnum), a));
                Console.WriteLine(@"SocialTypeEnum=" + social);
            }
            catch
            {
                Console.WriteLine(@"无此枚举");
            }
        }

        public static void EnumDemo3_Format()
        {
            SocialTypeEnum s = SocialTypeEnum.GooglePlus;
            Console.WriteLine($@"
                    d={Enum.Format(typeof(SocialTypeEnum), s, "d")}
                    x={Enum.Format(typeof(SocialTypeEnum), s, "x")}
                    g={Enum.Format(typeof(SocialTypeEnum), s, "g")}
                    f={Enum.Format(typeof(SocialTypeEnum), s, "f")}");
            const SocialTypeEnum se = SocialTypeEnum.Facebook | SocialTypeEnum.GooglePlus | SocialTypeEnum.Twitter;
            Console.WriteLine(se);

            Console.WriteLine(Enum.GetName(typeof(SocialTypeEnum), 10));
        }

        public static void EnumDemo04_GetNames()
        {
            Type type = typeof(SocialTypeEnum);
            foreach (string s in Enum.GetNames(type))
            {
                Console.WriteLine("{0,-11}= {1}", s, Enum.Format(type, Enum.Parse(type, s), "d"));
            }
        }

        public static void EnumDemo05_GetValues()
        {
            Type type = typeof(SocialTypeEnum);
            foreach (int i in Enum.GetValues(type))
            {
                Console.WriteLine(i);
            }
        }

        #endregion 02-EnumDemo

        #region 03-EventDemo

        private static int WriteLetter(string letter)
        {
            Console.Write(letter + " ");
            return 1;
        }

        private static void ExampleMethod(int a, int b, int c)
        {
        }

        public static void ExampleMethod(string p1 = null, object p2 = null)
        {
            Console.WriteLine(@"ExampleMethod: p2 is object");
        }

        public static void ExampleMethod(string p2 = null, object p1 = null, params int[] p3)
        {
            Console.WriteLine(@"ExampleMethod: p2 is string");
        }

        private static void publisher_SampleEvent(object sender, SampleEventArgs e)
        {
            Console.WriteLine("e.Text:" + e.Text);
        }

        public static void EventDemo1()
        {
            ExampleMethod(p2: "");
            Console.WriteLine(@"\n+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n");

            ExampleMethod(WriteLetter("A"), b: WriteLetter("B"), c: WriteLetter("C"));
            ExampleMethod(WriteLetter("A"), c: WriteLetter("C"), b: WriteLetter("B"));
            Console.WriteLine(@"\n+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n");

            var methods = new List<Action>();
            foreach (var word in new string[] { "hello", "world" })
            {
                methods.Add(() => Console.Write(word + " "));
            }

            methods[0]();
            methods[1]();
            Console.WriteLine(@"\n+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n");

            var lines = new List<IEnumerable<string>>();
            int[] numbers = { 1, 2, 3 };
            char[] letters = { 'a', 'b', 'c' };

            foreach (int number in numbers)
            {
                var line = from letter in letters
                           select number.ToString() + letter;

                lines.Add(line);
            }

            foreach (var line in lines)
            {
                foreach (var entry in line)
                    Console.Write(entry + " ");
                Console.WriteLine();
            }
            Console.WriteLine(@"\n+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n");

            Model.Publisher publisher = new Model.Publisher();

            publisher.SampleEvent += publisher_SampleEvent;
        }

        public static void EventDemo2()
        {
            var dealer = new CarDealer();

            var c1 = new Consumer("Consumer1");

            dealer.NewCarInfo += c1.NewCarIsHere;
            dealer.NewCar("Mercedes");

            Console.WriteLine("\r\n");

            var c2 = new Consumer("Consumer2");

            dealer.NewCarInfo += c2.NewCarIsHere;
            dealer.NewCar("Ferrari");

            Console.WriteLine("\r\n");

            dealer.NewCarInfo -= c2.NewCarIsHere;
            dealer.NewCar("Red Bull Racing");

            System.Console.ReadKey();
        }

        #endregion 03-EventDemo

        #region 04-PerformanceCounter

        public static void Demo04()
        {
            var counters = new List<PerformanceCounter>();
            Process[] processes = Process.GetProcesses();
            foreach (Process process in processes)
            {
                var counter = new PerformanceCounter("Process", "% Processor Time", process.ProcessName);
                counter.NextValue();
                counters.Add(counter);
            }

            int i = 0;

            Thread.Sleep(1000);

            foreach (var counter in counters)
            {
                Console.WriteLine(processes[i].ProcessName + " | CPU% " + (Math.Round(counter.NextValue(), 1)));
                ++i;
            }
        }

        #endregion 04-PerformanceCounter

        #region 05-GetHostEntryDemo

        public static void GetHostEntryDemo()
        {
            string[] args = { };
            if (args.Length == 0 || args[0].Length == 0)
            {
                Console.WriteLine(@"You must specify the name of a host computer.");
                return;
            }
            IAsyncResult result = Dns.BeginGetHostEntry(args[0], null, null);
            Console.WriteLine(@"Processing request for information...");

            while (result.IsCompleted != true)
            {
                Extension.UpdateUserInterface();
            }

            Console.WriteLine();
            try
            {
                IPHostEntry host = Dns.EndGetHostEntry(result);
                string[] aliases = host.Aliases;
                IPAddress[] addresses = host.AddressList;
                if (aliases.Length > 0)
                {
                    Console.WriteLine(@"Aliases");
                    foreach (string t in aliases)
                    {
                        Console.WriteLine(t);
                    }
                }
                if (addresses.Length > 0)
                {
                    Console.WriteLine(@"Addresses");
                    foreach (IPAddress t in addresses)
                    {
                        Console.WriteLine(t);
                    }
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine(@"An exception occurred while processing the request: {0}", e.Message);
            }
        }

        #endregion 05-GetHostEntryDemo

        #region 06-ProcessDemo

        public static void ProcessDemo()
        {
            Process myProcess = new Process();
            try
            {
                string myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                myProcess.StartInfo.FileName = myDocumentsPath + "\\MyFile.docx";
                myProcess.StartInfo.Verb = "Print";
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.Start();
            }
            catch (Win32Exception e)
            {
                if (e.NativeErrorCode == 2)//ErrorFileNotFound
                {
                    Console.WriteLine(e.Message + ". Check the path.");
                }
                else if (e.NativeErrorCode == 5)//ErrorAccessDenied
                {
                    Console.WriteLine(e.Message + ". You do not have permission to print this file.");
                }
            }
        }

        #endregion 06-ProcessDemo

        #region 07-AsyncWaitHandle

        public static void AsyncWaitHandleDemo()
        {
            string[] args = { };
            if (args.Length == 0 || args[0].Length == 0)
            {
                Console.WriteLine("You must specify the name of a host computer.");
                return;
            }
            IAsyncResult result = Dns.BeginGetHostEntry(args[0], null, null);
            Console.WriteLine("Processing request for information...");
            result.AsyncWaitHandle.WaitOne();
            try
            {
                IPHostEntry host = Dns.EndGetHostEntry(result);
                string[] aliases = host.Aliases;
                IPAddress[] addresses = host.AddressList;
                if (aliases.Length > 0)
                {
                    Console.WriteLine("Aliases");
                    foreach (string t in aliases)
                    {
                        Console.WriteLine("{0}", t);
                    }
                }
                if (addresses.Length > 0)
                {
                    Console.WriteLine("Addresses");
                    foreach (IPAddress t in addresses)
                    {
                        Console.WriteLine("{0}", t.ToString());
                    }
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("Exception occurred while processing the request: {0}", e.Message);
            }
        }

        #endregion 07-AsyncWaitHandle

        #region 08-AsyncOperationDemo

        public static void AsyncOperationDemo()
        {
            string[] args = { };

            if (args.Length == 0 || args[0].Length == 0)
            {
                Console.WriteLine(@"You must specify the name of a host computer.");
                return;
            }
            IAsyncResult result = Dns.BeginGetHostEntry(args[0], null, null);
            Console.WriteLine(@"Processing your request for information...");
            try
            {
                IPHostEntry host = Dns.EndGetHostEntry(result);
                string[] aliases = host.Aliases;
                IPAddress[] addresses = host.AddressList;
                if (aliases.Length > 0)
                {
                    Console.WriteLine(@"Aliases");
                    foreach (string t in aliases)
                    {
                        Console.WriteLine(@"{0}", t);
                    }
                }
                if (addresses.Length > 0)
                {
                    Console.WriteLine(@"Addresses");
                    foreach (IPAddress t in addresses)
                    {
                        Console.WriteLine(@"{0}", t);
                    }
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine(@"An exception occurred while processing the request: {0}", e.Message);
            }
        }

        #endregion 08-AsyncOperationDemo

        #region 09-AsyncResultDemo

        public static void AsyncResultDemo()
        {
            Func<bool> asncRun = Extension.AutoUpdate;
            asncRun.BeginInvoke(Extension.AutoUpdateSupplierMcScoreAsyncCallback, asncRun);
        }

        #endregion 09-AsyncResultDemo

        #region 10-自定义扩展方法

        public static void CusMethod()
        {
            #region 扩展方法

            //在list上添加一个方法，传一个委托到一个方法，满足当前委托条件的变量都给取出来
            List<string> list = new List<string>()
            {
                "1",
                "2",
                "3",
                "4"
            };
            //自己内部模拟的写法
            var temp1 = list.MyFindStrs(Extension.MyCalc);
            foreach (var item in temp1)
            {
                Console.WriteLine(item);
            }

            //普通写法
            var temp2 = list.FindAll(Extension.MyCalc);

            foreach (var item in temp2)
            {
                Console.WriteLine(item);
            }

            var temp3 = list.FindAll(a => int.Parse(a) >= 2);

            foreach (var item in temp3)
            {
                //Console.WriteLine(item);
            }

            #endregion 扩展方法
        }

        #endregion 10-自定义扩展方法

        #region 11-ExcuteXCopyCmd

        public static void ExcuteXCopyCmdDemo()
        {
            string sCmd = @"copy D:\a.txt D:\b.txt";
            Process proIP = new Process();
            proIP.StartInfo.FileName = "cmd.exe";
            proIP.StartInfo.UseShellExecute = false;
            proIP.StartInfo.RedirectStandardInput = true;
            proIP.StartInfo.RedirectStandardOutput = true;
            proIP.StartInfo.RedirectStandardError = true;
            proIP.StartInfo.CreateNoWindow = true;
            proIP.Start();
            proIP.StandardInput.WriteLine(sCmd);
            proIP.StandardInput.WriteLine("exit");
            string strResult = proIP.StandardOutput.ReadToEnd();
            proIP.Close();
            Console.WriteLine(strResult);

            Process compiler = new Process();
            compiler.StartInfo.FileName = "csc.exe";
            compiler.StartInfo.Arguments = "/r:System.dll /out:sample.exe stdstr.cs";
            compiler.StartInfo.UseShellExecute = false;
            compiler.StartInfo.RedirectStandardOutput = true;
            compiler.Start();
            Console.WriteLine(compiler.StandardOutput.ReadToEnd());
            compiler.WaitForExit();
        }

        #endregion 11-ExcuteXCopyCmd

        #region 12-属性相关

        public static void PropertyInfoDemo()
        {
            Dictionary<int, string> attrs = new Dictionary<int, string> { { 1, "1" } };
            Person person = new Person
            {
                Name = "huruiyi",
                Salary = 12345,
                Sex = 'N',
                Equips = new List<Equip>
                {
                    new Equip {Name = "N1", AttackValue = 123},
                    new Equip {Name = "N2", AttackValue = 123},
                    new Equip {Name = "N3", AttackValue = 123},
                },
                Hobbys = new[] { "h1", "h2", "h3", "h4" },
                Attributes = attrs
            };
            Console.WriteLine(typeof(List<>).Name);
            PropertyInfo[] propertyInfos = typeof(Person).GetProperties();
            foreach (PropertyInfo p in propertyInfos)
            {
                string pName = p.Name;
                string name = p.PropertyType.Name;
                Type t = p.PropertyType.GetType();
                bool pg = p.PropertyType.IsGenericType;
                var a = p.GetValue(person, null);
                if (p.PropertyType.Name == "String")
                {
                    p.SetValue(person, "Name", null);
                }
                if (p.PropertyType.Name == "Double")
                {
                    p.SetValue(person, 123.1345, null);
                }
                if (p.PropertyType.Name == "Char")
                {
                    p.SetValue(person, '男', null);
                }

                //if (p.PropertyType.IsGenericType)
                //{
                //    p.SetValue(person, new List<Equip>{
                //    new Equip {Name = "N1111", AttackValue = 123},
                //    new Equip {Name = "N2222", AttackValue = 123},
                //    new Equip {Name = "N3333", AttackValue = 123},
                //});
                //}
            }
        }

        #endregion 12-属性相关

        #region 13-EnumDemo

        public static void EnumDemo()
        {
            for (int i = 0; i < 5; i++)
            {
                var enumName = Enum.GetName(typeof(SocialTypeEnum), i);
                Console.WriteLine("{0}:{1}", i, enumName);
            }
            SocialTypeEnum result;
            bool result1 = Enum.TryParse("1", out result);
            bool result2 = Enum.TryParse<SocialTypeEnum>("2", out result);
            //string result3 = Enum.Format(typeof(SocialTypeEnum), "3", "X");

            string result4 = Enum.GetName(typeof(SocialTypeEnum), 2);
            string[] result5 = Enum.GetNames(typeof(SocialTypeEnum));
            Type result6 = Enum.GetUnderlyingType(typeof(SocialTypeEnum));
            Array array = Enum.GetValues(typeof(SocialTypeEnum));
            Console.WriteLine("数字{0}对应的枚举Name值:{1}", 3, Enum.GetName(typeof(SocialTypeEnum), 3));

            Type ste = typeof(SocialTypeEnum);
            object[] result7 = ste.GetField(SocialTypeEnum.Facebook.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), true);
        }

        #endregion 13-EnumDemo

        #region 14-HashtableDemo

        public static void HashtableDemo()
        {
            Hashtable hashtable1 = new Hashtable();
            hashtable1.Add("zd", "600719");
            hashtable1.Add("name", "denylau");
            hashtable1.Add("sex", "男");
            Console.WriteLine("hashtable长度为：" + hashtable1.Count);

            ArrayList akeys = new ArrayList(hashtable1.Keys);
            akeys.Sort();
            foreach (string skey in akeys)
            {
                Console.Write(skey + ":");
                Console.WriteLine(hashtable1[skey]);
            }

            // 默认输出是无序的
            foreach (DictionaryEntry item in hashtable1)
            {
                Console.WriteLine("{0}:\t{1}", item.Key, item.Value);
            }

            IDictionaryEnumerator en = hashtable1.GetEnumerator();
            while (en.MoveNext())
            {
                string str = en.Value.ToString();
                Console.WriteLine(str);
            }

            foreach (var item in hashtable1.Keys)
            {
                Console.WriteLine(item);
            }

            foreach (var item in hashtable1.Values)
            {
                Console.WriteLine(item);
            }

            //hashtable1 .Clear();

            Console.WriteLine(hashtable1.Contains("zd"));
            Console.WriteLine($"{ hashtable1["zd"] }");

            //hashtable1.Remove("zd");

            Console.WriteLine("**********************************************************");
            Hashtable hashtableItem = new Hashtable();
            hashtableItem.Add("Name", "小红");
            hashtableItem.Add("Sex", "女");
            hashtableItem.Add("Age", 20);

            Hashtable hashtableItem1 = new Hashtable();
            hashtableItem1.Add("Name", "小王");
            hashtableItem1.Add("Sex", "男");
            hashtableItem1.Add("Age", 21);

            Hashtable hashtableItem2 = new Hashtable();
            hashtableItem2.Add("Name", "小李");
            hashtableItem2.Add("Sex", "男");
            hashtableItem2.Add("Age", 22);

            ArrayList list = new ArrayList(hashtableItem.Keys);
            list.Add(hashtableItem);
            list.Add(hashtableItem1);
            list.Add(hashtableItem2);

            Person a = new Person("小王", 20, '男', 12345);
            Person b = new Person("小李", 21, '女', 22345);
            Person c = new Person("小胡", 22, '男', 32345);
            ArrayList array = new ArrayList();
            array.Add(a);
            array.Add(b);
            array.Add(c);
            foreach (Person item in array)
            {
                Person p = item;
                Console.WriteLine(p.Name + " " + p.Age + " " + p.Sex);
            }
        }

        #endregion 14-HashtableDemo

        #region 15-基本数据类型

        public static void BasicType()
        {
            Console.WriteLine("**************************************************");
            Console.WriteLine("short.MinValue:" + short.MinValue);
            Console.WriteLine("short.MaxValue:" + short.MaxValue);
            Console.WriteLine("**************************************************");
            Console.WriteLine("int.MinValue:" + int.MinValue);
            Console.WriteLine("int.MaxValue:" + int.MaxValue);
            Console.WriteLine("**************************************************");
            Console.WriteLine("Int16.MinValue:" + Int16.MinValue);
            Console.WriteLine("Int16.MaxValue:" + Int16.MaxValue);
            Console.WriteLine("**************************************************");
            Console.WriteLine("Int32.MinValue:" + Int32.MinValue);
            Console.WriteLine("Int32.MaxValue:" + Int32.MaxValue);
            Console.WriteLine("**************************************************");
            Console.WriteLine("Int64.MinValue:" + Int64.MinValue);
            Console.WriteLine("Int64.MaxValue:" + Int64.MaxValue);
            Console.WriteLine("**************************************************");
            Console.WriteLine("UInt16.MinValue:" + UInt16.MinValue);
            Console.WriteLine("UInt16.MaxValue:" + UInt16.MaxValue);
            Console.WriteLine("**************************************************");
            Console.WriteLine("UInt32.MinValue:" + UInt32.MinValue);
            Console.WriteLine("UInt32.MaxValue:" + UInt32.MaxValue);
            Console.WriteLine("**************************************************");
            Console.WriteLine("UInt64.MinValue:" + UInt64.MinValue);
            Console.WriteLine("UInt64.MaxValue:" + UInt64.MaxValue);
            Console.WriteLine("**************************************************");
            Console.WriteLine("byte.MinValue:" + byte.MinValue);
            Console.WriteLine("byte.MaxValue:" + byte.MaxValue);
            Console.WriteLine("**************************************************");
            Console.WriteLine("Byte.MinValue:" + Byte.MinValue);
            Console.WriteLine("Byte.MaxValue:" + Byte.MaxValue);
            Console.WriteLine("**************************************************");
            Console.WriteLine("sbyte.MinValue:" + sbyte.MinValue);
            Console.WriteLine("sbyte.MaxValue:" + sbyte.MaxValue);
            Console.WriteLine("**************************************************");
            Console.WriteLine("SByte.MinValue:" + SByte.MinValue);
            Console.WriteLine("SByte.MaxValue" + SByte.MaxValue);
            Console.WriteLine("**************************************************");
        }

        #endregion 15-基本数据类型

        #region 16-YieldDemo

        /*
        foreach (int i in YieldPower(2, 8))
        {
            Console.Write("{0} ", i);
        }
        */

        public static IEnumerable YieldPower(int number, int exponent)
        {
            int counter = 0;
            int result = 1;
            while (counter++ < exponent)
            {
                result = result * number;
                yield return result;
            }
        }

        #endregion 16-YieldDemo

        #region 17-GetEnumeratorDemo

        public static void GetEnumeratorDemo()
        {
            ArrayList arr = new ArrayList() { 12, 13, 1, 4, 15, 16, 17 };
            IEnumerator iEnumerator = arr.GetEnumerator();
            while (iEnumerator.MoveNext())
            {
                Console.WriteLine(iEnumerator.Current);
            }
        }

        #endregion 17-GetEnumeratorDemo

        #region 18-DateTimeDemo

        public static void DateTimeDemo()
        {
            DateTime startTime = DateTime.Now;
            DateTime endTime = DateTime.Now.AddDays(12);
            TimeSpan timeSpan = endTime.Subtract(startTime);
            Console.WriteLine(timeSpan.Days);
        }

        #endregion 18-DateTimeDemo

        #region 19-查看端口是否被占用

        public static bool PortInUse(int port)
        {
            bool inUse = false;

            IPGlobalProperties ipProperties = IPGlobalProperties.GetIPGlobalProperties();
            IPEndPoint[] ipEndPoints = ipProperties.GetActiveTcpListeners();

            foreach (IPEndPoint endPoint in ipEndPoints)
            {
                if (endPoint.Port == port)
                {
                    inUse = true;
                    break;
                }
            }
            return inUse;
        }

        public static void PortCon(object port)
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            IPEndPoint point = new IPEndPoint(ip, (int)port);
            try
            {
                Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                sock.Connect(point);
                Console.WriteLine("{0}成功!", point);
            }
            catch (SocketException e)
            {
                if (e.ErrorCode != 10061)
                {
                    Console.WriteLine(e.Message);
                }
                Console.WriteLine("{0}失败", port);
            }
        }

        #endregion 19-查看端口是否被占用

        #region 20-WeakReferenceDemo

        public static void WeakRefenceDemo()
        {
            WeakReference mathReference = new WeakReference(new MathDemo());
            MathDemo math;
            if (mathReference.IsAlive)
            {
                math = mathReference.Target as MathDemo;
                math.Value = 30;
                Console.WriteLine(@"Value field of math variable contains " + math.Value);
                Console.WriteLine(@"Square of 30 is " + math.GetSquare());
            }
            else
            {
                Console.WriteLine(@"Reference is not available.");
            }

            GC.Collect();

            if (mathReference.IsAlive)
            {
                math = mathReference.Target as MathDemo;
            }
            else
            {
                Console.WriteLine(@"Reference is not available.");
            }
        }

        #endregion 20-WeakReferenceDemo

        #region 21-不安全代码

        public unsafe static void ArrPrintDemo()
        {
            const int al = 10;
            byte[] ints = new byte[al];
            //for (int i = 0; i < 50000; i++)
            //{
            //    new object();
            //}

            fixed (byte* ip = ints)
            {
                for (int i = 0; i < al; i++)
                {
                    Console.WriteLine(Guid.NewGuid().GetHashCode());
                    ip[i] = (byte)new Random().Next(0, 256);
                }
            }

            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
            Array.ForEach(ints, b => Console.WriteLine(b));
        }

        public static unsafe void SquarePtrParamDemo(int i)
        {
            SquareIntPointer(&i);
            Console.WriteLine(i);
        }

        public static void SafeSwapDemo()
        {
            int i = 10, j = 20;
            SafeSwap(ref i, ref j);
            Console.WriteLine("Values after safe swap: i = {0}, j = {1}", i, j);

            unsafe
            {
                UnsafeSwap(&i, &j);
            }
            Console.WriteLine("Values after safe swap: i = {0}, j = {1}", i, j);
        }

        /// <summary>
        /// 求平方
        /// </summary>
        /// <param name="p"></param>
        private static unsafe void SquareIntPointer(int* p)
        {
            *p *= *p;
        }

        /// <summary>
        /// 交换两个数
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        public static void SafeSwap(ref int i, ref int j)
        {
            int temp = i;
            i = j;
            j = temp;
        }

        /// <summary>
        /// 交换两个数
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        public static unsafe void UnsafeSwap(int* i, int* j)
        {
            int temp = *i;
            *i = *j;
            *j = temp;
        }

        public static unsafe void UnsafeAddDemo1()
        {
            int[] a = new int[2];
            a[0] = 1;
            a[1] = 2;
            int b = 3;
            int res = UnsafeAdd1(a, b);
            Console.WriteLine(res);

            unsafe
            {
                int num = 5;
                int* intp = &num;

                int result = UnsafeAdd2(num, intp);
                Console.WriteLine(result);
            }
        }

        public static int UnsafeAdd1(int[] a, int b)
        {
            unsafe
            {
                fixed (int* pa = a)//此处将锁住a，使得在fixed操作块内，a不会被CLR移动
                {
                    return *pa + b;
                }
            }
        }

        public unsafe static int UnsafeAdd2(int a, int* b)//此处使用 指针，需要加入非安全代码关键字unsafe
        {
            return a + *b;
        }

        public static unsafe void UsePointerToPoint()
        {
            PointDemo point;
            PointDemo* p = &point;
            p->x = 100;
            p->y = 200;
            Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx:::" + p->ToString());

            PointDemo point2;
            PointDemo* p2 = &point2;
            (*p2).x = 100;
            (*p2).y = 200;
            Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx:::" + (*p2).ToString());
        }

        public static unsafe void UnsafeStackAlloc()
        {
            char* p = stackalloc char[256];
            for (int k = 0; k < 256; k++)
            {
                p[k] = (char)k;
            }
        }

        public static unsafe void PrintValueAndAddress()
        {
            int myInt;

            int* ptrToMyInt = &myInt;

            *ptrToMyInt = 123;

            Console.WriteLine("Vsalue of myInt {0}", myInt);
            Console.WriteLine("Address of myInt {0:X}", (int)&ptrToMyInt);
        }

        public static unsafe void UseAndPinPoint()
        {
            PointRef pt = new PointRef();
            pt.x = 5;
            pt.y = 6;

            // pin pt in place so it will not be moved or GC-ed.
            fixed (int* p = &pt.x)
            {
                // Use int* variable here!
            }

            // pt is now unpinned, and ready to be GC-ed once the method completes.
            Console.WriteLine("Point is: {0}", pt);
        }

        private static unsafe void UseSizeOfOperator()
        {
            Console.WriteLine("The size of short is {0}.", sizeof(short));
            Console.WriteLine("The size of int is {0}.", sizeof(int));
            Console.WriteLine("The size of long is {0}.", sizeof(long));
            Console.WriteLine("The size of Point is {0}.", sizeof(Point));
        }

        public unsafe static void PointDemo()
        {
            int[] arry = null;
            arry = new int[10];
            fixed (int* pi = arry)
            {
                Console.WriteLine("array = 0x{0:x}", (int)pi);
            }
            int[] intArr = { 12, 13, 14, 15, 16 };
            for (int i = 0; i < intArr.Length; i++)
            {
                Console.WriteLine("array = 0x{0:x}", intArr[i]);
            }
            fixed (int* p = intArr)
            {
                Console.WriteLine((int)p);
            }
        }

        /*
          由于涉及指针类型，因此 stackalloc 要求不安全上下文。 有关更多信息，请参见 不安全代码和指针（C# 编程指南）。
          stackalloc 类似于 C 运行库中的 _alloca。
          以下代码示例计算并演示 Fibonacci 序列中的前 20 个数字。 每个数字是先前两个数字的和。
          在代码中，大小足够容纳 20 个 int 类型元素的内存块是在堆栈上分配的，而不是在堆上分配的。
          该块的地址存储在 fib 指针中。 此内存不受垃圾回收的制约，因此不必将其钉住（通过使用 fixed）。
          内存块的生存期受限于定义它的方法的生存期。 不能在方法返回之前释放内存。
      */

        public static unsafe void Demo28()
        {
            const int arraySize = 20;
            int* fib = stackalloc int[arraySize];
            int* p = fib;
            // The sequence begins with 1, 1.
            *p++ = *p++ = 1;
            for (int i = 2; i < arraySize; ++i, ++p)
            {
                // Sum the previous two numbers.
                *p = p[-1] + p[-2];
            }
            for (int i = 0; i < arraySize; ++i)
            {
                Console.WriteLine(fib[i]);
            }
        }

        #endregion 21-不安全代码

        #region 22-TaskDemo

        public static void TasKdemo1()
        {
            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = source.Token;
            token.Register(delegate { Console.WriteLine("cancel........."); });
            Random rnd = new Random();
            Object lockObj = new Object();

            List<Task<int[]>> tasks = new List<Task<int[]>>();
            TaskFactory factory = new TaskFactory(token);
            for (int taskCtr = 0; taskCtr <= 10; taskCtr++)
            {
                int iteration = taskCtr + 1;
                tasks.Add(factory.StartNew(() =>
                {
                    int value;
                    int[] values = new int[10];
                    for (int ctr = 1; ctr <= 10; ctr++)
                    {
                        lock (lockObj)
                        {
                            value = rnd.Next(0, 101);
                        }
                        if (value == 0)
                        {
                            source.Cancel();
                            Console.WriteLine("Cancelling at task {0}", iteration);
                            break;
                        }
                        values[ctr - 1] = value;
                    }
                    return values;
                }, token));
            }
            try
            {
                Task<double> fTask = factory.ContinueWhenAll(tasks.ToArray(),
                                                             (results) =>
                                                             {
                                                                 Console.WriteLine("Calculating overall mean...");
                                                                 long sum = 0;
                                                                 int n = 0;
                                                                 foreach (var t in results)
                                                                 {
                                                                     foreach (var r in t.Result)
                                                                     {
                                                                         sum += r;
                                                                         n++;
                                                                     }
                                                                 }
                                                                 return sum / (double)n;
                                                             }, token);
                Console.WriteLine("The mean is {0}.", fTask.Result);
            }
            catch (AggregateException ae)
            {
                foreach (Exception e in ae.InnerExceptions)
                {
                    if (e is TaskCanceledException)
                    {
                        Console.WriteLine("Unable to compute mean: {0}", ((TaskCanceledException)e).Message);
                    }
                    else
                    {
                        Console.WriteLine("Exception: " + e.GetType().Name);
                    }
                }
            }
            finally
            {
                source.Dispose();
            }
        }

        public static void TasKdemo2()
        {
            List<Person> pers1 = new List<Person>();
            List<Person> pers2 = new List<Person>();
            List<Person> pers3 = new List<Person>();
            List<Person> pers4 = new List<Person>();
            List<Person> pers5 = new List<Person>();
            Task tack = Task.Factory.StartNew(delegate ()
            {
                GetPseronList1(pers1);
                GetPseronList2(pers2);
                GetPseronList3(pers3);
                GetPseronList4(pers4);
                GetPseronList5(pers5);
            });
            tack.ContinueWith(delegate (Task task)
            {
                Console.WriteLine("执行完成");
            });
        }

        public static void TasKWhenAll3()
        {
            List<Person> pers1 = new List<Person>();
            List<Person> pers2 = new List<Person>();
            List<Person> pers3 = new List<Person>();
            List<Person> pers4 = new List<Person>();
            List<Person> pers5 = new List<Person>();
            Task t1 = Task.Run(() => { GetPseronList1(pers1); });
            Task t2 = Task.Run(() => { GetPseronList2(pers2); });
            Task t3 = Task.Run(() => { GetPseronList3(pers3); });
            Task t4 = Task.Run(() => { GetPseronList4(pers4); });
            Task t5 = Task.Run(() => { GetPseronList5(pers5); });

            Task tb = Task.WhenAll(t1, t2, t3, t4, t5);
            tb.ContinueWith((Task tt) => { Console.WriteLine("执行完成"); });
        }

        public static void TaskContinueWithDemo()
        {
            List<Person> pers1 = new List<Person>();
            List<Person> pers2 = new List<Person>();
            List<Person> pers3 = new List<Person>();
            List<Person> pers4 = new List<Person>();
            List<Person> pers5 = new List<Person>();
            Task task = Task.Factory.StartNew(() =>
            {
                Parallel.Invoke(
                    delegate () { GetPseronList1(pers1); },
                    delegate () { GetPseronList2(pers2); },
                    delegate () { GetPseronList3(pers3); },
                    delegate () { GetPseronList4(pers4); },
                    delegate () { GetPseronList5(pers5); });
            });
            Task.WaitAll();
            task.ContinueWith(delegate (Task tt)
                {
                    Console.WriteLine("执行完成");
                }
            );
        }

        public static void GetPseronList1(List<Person> pers)
        {
            for (int i = 0; i < 5; i++)
            {
                pers.Add(new Person { Name = "pl1Name" + i, Age = i });
                Thread.Sleep(100 * i);
                Console.WriteLine("p1Listp{0}创建成功", i);
            }
        }

        public static void GetPseronList2(List<Person> pers)
        {
            for (int i = 0; i < 5; i++)
            {
                pers.Add(new Person { Name = "pl1Name" + i, Age = i });
                Thread.Sleep(100 * i);
                Console.WriteLine("p2Listp{0}创建成功", i);
            }
        }

        public static void GetPseronList3(List<Person> pers)
        {
            for (int i = 0; i < 5; i++)
            {
                pers.Add(new Person { Name = "pl2Name" + i, Age = i });
                Thread.Sleep(100 * i);
                Console.WriteLine("p3Listp{0}创建成功", i);
            }
        }

        public static void GetPseronList4(List<Person> pers)
        {
            for (int i = 0; i < 5; i++)
            {
                pers.Add(new Person { Name = "pl3Name" + i, Age = i });
                Thread.Sleep(100 * i);
                Console.WriteLine("p4Listp{0}创建成功", i);
            }
        }

        public static void GetPseronList5(List<Person> pers)
        {
            for (int i = 0; i < 5; i++)
            {
                pers.Add(new Person { Name = "pl4Name" + i, Age = i });
                Thread.Sleep(100 * i);
                Console.WriteLine("p5Listp{0}创建成功", i);
            }
        }

        #endregion 22-TaskDemo

        #region 23-SpinWaitDemo

        public static void SpinWaitDemo()
        {
            // Demonstrates:
            //      SpinWait construction
            //      SpinWait.SpinOnce()
            //      SpinWait.NextSpinWillYield
            //      SpinWait.Count
            bool someBoolean = false;
            int numYields = 0;

            // First task: SpinWait until someBoolean is set to true
            Task t1 = Task.Factory.StartNew(() =>
            {
                SpinWait sw = new SpinWait();
                while (!someBoolean)
                {
                    // The NextSpinWillYield property returns true if
                    // calling sw.SpinOnce() will result in yielding the
                    // processor instead of simply spinning.
                    if (sw.NextSpinWillYield) numYields++;
                    sw.SpinOnce();
                }

                // As of .NET Framework 4: After some initial spinning, SpinWait.SpinOnce() will yield every time.
                Console.WriteLine("SpinWait called {0} times, yielded {1} times", sw.Count, numYields);
            });

            // Second task: Wait 100ms, then set someBoolean to true
            Task t2 = Task.Factory.StartNew(() =>
            {
                Thread.Sleep(100);
                someBoolean = true;
            });

            // Wait for tasks to complete
            Task.WaitAll(t1, t2);
        }

        #endregion 23-SpinWaitDemo

        #region 24进制转换_Bin_Oct_Dec_Hex

        public static void Bin_Oct_Dec_Hex()
        {
            Console.WriteLine(UriPartial.Authority);
            Console.WriteLine(UriPartial.Path);
            Console.WriteLine(UriPartial.Query);
            Console.WriteLine(UriPartial.Scheme);
            Console.WriteLine(sizeof(char));
            Console.WriteLine(sizeof(byte));
            Console.WriteLine(sizeof(Byte));

            Console.WriteLine(sizeof(sbyte));
            Console.WriteLine(sizeof(SByte));

            Console.WriteLine(sizeof(short));
            Console.WriteLine(sizeof(ushort));

            Console.WriteLine(sizeof(int));
            Console.WriteLine(sizeof(uint));

            Console.WriteLine(sizeof(Int16));
            Console.WriteLine(sizeof(UInt16));

            Console.WriteLine(sizeof(Int32));
            Console.WriteLine(sizeof(UInt32));

            Console.WriteLine(sizeof(Int64));
            Console.WriteLine(sizeof(UInt64));

            Console.WriteLine(sizeof(decimal));
            Console.WriteLine(sizeof(Decimal));
            Console.WriteLine(sizeof(float));

            Console.WriteLine(sizeof(long));
            Console.WriteLine(sizeof(ulong));
            Console.WriteLine(sizeof(Single));

            Console.WriteLine(sizeof(UriPartial));

            for (int i = 0; i < 30; i++)
            {
                Console.WriteLine($"{i.ToString()} {i.ToString("x")} {i.ToString("x2")} {Convert.ToString(i, 2)} {Convert.ToString(i, 8)} {Convert.ToString(i, 16)}");
            }
        }

        #endregion 24进制转换_Bin_Oct_Dec_Hex

        #region 25-XMLDemo

        public static void XMLDemo1()
        {
            //删除节点
            //XDocument XMLDoc = XDocument.Load(path);
            //XElement elment = (from xml1 in XMLDoc.Descendants("Node")
            //                   select xml1).FirstOrDefault();
            //elment.Remove();
            //XMLDoc.Save(path);

            string xmlInfo = Properties.Resources.XML;

            DirectoryInfo basrDir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            DirectoryInfo codeDir = basrDir.Parent.Parent;
            string path = Path.Combine(codeDir.FullName, "Resource", "XML.xml");

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(path);
            XmlNodeList xmlNodeList = xmlDocument.SelectNodes("/info/collage");
            foreach (XmlNode xmlNode in xmlNodeList)
            {
                Console.WriteLine(xmlNode["name"].InnerText, xmlNode["students"].InnerText);
            }
        }

        public static void XMLDemo2()
        {
            CitiesListResponse response = new CitiesListResponse
            {
                Result = new Result
                {
                    Value = "123465",
                    Code = "001"
                },
                CitiesList = new CityObj[]
                {
                    new CityObj {PinYin="suzhou",Value="苏州" ,HasOutService="123",Info="苏州",Population=123456},
                    new CityObj {PinYin="wuxi",Value="无锡" ,HasOutService="234",Info="无锡",Population=234567},
                    new CityObj {PinYin="nanjing",Value="南京" ,HasOutService="456",Info="南京",Population=345678},
                }
            };
            string str = XmlSerializeHelper.Serializer(response);
            Console.WriteLine(str);
            Console.ReadLine();

            XmlSerializer serializer = new XmlSerializer(typeof(CitiesListResponse));
            serializer.Serialize(Console.Out, response);
            Console.Read();
        }

        #endregion 25-XMLDemo

        #region 26-WebRequestDemo

        public static void WebRequestDemo()
        {
            WebRequest request = WebRequest.Create("http://www.baidu.com");
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();

            Console.WriteLine("响应信息，内容长度：{0}，类型:{1},Uri:{2}", response.ContentLength, response.ContentType, response.ResponseUri);
            using (StreamReader sr = new StreamReader(stream))
            {
                Console.Write(sr.ReadToEnd());
            }
        }

        #endregion 26-WebRequestDemo

        #region 27-DirectorySecurity

        public static void DirectorySecurityDemo0()
        {
            IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());

            //IPHostEntry ent0 = Dns.GetHostByAddress("10.101.42.77");
            IPHostEntry ent1 = Dns.GetHostEntry(hostEntry.HostName);
            IPHostEntry name = Dns.GetHostEntry("hry6464");
            string hostName = Dns.GetHostName();
            Console.Write("Provide full directory path: ");
            string mentionedDir = @"D:\";
            try
            {
                DirectoryInfo myDir = new DirectoryInfo(mentionedDir);

                if (myDir.Exists)
                {
                    DirectorySecurity myDirSec = myDir.GetAccessControl();

                    foreach (FileSystemAccessRule fileRule in myDirSec.GetAccessRules(true, true, typeof(NTAccount)))
                    {
                        Console.WriteLine("{0} {1} {2} access for {3}", mentionedDir, fileRule.AccessControlType == AccessControlType.Allow ? "provides" : "denies", fileRule.FileSystemRights, fileRule.IdentityReference);
                    }
                }
            }
            catch
            {
                Console.WriteLine("Incorrect directory provided!");
            }
        }

        public static void DirectorySecurityDemo1()
        {
            DirectorySecurity security = new DirectorySecurity();
            const string path = @"D:\temp";
            //设置权限的应用为文件夹本身、子文件夹及文件,所以需要InheritanceFlags.ContainerInherit 或 InheritanceFlags.ObjectInherit
            security.AddAccessRule(new FileSystemAccessRule("NETWORK SERVICE",
                FileSystemRights.FullControl, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                PropagationFlags.None, AccessControlType.Allow));
            security.AddAccessRule(new FileSystemAccessRule("Everyone",
                FileSystemRights.FullControl, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));
            Directory.SetAccessControl(path, security);
        }

        #endregion 27-DirectorySecurity

        #region 28-字符串按指定长度分割

        public static void Demo31()
        {
            List<int> intList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            // intList.Find(m => m > 5)

            string longStr = @"标准通用标记语言下的一个应用HTML标准自1999年12月发布的HTML4.01后，后继的HTML5和其它标准被束之高阁，为了推动Web标准化运动的发展，一些公司联合起来，成立了一个叫做 Web Hypertext Application Technology Working Group （Web超文本应用技术工作组 -WHATWG） 的组织。WHATWG 致力于 Web 表单和应用程序，而W3C（World Wide Web Consortium，万维网联盟） 专注于XHTML2.0。在 2006 年，双方决定进行合作，来创建一个新版本的 HTML。";

            int count = (int)Math.Ceiling(longStr.Length / 100.0);
            string[] logStr = new string[count];

            for (int i = 0; i < count; i++)
            {
                if (i + 1 == count)
                {
                    logStr[i] = longStr.Substring(100 * i);
                }
                else
                {
                    logStr[i] = longStr.Substring(100 * i, 100);
                }
            }

            Console.WriteLine("原始");
            Console.WriteLine(longStr);
            Console.WriteLine("+++++++++++++++++++++++++++++++");
            foreach (string item in logStr)
            {
                Console.Write(item);
            }
        }

        #endregion 28-字符串按指定长度分割

        #region 29-AppDomain_AttachDb

        public static void Demo32()
        {
            string dataDir = AppDomain.CurrentDomain.BaseDirectory;
            if (dataDir.EndsWith(@"\bin\Debug\") || dataDir.EndsWith(@"\bin\Release\"))
            {
                dataDir = Directory.GetParent(dataDir).Parent.Parent.FullName;
                AppDomain.CurrentDomain.SetData("DataDirectory", dataDir);
            }
            Console.WriteLine("请输入用户名：");
            string username = Console.ReadLine();
            Console.WriteLine("请输入密码：");
            string password = Console.ReadLine();
            // admin 123456
            //  string ConStr = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\T_Test.mdf;Integrated Security=True;User Instance=True";
            string ConStr = @"Data Source=.;AttachDbFilename=|DataDirectory|\T_Test.mdf;uid=sa;pwd=sa";
            using (SqlConnection conn = new SqlConnection(ConStr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = string.Format("select * from T_Test Where UserName='{0}'", username);
                    using (SqlDataReader read = cmd.ExecuteReader())
                    {
                        if (read.Read())
                        {
                            string dbpassword = read.GetString(read.GetOrdinal("Password"));
                            if (password == dbpassword)
                            {
                                Console.WriteLine("登陆成功");
                            }
                            else
                            {
                                Console.WriteLine("密码错误，登录失败");
                            }
                        }
                        else
                        {
                            Console.WriteLine("无此用户名！");
                        }
                    }
                }
            }
        }

        #endregion 29-AppDomain_AttachDb

        #region 30-反射获取方法名

        public static void GetMethodsDemo()
        {
            Type t = typeof(ClassDemo);

            MethodInfo[] m01 = t.GetMethods(BindingFlags.CreateInstance);
            MethodInfo[] m02 = t.GetMethods(BindingFlags.DeclaredOnly);
            MethodInfo[] m03 = t.GetMethods(BindingFlags.Default);
            MethodInfo[] m04 = t.GetMethods(BindingFlags.ExactBinding);
            MethodInfo[] m05 = t.GetMethods(BindingFlags.FlattenHierarchy);
            MethodInfo[] m06 = t.GetMethods(BindingFlags.GetField);
            MethodInfo[] m07 = t.GetMethods(BindingFlags.GetProperty);
            MethodInfo[] m08 = t.GetMethods(BindingFlags.IgnoreCase);
            MethodInfo[] m09 = t.GetMethods(BindingFlags.IgnoreReturn);
            MethodInfo[] m10 = t.GetMethods(BindingFlags.Instance);
            MethodInfo[] m11 = t.GetMethods(BindingFlags.InvokeMethod);
            MethodInfo[] m12 = t.GetMethods(BindingFlags.NonPublic);
            MethodInfo[] m13 = t.GetMethods(BindingFlags.OptionalParamBinding);
            MethodInfo[] m14 = t.GetMethods(BindingFlags.Public);
            MethodInfo[] m15 = t.GetMethods(BindingFlags.PutDispProperty);
            MethodInfo[] m16 = t.GetMethods(BindingFlags.PutRefDispProperty);
            MethodInfo[] m17 = t.GetMethods(BindingFlags.SetField);
            MethodInfo[] m18 = t.GetMethods(BindingFlags.SetProperty);
            MethodInfo[] m19 = t.GetMethods(BindingFlags.Static);
            MethodInfo[] m20 = t.GetMethods(BindingFlags.SuppressChangeType);
            MethodInfo[] m21 = t.GetMethods();

            MethodInfo[] m22 = t.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public);
            foreach (MethodInfo item in m22)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine();
            MethodInfo[] m23 = t.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            foreach (MethodInfo item in m23)
            {
                Console.WriteLine(item.Name);
            }
            string methodName1 = MethodInfo.GetCurrentMethod().Name;
            string methodName2 = MethodBase.GetCurrentMethod().Name;
        }

        #endregion 30-反射获取方法名

        #region 31-HttpListenerDemo

        public static void HttpListenerDemo1()
        {
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:1231/");
            listener.Start();
            Console.WriteLine("Listening...");
            HttpListenerContext context = listener.GetContext();
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;
            string responseString = "<HTML><BODY> Hello world!</BODY></HTML>";
            byte[] buffer = Encoding.UTF8.GetBytes(responseString);
            response.ContentLength64 = buffer.Length;
            Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            output.Close();
            listener.Stop();
        }

        public static void HttpListenerDemo2()
        {
            if (HttpListener.IsSupported)
            {
                HttpListener listener = new HttpListener();
                listener.Prefixes.Add("http://+:8080/");
                listener.Start();
                while (true)
                {
                    Console.Write(DateTime.Now.ToString());
                    HttpListenerContext context = listener.GetContext();
                    string page = context.Request.Url.LocalPath.Replace("/", "");
                    String query = context.Request.Url.Query.Replace("?", "");
                    StreamReader sr = new StreamReader(context.Request.InputStream);
                    Console.WriteLine(sr.ReadToEnd());
                    Console.WriteLine("接收到请求{0}{1}", page, query);
                    StreamWriter sw = new StreamWriter(context.Response.OutputStream);
                    sw.Write("Hello World!");
                    sw.Flush();
                    context.Response.Close();
                }
            }
        }

        #endregion 31-HttpListenerDemo

        #region 32-XmlSerializerDemo

        public static void XmlSerializerDemo()
        {
            //XmlMapping
            XMLPlatformModel model = new XMLPlatformModel
            {
                CheckCode = "180014190010",
                Token = "H29G3-MZTKQ535-D7T95OAK-1PKOEV48",
                AplData = new AplDataPlatform
                {
                    Code = "01"
                }
            };

            StringBuilder sb = new StringBuilder();
            StringWriter tw = new StringWriter(sb);
            XmlSerializer sz = new XmlSerializer(typeof(XMLPlatformModel));
            sz.Serialize(tw, model);
            tw.Close();
            Console.WriteLine(sb.ToString());
        }

        #endregion 32-XmlSerializerDemo

        #region Environment信息获取

        public static void EnvironmentDemo()
        {
            string commandLine = Environment.CommandLine;
            string currentDirectory = Environment.CurrentDirectory;
            int currentManagedThreadId = Environment.CurrentManagedThreadId;
            //int ecode = Environment.ExitCode;
            //Environment.Exit(ecode);
            string[] cas = Environment.GetCommandLineArgs();
            string ev = Environment.GetEnvironmentVariable("Path");
            Environment.GetLogicalDrives();
            bool is64 = Environment.Is64BitOperatingSystem;
            bool is64p = Environment.Is64BitProcess;
            string machineName = Environment.MachineName;
            string nl = Environment.NewLine;
            OperatingSystem osVersion = Environment.OSVersion;
            int processorCount = Environment.ProcessorCount;
            string systemDirectory = Environment.SystemDirectory;
            int systemPageSize = Environment.SystemPageSize;
            int tickCount = Environment.TickCount;
            string userDomainName = Environment.UserDomainName;
            string userName = Environment.UserName;
            Version v = Environment.Version;
            long workingSet = Environment.WorkingSet;
            string computerName = Environment.GetEnvironmentVariable("ComputerName");
        }

        #endregion Environment信息获取

        #region 获取注册表的建

        public static void RegistryDemo()
        {
            Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE");
            if (rk != null)
            {
                String[] names = rk.GetSubKeyNames();
                foreach (string item in names)
                {
                    Console.WriteLine(item);
                }
            }
        }

        #endregion 获取注册表的建

        #region 获取电脑已安装软件

        public static void GetCurrentInstall()
        {
            StringBuilder result = new StringBuilder();
            for (int index = 0; ; index++)
            {
                StringBuilder productCode = new StringBuilder(39);
                if (MsiEnumProducts(index, productCode) != 0)
                {
                    break;
                }

                foreach (string property in new string[] { "ProductName", "Publisher", "VersionString", })
                {
                    int charCount = 512;
                    StringBuilder value = new StringBuilder(charCount);

                    if (MsiGetProductInfo(productCode.ToString(), property, value, ref charCount) == 0)
                    {
                        value.Length = charCount;
                        result.AppendLine(value.ToString());
                    }
                }
                result.AppendLine();
            }
            Console.WriteLine(result.ToString());
        }

        #endregion 获取电脑已安装软件

        #region 下载相关

        public static void DownLoadDemo1()
        {
            WebClient webClient = new WebClient();
            byte[] bytes = webClient.DownloadData("http://img1.40017.cn/cn/s/yry/img/shouceV1.1.pdf");
            HttpContext.Current.Response.BinaryWrite(bytes);
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("示例图片abc12.pdf"));
        }

        public static void DownLoadDemo2()
        {
            HttpContext.Current.Response.WriteFile(@"H:\Workplace\WebApp\Image\示例图片abc12.jpg", true);
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("示例图片abc12.jpg"));
        }

        #endregion 下载相关

        #region 反射系列

        public static void ReflectionClass1Demo()
        {
            #region Demo1 GetConstructors()

            ConstructorInfo[] p = typeof(ReflectionClass1).GetConstructors();
            Console.WriteLine(p.Length);

            foreach (ConstructorInfo t in p)
            {
                Console.WriteLine(t.IsStatic + "_" + t.DeclaringType);
                MethodBody mb = t.GetMethodBody();
            }

            #endregion Demo1 GetConstructors()

            ConstructorInfo[] p1 = typeof(ReflectionClass1).GetConstructors(BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine(p1.Length);

            foreach (ConstructorInfo t in p1)
            {
                Console.WriteLine(t.IsStatic);
            }
        }

        /// <summary>
        /// 使用反射获得类中所支持的方法，还有方法的信息。
        /// </summary>
        public static void ReflectionClass2Demo()
        {
            Type t = typeof(ReflectionClass2);   //获取描述MyClassA类型的Type对象
            Console.WriteLine("Analyzing methods in " + t.Name);  //t.Name="ReflectionClass2"

            MethodInfo[] mi = t.GetMethods();  //MethodInfo对象在System.Reflection命名空间下。
            foreach (MethodInfo m in mi) //遍历mi对象数组
            {
                Console.Write(m.ReturnType.Name); //返回方法的返回类型
                Console.Write(" " + m.Name + "("); //返回方法的名称

                ParameterInfo[] pi = m.GetParameters();  //获取方法参数列表并保存在ParameterInfo对象数组中
                for (int i = 0; i < pi.Length; i++)
                {
                    Console.Write(pi[i].ParameterType.Name); //方法的参数类型名称
                    Console.Write(" " + pi[i].Name);  // 方法的参数名
                    if (i + 1 < pi.Length)
                    {
                        Console.Write(", ");
                    }
                }
                Console.Write(")");
                Console.WriteLine(); //换行
            }
        }

        /// <summary>
        /// GetMethods(BindingFlags bindingAttr)这个方法，参数可以使用or把两个或更多标记连接在一起，
        /// 实际上至少要有Instance（或Static）与Public（或NonPublic）标记。否则将不会获取任何方法。
        /// </summary>
        public static void ReflectionClass3Demo()
        {
            /*
            DeclareOnly:仅获取指定类定义的方法，而不获取所继承的方法；
            Instance：获取实例方法
            NonPublic: 获取非公有方法
            Public： 获取共有方法
            Static：获取静态方法
            */
            Type t = typeof(ReflectionClass3);   //获取描述ConApp3类型的Type对象
            Console.WriteLine("Analyzing methods in " + t.Name);  //t.Name="ReflectionClass3"

            MethodInfo[] mi = t.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);  //不获取继承方法，为实例方法，为公开的
            foreach (MethodInfo m in mi) //遍历mi对象数组
            {
                Console.Write(m.ReturnType.Name); //返回方法的返回类型
                Console.Write(" " + m.Name + "("); //返回方法的名称

                ParameterInfo[] pi = m.GetParameters();  //获取方法参数列表并保存在ParameterInfo对象数组中
                for (int i = 0; i < pi.Length; i++)
                {
                    Console.Write(pi[i].ParameterType.Name); //方法的参数类型名称
                    Console.Write(" " + pi[i].Name);  // 方法的参数名
                    if (i + 1 < pi.Length)
                    {
                        Console.Write(",");
                    }
                }
                Console.Write(")");
                Console.WriteLine(); //换行
            }
        }

        public static void ReflectionClass4Demo()
        {
            Type t = typeof(ReflectionClass4);
            ReflectionClass4 reflectOb = new ReflectionClass4(10, 20);
            reflectOb.Show();  //输出为： x:10, y:20
            MethodInfo[] mi = t.GetMethods();
            foreach (MethodInfo m in mi)
            {
                ParameterInfo[] pi = m.GetParameters();

                if (m.Name.Equals("Set", StringComparison.Ordinal) && pi[0].ParameterType == typeof(int))
                {
                    object[] args = new object[2];
                    args[0] = 9;
                    args[1] = 10;
                    //参数reflectOb,为一个对象引用，将调用他所指向的对象上的方法，如果为静态方法这个参数必须设置为null
                    //参数args，为调用方法的参数数组，如果不需要参数为null
                    m.Invoke(reflectOb, args);   //调用MyClass类中的参数类型为int的Set方法，输出为Inside set(int,int).x:9, y:10
                }
            }
        }

        /// <summary>
        /// 反射获取构造函数并实例化
        /// </summary>
        public static void ReflectionClass5Demo()
        {
            /*
            在这之前的阐述中，由于Class类型的对象是都是显式创建的，
            因此使用反射技术调用Class类中的方法是没有任何优势的，
            还不如以普通方式调用方便简单呢。
            但是，如果对象是在运行时动态创建的，反射功能的优势就会显示出来。
            在这种情况下，要先获取一个构造函数列表，然后调用列表中的某个构造函数，创建一个该类型的实例。
            通过这种机制，可以在运行时实例化任意类型的对象，而不必在声明语句中指定类型。
            */
            Type t = typeof(ReflectionClass5);
            ConstructorInfo[] ci = t.GetConstructors(); //使用这个方法获取构造函数列表

            int x;
            for (x = 0; x < ci.Length; x++)
            {
                ParameterInfo[] pi = ci[x].GetParameters(); //获取当前构造函数的参数列表
                if (pi.Length == 2) break; //如果当前构造函数有2个参数，则跳出循环
            }

            if (x == ci.Length)
            {
                return;
            }

            object[] consargs = new object[2];
            consargs[0] = 10;
            consargs[1] = 20;
            object reflectOb = ci[x].Invoke(consargs); //实例化一个这个构造函数有两个参数的类型对象,如果参数为空，则为null
            ReflectionClass5 ac5 = reflectOb as ReflectionClass5;
            //实例化后，调用ConApp5中的方法
            MethodInfo[] mi = t.GetMethods(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance);
            foreach (MethodInfo m in mi)
            {
                if (m.Name.Equals("sum", StringComparison.Ordinal))
                {
                    int val = (int)m.Invoke(reflectOb, null);
                    Console.WriteLine(@" sum is " + val); //输出 sum is 30
                }
            }
        }

        #endregion 反射系列

        #region 发送邮件

        public static void SendEmail()
        {
            SmtpClient client = new SmtpClient("smtp.163.com", 25)
            {
                Credentials = new NetworkCredential("13372171750@163.com", "mima")
            };
            using (MailMessage msg = new MailMessage())
            {
                msg.From = new MailAddress("13372171750@163.com");
                msg.Subject = "Subject..........Greetings from Visual C# Recipes";
                msg.Body = "Body.................This is a message from Recipe 10-07 of";
                msg.Attachments.Add(new Attachment(@"ConsoleOutput.txt", "text/plain"));
                msg.Attachments.Add(new Attachment(@"ConApp.exe", "application/octet-stream"));
                msg.To.Add(new MailAddress("807776962@qq.com"));

                client.Send(msg);
            }
            Console.WriteLine("发送成功");
        }

        #endregion 发送邮件

        #region 控制台文本输出

        public static void StreamWriterSetOut()
        {
            StreamWriter sw = new StreamWriter(@"ConsoleOutput.txt");
            Console.SetOut(sw);

            Console.WriteLine("Here is the result:");
            Console.WriteLine("Processing......");
            Console.WriteLine("OK!");

            sw.Flush();
            sw.Close();

            //控制台输出重定向: > F:\ConsoleOutput.txt
        }

        #endregion 控制台文本输出

        #region Md5Token

        #region GetMd5

        public static string GetMd5(string input, string charset)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] data = md5.ComputeHash(Encoding.GetEncoding(charset).GetBytes(input));
            StringBuilder builder = new StringBuilder(32);
            foreach (byte t in data)
            {
                builder.Append(t.ToString("x2"));
            }
            return builder.ToString();
        }

        #endregion GetMd5

        #region GetTokenDemo

        public static void Md5TokenDemo()
        {
            string timestamp = DateTime.Now.ToString();

            DateTime stamp;
            DateTime.TryParse(timestamp, out stamp);
            StringBuilder securityKey = new StringBuilder();

            securityKey.Append(GetMd5(stamp.ToString("yyyy"), "UTF-8"));
            securityKey.Append(GetMd5(stamp.ToString("MM"), "UTF-8"));
            securityKey.Append(GetMd5(stamp.ToString("dd"), "UTF-8"));
            securityKey.Append(GetMd5(stamp.ToString("HH"), "UTF-8"));
            securityKey.Append(GetMd5(stamp.ToString("mm"), "UTF-8"));
            securityKey.Append(GetMd5(stamp.ToString("ss"), "UTF-8"));

            string key = GetMd5(securityKey.ToString(), "UTF-8");

            Console.WriteLine(timestamp + "\t" + key);

            bool falg = CheckTokenDemo(timestamp, key);

            Console.WriteLine(falg ? "Success" : "Fail");
        }

        #endregion GetTokenDemo

        #region CheckTokenDemo

        public static bool CheckTokenDemo(string timestamp, string key)
        {
            if (string.IsNullOrEmpty(timestamp) || string.IsNullOrEmpty(key))
            {
                return false;
            }

            DateTime stamp;
            try
            {
                stamp = DateTime.Parse(timestamp);
            }
            catch
            {
                return false;
            }

            TimeSpan timeSpan = new TimeSpan(0, 0, 8);
            if ((DateTime.Now - stamp) <= timeSpan)
            {
                StringBuilder s = new StringBuilder();

                s.Append(GetMd5(stamp.ToString("yyyy"), "UTF-8"));
                s.Append(GetMd5(stamp.ToString("MM"), "UTF-8"));
                s.Append(GetMd5(stamp.ToString("dd"), "UTF-8"));
                s.Append(GetMd5(stamp.ToString("HH"), "UTF-8"));
                s.Append(GetMd5(stamp.ToString("mm"), "UTF-8"));
                s.Append(GetMd5(stamp.ToString("ss"), "UTF-8"));

                if (key == GetMd5(s.ToString(), "UTF-8"))
                {
                    return true;
                }
            }

            return false;
        }

        #endregion CheckTokenDemo

        #endregion Md5Token

        #region ParallelTask

        public static void ParallelTask()
        {
            Console.WriteLine("Start......");
            Task.Factory.StartNew(delegate
            {
                M1();
                M2();
                M3();
            });
            Parallel.Invoke(new[] { new Action(M1), new Action(M2), new Action(M3) });
            Console.WriteLine("End......");
        }

        public static void M1()
        {
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(1000);

                Console.WriteLine("M1............");
            }
        }

        public static void M2()
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(1000);

                Console.WriteLine("M2............");
            }
        }

        public static void M3()
        {
            Thread.Sleep(1000);
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("M3............");
            }
        }

        #endregion ParallelTask

        #region 差集交集并集

        public static void PrintIntList(IEnumerable<int> list)
        {
            foreach (int item in list)
            {
                Console.Write(item.ToString().PadLeft(2, '0') + "\t");
            }
            Console.WriteLine();
        }

        public static void PrintIntList(List<int> list1, List<int> list2)
        {
            Console.Write("list1:");
            PrintIntList(list1);

            Console.WriteLine();
            PrintIntList(list1);
            Console.WriteLine();
        }

        public static void ExceptIntersectUnion()
        {
            List<int> list1 = new List<int>();
            list1.Add(10);
            list1.Add(1);
            list1.Add(4);
            list1.Add(5);
            list1.Add(8);
            list1.Sort();

            List<int> list2 = new List<int>();
            list2.Add(1);
            list2.Add(28);
            list2.Add(4);
            list2.Add(8);
            list2.Add(18);
            list2.Sort();

            PrintIntList(list1, list2);
            Console.WriteLine("+++++++++++++++++++差集+++++++++++++++++++");
            IEnumerable<int> nList1 = list1.Except(list2);
            Console.WriteLine();
            Console.WriteLine("list1.Except(list2)");
            PrintIntList(nList1);

            IEnumerable<int> nList2 = list2.Except(list1);
            Console.WriteLine();
            Console.WriteLine("list2.Except(list1)");
            PrintIntList(nList2);

            Console.WriteLine("+++++++++++++++++++交集+++++++++++++++++++");
            IEnumerable<int> nList3 = list1.Intersect(list2);
            Console.WriteLine();
            Console.WriteLine("list1.Intersect(list2)");
            PrintIntList(nList3);

            IEnumerable<int> nList4 = list2.Intersect(list1);
            Console.WriteLine();
            Console.WriteLine("list2.Intersect(list1)");
            PrintIntList(nList4);

            Console.WriteLine("+++++++++++++++++++并集+++++++++++++++++++");
            IEnumerable<int> nList5 = list2.Union(list1);
            Console.WriteLine();
            Console.WriteLine("list2.Union(list1)");
            PrintIntList(nList5);

            IEnumerable<int> nList6 = list1.Union(list2);
            Console.WriteLine();
            Console.WriteLine("list1.Union(list2)");
            PrintIntList(nList6);
        }

        #endregion 差集交集并集

        public async static void AsyncDemo()
        {
            using (StreamWriter writer = File.CreateText("ConsoleOutput.txt"))
            {
                await writer.WriteLineAsync("First line of example");
                await writer.WriteLineAsync("and second line");
            }
        }

        #region 特性相关

        public static void ValidateAttribute()
        {
            Person person = new Person { Name = "TT", Age = 20 };
            Type type = person.GetType();
            PropertyInfo propertyInfo = type.GetProperty("Age");
            ValidateAgeAttribute validateAgeAttribute = (ValidateAgeAttribute)Attribute.GetCustomAttribute(propertyInfo, typeof(ValidateAgeAttribute));
            Console.WriteLine("允许的最大年龄：" + validateAgeAttribute.MaxAge);
            validateAgeAttribute.Validate(person.Age);
            Console.WriteLine(validateAgeAttribute.ValidateResult);
        }

        #endregion 特性相关

        #region 文件生成

        public static void FontImage()
        {
            //设置画布字体
            Font drawFont = new Font("宋体", 12);
            //实例一个画布起始位置为1.1
            Bitmap image = new Bitmap(1, 1);
            Graphics g = Graphics.FromImage(image);
            //string text = File.ReadAllText("D:\\xx.html", Encoding.GetEncoding("GB2312"));
            string text = "互联网出版许可证编号新出网证(京)";
            SizeF sf = g.MeasureString(text, drawFont, 1024); //设置一个显示的宽度
            image = new Bitmap(image, new Size(Convert.ToInt32(sf.Width), Convert.ToInt32(sf.Height)));
            g = Graphics.FromImage(image);
            g.Clear(Color.White);
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            g.DrawString(text, drawFont, Brushes.Black, new RectangleF(new PointF(0, 0), sf));
            image.Save("D:\\1.jpg", System.Drawing.Imaging.ImageFormat.Png);
            g.Dispose();
            image.Dispose();
        }

        #endregion 文件生成

        public static void DataTableDemo1()
        {
            //DataTable table = new DataTable();
            //table.Columns.AddRange(new DataColumn[]
            //{
            //    new DataColumn("Resource_Id"),
            //    new DataColumn("TA"),
            //    new DataColumn("TB"),
            //    new DataColumn("TC"),
            //    new DataColumn("TD")
            //});
            //table.Rows.Add(1, 1, 2, 0, 0);
            //table.Rows.Add(1, 3, 0, 3, 4);
            //table.Rows.Add(2, 5, 6, 0, 0);
            //table.Rows.Add(2, 7, 0, 7, 8);

            //var aa = from t in table.AsEnumerable()
            //         group t by new { t1 = t.Field<string>("Resource_Id") } into m
            //         select new
            //         {
            //             name = m.Key.t1,
            //             score = m.Sum(n => n.Field<decimal>("TA"))
            //         };
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("name", typeof(string)),
                new DataColumn("sex", typeof(string)),
                new DataColumn("score", typeof(int))
            });
            dt.Rows.Add(new object[] { "张三", "男", 1 });
            dt.Rows.Add(new object[] { "张三", "男", 4 });
            dt.Rows.Add(new object[] { "李四", "男", 100 });
            dt.Rows.Add(new object[] { "李四", "女", 90 });
            dt.Rows.Add(new object[] { "王五", "女", 77 });
            DataTable dtResult = dt.Clone();
            DataTable dtName = dt.DefaultView.ToTable(true, "name", "sex");
            for (int i = 0; i < dtName.Rows.Count; i++)
            {
                DataRow[] rows = dt.Select("name='" + dtName.Rows[i]["name"] + "' and sex='" + dtName.Rows[i]["sex"] + "'");
                //temp用来存储筛选出来的数据
                DataTable temp = dtResult.Clone();
                foreach (DataRow row in rows)
                {
                    temp.Rows.Add(row.ItemArray);
                }

                DataRow dr = dtResult.NewRow();
                dr[0] = dtName.Rows[i][0].ToString();
                dr[1] = temp.Compute("sum(score)", "");
                dtResult.Rows.Add(dr);
            }
        }

        public static void DataTableDemo2()
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[] { new DataColumn("name", typeof(string)),
                                         new DataColumn("sex", typeof(string)),
                                         new DataColumn("score", typeof(decimal)) });
            dt.Rows.Add(new object[] { "张三", "男", 1 });
            dt.Rows.Add(new object[] { "张三", "男", 4 });
            dt.Rows.Add(new object[] { "李四", "男", 100 });
            dt.Rows.Add(new object[] { "李四", "女", 90 });
            dt.Rows.Add(new object[] { "王五", "女", 77 });
            var query = from t in dt.AsEnumerable()
                        group t by new { t1 = t.Field<string>("name"), t2 = t.Field<string>("sex") } into m
                        select new
                        {
                            name = m.Key.t1,
                            sex = m.Key.t2,
                            score = m.Sum(n => n.Field<decimal>("score"))
                        };
            if (query.ToList().Count > 0)
            {
                query.ToList().ForEach(q =>
                {
                    Console.WriteLine(q.name + "," + q.sex + "," + q.score);
                });
            }
        }

        [DllImport("msi.dll", SetLastError = true)]
        private static extern int MsiEnumProducts(int iProductIndex, StringBuilder lpProductBuf);

        [DllImport("msi.dll", SetLastError = true)]
        private static extern int MsiGetProductInfo(string szProduct, string szProperty, StringBuilder lpValueBuf, ref int pcchValueBuf);

        public static void PathDemo()
        {
            AppDomainSetup app1 = AppDomain.CurrentDomain.SetupInformation;
            string entryAssemblyLocation = Assembly.GetEntryAssembly().Location;

            string str1 = Process.GetCurrentProcess().MainModule.FileName;//可获得当前执行的exe的文件名。
            string str2 = Environment.CurrentDirectory;//获取和设置当前目录（即该进程从中启动的目录）的完全限定路径。(备注:按照定义，如果该进程在本地或网络驱动器的根目录中启动，则此属性的值为驱动器名称后跟一个尾部反斜杠（如“C:\”）。如果该进程在子目录中启动，则此属性的值为不带尾部反斜杠的驱动器和子目录路径[如“C:\mySubDirectory”])。
            string str3 = Directory.GetCurrentDirectory(); //获取应用程序的当前工作目录。
            string str4 = System.Windows.Forms.Application.StartupPath;//获取启动了应用程序的可执行文件的路径，不包括可执行文件的名称。
            string str5 = System.Windows.Forms.Application.ExecutablePath;//获取启动了应用程序的可执行文件的路径，包括可执行文件的名称。
            string str6 = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;//获取或设置包含该应用程序的目录的名称。
            string str7 = AppDomain.CurrentDomain.BaseDirectory;//获取基目录，它由程序集冲突解决程序用来探测程序集。
            string str8 = AppDomain.CurrentDomain.FriendlyName;

            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            string codeBase = executingAssembly.CodeBase;
            string location = executingAssembly.Location;
        }

        public static void MathDemo()
        {
            List<int> ids = new List<int>();
            ids.AddRange(new List<int> { 1, 2, 3, 4 });
            ids.AddRange(new List<int> { 5, 6, 7, 8 });
            ids.AddRange(new List<int> { 9, 10, 11, 12 });

            int idg = Convert.ToInt32(Math.Ceiling(ids.Count / 5.0));

            List<int> sInts = new List<int>();
            for (int i = 1; i <= idg; i++)
            {
                sInts = new List<int>();
                sInts.AddRange(ids.Skip((i - 1) * 5).Take(5));

                string jboNumbers = sInts.Aggregate(string.Empty, (current, item) => current + (item + ",")).TrimEnd(',');

                Console.WriteLine(jboNumbers);
            }
        }

        #region 实现IIS应用池的远程回收

        public static void RemoteRecycle()
        {
            ServerManager manager = ServerManager.OpenRemote("184.12.15.157");
            ApplicationPoolCollection appPools = manager.ApplicationPools;
            foreach (var ap in appPools)
            {
                ap.Recycle();
            }
            /*
             * 回收注意事项：
                1.需要添加引用 C:\Windows\System32\inetsrv\Microsoft.Web.Administration.dll ,然后using Microsoft.Web.Administration;
                2.远程账号需要有管理员权限；
                3.远程主机的账号密码添加在服务器的凭据管理器中 (控制面板->凭据管理器) ，能成功使用mstsc 登录即可；
                4.远程主机需要关闭UAC！！ 因为这个问题卡了好几个礼拜才无意发现。
             */
        }

        #endregion 实现IIS应用池的远程回收

        #region IIS配置相关

        public static void AddIsapiCgi()
        {
            //appcmd.exe set config -section:system.webServer/security/isapiCgiRestriction /+"[path='C:\Inetpub\www.contoso.com\wwwroot\isapi\custom.dll',allowed='True',groupId='ContosoGroup',description='Contoso Extension']" /commit:apphost
            using (ServerManager serverManager = new ServerManager())
            {
                Configuration config = serverManager.GetApplicationHostConfiguration();
                ConfigurationSection isapiCgiRestrictionSection = config.GetSection("system.webServer/security/isapiCgiRestriction");
                ConfigurationElementCollection isapiCgiRestrictionCollection = isapiCgiRestrictionSection.GetCollection();

                ConfigurationElement addElement = isapiCgiRestrictionCollection.CreateElement("add");
                addElement["path"] = @"C:\Inetpub\www.contoso.com\wwwroot\isapi\custom.dll";
                addElement["allowed"] = true;
                addElement["groupId"] = @"ContosoGroup";
                addElement["description"] = @"Contoso Extension";
                isapiCgiRestrictionCollection.Add(addElement);
                serverManager.CommitChanges();
            }
        }

        public static void ConfigurationSectionDemo0()
        {
            const string siteName = "fairy.vip";

            using (ServerManager manager = new ServerManager())
            {
                //获得 IIS 站点信息。
                var site = manager.Sites[siteName];

                //获得站点根目录下的“Web.Config”文件配置信息。
                Configuration config = site.GetWebConfiguration();

                ConfigurationSection httpRedirectSection = config.GetSection("system.webServer/httpRedirect");
                /*
                 * 设置节点参数。
                 * enabled：是否启用。
                 * destination：目标 URL 或者文件。
                 * exactDestination：
                 * httpResponseStatus：
                 */
                httpRedirectSection["enabled"] = false;
                httpRedirectSection["destination"] = @"http://www.rapid.com/error/500$S$Q";
                httpRedirectSection["exactDestination"] = true;
                httpRedirectSection["httpResponseStatus"] = @"Temporary";

                //回收应用程序池。
                manager.ApplicationPools[siteName].Recycle();

                //提交。
                manager.CommitChanges();
            }
        }

        public static void ConfigurationSectionDemo1()
        {
            const string isAPI_partialPath = @"v4.0.30319\aspnet_isapi.dll";
            using (ServerManager manager = new ServerManager())
            {
                Configuration config = manager.GetApplicationHostConfiguration();

                ConfigurationSection section = config.GetSection("system.webServer/security/isapiCgiRestriction");

                foreach (ConfigurationElement item in section.GetCollection())
                {
                    if (item.Attributes.Count > 0 && item.Attributes["path"].Value != null && item.Attributes["path"].Value.ToString().EndsWith(isAPI_partialPath))
                    {
                        item.Attributes["allowed"].Value = true;
                    }
                }
                manager.CommitChanges();
            }
        }

        public static void AppSetingSet()
        {
            using (ServerManager serverManager = new ServerManager())
            {
                Configuration config = serverManager.GetWebConfiguration("Default Web Site");
                ConfigurationSection appSettingsSection = config.GetSection("appSettings");
                ConfigurationElementCollection appSettingsCollection = appSettingsSection.GetCollection();
                ConfigurationElement addElement = appSettingsCollection.CreateElement("add");
                addElement["key"] = @"key1";
                addElement["value"] = @"value1";
                appSettingsCollection.Add(addElement);
                serverManager.CommitChanges();
            }
        }

        public static void GetIISRequest()
        {
            using (ServerManager manager = new ServerManager())
            {
                foreach (WorkerProcess w3wp in manager.WorkerProcesses)
                {
                    Console.WriteLine("W3WP()", w3wp.ProcessId);

                    foreach (Request request in w3wp.GetRequests(0))
                    {
                        Console.WriteLine(" - ,,", request.Url, request.ClientIPAddr, request.TimeElapsed, request.TimeInState);
                    }
                }
            }
        }

        #endregion IIS配置相关

        #region 返回有关本地计算机上的 Internet 协议版本 4 (IPv4) 和 IPv6 传输控制协议 (TCP) 连接的信息。

        public static void GetIPDemo()
        {
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            TcpConnectionInformation[] connections = properties.GetActiveTcpConnections();
            foreach (TcpConnectionInformation t in connections)
            {
                Console.Write(@"Local endpoint: {0} ", t.LocalEndPoint);
                Console.Write(@"Remote endpoint: {0} ", t.RemoteEndPoint);
                Console.WriteLine(@"{0}", t.State);
            }
        }

        #endregion 返回有关本地计算机上的 Internet 协议版本 4 (IPv4) 和 IPv6 传输控制协议 (TCP) 连接的信息。

        #region TCP检查端口是否打开

        public static void PortISOpen0()
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            IPEndPoint point = new IPEndPoint(ip, 80);
            try
            {
                TcpClient tcp = new TcpClient();
                tcp.Connect(point);
                Console.WriteLine("打开的端口");
            }
            catch (Exception ex)
            {
                Console.WriteLine("已开启的端口:" + ex.Message);
            }
        }

        #endregion TCP检查端口是否打开

        #region Http检查端口是否打开

        public static void PortISOpen1()
        {
            HttpListener httpListner = new HttpListener();
            httpListner.Prefixes.Add("http://*:8080/");
            httpListner.Start();
            Console.WriteLine("Port: 8080 status: " + (PortInUse(8080) ? "in use" : "not in use"));
        }

        #endregion Http检查端口是否打开

        #region 异步委托

        public static void AsyncCallbackDemo()
        {
            AsyncCallback ac = delegate (IAsyncResult aar)
            {
                Console.WriteLine("跑完了");
                Console.WriteLine(aar.AsyncState);
            };

            AsycRun ar = delegate
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.Write(i + "\t");
                }
            };
            ar.BeginInvoke(ac, "object");
        }

        #endregion 异步委托

        #region 多线程查询端口情况

        public static void Demo()
        {
            for (int i = 1; i <= 8; i++)
            {
                ParameterizedThreadStart pts = x =>
                {
                    for (int j = 1000 * ((int)x - 1) + 1; j <= 1000 * (int)x; j++)
                    {
                        PortCon(j);
                    }
                };

                Thread t = new Thread(pts);
                t.Start(i);
            }
        }

        #endregion 多线程查询端口情况

        #region 应用程序域

        public static void AppDomainDemo1()
        {
            AppDomain.CurrentDomain.SetData("name", "Hello");
            string name = AppDomain.CurrentDomain.GetData("name").ToString();
            Console.WriteLine(name);

            // Create application domain setup information
            AppDomainSetup domaininfo = new AppDomainSetup();
            domaininfo.ConfigurationFile = Environment.CurrentDirectory + "ADSetup.exe.config";
            domaininfo.ApplicationBase = Environment.CurrentDirectory;

            //Create evidence for the new appdomain from evidence of the current application domain
            Evidence adevidence = AppDomain.CurrentDomain.Evidence;

            // Create appdomain
            AppDomain domain = AppDomain.CreateDomain("MyDomain", adevidence, domaininfo);

            // Write out application domain information
            Console.WriteLine("Host domain: " + AppDomain.CurrentDomain.FriendlyName);
            Console.WriteLine("child domain: " + domain.FriendlyName);
            Console.WriteLine();
            Console.WriteLine("Configuration file is: " + domain.SetupInformation.ConfigurationFile);
            Console.WriteLine("Application Base Directory is: " + domain.BaseDirectory);

            AppDomain.Unload(domain);
        }

        public static void AppDomainDemo2()
        {
            // AppDomain.Unload(AppDomain.CurrentDomain);

            if (AppDomain.CurrentDomain.IsDefaultAppDomain())
            {
                Console.WriteLine("hellp");
            }

            //我们自己写一个AppDomain
            // 设置应用程序域
            AppDomainSetup appDomainSetup = new AppDomainSetup();

            //设置程序集不共享
            appDomainSetup.LoaderOptimization = LoaderOptimization.SingleDomain;

            // 主应用程序域创建 程序域
            AppDomain appDomain = AppDomain.CreateDomain("MultThread", null, appDomainSetup);
            // 程序域  执行exe
            // 每个应用程序域  只能执行一个exe，但是可以加载多个 dll
            appDomain.ExecuteAssembly("ConApp.exe");
        }

        #endregion 应用程序域

        #region 把csv文件中的联系人姓名和电话显示出来。简单模拟csv文件，csv文件就是使用,分割数据的文本

        public static void ReadAllLinesDemo()
        {
            // 姓名：张三 电话：15001111113

            string[] lines = File.ReadAllLines("1.csv", Encoding.Default);

            string[] arr = new string[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                string tmp = lines[i].Replace("\"", "");
                string[] array = tmp.Split(',');
                if (array.Length == 3)
                {
                    arr[i] = string.Format("{0} {1}", array[0] + array[1], array[2]);
                }
                else
                {
                    arr[i] = null;
                }
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (!string.IsNullOrEmpty(arr[i]))
                {
                    Console.WriteLine(arr[i]);
                }
            }
        }

        #endregion 把csv文件中的联系人姓名和电话显示出来。简单模拟csv文件，csv文件就是使用,分割数据的文本

        #region 简单泛型

        public static void GenericDemo<T>(T s, T t) where T : class
        {
            Console.WriteLine(s == t);
        }

        public static void GenericDemo()
        {
            string s1 = "target";
            StringBuilder sb = new StringBuilder("target");
            string s2 = sb.ToString();
            GenericDemo(s1, s2);

            CreateInstance<Person>(5);
            Person b = CreateBossInstance<Person>(3);
            b.Name = "Wb";
        }

        private static T CreateInstance<T>(int n) where T : new()
        {
            T t = default(T);
            for (int i = 0; i < n; i++)
            {
                t = new T();
            }
            return t;
        }

        private static T CreateBossInstance<T>(int n) where T : Person, new()
        {
            T t = default(T);
            for (int i = 0; i < n; i++)
            {
                t = new T();
            }
            return t;
        }

        #endregion 简单泛型

        #region 反转字符串

        public static string ReverseDemo(string str)
        {
            //反转字符串
            char[] arr = str.ToCharArray();

            for (int i = 0; i < arr.Length / 2; i++)
            {
                char tmp = arr[i];
                arr[i] = arr[arr.Length - i - 1];
                arr[arr.Length - i - 1] = tmp;
            }
            //string s = new string(arr);
            return string.Join("", arr);
        }

        #endregion 反转字符串

        #region ManualResetEventSlimDemo

        public static void ManualResetEventSlimDemo()
        {
            MRES_SetWaitReset();
            MRES_SpinCountWaitHandle();
        }

        // Demonstrates:
        //      ManualResetEventSlim construction
        //      ManualResetEventSlim.Wait()
        //      ManualResetEventSlim.Set()
        //      ManualResetEventSlim.Reset()
        //      ManualResetEventSlim.IsSet
        private static void MRES_SetWaitReset()
        {
            ManualResetEventSlim mres1 = new ManualResetEventSlim(false); // initialize as unsignaled
            ManualResetEventSlim mres2 = new ManualResetEventSlim(false); // initialize as unsignaled
            ManualResetEventSlim mres3 = new ManualResetEventSlim(true);  // initialize as signaled

            // Start an asynchronous Task that manipulates mres3 and mres2
            var observer = Task.Factory.StartNew(() =>
            {
                mres1.Wait();
                Console.WriteLine("observer sees signaled mres1!");
                Console.WriteLine("observer resetting mres3...");
                mres3.Reset(); // should switch to unsignaled
                Console.WriteLine("observer signalling mres2");
                mres2.Set();
            });

            Console.WriteLine("main thread: mres3.IsSet = {0} (should be true)", mres3.IsSet);
            Console.WriteLine("main thread signalling mres1");
            mres1.Set(); // This will "kick off" the observer Task
            mres2.Wait(); // This won't return until observer Task has finished resetting mres3
            Console.WriteLine("main thread sees signaled mres2!");
            Console.WriteLine("main thread: mres3.IsSet = {0} (should be false)", mres3.IsSet);

            // It's good form to Dispose() a ManualResetEventSlim when you're done with it
            observer.Wait(); // make sure that this has fully completed
            mres1.Dispose();
            mres2.Dispose();
            mres3.Dispose();
        }

        // Demonstrates:
        //      ManualResetEventSlim construction w/ SpinCount
        //      ManualResetEventSlim.WaitHandle
        private static void MRES_SpinCountWaitHandle()
        {
            // Construct a ManualResetEventSlim with a SpinCount of 1000
            // Higher spincount => longer time the MRES will spin-wait before taking lock
            ManualResetEventSlim mres1 = new ManualResetEventSlim(false, 1000);
            ManualResetEventSlim mres2 = new ManualResetEventSlim(false, 1000);

            Task bgTask = Task.Factory.StartNew(() =>
            {
                // Just wait a little
                Thread.Sleep(100);

                // Now signal both MRESes
                Console.WriteLine("Task signalling both MRESes");
                mres1.Set();
                mres2.Set();
            });

            // A common use of MRES.WaitHandle is to use MRES as a participant in
            // WaitHandle.WaitAll/WaitAny.  Note that accessing MRES.WaitHandle will
            // result in the unconditional inflation of the underlying ManualResetEvent.
            WaitHandle.WaitAll(new WaitHandle[] { mres1.WaitHandle, mres2.WaitHandle });
            Console.WriteLine("WaitHandle.WaitAll(mres1.WaitHandle, mres2.WaitHandle) completed.");

            // Clean up
            bgTask.Wait();
            mres1.Dispose();
            mres2.Dispose();
        }

        #endregion ManualResetEventSlimDemo

        public static void RunPowerShellCmd()
        {
            /*
             using System.Management.Automation;
             using System.Management.Automation.Runspaces;
             */
            // code from 1-code.codeprojet.com
            // Create a RunSpace to host the Powershell script enviroment
            // using RunspaceFactory.CreateRunSpace
            Runspace runSpace = RunspaceFactory.CreateRunspace();
            runSpace.Open();

            // Create a Pipeline to host commands to be executed using
            // Runspace.CreatePipeline
            Pipeline pipeLine = runSpace.CreatePipeline();

            // Create a Command object by passing the command to the constructor
            Command getProcessCStarted = new Command("Get-Process");

            // Add parameters to the Command.
            getProcessCStarted.Parameters.Add("name", "C*");

            // Add the commands to the Pipeline
            pipeLine.Commands.Add(getProcessCStarted);

            // Run all commands in the current pipeline by calling Pipeline.Invoke.
            // It returns a System.Collections.ObjectModel.Collection object.
            // In this example, the executed script is "Get-Process -name C*".
            Collection<PSObject> cNameProcesses = pipeLine.Invoke();

            foreach (PSObject psObject in cNameProcesses)
            {
                Process process = psObject.BaseObject as Process;
                Console.WriteLine("Process Name: {0}", process.ProcessName);
            }
        }

        #region Demo

        public static void DynamicDemo0()
        {
            dynamic d = new DynamicClass();
            d.X = 123;
            d.Y = "123";
            //d.Z = 123.456; 未包含Z的定义
            Console.WriteLine(d.Return(123));
            Console.WriteLine(d.Return("123"));
            Console.WriteLine(d.Return(123.456));
        }

        private static void DynamicDemo1()
        {
            dynamic calc = Calculator.GetCalculator();
            int r = calc.Add(2, 3);
            Console.WriteLine(r);
        }

        private static void StaticDemo()
        {
            var calc = new Calculator();
            int r = calc.Add(2, 3);
            Console.WriteLine(r);
        }

        private static void IronPython()
        {
            // http://ironpython.codeplex.com
            // var engine = Python.CreateEngine();
            // dynamic scope = engine.ImportModule("Calculator");

            //  var calc = scope.GetCalculator();
            // int r = calc.Add(2, 3);
            // Console.WriteLine(r);
        }

        public void BulidMethod()
        {
            //得到当前的应用程序域
            AppDomain appDm = AppDomain.CurrentDomain;
            //初始化AssemblyName的一个实例
            AssemblyName an = new AssemblyName();
            //设置程序集的名称
            an.Name = "EmitLind";
            //动态的在当前应用程序域创建一个应用程序集
            AssemblyBuilder ab = appDm.DefineDynamicAssembly(an, AssemblyBuilderAccess.Run);
            //动态在程序集内创建一个模块
            ModuleBuilder mb = ab.DefineDynamicModule("EmitLind");
            //动态的在模块内创建一个类
            TypeBuilder tb = mb.DefineType("HelloEmit", TypeAttributes.Public | TypeAttributes.Class);
            //动态的为类里创建一个方法
            MethodBuilder mdb = tb.DefineMethod("HelloWord", MethodAttributes.Public, null, new Type[] { typeof(string) });

            //得到该方法的ILGenerator
            ILGenerator ilG = mdb.GetILGenerator();
            ilG.Emit(OpCodes.Ldstr, "Hello：{0}");
            //加载传入方法的参数到堆栈
            ilG.Emit(OpCodes.Ldarg_1);
            //调用Console.WriteLine方法，输出传入的字符
            ilG.Emit(OpCodes.Call, typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string), typeof(string) }));

            ilG.Emit(OpCodes.Ret);
            //创建类的Type对象
            Type tp = tb.CreateType();
            //实例化一个类
            object ob = Activator.CreateInstance(tp);
            //得到类中的方法，通过Invoke来触发方法的调用..
            MethodInfo mdi = tp.GetMethod("HelloWord");
            mdi.Invoke(ob, new object[] { "Hello Lind" });
        }

        public void BulidMethodRet()
        {
            //得到当前的应用程序域
            AppDomain appDm = AppDomain.CurrentDomain;
            //初始化AssemblyName的一个实例
            AssemblyName an = new AssemblyName();
            //设置程序集的名称
            an.Name = "EmitLind";
            //动态的在当前应用程序域创建一个应用程序集
            AssemblyBuilder ab = appDm.DefineDynamicAssembly(an, AssemblyBuilderAccess.Run);
            //动态在程序集内创建一个模块
            ModuleBuilder mb = ab.DefineDynamicModule("EmitLind");
            //动态的在模块内创建一个类
            TypeBuilder tb = mb.DefineType("HelloEmit", TypeAttributes.Public | TypeAttributes.Class);

            //动态的为类里创建一个方法
            MethodBuilder mdb = tb.DefineMethod("HelloWorldReturn", MethodAttributes.Public, typeof(string), new Type[] { typeof(string), typeof(string) });

            //得到该方法的ILGenerator
            ILGenerator ilG = mdb.GetILGenerator();
            ilG.Emit(OpCodes.Ldstr, "你好：{0}-{1}");
            //加载传入方法的参数到堆栈
            ilG.Emit(OpCodes.Ldarg_1);
            ilG.Emit(OpCodes.Ldarg_2);
            //调用Console.WriteLine方法，输出传入的字符
            ilG.Emit(OpCodes.Call, typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string), typeof(string), typeof(string) }));

            // ilG.Emit(OpCodes.Pop);//加这个就有问题了
            //返回值部分
            LocalBuilder local = ilG.DeclareLocal(typeof(string));
            ilG.Emit(OpCodes.Ldstr, "Return Value：{0}");
            ilG.Emit(OpCodes.Ldarg_1);
            ilG.Emit(OpCodes.Call, typeof(string).GetMethod("Format", new Type[] { typeof(string), typeof(string) }));
            ilG.Emit(OpCodes.Stloc_0, local);
            ilG.Emit(OpCodes.Ldloc_0, local);
            ilG.Emit(OpCodes.Ret);
            //创建类的Type对象
            Type tp = tb.CreateType();
            //实例化一个类
            object ob = Activator.CreateInstance(tp);
            //得到类中的方法，通过Invoke来触发方法的调用..
            MethodInfo mdi = tp.GetMethod("HelloWorldReturn");
            mdi.Invoke(ob, new object[] { "Hello Lind", "OK" });
        }

        private static void ClassDemo()
        {
            StaticDemo();
            DynamicDemo0();
            DynamicDemo1();
            IronPython();
        }

        #endregion Demo

        #region ExpressionDemo

        public static void ExpressionDemo()
        {
            string idField = ((MemberExpression)((Expression<Func<Person, int>>)(c => c.Age)).Body).Member.Name;
            string textField = ((MemberExpression)((Expression<Func<Person, string>>)(c => c.Name)).Body).Member.Name;
        }

        #endregion ExpressionDemo

        #region MyRegion

        public static void BitmapDemo0()
        {
            Bitmap bmp = new Bitmap(600, 500);
            Graphics dc = Graphics.FromImage(bmp);
            RectangleF[] rects = dc.Clip.GetRegionScans(new Matrix());

            for (int i = 0; i < rects.GetLength(0); i++)
                Console.WriteLine("clip: " + rects[i].ToString());

            Console.WriteLine("VisibleClipBounds: " + dc.VisibleClipBounds);
            Console.WriteLine("IsVisible Point 650, 650: " + dc.IsVisible(650, 650));
            Console.WriteLine("IsVisible Point 0, 0: " + dc.IsVisible(0.0f, 0.0f));

            Console.WriteLine("IsVisible Rectangle (20,20,100,100): " + dc.IsVisible(new Rectangle(20, 20, 100, 100)));
            Console.WriteLine("IsVisible Rectangle (1000, 1000,100,100): " + dc.IsVisible(new RectangleF(1000, 1000, 100, 100)));
        }

        public static void BitmapDemo1()
        {
            float width = 400.0F;
            float height = 800.0F;
            Bitmap bmp = new Bitmap((int)width, (int)height);
            Graphics gr = Graphics.FromImage(bmp);
            gr.Clear(Color.White);

            int LINES = 32;
            float MAX_THETA = (.80F * 90.0F);
            float THETA = (2 * MAX_THETA / (LINES - 1));

            GraphicsState oldState = gr.Save();

            Pen blackPen = new Pen(Color.Black, 2.0F);
            gr.TranslateTransform(width / 2.0F, height / 2.0F);
            gr.RotateTransform(MAX_THETA);
            for (int i = 0; i < LINES; i++)
            {
                gr.DrawLine(blackPen, -2.0F * width, 0.0F, 2.0F * width, 0.0F);
                gr.RotateTransform(-THETA);
            }

            gr.Restore(oldState);

            Pen redPen = new Pen(Color.Red, 6F);
            gr.DrawLine(redPen, width / 4F, 0F, width / 4F, height);
            gr.DrawLine(redPen, 3F * width / 4F, 0F, 3F * width / 4F, height);

            /* save image in all the formats */
            bmp.Save("hering.png", ImageFormat.Png);
            Console.WriteLine("output file hering.png");
            bmp.Save("hering.jpg", ImageFormat.Jpeg);
            Console.WriteLine("output file hering.jpg");
            bmp.Save("hering.bmp", ImageFormat.Bmp);
            Console.WriteLine("output file hering.bmp");
        }

        public static void TaskActionDemo()
        {
            Action<object> action = (object obj) =>
            {
                Console.WriteLine("Task={0}, obj={1}, Thread={2}", Task.CurrentId, obj, Thread.CurrentThread.ManagedThreadId);
            };

            // Construct an unstarted task
            Task t1 = new Task(action, "alpha");

            // Construct a started task
            Task t2 = Task.Factory.StartNew(action, "beta");

            // Block the main thread to demonstate that t2 is executing
            t2.Wait();

            t1.Start();

            Console.WriteLine("t1 has been launched. (Main Thread={0})", Thread.CurrentThread.ManagedThreadId);

            // Wait for the task to finish.
            // You may optionally provide a timeout interval or a cancellation token
            // to mitigate situations when the task takes too long to finish.
            t1.Wait();

            // Construct an unstarted task
            Task t3 = new Task(action, "gamma");

            // Run it synchronously
            t3.RunSynchronously();

            // Although the task was run synchronously, it is a good practice
            // to wait for it in the event exceptions were thrown by the task.
            t3.Wait();
        }

        public static void ReflectDemo()
        {
            Person p1 = new Person
            {
                Name = "p1",

                Equips = new List<Equip>
                {
                 new Equip {AttackValue=1,Name="0N1"  },
                 new Equip {AttackValue=2,Name="0N2"  },
                 new Equip {AttackValue=3,Name="0N3"  }
                }
            };

            Type t1 = p1.GetType();
            PropertyInfo[] pi1 = t1.GetProperties();

            var type = pi1[2].PropertyType.IsGenericType;

            var p2type = pi1[2].PropertyType;

            var tyep = typeof(List<Person>);
        }

        public static object CreateGeneric(Type generic, Type innerType, params object[] args)
        {
            Type specificType = generic.MakeGenericType(new Type[] { innerType });
            return Activator.CreateInstance(specificType, args);
        }

        public static void CreateGenericDemo()
        {
            object genericList = CreateGeneric(typeof(List<>), typeof(Person));
            var orderList = genericList as List<Person>;
            orderList.Add(new Person { });
            orderList.Add(new Person { });
            orderList.Add(new Person { });
            orderList.Add(new Person { });
        }

        public static void StackDemo()
        {
            Stack stack = new Stack();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");
            stack.Push("d");
            stack.Push("e");
            stack.Push("f");
            stack.Push("g");
            stack.Push("h");
            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack.Count);
        }

        public static void TaskCancellationTokenSource()
        {
            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = source.Token;

            Random rnd = new Random();
            object lockObj = new object();

            List<Task<int[]>> tasks = new List<Task<int[]>>();
            TaskFactory factory = new TaskFactory(token);
            for (int taskCtr = 0; taskCtr <= 10; taskCtr++)
            {
                int iteration = taskCtr + 1;
                tasks.Add(factory.StartNew(() =>
                {
                    int value;
                    int[] values = new int[10];
                    for (int ctr = 1; ctr <= 10; ctr++)
                    {
                        lock (lockObj)
                        {
                            value = rnd.Next(0, 101);
                        }
                        if (value == 0)
                        {
                            source.Cancel();
                            Console.WriteLine("Cancelling at task {0}", iteration);
                            break;
                        }
                        values[ctr - 1] = value;
                    }
                    return values;
                }, token));
            }
            try
            {
                Task<double> fTask =
                factory.ContinueWhenAll(tasks.ToArray(), (results) =>
                {
                    Console.WriteLine("Calculating overall mean...");
                    long sum = 0;
                    int n = 0;
                    foreach (var t in results)
                    {
                        foreach (var r in t.Result)
                        {
                            sum += r;
                            n++;
                        }
                    }
                    return sum / (double)n;
                }, token);
                Console.WriteLine("The mean is {0}.", fTask.Result);
            }
            catch (AggregateException ae)
            {
                foreach (Exception e in ae.InnerExceptions)
                {
                    if (e is TaskCanceledException)
                    {
                        Console.WriteLine("Unable to compute mean: {0}", e.Message);
                    }
                    else
                    {
                        Console.WriteLine("Exception: " + e.GetType().Name);
                    }
                }
            }
            finally
            {
                source.Dispose();
            }
        }

        public static bool GetPicThumbnail(string sourceFile, string dFile, int dHeight, int dWidth, int flag)
        {
            Image iSource = Image.FromFile(sourceFile);
            ImageFormat tFormat = iSource.RawFormat;
            int sW, sH;

            //按比例缩放
            Size temSize = new Size(iSource.Width, iSource.Height);
            if (temSize.Width > dHeight || temSize.Width > dWidth) //将**改成c#中的或者操作符号
            {
                if ((temSize.Width * dHeight) > (temSize.Height * dWidth))
                {
                    sW = dWidth;
                    sH = (dWidth * temSize.Height) / temSize.Width;
                }
                else
                {
                    sH = dHeight;
                    sW = (temSize.Width * dHeight) / temSize.Height;
                }
            }
            else
            {
                sW = temSize.Width;

                sH = temSize.Height;
            }

            Bitmap ob = new Bitmap(dWidth, dHeight);
            Graphics g = Graphics.FromImage(ob);
            g.Clear(Color.WhiteSmoke);
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(iSource, new Rectangle((dWidth - sW) / 2, (dHeight - sH) / 2, sW, sH), 0, 0, iSource.Width, iSource.Height, GraphicsUnit.Pixel);
            g.Dispose();

            //以下代码为保存图片时，设置压缩质量

            EncoderParameters ep = new EncoderParameters();
            long[] qy = new long[1];
            qy[0] = flag;
            //设置压缩的比例1-100

            EncoderParameter eParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qy);
            ep.Param[0] = eParam;
            try
            {
                ImageCodecInfo[] arrayIci = ImageCodecInfo.GetImageEncoders();

                ImageCodecInfo jpegIcIinfo = arrayIci.FirstOrDefault(t => t.FormatDescription.Equals("JPEG"));

                if (jpegIcIinfo != null)
                {
                    ob.Save(dFile, jpegIcIinfo, ep);
                }
                else
                {
                    ob.Save(dFile, tFormat);
                }

                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                iSource.Dispose();

                ob.Dispose();
            }
        }

        public static bool GetThumImage2(string sourceFile, long quality, int multiple, string outputFile)
        {
            try
            {
                Bitmap sourceImage = new Bitmap(sourceFile);
                ImageCodecInfo myImageCodecInfo = GetEncoderInfo("image/jpeg");
                System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                EncoderParameters myEncoderParameters = new EncoderParameters(1);
                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, quality);
                myEncoderParameters.Param[0] = myEncoderParameter;
                float xWidth = sourceImage.Width;
                float yWidth = sourceImage.Height;
                Bitmap newImage = new Bitmap((int)(xWidth / multiple), (int)(yWidth / multiple));
                Graphics g = Graphics.FromImage(newImage);

                g.DrawImage(sourceImage, 0, 0, xWidth / multiple, yWidth / multiple);
                g.Dispose();
                newImage.Save(outputFile, myImageCodecInfo, myEncoderParameters);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool GetThumImage(string sourceFile, long quality, int multiple, string outputFile)
        {
            try
            {
                long imageQuality = quality;
                Bitmap sourceImage = new Bitmap(sourceFile);
                ImageCodecInfo myImageCodecInfo = GetEncoderInfo("image/jpeg");
                System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                EncoderParameters myEncoderParameters = new EncoderParameters(1);
                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, imageQuality);
                myEncoderParameters.Param[0] = myEncoderParameter;
                float xWidth = sourceImage.Width;
                float yWidth = sourceImage.Height;
                Bitmap newImage = new Bitmap((int)(xWidth / multiple), (int)(yWidth / multiple));
                Graphics g = Graphics.FromImage(newImage);
                g.DrawImage(sourceImage, 0, 0, xWidth / multiple, yWidth / multiple);
                g.Dispose();
                newImage.Save(outputFile, myImageCodecInfo, myEncoderParameters);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }

        #endregion MyRegion

        public static void DSADemo()
        {
            // Create a digital signature based on RSA encryption.
            SignatureDescription rsaSignature = CreateRSAPKCS1Signature();
            ShowProperties(rsaSignature);

            // Create a digital signature based on DSA encryption.
            SignatureDescription dsaSignature = CreateDSASignature();
            ShowProperties(dsaSignature);

            // Create a HashAlgorithm using the digest algorithm of the signature.
            HashAlgorithm hashAlgorithm = dsaSignature.CreateDigest();
            Console.WriteLine("\nHash algorithm for the DigestAlgorithm property:"
                + " " + hashAlgorithm.ToString());

            // Create an AsymmetricSignatureFormatter instance using the DSA key.
            DSA dsa = DSA.Create();
            AsymmetricSignatureFormatter asymmetricFormatter = CreateDSAFormatter(dsa);

            // Create an AsymmetricSignatureDeformatter instance using the
            // DSA key.
            AsymmetricSignatureDeformatter asymmetricDeformatter = CreateDSADeformatter(dsa);

            Console.WriteLine("This sample completed successfully; " + "press Enter to exit.");
            Console.ReadLine();
        }

        // Create a SignatureDescription for RSA encryption.
        private static SignatureDescription CreateRSAPKCS1Signature()
        {
            SignatureDescription signatureDescription = new SignatureDescription();

            // Set the key algorithm property for RSA encryption.
            signatureDescription.KeyAlgorithm =
                "System.Security.Cryptography.RSACryptoServiceProvider";

            // Set the digest algorithm for RSA encryption using the
            // SHA1 provider.
            signatureDescription.DigestAlgorithm = "System.Security.Cryptography.SHA1CryptoServiceProvider";

            // Set the formatter algorithm with the RSAPKCS1 formatter.
            signatureDescription.FormatterAlgorithm = "System.Security.Cryptography.RSAPKCS1SignatureFormatter";

            // Set the formatter algorithm with the RSAPKCS1 deformatter.
            signatureDescription.DeformatterAlgorithm = "System.Security.Cryptography.RSAPKCS1SignatureDeformatter";

            return signatureDescription;
        }

        // Create a SignatureDescription using a constructed SecurityElement for
        // DSA encryption.
        private static SignatureDescription CreateDSASignature()
        {
            SecurityElement securityElement = new SecurityElement("DSASignature");

            // Create new security elements for the four algorithms.
            securityElement.AddChild(new SecurityElement("Key", "System.Security.Cryptography.DSACryptoServiceProvider"));
            securityElement.AddChild(new SecurityElement("Digest", "System.Security.Cryptography.SHA1CryptoServiceProvider"));
            securityElement.AddChild(new SecurityElement("Formatter", "System.Security.Cryptography.DSASignatureFormatter"));
            securityElement.AddChild(new SecurityElement("Deformatter", "System.Security.Cryptography.DSASignatureDeformatter"));

            SignatureDescription signatureDescription = new SignatureDescription(securityElement);

            return signatureDescription;
        }

        // Create a signature formatter for DSA encryption.
        private static AsymmetricSignatureFormatter CreateDSAFormatter(DSA dsa)
        {
            // Create a DSA signature formatter for encryption.
            SignatureDescription signatureDescription = new SignatureDescription();
            signatureDescription.FormatterAlgorithm = "System.Security.Cryptography.DSASignatureFormatter";

            AsymmetricSignatureFormatter asymmetricFormatter = signatureDescription.CreateFormatter(dsa);

            Console.WriteLine("\nCreated formatter : " + asymmetricFormatter.ToString());
            return asymmetricFormatter;
        }

        // Create a signature deformatter for DSA decryption.
        private static AsymmetricSignatureDeformatter CreateDSADeformatter(DSA dsa)
        {
            // Create a DSA signature deformatter to verify the signature.
            SignatureDescription signatureDescription = new SignatureDescription();
            signatureDescription.DeformatterAlgorithm = "System.Security.Cryptography.DSASignatureDeformatter";

            AsymmetricSignatureDeformatter asymmetricDeformatter = signatureDescription.CreateDeformatter(dsa);

            Console.WriteLine("\nCreated deformatter : " + asymmetricDeformatter.ToString());
            return asymmetricDeformatter;
        }

        // Display to the console the properties of the specified
        // SignatureDescription.
        private static void ShowProperties(SignatureDescription signatureDescription)
        {
            // Retrieve the class path for the specified SignatureDescription.
            string classDescription = signatureDescription.ToString();

            string deformatterAlgorithm = signatureDescription.DeformatterAlgorithm;
            string formatterAlgorithm = signatureDescription.FormatterAlgorithm;
            string digestAlgorithm = signatureDescription.DigestAlgorithm;
            string keyAlgorithm = signatureDescription.KeyAlgorithm;

            Console.WriteLine("\n** " + classDescription + " **");
            Console.WriteLine("DeformatterAlgorithm : " + deformatterAlgorithm);
            Console.WriteLine("FormatterAlgorithm : " + formatterAlgorithm);
            Console.WriteLine("DigestAlgorithm : " + digestAlgorithm);
            Console.WriteLine("KeyAlgorithm : " + keyAlgorithm);
        }

        #region 开机启动

        public static void Run()
        {
            string fileName = "";
            string ShortFileName = fileName.Substring(fileName.LastIndexOf("\\") + 1);
            //打开子键节点
            using (RegistryKey refKey =
                Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true) ??
                Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run"))
            {
                if (refKey != null)
                    refKey.SetValue(ShortFileName, fileName);
            }
        }

        #endregion 开机启动

        #region SQLiteDemo

        public static void SQLiteCreate()
        {
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + SqliteFilePath))
            {
                using (SQLiteCommand comm = conn.CreateCommand())
                {
                    conn.Open();

                    comm.CommandText = @"CREATE TABLE COMPANY(
                                                ID INTEGER PRIMARY KEY   AUTOINCREMENT,
                                                NAME           TEXT      NOT NULL,
                                                AGE            INT       NOT NULL,
                                                ADDRESS        CHAR(50),
                                                SALARY         REAL
                                            );";
                    comm.ExecuteNonQuery();
                }
            }
        }

        public static void SQLiteSelect()
        {
            DataSet ds = new DataSet();
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + SqliteFilePath))
            {
                using (SQLiteCommand comm = conn.CreateCommand())
                {
                    conn.Open();

                    //comm.Parameters.Clear();
                    comm.CommandText = "Select * From COMPANY";
                    //  comm.CommandText = "SELECT * FROM sqlite_master WHERE type = 'table' and name='COMPANY'";

                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(comm))
                    {
                        adapter.Fill(ds);
                    }
                }
            }
        }

        public static void SQLiteInsert()
        {
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + SqliteFilePath))
            {
                using (SQLiteCommand comm = conn.CreateCommand())
                {
                    conn.Open();

                    #region 1.1插入数据

                    comm.CommandText = @"INSERT INTO COMPANY (NAME,AGE,ADDRESS,SALARY) VALUES ( 'Paul', 32, 'California', 20000.00 );";
                    comm.ExecuteNonQuery();

                    #endregion 1.1插入数据

                    #region 1.2使用参数插入数据

                    //comm.CommandText = "INSERT INTO COMPANY VALUES(@id,@name)";
                    //comm.Parameters.AddRange(
                    //    new[]
                    //    {
                    //        CreateSqliteParameter("@id", DbType.Int32, 4, 11),
                    //        CreateSqliteParameter("@name", DbType.String, 10, "Hello 11")
                    //    });
                    //comm.ExecuteNonQuery();

                    #endregion 1.2使用参数插入数据
                }
            }
        }

        private static SQLiteParameter CreateSqliteParameter(string name, DbType type, int size, object value)
        {
            SQLiteParameter parm = new SQLiteParameter(name, type, size);
            parm.Value = value;
            return parm;
        }

        #endregion SQLiteDemo
    }

    public class CarInfoEventArgs : EventArgs
    {
        public CarInfoEventArgs(string car)
        {
            Car = car;
        }

        public string Car { get; }
    }

    public class CarDealer
    {
        public event EventHandler<CarInfoEventArgs> NewCarInfo;

        public void NewCar(string car)
        {
            Console.WriteLine($"CarDealer, new car {car}");

            NewCarInfo?.Invoke(this, new CarInfoEventArgs(car));
        }
    }

    public class Consumer
    {
        private string _name;

        public Consumer(string name)
        {
            _name = name;
        }

        public void NewCarIsHere(object sender, CarInfoEventArgs e)
        {
            Console.WriteLine($"{_name}: car {e.Car} is new");
        }
    }
}