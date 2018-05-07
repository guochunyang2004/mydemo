using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Xilium.CefGlue;
using CefDemo.bs;

namespace CefDemo
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            BsCtl.Init();
            Application.Run(new Demo());
            BsCtl.ShutDown();
        }
    }
}
