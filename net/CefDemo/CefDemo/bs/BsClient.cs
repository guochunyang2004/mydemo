using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xilium.CefGlue;

namespace CefDemo.bs
{
    public class BsClient:CefClient
    {
        public event EventHandler OnCreated;
        private readonly CefLifeSpanHandler lifeSpanHandler;
        private readonly BsDownloadHandler downloadHandler;
        private readonly BsRequestHandler requestHandler;       
        private readonly BSWebLoadHandler webLoadHandler;

        public BsClient()
        {
            lifeSpanHandler = new BsLifeSpanHandler(this);
            downloadHandler = new BsDownloadHandler();
            requestHandler = new BsRequestHandler();
            webLoadHandler = new BSWebLoadHandler();
        }
        /// <summary>
        /// 设置代理用户和密码
        /// </summary>
        /// <param name="user"></param>
        /// <param name="pass"></param>
        public void SetUser(string user, string pass)
        {
            if (requestHandler!=null)
            requestHandler.SetUser(user, pass);
        }
        /// <summary>
        /// 页面加载完成同步事件
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public bool IsLoadEndSync(Action action)
        {
            return webLoadHandler.IsLoadEndSync(action);
        }
        /// <summary>
        /// 设置自定义下载目录
        /// </summary>
        /// <param name="downloadPath"></param>
        public void SetDownloadPath(string downloadPath)
        {
            downloadHandler.DownloadPath = downloadPath;
        }
        /// <summary>
        /// 设置自定义下载目录
        /// </summary>
        /// <param name="func"></param>
        public void SetDownloadPath(Func<string, string> func)
        {
            downloadHandler.SetDownloadPath = func;
        }
        /// <summary>
        /// 下载中事件，返回flase取消下载
        /// </summary>
        public void SetDownloadUpdated(Func<CefDownloadItem, bool> DownloadUpdated)
        {
            downloadHandler.DownloadUpdated = DownloadUpdated;
        }
        
        #region override
        protected override CefLifeSpanHandler GetLifeSpanHandler()
        {
            return lifeSpanHandler;
        }
        protected override CefDownloadHandler GetDownloadHandler()
        {
            return downloadHandler;
        }
        protected override CefRequestHandler GetRequestHandler()
        {
            return requestHandler;
        }
        protected override CefLoadHandler GetLoadHandler()
        {
            return webLoadHandler;
        } 
        #endregion
        public void Created(CefBrowser bs)
        {
            if (OnCreated != null)
            {
                OnCreated(bs, EventArgs.Empty);
            }
        }
    }
}
