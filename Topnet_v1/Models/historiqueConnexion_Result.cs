//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Topnet_v1.Models
{
    using System;
    
    public partial class historiqueConnexion_Result
    {
        public string userName { get; set; }
        public int numSequence { get; set; }
        public Nullable<int> startTimeSeconde { get; set; }
        public Nullable<int> stopTimeSeconde { get; set; }
        public Nullable<System.DateTime> startSession { get; set; }
        public Nullable<System.DateTime> endSession { get; set; }
        public Nullable<System.TimeSpan> startTime { get; set; }
        public Nullable<System.TimeSpan> endTime { get; set; }
        public Nullable<System.DateTime> dateDebutSession { get; set; }
        public Nullable<System.DateTime> dateFinSession { get; set; }
    }
}
