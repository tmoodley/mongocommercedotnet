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
    
    public partial class Audit
    {
        public int AuditID { get; set; }
        public int OrderID { get; set; }
        public int webstore_id { get; set; }
        public System.DateTime DateStamp { get; set; }
        public string Message { get; set; }
        public Nullable<int> MessageNumber { get; set; }
    
        public virtual Order Order { get; set; }
    }
}
