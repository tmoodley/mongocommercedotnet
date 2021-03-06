﻿using seoWebApplication.Models;
using System; 
using System.Collections.Generic; 
using System.Linq; 

namespace seoWebApplication.UserControls
{
    public partial class CartSummary : System.Web.UI.UserControl
    {

        protected void Page_PreRender(object sender, EventArgs e)
        {
            PopulateControls();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // get the current page
            string page = Request.AppRelativeCurrentExecutionFilePath;
            // if we're in the shopping cart, don't display the cart summary
            if (String.Compare(page, "~/ShoppingCart.aspx", true) == 0)
                this.Visible = false;
            else
                this.Visible = true; 
        }

        private void PopulateControls()
        {
        // get the items in the shopping cart
            IList<mShoppingCart> dt = ShoppingCartAccess.GetItems();
        // if the shopping cart is empty...
        if (dt.Count == 0)
        {
        cartSummaryLabel.Text = "Your shopping cart is empty.";
        totalAmountLabel.Text = String.Format("{0:c}", 0);
        viewCartLink.Visible = false;
        list.Visible = false;
        }
        else
        // if the shopping cart is not empty...
        {
        // populate the list with the shopping cart contents
        list.Visible = true;
        list.DataSource = dt;
        list.DataBind();
        // set up controls
        cartSummaryLabel.Text = "Cart summary ";
        viewCartLink.Visible = true;
        // display the total amount
        decimal amount = ShoppingCartAccess.GetTotalAmount();
        totalAmountLabel.Text = String.Format("{0:c}", amount);
        }
        }
 
    }
}