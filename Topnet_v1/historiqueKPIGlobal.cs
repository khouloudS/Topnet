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
    
    public partial class historiqueKPIGlobal
    {
        public int idHistoriqueKPIGlobal { get; set; }
        public int idKPI { get; set; }
        public Nullable<double> valeurKPIGlobal { get; set; }
        public Nullable<System.DateTime> dateHistoriqueKPIGlobal { get; set; }
        public Nullable<System.DateTime> dateFinHistoriqueKPIGlobal { get; set; }
    
        public virtual KPI KPI { get; set; }
    }
}
