//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Topnet_v1
{
    using System;
    using System.Collections.Generic;
    
    public partial class reference
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public reference()
        {
            this.historiqueKPI = new HashSet<historiqueKPI>();
        }
    
        public decimal idReference { get; set; }
        public string bornedebutReference { get; set; }
        public string bornefinReference { get; set; }
        public string descriptionReference { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<historiqueKPI> historiqueKPI { get; set; }
    }
}
