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
    using System.Collections.Generic;
    
    public partial class ShoppingCart
    {
        public string cart_id { get; set; }
        public int product_id { get; set; }
        public int webstore_id { get; set; }
        public string attributes { get; set; }
        public int quantity { get; set; }
        public System.DateTime dateadded { get; set; }
        public int idShoppingCart { get; set; }
    
        public virtual product product { get; set; }
    }
}
