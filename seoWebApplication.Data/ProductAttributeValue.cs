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
    
    public partial class ProductAttributeValue
    {
        public int ProductAttributeValueId { get; set; }
        public int product_id { get; set; }
        public int AttributeValueID { get; set; }
        public int webstore_id { get; set; }
        public decimal Value { get; set; }
        public System.DateTime InsertDate { get; set; }
        public int InsertENTUserAccountId { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public int UpdateENTUserAccountId { get; set; }
        public byte[] Version { get; set; }
    
        public virtual AttributeValue AttributeValue { get; set; }
        public virtual product product { get; set; }
    }
}
