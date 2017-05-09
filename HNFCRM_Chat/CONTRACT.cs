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
    
    public partial class CONTRACT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CONTRACT()
        {
            this.CONTRACTDETAILs = new HashSet<CONTRACTDETAIL>();
            this.PRODUCTLINEs = new HashSet<PRODUCTLINE>();
        }
    
        public int ID { get; set; }
        public Nullable<System.DateTime> DateConsult { get; set; }
        public Nullable<System.DateTime> Appointment { get; set; }
        public string Note { get; set; }
        public string SendMarket { get; set; }
        public string Price { get; set; }
        public Nullable<bool> MarketConfirm { get; set; }
        public string MarketPicture { get; set; }
        public string Contract1 { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string MoneyTransfer { get; set; }
        public string Remind { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<bool> IsAvailable { get; set; }
        public Nullable<int> ID_Customer { get; set; }
        public Nullable<int> ID_RequireProduct { get; set; }
        public Nullable<int> ID_Staff { get; set; }
        public Nullable<bool> CheckConfirm { get; set; }
        public Nullable<System.DateTime> AppointmentMarket { get; set; }
        public string StatusContract { get; set; }
    
        public virtual CUSTOMER CUSTOMER { get; set; }
        public virtual REQUIREPRODUCT REQUIREPRODUCT { get; set; }
        public virtual STAFF STAFF { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONTRACTDETAIL> CONTRACTDETAILs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUCTLINE> PRODUCTLINEs { get; set; }
    }
}
