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
    
    public partial class ProjectTemplateForm
    {
        public long ProjectTemplateFormId { get; set; }
        public long ProjectTemplateId { get; set; }
        public bool HasPMCGovernanceForm { get; set; }
        public bool HasRMCGovernanceForm { get; set; }
        public bool HasPMCSRCMForm { get; set; }
        public bool HasRMCSRCMForm { get; set; }
        public bool IsDeleted { get; set; }
    
        public virtual ProjectTemplate ProjectTemplate { get; set; }
    }
}
