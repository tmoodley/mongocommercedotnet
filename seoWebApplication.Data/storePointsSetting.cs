
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
    
public partial class storePointsSetting
{

    public int storePoint_id { get; set; }

    public bool active { get; set; }

    public string Definition { get; set; }

    public Nullable<int> ConversionRate { get; set; }

    public bool RefPointsNo { get; set; }

    public bool RefPointsFlat { get; set; }

    public bool RefPointsPercentage { get; set; }

    public Nullable<int> RefPointsFlatValue { get; set; }

    public Nullable<int> RefPointsPercentageValue { get; set; }

    public int webstore_id { get; set; }

}

}
