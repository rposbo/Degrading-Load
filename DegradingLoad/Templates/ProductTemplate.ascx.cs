using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using DegradingLoad.Entities;
using DegradingLoad.BusinessLogic;

namespace DegradingLoad.Templates
{
    public partial class ProductTemplate : GenericContentTemplate
    {
        public override string Data
        {
            set
            {
                var js = new JavaScriptSerializer();
                rptProductList.DataSource = js.Deserialize(value, typeof(List<Product>));
                rptProductList.ItemDataBound += rptProductList_OnItemDataBound;
                rptProductList.DataBind();
            }
        }

        protected void rptProductList_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        { 
          if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
              var product = ((Product)e.Item.DataItem);
              ((Image)e.Item.FindControl("ProductImage")).ImageUrl = product.imageUrl;
              ((HyperLink)e.Item.FindControl("ProductTitle")).Text = product.title;
              ((HyperLink)e.Item.FindControl("ProductTitle")).NavigateUrl = "http://www.asos.com/pgeproduct.aspx?iid=" + product.productId;
              ((Literal)e.Item.FindControl("ProductPrice")).Text = string.Format("{0:C}",product.price);
          }
        }
    }
}