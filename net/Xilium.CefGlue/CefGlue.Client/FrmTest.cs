using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Xilium.CefGlue.WindowsForms;
namespace Xilium.CefGlue.Client
{
    public partial class FrmTest : Form
    {
        public FrmTest()
        {
            InitializeComponent();
            NewTab("http://google.com");
        }
       // CefWebBrowser browser = new CefWebBrowser();


        //private CefWebBrowser GetActiveBrowser()
        //{
        //    if (tabControl1.TabCount > 0)
        //    {
        //        var page = tabControl1.TabPages[tabControl1.SelectedIndex];
        //        foreach (var ctl in page.Controls)
        //        {
        //            if (ctl is CefWebBrowser)
        //            {
        //                var browser = (CefWebBrowser)ctl;
        //                return browser;
        //            }
        //        }
        //    }

        //    return null;
        //}
        CefWebBrowser browser = new CefWebBrowser();
        private void NewTab(string startUrl)
        {
            var page = new TabPage("New Tab");
            page.Padding = new Padding(0, 0, 0, 0);

  
            browser.StartUrl = startUrl;
            browser.Dock = DockStyle.Fill;
            browser.TitleChanged += (s, e) =>
            {
                BeginInvoke(new Action(() =>
                {
                    var title = browser.Title;
                    //if (tabControl1.SelectedTab == page)
                    //{
                    //    Text = browser.Title + " - " + "test";
                    //}
                    page.ToolTipText = title;
                    if (title.Length > 18)
                    {
                        title = title.Substring(0, 18) + "...";
                    }
                    page.Text = title;
                }));
            };
            browser.AddressChanged += (s, e) =>
            {
                BeginInvoke(new Action(() =>
                {
                    ;///addressTextBox.Text = browser.Address;
                }));
            };
            browser.StatusMessage += (s, e) =>
            {
                BeginInvoke(new Action(() =>
                {
                    ;// statusLabel.Text = e.Value;
                }));
            };

            panel2.Controls.Add(browser);

            //page.Controls.Add(browser);

            //tabControl1.TabPages.Add(page);

            //tabControl1.SelectedTab = page;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            browser.Browser.GetMainFrame().LoadUrl(this.textBox1.Text);
            //var ctl = GetActiveBrowser();
            //if (ctl != null)
            //{
            //    ctl.Browser.GetMainFrame().LoadUrl(this.textBox1.Text);
               
            //}
        }
    }
}
