//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectData
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProjectBrandMonthWiseLog
    {
        public long ProjectBrandMonthWiseLogID { get; set; }
        public long BrandId { get; set; }
        public Nullable<long> ProjectsPMCSRCMMonthwiseLogId { get; set; }
        public Nullable<long> ProjectsRMCSRCMMonthwiseLogId { get; set; }
    
        public virtual Brand Brand { get; set; }
        public virtual ProjectsPMCSRCMMonthwiseLog ProjectsPMCSRCMMonthwiseLog { get; set; }
        public virtual ProjectsRMCSRCMMonthwiseLog ProjectsRMCSRCMMonthwiseLog { get; set; }
    }
}
