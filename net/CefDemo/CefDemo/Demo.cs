using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Xilium.CefGlue;
using CefDemo.bs;

namespace CefDemo
{
    public partial class Demo : Form
    {
        BsCtl bs;
        public Demo()
        {
            InitializeComponent();
            this.Name = "CefBrowser";
            this.Text = "最简单的实现";            
        }
        private void CefBrowser_Load(object sender, EventArgs e)
        {
            bs = new BsCtl(BrowserContainer);
           // bs.SetUser("", "");
            bs.SetDownloadUpdated((item) => {
                if (item.IsComplete)
                {                   
                    SetText(lbDownLoad, "完成");
                }
                else
                {
                    var PercentComplete = (item.PercentComplete > -1?item.PercentComplete:0); 
                    SetProgressBar(progressBar1, PercentComplete);
                    SetText(lbDownLoad, PercentComplete.ToString() + "%");
                }
                return true;
            });
        }
        private delegate void SetTextInvoke(Control con, string msg, bool isAppend = false);
        private void SetText(Control con, string txt, bool isAppend = false)
        {
            if (con.InvokeRequired)
            {
                con.Invoke(new SetTextInvoke(SetText), new object[] { con, txt, isAppend });
            }
            else
            {
                if (isAppend)
                    con.Text += txt;
                else
                    con.Text = txt.ToString(); 
            }
        }
        private delegate void SetProgressBarInvoke(ProgressBar con, int value);
        private void SetProgressBar(ProgressBar con, int value)
        {
            if (con.InvokeRequired)
            {
                con.Invoke(new SetProgressBarInvoke(SetProgressBar), new object[] { con, value });
            }
            else
            {
                con.Value = value;
            }
        }

        private void GoBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(AddressTB.Text))
            {
                bs.GetPageSync(AddressTB.Text);
                var txt = bs.GetTextAsync();
                tbSource.Text = txt;
                button2_Click(null, null);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
          var txt =  bs.GetSourceAsync();
          tbSource.Text = txt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bs.SetDownloadPath((fileName) =>
            {
                return "d:\\aaa_" + fileName;
            });
            bs.ExecuteJavaScript("$('[data-download]').eq(0).click()");
        }
    }
}
