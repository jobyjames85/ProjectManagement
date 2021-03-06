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
    
    public partial class Attachment
    {
        public long AttachmentId { get; set; }
        public string Title { get; set; }
        public string FullFilePath { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public long UserId { get; set; }
        public Nullable<long> TaskId { get; set; }
        public long ProjectId { get; set; }
        public string Description { get; set; }
    
        public virtual Project Project { get; set; }
        public virtual Task Task { get; set; }
        public virtual User User { get; set; }
    }
}
