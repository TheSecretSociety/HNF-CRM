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
    
    public partial class Criterion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Criterion()
        {
            this.CUSTOMERCAREDETAILs = new HashSet<CUSTOMERCAREDETAIL>();
        }
    
        public int ID { get; set; }
        public Nullable<int> Fabric { get; set; }
        public Nullable<int> ShirtStyle { get; set; }
        public Nullable<int> RequireProduct { get; set; }
        public Nullable<int> PrintAndEmbroider { get; set; }
        public Nullable<int> Price { get; set; }
        public Nullable<int> Support { get; set; }
        public Nullable<int> Maintenance { get; set; }
        public Nullable<int> Attitude { get; set; }
        public Nullable<int> Durability { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CUSTOMERCAREDETAIL> CUSTOMERCAREDETAILs { get; set; }
    }
}
