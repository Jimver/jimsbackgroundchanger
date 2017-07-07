using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;

namespace JimsBackgroundChanger
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyHandler);
            SystemEvents.DisplaySettingsChanged += Wallpaper.SystemEvents_DisplaySettingsChanged;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form());
        }

        static void MyHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
            string msg = "MyHandler caught : " + e.Message + Environment.NewLine;
            msg += $"Runtime terminating: {args.IsTerminating}";
            Console.WriteLine(msg);
            File.AppendAllText(@"C:\path\jbclog.txt", msg + Environment.NewLine);
        }
    }
}
