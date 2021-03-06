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
    
    public partial class ProjectTemplateMilestone
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProjectTemplateMilestone()
        {
            this.Activities = new HashSet<Activity>();
            this.Milestones = new HashSet<Milestone>();
            this.ProjectTemplateTasks = new HashSet<ProjectTemplateTask>();
        }
    
        public long ProjectTemplateMilestoneId { get; set; }
        public long ProjectTemplateId { get; set; }
        public long MilestoneId { get; set; }
        public string MilestoneTitle { get; set; }
        public string MilestoneDescription { get; set; }
        public Nullable<System.DateTime> MilestoneDate { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> LastModifiedOn { get; set; }
        public double PercentComplete { get; set; }
        public Nullable<System.DateTime> EstimatedStartDate { get; set; }
        public Nullable<System.DateTime> EstimatedEndDate { get; set; }
        public Nullable<System.DateTime> ActualStartDate { get; set; }
        public Nullable<System.DateTime> ActualEndDate { get; set; }
        public long WorkstreamId { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<long> SNo { get; set; }
        public Nullable<long> LastTaskSNo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Activity> Activities { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Milestone> Milestones { get; set; }
        public virtual ProjectTemplate ProjectTemplate { get; set; }
        public virtual Workstream Workstream { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectTemplateTask> ProjectTemplateTasks { get; set; }
    }
}
