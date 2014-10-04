﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Configuration; 
using System.Collections;
using System.ComponentModel; 
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Net;
using seoWebApplication.st.SharkTankDAL;
using seoWebApplication.st.SharkTankDAL.entObject;
using seoWebApplication.Service;
using seoWebApplication.Models;

namespace seoWebApplication
{
    public class ShoppingCartAccess
    {
        
        public ShoppingCartAccess()
        {
            //
            // TODO: Add constructor logic here 
        }

        

        // returns the shopping cart ID for the current user
        private static string shoppingCartId
            {
                get
                    {
                    // get the current HttpContext
                    HttpContext context = HttpContext.Current;
                  
                    // try to retrieve the cart ID from the user cookie
                    //string cart_id = System.Web.HttpContext.Current.Request.Cookies["SeoWebApp_cart_id"].Value;
                        string cart_id;
                    HttpCookie myCookie = HttpContext.Current.Request.Cookies["SeoWebApp_cart_id"];
                    cart_id = "";
                    // if the cart ID isn't in the cookie...
                    {
                        // check if the cart ID exists as a cookie
                        if (myCookie != null)
                        {
                            //cart_id = myCookie.Value["SeoWebApp_cart_id"];
                            cart_id = context.Request.Cookies["SeoWebApp_cart_id"].Value;
                        // return the id
                            return cart_id;
                        }
                        else
                        // if the cart ID doesn't exist in the cookie as well, generate
                        // a new ID
                            {
                            // generate a new GUID
                            cart_id = Guid.NewGuid().ToString();
                            // create the cookie object and set its value
                            HttpCookie cookie = new HttpCookie("SeoWebApp_cart_id", cart_id);
                            // set the cookie's expiration date
                            int howManyDays = seoWebAppConfiguration.CartPersistDays;
                            DateTime currentDate = DateTime.Now;
                            TimeSpan timeSpan = new TimeSpan(howManyDays, 0, 0, 0);
                            DateTime expirationDate = currentDate.Add(timeSpan);
                            cookie.Expires = expirationDate;
                            // set the cookie on the client's browser
                            context.Response.Cookies.Add(cookie);
                            // return the CartID
                            return cart_id.ToString();
                            }
                    }
                }
            }

        // Add a new shopping cart item
        public static bool AddItem(string product_id, string attributes)
        {
            ShoppingCartService _shoppingcartservice = new ShoppingCartService();
            ProductService _productservice = new ProductService();
            mShoppingCart sc = new mShoppingCart();
            sc.cart_id = shoppingCartId;
            sc.attributes = attributes;
            sc.dateadded = DateTime.Now;
            sc.product_id = Convert.ToInt32(product_id);
            var _product = _productservice.GetProduct(Convert.ToInt32(product_id));
            sc.name = _product.name;
            sc.price = _product.price;
            sc.subtotal = _product.price * 1;
            sc.quantity = 1;
            // returns true in case of success and false in case of an error
            try
            {
                // execute the stored procedure and return true if it executes 
                return _shoppingcartservice.Create(sc); 
            }
            catch
            {
                // prevent the exception from propagating, but return false to
                // signal the error
                return false;
            }
        }

        // Update the quantity of a shopping cart item
        public static bool UpdateItem(string product_id, int quantity)
        {
            ShoppingCartService _shoppingcartservice = new ShoppingCartService();
            ProductService _productservice = new ProductService();
            mShoppingCart sc = new mShoppingCart();
            sc.cart_id = shoppingCartId;
            sc.quantity = quantity;
            sc.dateadded = DateTime.Now;
            sc.product_id = Convert.ToInt32(product_id);
            sc.webstore_id = dBHelper.GetWebstoreId();
            var _product = _productservice.GetProduct(Convert.ToInt32(product_id));
            sc.name = _product.name;
            sc.price = _product.price;
            sc.subtotal = _product.price * quantity;
            sc.quantity = quantity;
            // returns true in case of success and false in case of an error
            try
            {
                // execute the stored procedure and return true if it executes
                // successfully, and false otherwise
                return _shoppingcartservice.Update(sc);
            }
            catch
            {
                // prevent the exception from propagating, but return false to
                // signal the error
                return false;
            }
        }

        // Remove a shopping cart item
        public static bool RemoveItem(string product_id)
        {
            ShoppingCartService _shoppingcartservice = new ShoppingCartService();
            mShoppingCart sc = new mShoppingCart();
            sc.cart_id = shoppingCartId; 
            sc.dateadded = DateTime.Now;
            sc.product_id = Convert.ToInt32(product_id);
            sc.webstore_id = dBHelper.GetWebstoreId(); 
            // returns true in case of success and false in case of an error
            try
            {
                // execute the stored procedure and return true if it executes
                // successfully, and false otherwise
                return _shoppingcartservice.Delete(sc);
            }
            catch
            {
                // prevent the exception from propagating, but return false to
                // signal the error
                return false;
            }
        }

        // Retrieve shopping cart items
        public static IList<mShoppingCart> GetItems()
        {
            ShoppingCartService _shoppingcartservice = new ShoppingCartService();
            var items = _shoppingcartservice.GetShoppingCartById(shoppingCartId);
       
            return items;
        }

        // Retrieve shopping cart items
        public static decimal GetTotalAmount()
        { 
            // return the result table
            ShoppingCartService _shoppingcartservice = new ShoppingCartService(); 
            return _shoppingcartservice.GetShoppingTotalById(shoppingCartId);
        }

        // Retrieve shopping cart items
        public string GetUser()
        {
            return HttpContext.Current.Session["UserName"].ToString();  
        }

        public int getUserId()
        {
            customerEO customer = new customerEO();
            return customer.getUserId(HttpContext.Current.Session["UserName"].ToString());
            
        }
        // Counts old shopping carts
        public static int CountOldCarts(byte days)
        {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccessor.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "ShoppingCartCountOldCarts";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@Days";
        param.Value = days;
        param.DbType = DbType.Byte;
        comm.Parameters.Add(param);
        // execute the procedure and return number of old shopping carts
        try
        {
            return Byte.Parse(GenericDataAccessor.ExecuteScalar(comm));
        }
        catch
        {
            return -1;
        }
        }

        // Deletes old shopping carts
        public static bool DeleteOldCarts(byte days)
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccessor.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "ShoppingCartDeleteOldCarts";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@Days";
            param.Value = days;
            param.DbType = DbType.Byte;
            comm.Parameters.Add(param);
            // execute the procedure and return true if no problem occurs
            try
            {
                GenericDataAccessor.ExecuteNonQuery(comm);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Create a new order from the shopping cart
        public static string CreateOrder()
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccessor.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "CreateOrder";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@cart_id";
            param.Value = shoppingCartId;
            param.DbType = DbType.String;
            param.Size = 36;
            comm.Parameters.Add(param);
            // return the result table
            return GenericDataAccessor.ExecuteScalar(comm);
        }

        // Create a new order with customer ID
        public static string CreateCommerceLibOrder()
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccessor.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "CreateCustomerOrder";
            // create parameters
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@CartID";
            param.Value = shoppingCartId;
            param.DbType = DbType.String;
            param.Size = 36;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@CustomerId";
            param.Value = new ShoppingCartAccess().getUserId();
            param.DbType = DbType.Int32;
            param.Size = 16;
            comm.Parameters.Add(param);
            // return the result table
            return GenericDataAccessor.ExecuteScalar(comm);
        }

        // gets product recommendations for the shopping cart
        public static DataTable GetRecommendations()
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccessor.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "CatalogGetCartRecommendations";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@cart_id";
            param.Value = shoppingCartId;
            param.DbType = DbType.String;
            param.Size = 36;
            comm.Parameters.Add(param);
            // create a new parameter 
            param = comm.CreateParameter();
            param.ParameterName = "@webstore_id";
            param.Value = dBHelper.GetWebstoreId();
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@DescriptionLength";
            param.Value = seoWebAppConfiguration.ProductDescriptionLength;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // execute the stored procedure
            return GenericDataAccessor.ExecuteSelectCommand(comm);
        }
    }

 }
 
