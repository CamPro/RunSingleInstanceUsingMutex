using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RunSingleInstanceUsingMutex
{
    static class Program
    {
        static Mutex appMutex;
        static string appGuid;

        [STAThread]
        static void Main()
        {
            bool createdNew;
            appGuid = ((GuidAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(GuidAttribute), false).GetValue(0)).Value.ToString();
            appMutex = new Mutex(true, appGuid, out createdNew);
            if (!createdNew)
            {
                Environment.Exit(0);
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
