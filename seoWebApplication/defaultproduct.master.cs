﻿using System; 
using System.Linq;
using System.Web; 

namespace seoWebApplication
{
    public partial class _defaultproduct : System.Web.UI.MasterPage
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
        public string facebookUrl;
        public string facebookAppId;
        public string twitterUrl;

        protected void Page_Load(object sender, EventArgs e)
        {
            facebookUrl = seoWebAppConfiguration.FacebookUrl;
            facebookAppId = seoWebAppConfiguration.FacebookAppId;
            twitterUrl = seoWebAppConfiguration.TwitterUrl;
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

            if (imgLogo == null) {
                imgLogo = "";
            }
            if (Session["User"] == null)
            {
                loggedIn = false;
            }
            else
            {
                loggedIn = true;
            }
 
            


        }
    }
}
