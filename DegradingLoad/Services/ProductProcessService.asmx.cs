using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.ServiceModel.Web;
using DegradingLoad.BusinessLogic;
using DegradingLoad.LongRunningProcess;
using System.Threading;

namespace DegradingLoad.Services
{
    [WebService(Namespace = "")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.Web.Script.Services.ScriptService]
    public class ProductProcessService : System.Web.Services.WebService
    {
        [WebMethod (EnableSession=true)]
        [WebGet(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public string GetProductListingHtml()
        {
            System.Diagnostics.Trace.WriteLine("GetProductListingHtml " + Thread.CurrentThread.ManagedThreadId);

            string products = (Context.Session != null && Context.Session["products"] != null) ?
                              Context.Session["products"].ToString() :
                              ProductProcess.GetProductList(Context.Session);

            return LoadTemplate.GetRenderedHtmlFromTemplate(products,"/Templates/ProductTemplate.ascx");
        }

        [WebMethod (EnableSession = true)]
        [WebGet(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public string GetProductListingJson()
        {
            return ProductProcess.GetProductList(Context.Session);
        }
    }
}
