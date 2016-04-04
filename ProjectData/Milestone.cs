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
    
    public partial class Milestone
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Milestone()
        {
            this.Activities = new HashSet<Activity>();
            this.Tasks = new HashSet<Task>();
        }
    
        public long MilestoneId { get; set; }
        public long ProjectId { get; set; }
        public string MilestoneTitle { get; set; }
        public string MilestoneDescription { get; set; }
        public Nullable<System.DateTime> MilestoneDate { get; set; }
        public double PercentComplete { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> LastModifiedOn { get; set; }
        public Nullable<System.DateTime> EstimatedStartDate { get; set; }
        public Nullable<System.DateTime> EstimatedEndDate { get; set; }
        public Nullable<System.DateTime> ActualStartDate { get; set; }
        public Nullable<System.DateTime> ActualEndDate { get; set; }
        public long WorkstreamId { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<long> ProjectTemplateId { get; set; }
        public Nullable<long> ProjectTemplateMilestoneId { get; set; }
        public Nullable<bool> IsCompleted { get; set; }
        public Nullable<long> SNo { get; set; }
        public Nullable<long> LastTaskSNo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Activity> Activities { get; set; }
        public virtual Project Project { get; set; }
        public virtual ProjectTemplateMilestone ProjectTemplateMilestone { get; set; }
        public virtual ProjectTemplate ProjectTemplate { get; set; }
        public virtual Workstream Workstream { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
