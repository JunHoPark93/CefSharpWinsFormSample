using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CefSharp;
using CefSharp.WinForms;

namespace CefSharpWinsFormSample
{
    public partial class Form1 : Form
    {
        public ChromiumWebBrowser chromeBrowser;

        public Form1()
        {
            // 레거시 바인딩 에러 https://github.com/cefsharp/CefSharp/issues/2246 이슈 참고
            CefSharpSettings.LegacyJavascriptBindingEnabled = true;

            InitializeComponent();

            InitializeChromium();

            chromeBrowser.RegisterJsObject("cefCustomObject", new CefCustomObject(chromeBrowser, this));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 참조에러
            //chromeBrowser.ShowDevTools();
        }

        public void InitializeChromium()
        {
            CefSettings settings = new CefSettings();
            Console.WriteLine(Application.StartupPath);

            // 경로 참조 에러
            //String page = string.Format(@"{0}\html-resources\html\index.html", Application.StartupPath);
            String page = string.Format(@"C:\Users\Jun Ho Park\source\index.html");
 
            if (!File.Exists(page))
            {
                MessageBox.Show("Error The html file doensn't exists : " + page);
            }

            Cef.Initialize(settings);

            chromeBrowser = new ChromiumWebBrowser(page);

            this.Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;

            // 로컬 리소스들을 브라우저에서 사용할 수 있게 함
            BrowserSettings browserSettings = new BrowserSettings();
            browserSettings.FileAccessFromFileUrls = CefState.Enabled;
            browserSettings.UniversalAccessFromFileUrls = CefState.Enabled;
            chromeBrowser.BrowserSettings = browserSettings;

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }
    }
}
