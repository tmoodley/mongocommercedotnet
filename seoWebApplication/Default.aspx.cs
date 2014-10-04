using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq; 
using seoWebApplication.st.SharkTankDAL;
using seoWebApplication.st.SharkTankDAL.dataObject;
using seoWebApplication.st.SharkTankDAL.Framework;
using seoWebApplication.DAL;
using seoWebApplication.Service;


namespace seoWebApplication
{
    public partial class _Default : System.Web.UI.Page
    {
        public bool loggedIn;
        public string storeName;
        public string seoDesc;
        public string seoKeywords;
        public string seoTitle;
        public string imgLogo; 
        public int webstoreId;

        public string address;
        public string city2;
        public int phone;
        public string url;
        public string host;


        protected void Page_Load(object sender, EventArgs e)
        {
            webstoreId = seoWebAppConfiguration.IdWebstore;

            storeName = seoWebAppConfiguration.StoreName;
            seoDesc = seoWebAppConfiguration.StoreDesc + " at " + storeName;
            seoKeywords = seoWebAppConfiguration.StoreKeywords + " at " + storeName;
            seoTitle = seoWebAppConfiguration.StoreTitle;
            address = seoWebAppConfiguration.StoreAddress;
            city2 = seoWebAppConfiguration.StoreCity;
            phone = Convert.ToInt32(seoWebAppConfiguration.StorePhone);
            imgLogo = seoWebAppConfiguration.StoreImgLogo;
            url = HttpContext.Current.Request.Url.AbsoluteUri;
            host = HttpContext.Current.Request.Url.Host;

            // Retrieve Page from the query string
            string page = Request.QueryString["Page"];
            if (page == null) page = "1";
            // How many pages of products?
            int howManyPages = 1;
            // pager links format
            string firstPageUrl = "";
            string pagerFormat = "";
            // If browsing a category...

            // Retrieve list of products on department promotion         
            var dc = new ProductService();
            list.DataSource = dc.GetProductsOnFrontPromo();
            list.DataBind();

            // have the current page as integer
            int currentPage = Int32.Parse(page);
        }


        protected void R1_ItemCreated(Object Sender, RepeaterItemEventArgs e)
        {
            int i = 0;
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                if (e.Item.ItemIndex % 3 == 0)
                {
                    Literal lblDivStart = (Literal)e.Item.FindControl("lblDivStart");
                    Literal lblDivEnd = (Literal)e.Item.FindControl("lblDivEnd");

                    lblDivStart.Text = "<div class=row work-row'>";
                    i++;
                    if (i == 3)
                    {
                        lblDivEnd.Text = "</div>";
                        i = 0;
                    }
                }

            }
        }

    }

}