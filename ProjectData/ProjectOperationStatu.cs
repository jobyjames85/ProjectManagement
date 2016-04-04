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
    
    public partial class ProjectOperationStatu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProjectOperationStatu()
        {
            this.Projects = new HashSet<Project>();
            this.ProjectsMonthwiseLogs = new HashSet<ProjectsMonthwiseLog>();
            this.ProjectTemplates = new HashSet<ProjectTemplate>();
        }
    
        public long ProjectOperationStatusId { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsInMaterialGovernance { get; set; }
        public bool IsInMiscellaneousOnly { get; set; }
        public string Name { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Project> Projects { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectsMonthwiseLog> ProjectsMonthwiseLogs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectTemplate> ProjectTemplates { get; set; }
    }
}
