using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CefSharp;
using CefSharp.WinForms;
using System.Diagnostics;

namespace CefSharpWinsFormSample
{
    class CefCustomObject
    {
        // 메인 스레드에서 사용하기 위해 크로미움 로컬 변수 선언
        private static ChromiumWebBrowser _instanceBrowser = null;
        // 사용자정의 폼
        private static Form1 _instanceMainForm = null;

        public CefCustomObject(ChromiumWebBrowser originalBrowser, Form1 mainForm)
        {
            _instanceBrowser = originalBrowser;
            _instanceMainForm = mainForm;
        }

        /**
         * 개발자 도구를 보여준다.
         **/
        public void showDevTools()
        {
            _instanceBrowser.ShowDevTools();
        }

        /**
         * 콘솔창 오픈
         **/
        public void opencmd()
        {
            ProcessStartInfo start = new ProcessStartInfo("cmd.exe", "/c pause");
            Process.Start(start);
        }

    }
}
