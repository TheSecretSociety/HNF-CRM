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
    
    public partial class STAFF
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public STAFF()
        {
            this.CHATINFOes = new HashSet<CHATINFO>();
            this.CONTRACTs = new HashSet<CONTRACT>();
            this.CUSTOMERCAREs = new HashSet<CUSTOMERCARE>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Nullable<int> ID_Role { get; set; }
        public byte[] Avartar { get; set; }
        public string Password { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHATINFO> CHATINFOes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONTRACT> CONTRACTs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CUSTOMERCARE> CUSTOMERCAREs { get; set; }
        public virtual ROLE ROLE { get; set; }
    }
}
