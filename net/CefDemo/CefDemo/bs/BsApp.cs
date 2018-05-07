using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xilium.CefGlue;

namespace CefDemo.bs
{
    public class BsApp:CefApp
    {
        public Action<string,CefCommandLine> CommandLineAction;
        public BsApp() { }
        public BsApp(Action<string, CefCommandLine> commandLineAction)
        {
            CommandLineAction = commandLineAction;
        }
        protected override void OnBeforeCommandLineProcessing(string processType, CefCommandLine commandLine)
        {           
            if (CommandLineAction != null)
                CommandLineAction(processType,commandLine);
        }

        protected override CefRenderProcessHandler GetRenderProcessHandler()
        {
            return new RenderProcessHandler();//插入脚本
        }
    }

    /// <summary>
    /// 插入脚本
    /// </summary>
    internal sealed class RenderProcessHandler : CefRenderProcessHandler
    {
        protected override void OnWebKitInitialized()
        {
            CefRuntime.RegisterExtension("testExtension", "var test;if (!test)test = {};(function() {test.myval = 'My Value!';})();", null);
            base.OnWebKitInitialized();
        }
    }
}
