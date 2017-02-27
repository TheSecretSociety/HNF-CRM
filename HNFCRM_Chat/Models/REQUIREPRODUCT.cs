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
    
    public partial class REQUIREPRODUCT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public REQUIREPRODUCT()
        {
            this.CONTRACTs = new HashSet<CONTRACT>();
        }
    
        public int ID { get; set; }
        public string RequireFabric { get; set; }
        public string Purpose { get; set; }
        public Nullable<bool> PreviousDesign { get; set; }
        public string PrintAndEmbroider { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<double> Price { get; set; }
        public string Note { get; set; }
        public Nullable<int> ID_Customer { get; set; }
        public Nullable<int> ID_Color { get; set; }
    
        public virtual COLOR COLOR { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONTRACT> CONTRACTs { get; set; }
        public virtual CUSTOMER CUSTOMER { get; set; }
    }
}
