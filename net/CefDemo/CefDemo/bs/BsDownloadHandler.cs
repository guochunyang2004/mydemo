using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xilium.CefGlue;

namespace CefDemo.bs
{
    public class BsDownloadHandler : CefDownloadHandler
    {
        public string DownloadPath = null;
        public Func<string, string> SetDownloadPath;
        /// <summary>
        /// 下载中事件，返回flase取消下载
        /// </summary>
        public Func< CefDownloadItem,bool> DownloadUpdated;
        protected override void OnBeforeDownload(CefBrowser browser, CefDownloadItem downloadItem, string suggestedName, CefBeforeDownloadCallback callback)
        {
            // callback.Continue(string.Empty, true);
            //callback.Continue("d:\\"+suggestedName, false);

            if (callback!=null )
            {
                //using (callback)
                //{
                
                        //SaveFileDialog saveFileDialog = new SaveFileDialog();
                        //saveFileDialog.FileName = downloadItem.SuggestedFileName;
                        //saveFileDialog.Filter ="|*"+ System.IO.Path.GetExtension(saveFileDialog.FileName);
                        //saveFileDialog.ShowDialog();
                        //if (saveFileDialog.ShowDialog() == DialogResult.OK && saveFileDialog.FileName != "")
                        //{
                        //    downloadItem.SuggestedFileName = saveFileDialog.FileName;                            
                        //}
                if (SetDownloadPath != null)
                    DownloadPath = SetDownloadPath(suggestedName);
                if (!string.IsNullOrWhiteSpace(DownloadPath))
                    callback.Continue(DownloadPath, showDialog: false);
                else
                    callback.Continue(string.Empty, showDialog: true);
                //}
            }
        
        }
        protected override void OnDownloadUpdated(CefBrowser browser, CefDownloadItem downloadItem, CefDownloadItemCallback callback)
        {
            if (DownloadUpdated!=null)
                if (!DownloadUpdated(downloadItem) && !downloadItem.IsComplete)
                {
                    callback.Cancel();
                }
            if (downloadItem.IsComplete)
            {
               // MessageBox.Show("下载成功");
                if (browser.IsPopup && !browser.HasDocument)
                {
                    browser.GetHost().ParentWindowWillClose();
                    browser.GetHost().CloseBrowser();
                }
            }
        }
    }

   public class CefProxy : CefUrlRequestClient
    {
        protected override void OnDownloadData(CefUrlRequest request, Stream data)
        {
            throw new NotImplementedException();
        }

        protected override void OnDownloadProgress(CefUrlRequest request, ulong current, ulong total)
        {
            throw new NotImplementedException();
        }

        protected override void OnRequestComplete(CefUrlRequest request)
        {
            throw new NotImplementedException();
        }

        protected override void OnUploadProgress(CefUrlRequest request, ulong current, ulong total)
        {
            throw new NotImplementedException();
        }

        protected override bool GetAuthCredentials(bool isProxy, string host, int port, string realm, string scheme, CefAuthCallback callback)
        {
            return base.GetAuthCredentials(true, host, port, realm, scheme, callback);
        }
    }

    /* 来源网上：
    Cef.UIThreadTaskFactory.StartNew(delegate
{

      chrome.RequestHandler = new MyRequestHandler();

      string ip = "IP";
      string port = "PORT";
      var rc = chrome.GetBrowser().GetHost().RequestContext;
      var dict = new Dictionary<string, object>();
      dict.Add("mode", "fixed_servers");
      dict.Add("server", "" + ip + ":" + port + "");
      string error;
      bool success = rc.SetPreference("proxy", dict, out error);
});*/


   
}
