//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MaintainenceApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class room
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public room()
        {
            this.booking = new HashSet<booking>();
            this.cleanRequest = new HashSet<cleanRequest>();
            this.maintainenceRequest = new HashSet<maintainenceRequest>();
            this.roomService = new HashSet<roomService>();
        }
    
        public int roomNr { get; set; }
        public Nullable<int> noBeds { get; set; }
        public Nullable<int> roomSize { get; set; }
        public string roomType { get; set; }
        public string roomState { get; set; }
        public string roomQuality { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<booking> booking { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cleanRequest> cleanRequest { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<maintainenceRequest> maintainenceRequest { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<roomService> roomService { get; set; }
    }
}