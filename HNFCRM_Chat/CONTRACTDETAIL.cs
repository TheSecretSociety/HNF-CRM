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
    
    public partial class CONTRACTDETAIL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CONTRACTDETAIL()
        {
            this.MENSIZEs = new HashSet<MENSIZE>();
            this.WOMENSIZEs = new HashSet<WOMENSIZE>();
        }
    
        public int ID { get; set; }
        public Nullable<int> Quantity { get; set; }
        public string ProductDesign { get; set; }
        public string CollarArmAdjustment { get; set; }
        public string FabricateStyle { get; set; }
        public Nullable<bool> SideCut { get; set; }
        public Nullable<bool> ArmBorder { get; set; }
        public string Note { get; set; }
        public Nullable<System.DateTime> PrintStartDate { get; set; }
        public Nullable<System.DateTime> PrintEndDate { get; set; }
        public string PrintSpot { get; set; }
        public string PrintSize { get; set; }
        public string PrintNote { get; set; }
        public Nullable<System.DateTime> EmbroiderStartDate { get; set; }
        public Nullable<System.DateTime> EmbroiderEndDate { get; set; }
        public string EmbroiderMakingUnit { get; set; }
        public string EmbroiderSpot { get; set; }
        public string EmbroiderSize { get; set; }
        public string EmbroiderNote { get; set; }
        public string PrintMakingUnit { get; set; }
        public Nullable<int> ID_Contract { get; set; }
        public string NotePrint { get; set; }
        public string NoteSize { get; set; }
        public string ShirtColor { get; set; }
        public Nullable<bool> ArmpitBorder { get; set; }
    
        public virtual CONTRACT CONTRACT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MENSIZE> MENSIZEs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WOMENSIZE> WOMENSIZEs { get; set; }
    }
}
