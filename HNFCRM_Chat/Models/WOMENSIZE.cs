//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HNFCRM_Chat.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class WOMENSIZE
    {
        public int ID_WOMENSIZE { get; set; }
        public Nullable<int> S { get; set; }
        public Nullable<int> M { get; set; }
        public Nullable<int> L { get; set; }
        public Nullable<int> XL { get; set; }
        public Nullable<int> XXL { get; set; }
        public Nullable<int> ID_CONTRACTDETAIL { get; set; }
    
        public virtual CONTRACTDETAIL CONTRACTDETAIL { get; set; }
    }
}
