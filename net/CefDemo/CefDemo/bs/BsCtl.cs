using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xilium.CefGlue;
using System.Threading;

namespace CefDemo.bs
{
    public partial class BsCtl
    {
        CefBrowser cefBrowser;
        Control parent;
        BsClient bsClient;      
        public BsCtl(Control ctl)
        {
            parent = ctl;
            var cefWindowInfo = CefWindowInfo.Create();
            cefWindowInfo.SetAsChild(parent.Handle, new CefRectangle(0, 0, parent.Width, parent.Height));
            bsClient = new BsClient();
            bsClient.OnCreated += bc_OnCreated;
            var cefBrowserSettings = new CefBrowserSettings() {  };

            CefBrowserHost.CreateBrowser(cefWindowInfo, bsClient, cefBrowserSettings, "about:blank");
            parent.SizeChanged += parent_SizeChanged;
        }
        /// <summary>
        /// 设置代理用户和密码
        /// </summary>
        /// <param name="user"></param>
        /// <param name="pass"></param>
        public void SetUser(string user, string pass)
        {
            if (bsClient != null)
                bsClient.SetUser(user, pass);
        }
        /// <summary>
        /// 设置自定义下载目录
        /// </summary>
        /// <param name="downloadPath"></param>
        public void SetDownloadPath(string downloadPath)
        {
            if (bsClient != null)
                bsClient.SetDownloadPath(downloadPath); 
        }
        /// <summary>
        /// 设置自定义下载目录
        /// </summary>
        /// <param name="func"></param>
        public void SetDownloadPath(Func<string, string> func)
        {
            if (bsClient != null)
                bsClient.SetDownloadPath(func);
        }
        /// <summary>
        /// 下载中事件，返回flase取消下载
        /// </summary>
        public void SetDownloadUpdated(Func<CefDownloadItem, bool> DownloadUpdated)
        {
            if (bsClient != null)
                bsClient.SetDownloadUpdated(DownloadUpdated);
        }

        void bc_OnCreated(object sender, EventArgs e)
        {
            cefBrowser = (CefBrowser)sender;
            var handle = cefBrowser.GetHost().GetWindowHandle();
            ResizeWindow(handle,parent.Width,parent.Height);
        }

        void parent_SizeChanged(object sender, EventArgs e)
        {
            if (cefBrowser != null)
            {
                var handle = cefBrowser.GetHost().GetWindowHandle();
                ResizeWindow(handle, parent.Width, parent.Height);                
            }
        }
        private void ResizeWindow(IntPtr handle, int width, int height)
        {
            if (handle != IntPtr.Zero)
            {
                NativeMethod.SetWindowPos(handle, IntPtr.Zero,
                    0, 0, width, height,
                    0x0002 | 0x0004
                    );
            }
        }

        /// <summary>
        /// 打开网页
        /// </summary>
        /// <param name="url"></param>
        public void GetPage(string url)
        {           
            cefBrowser.GetMainFrame().LoadUrl(url);          
        }

        /// <summary>
        /// 打开网页(同步方法，等待页面全部加载完成)
        /// </summary>
        /// <param name="url"></param>
        public void GetPageSync(string url)
        {
            bsClient.IsLoadEndSync(() =>
            {
                cefBrowser.GetMainFrame().LoadUrl(url);
            });           
        }

        /// <summary>
        /// 获取原文
        /// </summary>
        /// <returns></returns>
        public string GetSourceAsync()
        {
            //CefStringVisitor str =null;
            //bs.GetMainFrame().GetSource(str);

            var str = cefBrowser.GetSourceAsync(); 
           return str.Result;
        }

        /// <summary>
        /// 获取文本
        /// </summary>
        /// <returns></returns>
        public string GetTextAsync()
        {           
            var str = cefBrowser.GetTextAsync();
            return str.Result;
        }

        public void ExecuteJavaScript(string js)
        {
            cefBrowser.GetMainFrame().ExecuteJavaScript(js, null, 0);
            //CefV8Value returninformation;
            //CefV8Exception exx;
            //bs.GetMainFrame().V8Context.TryEval("GetDirtyFlag", out returninformation, out exx);
            //return returninformation.GetStringValue();
        }

        #region Init
        public static void Init(string proxy_server=null)
        {
            CefRuntime.Load();
            //Chrome 快捷方式中添加命令行参数：–force-renderer-accessibility；
            var mainArgs = new CefMainArgs(new string[] { "--force-renderer-accessibility" });

            var app = new BsApp((processType, commandLine) =>
            {
                if (!string.IsNullOrWhiteSpace(proxy_server))
                    commandLine.AppendSwitch("proxy-server", proxy_server);//设置代理
            });
            var exitCode = CefRuntime.ExecuteProcess(mainArgs, app);
            if (exitCode != -1)
                return;
            var settings = new CefSettings
            {
                SingleProcess = false,
                MultiThreadedMessageLoop = true,
                LogSeverity = CefLogSeverity.Disable,
                Locale = "zh-CN"
               // LogFile = "CefGlue.log"
            };
            CefRuntime.Initialize(mainArgs, settings, app);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!settings.MultiThreadedMessageLoop)
            {
                Application.Idle += (sender, e) => { CefRuntime.DoMessageLoopWork(); };
            }

            //settings.CefCommandLineArgs.Add("proxy-server", proxy.ProxyAddress);
            //settings.CefCommandLineArgs.Add("proxy-bypass-list", "127.*,192.168.*,10.10.*,193.9.162.*");
        } 
        #endregion

        public static void ShutDown()
        {
            CefRuntime.Shutdown();
        }
    }
}
