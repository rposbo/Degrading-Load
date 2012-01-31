using System.Web;

namespace DegradingLoad.BusinessLogic
{
    public static class LoadTemplate
    {
        public static string GetRenderedHtmlFromTemplate(string data, string templatePath)
        {
            var pageHolder = new PageOverride();
            var viewControl = (GenericContentTemplate) pageHolder.LoadControl(templatePath);

            viewControl.Data = data;
            pageHolder.Controls.Add(viewControl);

            var outputHtml = new System.IO.StringWriter();
            HttpContext.Current.Server.Execute(pageHolder, outputHtml, false);

            return outputHtml.ToString();
        }
    }

    public class PageOverride : System.Web.UI.Page
    {
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            // overriding this method like this allows for inclusion of "<asp:" controls 
            // on the referenced usercontrol without errors
        }
    }
}