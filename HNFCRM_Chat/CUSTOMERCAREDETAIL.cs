//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HNFCRM_Chat
{
    using System;
    using System.Collections.Generic;
    
    public partial class CUSTOMERCAREDETAIL
    {
        public int ID_CustomerCare { get; set; }
        public int ID_Criteria { get; set; }
        public Nullable<int> Point { get; set; }
    
        public virtual Criterion Criterion { get; set; }
        public virtual CUSTOMERCARE CUSTOMERCARE { get; set; }
    }
}