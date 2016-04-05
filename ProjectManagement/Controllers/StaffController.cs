using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectData;
using ProjectManagement.Helper;
using ProjectManagement.Models;
using ProjectManagement.Properties;

namespace ProjectManagement.Controllers
{
    public class StaffController : Controller
    {
        #region Public Methods

        public ActionResult CreateStaff()
        {
            TrackerONEDbEntities objcontext = new TrackerONEDbEntities();
            StaffUserViewModel staffUserViewModel = new StaffUserViewModel();

            staffUserViewModel.FunctionalGroups = objcontext.ProjectTypes.ToList().ConvertAll(x => new SelectListItem() { Text = x.Name, Value = x.ProjectTypeId.ToString() });
            staffUserViewModel.FunctionalGroups.Add(new SelectListItem() { Text = "Select Function Type", Value = "0", Selected = true });

            staffUserViewModel.Designations = objcontext.Designations.ToList().ConvertAll(x => new SelectListItem() { Text = x.Name, Value = x.DesignationId.ToString() });
            staffUserViewModel.Designations.Add(new SelectListItem() { Text = "Select Designation", Value = "0", Selected = true });

            staffUserViewModel.RoleTypes = objcontext.Roles.ToList().ConvertAll(x => new SelectListItem() { Text = x.RoleTitle, Value = x.RoleId.ToString() });
            staffUserViewModel.RoleTypes.Add(new SelectListItem() { Text = "Select Role", Value = "0", Selected = true });

            staffUserViewModel.Workstreams = objcontext.Workstreams.ToList().ConvertAll(x => new SelectListItem() { Text = x.Name, Value = x.WorkstreamId.ToString() });
            staffUserViewModel.Workstreams.Add(new SelectListItem() { Text = "Select Workstream", Value = "0", Selected = true });

            return View(staffUserViewModel);
        }

        //from action in objcontext.ProjectTypes
        //                                         select new SelectListItem
        //                                         {
        //                                             Text = x.ToString(),
        //                                             Value = ((int)action).ToString()
        //                                         };

        [HttpPost]
        public ActionResult CreateStaff(StaffUserViewModel staffModel, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                var allowedExtensions = new[] {
            ".Jpg", ".png", ".jpg", "jpeg"
             };

                var Image_url = file.ToString();

                var fileName = Path.GetFileName(file.FileName); //getting only file name(ex-ganesh.jpg)
                var ext = Path.GetExtension(file.FileName); //getting the extension(ex-.jpg)

                if (allowedExtensions.Contains(ext)) //check what type of extension
                {
                    string name = Path.GetFileNameWithoutExtension(fileName); //getting file name without extension
                    string myfile = name + "_" + staffModel.UserName + ext; //appending the name with id
                    // store the file inside ~/project folder(Img)
                    var path = Path.Combine(Server.MapPath("~/images"), myfile);
                    staffModel.PhotoFilePath = path;
                    file.SaveAs(path);
                }
                else
                {
                    ViewBag.ErrorMessage = "Please choose only Image file";
                    return View(staffModel);
                }
                TrackerONEDbEntities objcontext = new TrackerONEDbEntities();
                staffModel.Designation = objcontext.Designations.Where(p => p.DesignationId == (long)staffModel.DesignationId).FirstOrDefault();
                staffModel.Workstream = objcontext.Workstreams.Where(p => p.WorkstreamId == (long)staffModel.WorkstreamId).FirstOrDefault();
                staffModel.FunctionalGroup = objcontext.ProjectTypes.Where(p => p.ProjectTypeId == (long)staffModel.FunctionalGroupId).FirstOrDefault();
                objcontext.Users.Add(new User() { UserName = staffModel.UserName, FirstName = staffModel.FirstName, LastName = staffModel.LastName, Password = staffModel.Password, Email = staffModel.Email, Mobile = staffModel.Mobile, LandPhone = staffModel.LandPhone, CreatedOn = DateTime.Now, Designation = staffModel.Designation, Workstream = staffModel.Workstream, ProjectType = staffModel.FunctionalGroup, PhotoFilePath = staffModel.PhotoFilePath });

                objcontext.SaveChanges();
                ModelState.Clear();
                return RedirectToAction("StaffList", "Staff");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid User";
                return View(staffModel);
            }
        }

        [HttpPost]
        public ActionResult DeleteStaff(int UserId)
        {
            TrackerONEDbEntities objcontext = new TrackerONEDbEntities();
            var user = objcontext.Users.Where(p => p.UserId == UserId).FirstOrDefault();
            objcontext.Users.Remove(user);
            var saveresult = objcontext.SaveChanges();
            return Json(new { returnvalue = saveresult });
        }

        [HttpPost]
        public ActionResult IsUserBlock(int UserId, bool IsBlock)
        {
            TrackerONEDbEntities objcontext = new TrackerONEDbEntities();
            var user = objcontext.Users.Where(p => p.UserId == UserId).FirstOrDefault();
            user.IsBlocked = IsBlock;
            var saveresult = objcontext.SaveChanges();
            return Json(new { returnvalue = saveresult });
        }

        [HttpPost]
        public ActionResult SearchStaffList(string name)
        {
            TrackerONEDbEntities objcontext = new TrackerONEDbEntities();
            List<StaffUserViewModel> staffViewModelList = new List<StaffUserViewModel>();
            if (!string.IsNullOrWhiteSpace(name))
            {
                staffViewModelList = objcontext.Users.Where(p => p.FirstName.ToLower().StartsWith(name.ToLower())).ToList().ConvertAll(x => new StaffUserViewModel() { UserId = x.UserId, FirstName = x.FirstName, LastName = x.LastName, WorkstreamId = x.WorkstreamId, Workstream = x.Workstream, Designation = x.Designation, DesignationId = x.DesignationId, Email = x.Email, Mobile = x.Mobile, IsBlocked = x.IsBlocked }); ;
            }
            else
            {
                staffViewModelList = objcontext.Users.ToList().ConvertAll(x => new StaffUserViewModel() { UserId = x.UserId, FirstName = x.FirstName, LastName = x.LastName, WorkstreamId = x.WorkstreamId, Workstream = x.Workstream, Designation = x.Designation, DesignationId = x.DesignationId, Email = x.Email, Mobile = x.Mobile, IsBlocked = x.IsBlocked });
            }

            return PartialView(staffViewModelList);
        }

        public ActionResult StaffDashboard()
        {
            return View();
        }

        public ActionResult StaffList()
        {
            TrackerONEDbEntities objcontext = new TrackerONEDbEntities();
            var staffViewModelList = objcontext.Users.ToList().ConvertAll(x => new StaffUserViewModel() { UserId = x.UserId, FirstName = x.FirstName, LastName = x.LastName, WorkstreamId = x.WorkstreamId, Workstream = x.Workstream, Designation = x.Designation, DesignationId = x.DesignationId, Email = x.Email, Mobile = x.Mobile, IsBlocked = x.IsBlocked });

            return View(staffViewModelList);
        }

        public ActionResult StaffLogin()
        {
            ViewBag.ErrorMessage = string.Empty;
            return View();
        }

        [HttpPost]
        public ActionResult StaffLogin(StaffLoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                if (loginViewModel.UserName == "aa" && loginViewModel.Password == "aa")
                {
                    var culture = CultureHelper.GetImplementedCulture("en-US");

                    return RedirectToAction("StaffDashboard", "Staff");
                }
                else
                {
                    ViewBag.ErrorMessage = "Invalid User";
                    return View(loginViewModel);
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Error in Validation");
            }

            return View(loginViewModel);
        }

        #endregion Public Methods

        #region Private Methods

        private List<StaffViewModel> CreateStaffList()
        {
            List<StaffViewModel> staffViewModelList = new List<StaffViewModel>();

            StaffViewModel staffViewModel = new StaffViewModel() { StaffID = 1, Age = 20, Name = "Joby", Experience = 2, PhoneNumber = 854798921, Qualification = "MCA", UserName = "JobyJ" };
            StaffViewModel staffViewModel1 = new StaffViewModel() { StaffID = 1, Age = 20, Name = "Joby", Experience = 2, PhoneNumber = 854798921, Qualification = "MCA", UserName = "JobyJ" };
            StaffViewModel staffViewModel2 = new StaffViewModel() { StaffID = 1, Age = 20, Name = "Joby", Experience = 2, PhoneNumber = 854798921, Qualification = "MCA", UserName = "JobyJ" };
            StaffViewModel staffViewModel3 = new StaffViewModel() { StaffID = 1, Age = 20, Name = "Joby", Experience = 2, PhoneNumber = 854798921, Qualification = "MCA", UserName = "JobyJ" };
            StaffViewModel staffViewModel4 = new StaffViewModel() { StaffID = 1, Age = 20, Name = "Joby", Experience = 2, PhoneNumber = 854798921, Qualification = "MCA", UserName = "JobyJ" };
            StaffViewModel staffViewModel5 = new StaffViewModel() { StaffID = 1, Age = 20, Name = "Joby", Experience = 2, PhoneNumber = 854798921, Qualification = "MCA", UserName = "JobyJ" };
            StaffViewModel staffViewModel6 = new StaffViewModel() { StaffID = 1, Age = 20, Name = "Joby", Experience = 2, PhoneNumber = 854798921, Qualification = "MCA", UserName = "JobyJ" };
            StaffViewModel staffViewModel7 = new StaffViewModel() { StaffID = 1, Age = 20, Name = "Joby", Experience = 2, PhoneNumber = 854798921, Qualification = "MCA", UserName = "JobyJ" };
            StaffViewModel staffViewModel8 = new StaffViewModel() { StaffID = 1, Age = 20, Name = "Joby", Experience = 2, PhoneNumber = 854798921, Qualification = "MCA", UserName = "JobyJ" };
            StaffViewModel staffViewModel9 = new StaffViewModel() { StaffID = 1, Age = 20, Name = "Joby", Experience = 2, PhoneNumber = 854798921, Qualification = "MCA", UserName = "JobyJ" };
            StaffViewModel staffViewModel10 = new StaffViewModel() { StaffID = 1, Age = 20, Name = "Joby", Experience = 2, PhoneNumber = 854798921, Qualification = "MCA", UserName = "JobyJ" };
            StaffViewModel staffViewModel11 = new StaffViewModel() { StaffID = 1, Age = 20, Name = "Joby", Experience = 2, PhoneNumber = 854798921, Qualification = "MCA", UserName = "JobyJ" };
            StaffViewModel staffViewModel12 = new StaffViewModel() { StaffID = 1, Age = 20, Name = "Joby", Experience = 2, PhoneNumber = 854798921, Qualification = "MCA", UserName = "JobyJ" };
            StaffViewModel staffViewModel13 = new StaffViewModel() { StaffID = 1, Age = 20, Name = "Joby", Experience = 2, PhoneNumber = 854798921, Qualification = "MCA", UserName = "JobyJ" };
            StaffViewModel staffViewModel14 = new StaffViewModel() { StaffID = 1, Age = 20, Name = "Joby", Experience = 2, PhoneNumber = 854798921, Qualification = "MCA", UserName = "JobyJ" };
            StaffViewModel staffViewModel15 = new StaffViewModel() { StaffID = 1, Age = 20, Name = "Joby", Experience = 2, PhoneNumber = 854798921, Qualification = "MCA", UserName = "JobyJ" };
            StaffViewModel staffViewModel16 = new StaffViewModel() { StaffID = 1, Age = 20, Name = "Joby", Experience = 2, PhoneNumber = 854798921, Qualification = "MCA", UserName = "JobyJ" };
            StaffViewModel staffViewModel17 = new StaffViewModel() { StaffID = 1, Age = 20, Name = "Joby", Experience = 2, PhoneNumber = 854798921, Qualification = "MCA", UserName = "JobyJ" };
            StaffViewModel staffViewModel18 = new StaffViewModel() { StaffID = 1, Age = 20, Name = "Joby", Experience = 2, PhoneNumber = 854798921, Qualification = "MCA", UserName = "JobyJ" };
            StaffViewModel staffViewModel19 = new StaffViewModel() { StaffID = 1, Age = 20, Name = "Joby", Experience = 2, PhoneNumber = 854798921, Qualification = "MCA", UserName = "JobyJ" };
            StaffViewModel staffViewModel20 = new StaffViewModel() { StaffID = 1, Age = 20, Name = "Joby", Experience = 2, PhoneNumber = 854798921, Qualification = "MCA", UserName = "JobyJ" };

            staffViewModelList.Add(staffViewModel);
            staffViewModelList.Add(staffViewModel1);
            staffViewModelList.Add(staffViewModel2);
            staffViewModelList.Add(staffViewModel3);
            staffViewModelList.Add(staffViewModel4);
            staffViewModelList.Add(staffViewModel5);
            staffViewModelList.Add(staffViewModel6);
            staffViewModelList.Add(staffViewModel7);
            staffViewModelList.Add(staffViewModel8);
            staffViewModelList.Add(staffViewModel9);
            staffViewModelList.Add(staffViewModel10);
            staffViewModelList.Add(staffViewModel11);
            staffViewModelList.Add(staffViewModel12);
            staffViewModelList.Add(staffViewModel13);
            staffViewModelList.Add(staffViewModel4);
            staffViewModelList.Add(staffViewModel15);
            staffViewModelList.Add(staffViewModel16);
            staffViewModelList.Add(staffViewModel17);
            staffViewModelList.Add(staffViewModel18);
            staffViewModelList.Add(staffViewModel19);
            staffViewModelList.Add(staffViewModel20);

            return staffViewModelList;
        }

        #endregion Private Methods
    }
}