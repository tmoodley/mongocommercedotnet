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
    
    public partial class vw_product
    {
        public int product_id { get; set; }
        public int webstore_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public string thumbnail { get; set; }
        public string image { get; set; }
        public bool promofront { get; set; }
        public bool promodept { get; set; }
    }
}
