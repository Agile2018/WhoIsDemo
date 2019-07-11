using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Reflection;

namespace WhoIsDemo
{
    static class Program
    {
        #region constants
        static readonly string appGuid = Assembly.GetExecutingAssembly()
            .GetCustomAttribute<GuidAttribute>().Value;

        #endregion

        [STAThread]
        static void Main()
        {
            using (Mutex mutex = new Mutex(false, @"Global\" + appGuid))
            {
                if (!mutex.WaitOne(0, false))
                {
                    MessageBox.Show("Instance already running");
                    return;
                }

                GC.Collect();
                Application.EnableVisualStyles();
                Application.Run(new mdiMain());
                                
            }
        }
    }
}
