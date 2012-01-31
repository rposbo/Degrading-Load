using System;
using System.Web.UI;
using DegradingLoad.LongRunningProcess;
using System.Threading;
using System.Web.SessionState;

namespace DegradingLoad
{
    public partial class _Default : Page
    {
        protected delegate void DoWorkDelegate();
        private DoWorkDelegate _doWork;
        private HttpSessionState _context;
                
        string productListingData = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadUsingAsync();
        }

        private void LoadUsingAsync()
        {
            System.Diagnostics.Trace.WriteLine("Page_Load " + Thread.CurrentThread.ManagedThreadId);

            AsyncTimeout = GetTimeout();
            _context = Session;

            var task = new PageAsyncTask(
                BeginLoadSlowContent,
                EndLoadSlowContent,
                FailedToLoadSlowContent,
                null,
                true
                );

            RegisterAsyncTask(task);
        }


        private IAsyncResult BeginLoadSlowContent(Object src, EventArgs args, AsyncCallback cb, Object state)
        {
            System.Diagnostics.Trace.WriteLine("BeginLoadSlowContent " + Thread.CurrentThread.ManagedThreadId);

            _doWork = LoadProductList;
            return _doWork.BeginInvoke(cb, state);
        }

        private void EndLoadSlowContent(IAsyncResult ar)
        {
            System.Diagnostics.Trace.WriteLine("EndLoadSlowContent " + Thread.CurrentThread.ManagedThreadId);

            LocalContent.Visible = true;
            RemoteContent.Visible = false;
            ctlProductListing.Data = productListingData;
        }

        private void FailedToLoadSlowContent(IAsyncResult ar)
        {
            System.Diagnostics.Trace.WriteLine("FailedToLoadSlowContent " + Thread.CurrentThread.ManagedThreadId);

            LocalContent.Visible = false;
            RemoteContent.Visible = true;
        }  


        private TimeSpan GetTimeout()
        {
            var timeout = 10;
            int test;

            if (Request.QueryString["timeout"] != null)
                if (int.TryParse(Request.QueryString["timeout"], out test))
                    timeout = Convert.ToInt32(Request.QueryString["timeout"]);

            return new TimeSpan(0, 0, timeout);
 
        }

        private void LoadProductList()
        {
            productListingData = ProductProcess.GetProductList(_context);
        }
      
    }
}
