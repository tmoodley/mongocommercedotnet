
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace seoWebApplication.Data
{

using System;
    
public partial class OrdersSelectById_Result
{

    public int OrderID { get; set; }

    public int webstore_id { get; set; }

    public System.DateTime DateCreated { get; set; }

    public Nullable<System.DateTime> DateShipped { get; set; }

    public bool Verified { get; set; }

    public bool Completed { get; set; }

    public bool Canceled { get; set; }

    public string Comments { get; set; }

    public string CustomerName { get; set; }

    public string CustomerEmail { get; set; }

    public string ShippingAddress { get; set; }

    public Nullable<int> CustomerID { get; set; }

    public Nullable<int> Status { get; set; }

    public string AuthCode { get; set; }

    public string Reference { get; set; }

    public Nullable<int> TaxID { get; set; }

    public Nullable<int> ShippingID { get; set; }

    public Nullable<decimal> total { get; set; }

    public string cart_id { get; set; }

    public Nullable<int> points { get; set; }

}

}
