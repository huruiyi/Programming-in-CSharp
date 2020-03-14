﻿using ConApp.AopDemo1;
using ConApp.AopDemo2;
using ConApp.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Security.Policy;
using System.Text;
using System.Threading;

namespace ConApp
{
    internal class TestClass
    {
    }

    public partial class Program
    {
        public static unsafe void Main(string[] args)
        {
            //TaskDemo.SumPageSizes();
            TaskDemo.SumPageSizesAsync();
            Console.WriteLine("pok");
            Thread.Sleep(10000000);
        }

        public static void Other3()
        {
            TestClass t1 = new TestClass();
            TestClass t2 = new TestClass();
            Console.WriteLine(t1.Equals(t2));
            Console.WriteLine(object.ReferenceEquals(t1, t2));
            t2 = t1;
            Console.WriteLine(t1.Equals(t2));
            Console.WriteLine(object.ReferenceEquals(t1, t2));
        }

        public static void Other2()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Thread.Sleep(3610);

            stopwatch.Stop();

            Console.WriteLine(stopwatch.Elapsed.TotalSeconds);

            stopwatch.Restart();
            Thread.Sleep(3617);

            stopwatch.Stop();

            Console.WriteLine(stopwatch.Elapsed.TotalSeconds);
        }

        public static void Other1()
        {
            //https://www.cnblogs.com/lanxiaoke/p/6657935.html
            //https://www.cnblogs.com/niunan/

            TestClass c1 = new TestClass();
            unsafe
            {
                GCHandle h = GCHandle.Alloc(c1, GCHandleType.WeakTrackResurrection);

                IntPtr addr = GCHandle.ToIntPtr(h);
                Console.WriteLine(addr.ToString("X"));
            }

            Console.ReadKey();

            //Mutex
            //Marshal.
            Console.ReadKey();
        }

        public static void Other0()
        {
            Hash hash = Hash.CreateMD5(Encoding.UTF8.GetBytes("ABCDEFG"));
            //Hash.CreateSHA1()
            //Hash.CreateSHA1()
            //Hash.CreateSHA256()
            Byte[] bytes = hash.MD5;
            string str = Encoding.UTF8.GetString(bytes);
        }

        #region AOP

        private static void ApoDemo1(string[] args)
        {
            AopClassTest test1 = new AopClassTest();
            test1.MethodName("arg1", "arg2");

            Console.ReadKey();
        }

        [SecurityPermission(SecurityAction.LinkDemand)]
        public static void AopDemo2()
        {
            Console.WriteLine("Generate a new MyProxy.");
            MyProxyClass myProxy = new MyProxyClass(typeof(MyMarshalByRefClass));

            Console.WriteLine("Obtain the transparent proxy from myProxy.");
            MyMarshalByRefClass myMarshalByRefClassObj = (MyMarshalByRefClass)myProxy.GetTransparentProxy();

            Console.WriteLine("Calling the Proxy.");
            object myReturnValue = myMarshalByRefClassObj.MyMethod("Microsoft", 1.2, 6);

            Console.WriteLine("Sample Done.");
        }

        #endregion AOP

        #region EventDemo

        public static int WriteLetter(string letter)
        {
            Console.Write(letter + " ");
            return 1;
        }

        public static void ExampleMethod(int a, int b, int c)
        {
            Console.WriteLine("ExampleMethod(int a, int b, int c)");
        }

        public static void ExampleMethod(string p1 = null, object p2 = null)
        {
            Console.WriteLine(@"ExampleMethod: p2 is object");
        }

        public static void ExampleMethod(string p2 = null, object p1 = null, params int[] p3)
        {
            Console.WriteLine(@"ExampleMethod: p2 is string");
        }

        public static void publisher_SampleEvent(object sender, SampleEventArgs e)
        {
            Console.WriteLine("e.Text:" + e.Text);
        }

        public static void EventDemo1()
        {
            ExampleMethod(p2: "");
            Console.WriteLine("\n+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n");

            ExampleMethod(WriteLetter("A"), b: WriteLetter("B"), c: WriteLetter("C"));
            ExampleMethod(WriteLetter("A"), c: WriteLetter("C"), b: WriteLetter("B"));
            Console.WriteLine("\n+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n");

            var methods = new List<Action>();
            string[] words = new[] { "hello", "world" };
            foreach (var word in words)
            {
                methods.Add(() => Console.Write(word + " "));
            }

            methods[0]();
            methods[1]();
            Console.WriteLine("\n+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n");

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
                {
                    Console.Write(entry + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n");

            Model.Publisher publisher = new Model.Publisher();

            publisher.SampleEvent += publisher_SampleEvent;
        }

        #endregion EventDemo

        #region PerformanceCounter

        public static void PerformanceCounterDemo1()
        {
            List<PerformanceCounter> counters = new List<PerformanceCounter>();
            Process[] processes = Process.GetProcesses();
            foreach (Process process in processes)
            {
                PerformanceCounter counter = new PerformanceCounter("Process", "% Processor Time", process.ProcessName);
                counter.NextValue();
                counters.Add(counter);
            }

            int i = 0;

            //Thread.Sleep(1000);

            //格式化输出
            //Console.WriteLine("{0,-7}{1,-24}{2,-6}", "Method", "X-HTTP-Method-Override", "Action");

            foreach (PerformanceCounter counter in counters)
            {
                Console.WriteLine(processes[i].ProcessName + " | CPU% " + (Math.Round(counter.NextValue(), 1)));
                ++i;
            }
        }

        public static void PerformanceCounterDemo2()
        {
            Console.Title = ("Simple CPU Monitor");
            Console.ForegroundColor = ConsoleColor.Green;
            PerformanceCounter perfCounter = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");

            while (true)
            {
                Thread.Sleep(1000);
                Console.Beep();
                Console.WriteLine("CPU Load: {0}%", perfCounter.NextValue());
            }
        }

        #endregion PerformanceCounter

        #region ProcessDemo

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

        private void MainWindowTitleProcess()
        {
            Process[] processes = Process.GetProcesses();

            foreach (Process item in processes)
            {
                if (item.MainWindowTitle.Length > 0)
                {
                    Console.WriteLine("标题：" + item.MainWindowTitle);
                    Console.WriteLine("编号：" + item.Id.ToString());
                    Console.WriteLine("进程：" + item.ProcessName);
                    Console.WriteLine("开始时间" + item.StartTime.ToString());
                    Console.WriteLine();
                }
            }
        }

        #endregion ProcessDemo

        #region GetEnumeratorDemo

        public static void GetEnumeratorDemo()
        {
            ArrayList arr = new ArrayList() { 12, 13, 1, 4, 15, 16, 17 };
            IEnumerator iEnumerator = arr.GetEnumerator();
            while (iEnumerator.MoveNext())
            {
                Console.WriteLine(iEnumerator.Current);
            }
        }

        #endregion GetEnumeratorDemo

        #region WeakReferenceDemo

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

        #endregion WeakReferenceDemo

        #region 异步委托

        public delegate void AsycRun();

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

        #region 应用程序域

        public static void AppDomainDemo1()
        {
            AppDomain.CurrentDomain.SetData("name", "Hello");
            string name = AppDomain.CurrentDomain.GetData("name").ToString();
            Console.WriteLine(name);

            // Create application domain setup information
            AppDomainSetup domaininfo = new AppDomainSetup
            {
                ConfigurationFile = Environment.CurrentDirectory + "ADSetup.exe.config",
                ApplicationBase = Environment.CurrentDirectory
            };

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

            AppDomainSetup appDomainSetup = new AppDomainSetup { LoaderOptimization = LoaderOptimization.SingleDomain };
            AppDomain appDomain = AppDomain.CreateDomain("MultThread", null, appDomainSetup);
            appDomain.ExecuteAssembly("ConApp.exe");
        }

        #endregion 应用程序域

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

        public static T CreateInstance<T>(int n) where T : new()
        {
            T t = default(T);
            for (int i = 0; i < n; i++)
            {
                t = new T();
            }
            return t;
        }

        public static T CreateBossInstance<T>(int n) where T : Person, new()
        {
            T t = default(T);
            for (int i = 0; i < n; i++)
            {
                t = new T();
            }
            return t;
        }

        #endregion 简单泛型

        public async static void AsyncDemo()
        {
            using (StreamWriter writer = File.CreateText("ConsoleOutput.txt"))
            {
                await writer.WriteLineAsync("First line of example");
                await writer.WriteLineAsync("and second line");
            }
        }

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

        public static void DynamicDemo1()
        {
            dynamic calc = Calculator.GetCalculator();
            int r = calc.Add(2, 3);
            Console.WriteLine(r);
        }

        public static void StaticDemo()
        {
            var calc = new Calculator();
            int r = calc.Add(2, 3);
            Console.WriteLine(r);
        }

        public static void GetPortNamesDemo()
        {
            string[] ports = SerialPort.GetPortNames();

            Console.WriteLine("The following serial ports were found:");

            foreach (string port in ports)
            {
                Console.WriteLine(port);
            }
        }
    }
}