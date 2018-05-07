using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xilium.CefGlue;

namespace CefDemo.bs
{
   
    public class BsRequestHandler : CefRequestHandler
    {
        private string userName;
        private string password;
        /// <summary>
        /// 设置代理用户和密码
        /// </summary>
        /// <param name="user"></param>
        /// <param name="pass"></param>
        public void SetUser(string user, string pass)
        {
            userName = user;
            password = pass;
        }
        //
        // 摘要: 
        //     Called on the IO thread when the browser needs credentials from the user.
        //      |isProxy| indicates whether the host is a proxy server. |host| contains
        //     the hostname and |port| contains the port number. Return true to continue
        //     the request and call CefAuthCallback::Continue() when the authentication
        //     information is available. Return false to cancel the request.
        protected override bool GetAuthCredentials(CefBrowser browser, CefFrame frame, bool isProxy, string host,
            int port, string realm, string scheme, CefAuthCallback callback)
        {
            if (isProxy == true)//设置代理用户密码
            {
                if (!string.IsNullOrWhiteSpace(userName) && !string.IsNullOrWhiteSpace(password))
                    callback.Continue(userName, password);
            }
            return true;
        }
        //
        // 摘要: 
        //     Called on the IO thread before a resource is loaded. To allow the resource
        //     to load normally return NULL. To specify a handler for the resource return
        //     a CefResourceHandler object. The |request| object should not be modified
        //     in this callback.
        //protected virtual CefResourceHandler GetResourceHandler(CefBrowser browser, CefFrame frame, CefRequest request);
        //
        // 摘要: 
        //     Called on the UI thread before browser navigation. Return true to cancel
        //     the navigation or false to allow the navigation to proceed. The |request|
        //     object cannot be modified in this callback.  CefLoadHandler::OnLoadingStateChange
        //     will be called twice in all cases.  If the navigation is allowed CefLoadHandler::OnLoadStart
        //     and CefLoadHandler::OnLoadEnd will be called. If the navigation is canceled
        //     CefLoadHandler::OnLoadError will be called with an |errorCode| value of ERR_ABORTED.
        //protected virtual bool OnBeforeBrowse(CefBrowser browser, CefFrame frame, CefRequest request, bool isRedirect);
        //
        // 摘要: 
        //     Called on the browser process IO thread before a plugin is loaded. Return
        //     true to block loading of the plugin.
        //protected virtual bool OnBeforePluginLoad(CefBrowser browser, string url, string policyUrl, CefWebPluginInfo info);
        //
        // 摘要: 
        //     Called on the IO thread before a resource request is loaded. The |request|
        //     object may be modified. To cancel the request return true otherwise return
        //     false.
        //protected virtual bool OnBeforeResourceLoad(CefBrowser browser, CefFrame frame, CefRequest request);
        //
        // 摘要: 
        //     Called on the UI thread to handle requests for URLs with an invalid SSL certificate.
        //     Return true and call CefAllowCertificateErrorCallback:: Continue() either
        //     in this method or at a later time to continue or cancel the request. Return
        //     false to cancel the request immediately. If |callback| is empty the error
        //     cannot be recovered from and the request will be canceled automatically.
        //     If CefSettings.ignore_certificate_errors is set all invalid certificates
        //     will be accepted without calling this method.
        //protected virtual bool OnCertificateError(CefErrorCode certError, string requestUrl, CefAllowCertificateErrorCallback callback);
        //
        // 摘要: 
        //     Called on the browser process UI thread when a plugin has crashed.  |plugin_path|
        //     is the path of the plugin that crashed.
        //protected virtual void OnPluginCrashed(CefBrowser browser, string pluginPath);
        //
        // 摘要: 
        //     Called on the UI thread to handle requests for URLs with an unknown protocol
        //     component. Set |allow_os_execution| to true to attempt execution via the
        //     registered OS protocol handler, if any.  SECURITY WARNING: YOU SHOULD USE
        //     THIS METHOD TO ENFORCE RESTRICTIONS BASED ON SCHEME, HOST OR OTHER URL ANALYSIS
        //     BEFORE ALLOWING OS EXECUTION.
        //protected virtual void OnProtocolExecution(CefBrowser browser, string url, out bool allowOSExecution);
        //
        // 摘要: 
        //     Called on the IO thread when JavaScript requests a specific storage quota
        //     size via the webkitStorageInfo.requestQuota function. |origin_url| is the
        //     origin of the page making the request. |new_size| is the requested quota
        //     size in bytes. Return true and call CefQuotaCallback::Continue() either in
        //     this method or at a later time to grant or deny the request. Return false
        //     to cancel the request.
        //protected virtual bool OnQuotaRequest(CefBrowser browser, string originUrl, long newSize, CefQuotaCallback callback);
        //
        // 摘要: 
        //     Called on the browser process UI thread when the render process terminates
        //     unexpectedly. |status| indicates how the process terminated.
        //protected virtual void OnRenderProcessTerminated(CefBrowser browser, CefTerminationStatus status);
        //
        // 摘要: 
        //     Called on the IO thread when a resource load is redirected. The |old_url|
        //     parameter will contain the old URL. The |new_url| parameter will contain
        //     the new URL and can be changed if desired.
        //protected virtual void OnResourceRedirect(CefBrowser browser, CefFrame frame, string oldUrl, ref string newUrl);
    }
}
