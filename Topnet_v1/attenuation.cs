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
    
    public partial class attenuation
    {
        public int idAttenuation { get; set; }
        public Nullable<int> DWMAXRATE { get; set; }
        public Nullable<double> DWSNR { get; set; }
        public Nullable<double> DWATTEN { get; set; }
        public Nullable<int> UPMAXRATE { get; set; }
        public Nullable<double> UPSNR { get; set; }
        public Nullable<double> UPATTEN { get; set; }
        public string SYNCHRO { get; set; }
        public Nullable<int> DEBIT { get; set; }
        public Nullable<System.DateTime> DATE_SCAN { get; set; }
        public int numSequence { get; set; }
    
        public virtual ligneADSL ligneADSL { get; set; }
    }
}
