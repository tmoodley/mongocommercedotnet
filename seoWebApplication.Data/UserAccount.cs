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
    
    public partial class UserAccount
    {
        public int UserAccountId { get; set; }
        public bool IsActive { get; set; }
        public string AccountName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int webstore_id { get; set; }
        public System.DateTime InsertDate { get; set; }
        public int InsertENTUserAccountId { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public int UpdateENTUserAccountId { get; set; }
        public byte[] Version { get; set; }
    }
}
