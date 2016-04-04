using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectData;
using ProjectManagement.Properties;

namespace ProjectManagement.Models
{
    public class StaffLoginViewModel
    {
        #region Public Properties

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        #endregion Public Properties
    }

    public class StaffUserViewModel
    {
        #region Public Properties

        public Nullable<System.DateTime> AccountValidFrom { get; set; }
        public Nullable<System.DateTime> AccountValidTo { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public virtual Designation Designation { get; set; }
        public long? DesignationId { get; set; }
        public List<SelectListItem> Designations { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public virtual ProjectType FunctionalGroup { get; set; }
        public Nullable<long> FunctionalGroupId { get; set; }
        public List<SelectListItem> FunctionalGroups { get; set; }
        public bool IsBlocked { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsNonSystemUser { get; set; }
        public string LandPhone { get; set; }
        public Nullable<System.DateTime> LastModifiedOn { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public string PhotoFilePath { get; set; }
        public long? RoleId { get; set; }
        public List<SelectListItem> RoleTypes { get; set; }
        public long UserId { get; set; }
        public string UserName { get; set; }
        public virtual Workstream Workstream { get; set; }
        public Nullable<long> WorkstreamId { get; set; }
        public List<SelectListItem> Workstreams { get; set; }

        #endregion Public Properties
    }

    public class StaffViewModel
    {
        #region Public Properties

        [Required]
        [Display(Name = "Age")]
        public int Age
        {
            get;
            set;
        }

        [Required]
        [Display(Name = "Experience")]
        public int Experience
        {
            get;
            set;
        }

        [Required]
        [Display(Name = "Name")]
        public string Name
        {
            get;
            set;
        }

        [Required]
        [Display(Name = "Phone Number")]
        public int PhoneNumber
        {
            get;
            set;
        }

        [Required]
        [Display(Name = "Qualification")]
        public string Qualification
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the summary.
        /// </summary>
        /// <value>The summary.</value>
        public int StaffID
        {
            get;
            set;
        }

        [Required]
        [Display(Name = "User Name")]
        public string UserName
        {
            get;
            set;
        }

        #endregion Public Properties
    }
}