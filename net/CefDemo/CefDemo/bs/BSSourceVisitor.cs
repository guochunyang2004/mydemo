using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xilium.CefGlue;

namespace CefDemo.bs
{
    public sealed class BSSourceVisitor : CefStringVisitor
    {
        //private string html;

        //protected override void Visit(string value)
        //{
        //    html = value;
        //}
        //public string Html
        //{
        //    get { return html; }
        //    set { html = value; }
        //}

         private readonly TaskCompletionSource<string> taskCompletionSource;

         public BSSourceVisitor()
        {
            taskCompletionSource = new TaskCompletionSource<string>();
        }

        protected override void Visit(string value)
        {
            taskCompletionSource.SetResult(value);
        }

        public Task<string> Task
        {
            get { return taskCompletionSource.Task; }
        }
    }

    public static class CEFExtensions
    {
        public static Task<string> GetSourceAsync(this CefBrowser browser)
        {
            BSSourceVisitor taskStringVisitor = new BSSourceVisitor();
            browser.GetMainFrame().GetSource(taskStringVisitor);
            return taskStringVisitor.Task;
        }

        public static Task<string> GetTextAsync(this CefBrowser browser)
        {
            BSSourceVisitor taskStringVisitor = new BSSourceVisitor();
            browser.GetMainFrame().GetText(taskStringVisitor);
            return taskStringVisitor.Task;
        }
    }
}
