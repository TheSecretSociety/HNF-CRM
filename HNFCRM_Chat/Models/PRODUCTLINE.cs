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
    
    public partial class PRODUCTLINE
    {
        public int ID { get; set; }
        public Nullable<bool> Cut { get; set; }
        public Nullable<bool> Embroider { get; set; }
        public Nullable<bool> Sew { get; set; }
        public Nullable<bool> Iron { get; set; }
        public Nullable<bool> Packaging { get; set; }
        public Nullable<bool> Delivery { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<bool> IsAvailable { get; set; }
        public int ID_Contract { get; set; }
    
        public virtual CONTRACT CONTRACT { get; set; }
    }
}
