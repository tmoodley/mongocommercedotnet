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
    
    public partial class city
    {
        public city()
        {
            this.zones = new HashSet<zone>();
        }
    
        public int idCity { get; set; }
        public int idState { get; set; }
        public string city1 { get; set; }
    
        public virtual state state { get; set; }
        public virtual ICollection<zone> zones { get; set; }
    }
}
