
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
    
public partial class AttributeValue
{

    public AttributeValue()
    {

        this.ProductAttributeValues = new HashSet<ProductAttributeValue>();

    }


    public int AttributeValueID { get; set; }

    public int AttributeID { get; set; }

    public string Value { get; set; }

    public int webstore_id { get; set; }

    public System.DateTime InsertDate { get; set; }

    public int InsertENTUserAccountId { get; set; }

    public System.DateTime UpdateDate { get; set; }

    public int UpdateENTUserAccountId { get; set; }

    public byte[] Version { get; set; }



    public virtual Attribute Attribute { get; set; }

    public virtual ICollection<ProductAttributeValue> ProductAttributeValues { get; set; }

}

}
