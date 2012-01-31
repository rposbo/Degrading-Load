using System.Web.SessionState;
using System.Web.Script.Serialization;
using DegradingLoad.Entities;
using System.Threading;

namespace DegradingLoad.LongRunningProcess
{
    public static class ProductProcess
    {
        public static string GetProductList(HttpSessionState context)
        {
            System.Diagnostics.Trace.WriteLine("GetProductList " + Thread.CurrentThread.ManagedThreadId);

            // fake a slow process
            System.Threading.Thread.Sleep(2000);

            var js = new JavaScriptSerializer();
            var products = js.Serialize(DemoProduct.GetDemoProducts());

            if (context != null)
                context["products"] = products;

            return products;
        }
    }
}
