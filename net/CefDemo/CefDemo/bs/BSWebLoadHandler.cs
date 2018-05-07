using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xilium.CefGlue;

namespace CefDemo.bs
{
   
    public class BSWebLoadHandler : CefLoadHandler
    {
        private AutoResetEvent autoResetMainLoad = new AutoResetEvent(false);
        private bool SetLoadStart()
        {
            autoResetMainLoad.Reset();
            autoResetMainLoad.SetAccessControl(new System.Security.AccessControl.EventWaitHandleSecurity());
            return true;
        }
        /// <summary>
        /// 页面加载完成同步事件
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public bool IsLoadEndSync(Action action)
        {
            SetLoadStart();
            action();
            while (!autoResetMainLoad.WaitOne(10, false)) { Application.DoEvents(); };//阻塞
            return true;
        }
        //
        // 摘要: 
        //     Called when the browser begins loading a frame. The |frame| value will never
        //     be empty -- call the IsMain() method to check if this frame is the main frame.
        //     Multiple frames may be loading at the same time. Sub-frames may start or
        //     continue loading after the main frame load has ended. This method may not
        //     be called for a particular frame if the load request for that frame fails.
        //     For notification of overall browser load status use OnLoadingStateChange
        //     instead.
        protected override void OnLoadStart(CefBrowser browser, CefFrame frame)
        {
            if (frame.IsMain)
            {
                
                ;// Console.WriteLine("START: {0}", browser.GetMainFrame().Url);
            }
        }

        protected override void OnLoadEnd(CefBrowser browser, CefFrame frame, int httpStatusCode)
        {
            if (frame.IsMain)
            {               
                autoResetMainLoad.Set();
                BSSourceVisitor mcsv = new BSSourceVisitor();
                frame.GetSource(mcsv);

               // Console.WriteLine("END: {0}, {1}", browser.GetMainFrame().Url, httpStatusCode);
            }           
        }
        //
        // 摘要: 
        //     Called when the resource load for a navigation fails or is canceled.  |errorCode|
        //     is the error code number, |errorText| is the error text and |failedUrl| is
        //     the URL that failed to load. See net\base\net_error_list.h for complete descriptions
        //     of the error codes.
        protected override void OnLoadError(CefBrowser browser, CefFrame frame, CefErrorCode errorCode, string errorText, string failedUrl)
        {
           // autoResetMainLoad.Set();
        }
        //
        // 摘要: 
        //     Called when the loading state has changed. This callback will be executed
        //     twice -- once when loading is initiated either programmatically or by user
        //     action, and once when loading is terminated due to completion, cancellation
        //     of failure.
        //protected virtual void OnLoadingStateChange(CefBrowser browser, bool isLoading, bool canGoBack, bool canGoForward);
       
    }
}
