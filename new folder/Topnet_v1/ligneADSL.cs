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
    
    public partial class ligneADSL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ligneADSL()
        {
            this.panneLigneADSL = new HashSet<panneLigneADSL>();
            this.userLigneADSL = new HashSet<userLigneADSL>();
            this.KPI = new HashSet<KPI>();
            this.typeReseau = new HashSet<typeReseau>();
        }
    
        public string numSequence { get; set; }
        public string nature { get; set; }
        public decimal codeClient { get; set; }
    
        public virtual client client { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<panneLigneADSL> panneLigneADSL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<userLigneADSL> userLigneADSL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KPI> KPI { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<typeReseau> typeReseau { get; set; }
    }
}
