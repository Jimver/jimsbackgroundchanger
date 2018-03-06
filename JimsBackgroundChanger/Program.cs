// #define DEBUG

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
            string appPath = new Uri(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase) ??
                                     throw new InvalidOperationException()).LocalPath;
            Directory.SetCurrentDirectory(appPath);
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += MyHandler;
            SystemEvents.DisplaySettingsChanged += Wallpaper.SystemEvents_DisplaySettingsChanged;
            Wallpaper.SystemEvents_DisplaySettingsChanged(null, EventArgs.Empty);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form());
        }

        // Catching exception globally
        private static void MyHandler(object sender, UnhandledExceptionEventArgs args)
        {
            DateTime dt = DateTime.Now;
            Exception e = (Exception) args.ExceptionObject;
            string msg = "[" + dt + "] MyHandler caught : " + e.Message + Environment.NewLine;
            msg += $"Runtime terminating: {args.IsTerminating}";
            Console.WriteLine(msg);
            MessageBox.Show(msg, "Jim's background changer error");
#if DEBUG
            File.AppendAllText("C:\\Users\\Jim\\Desktop\\jbclog.txt", msg + Environment.NewLine);     
#endif
        }
    }
}