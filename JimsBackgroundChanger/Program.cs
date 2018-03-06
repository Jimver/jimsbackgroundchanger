using System;
using System.IO;
using System.Reflection;
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
            //string path = Directory.GetCurrentDirectory();
            //DateTime dt = DateTime.Now;
            //File.AppendAllText("C:\\Users\\Jim\\jbcstart.txt", "[" + dt + "] Started from : " + path + Environment.NewLine);
            string appPath = new Uri(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase) ?? throw new InvalidOperationException()).LocalPath;
            Directory.SetCurrentDirectory(appPath);
            //AppDomain currentDomain = AppDomain.CurrentDomain;
            //currentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyHandler);
            SystemEvents.DisplaySettingsChanged += Wallpaper.SystemEvents_DisplaySettingsChanged;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form());
        }

        /* Some debug code
         private static void MyHandler(object sender, UnhandledExceptionEventArgs args)
        {
            DateTime dt = DateTime.Now;
            Exception e = (Exception)args.ExceptionObject;
            string msg = "[" + dt + "] MyHandler caught : " + e.Message + Environment.NewLine;
            msg += $"Runtime terminating: {args.IsTerminating}";
            Console.WriteLine(msg);
            MessageBox.Show(msg, "ERROR");
            File.AppendAllText("C:\\Users\\Jim\\jbclog.txt", msg + Environment.NewLine);
        }
        */
    }
}
