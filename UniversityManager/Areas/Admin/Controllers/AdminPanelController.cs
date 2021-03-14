using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManager.Helpers;
using UniversityManager.Models;


namespace UniversityManager.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminPanelController : Controller
    {
        private ApplicationDbContext _ctx;

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AdminPanelController()
        {
            _ctx = new ApplicationDbContext();
        }

        public AdminPanelController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult StudentsList()
        {
            var role = _ctx.Roles.FirstOrDefault(r => r.Name == "Student");
            List<UserViewModel> Users = new List<UserViewModel>();
            foreach (var item in _ctx.Users.ToList())
            {
                var roles = item.Roles.ToList();
                if (roles.FirstOrDefault(r => r.RoleId == role.Id) != null)
                    Users.Add(new UserViewModel { Email = item.Email });
            }
            return View(Users);
        }

        public ActionResult TeachersList()
        {
            var role = _ctx.Roles.FirstOrDefault(r => r.Name == "Teacher");
            List<UserViewModel> Users = new List<UserViewModel>();
            foreach (var item in _ctx.Users.ToList())
            {
                var roles = item.Roles.ToList();
                if (roles.FirstOrDefault(r => r.RoleId == role.Id) != null)
                    Users.Add(new UserViewModel { Email = item.Email });
            }
            return View(Users);
        }

        [HttpGet]
        public ActionResult CreateTeacher()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
      
        public async System.Threading.Tasks.Task<ActionResult> CreateTeacher(RegisterTeacherViewModel model, HttpPostedFileBase ImgFile)
        {

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    string fileName = Guid.NewGuid().ToString() + ".jpg";

                    string image = Server.MapPath(UniversityManager.Helpers.Constants.ImagePath) + "//" + fileName;

                    using (Bitmap img = new Bitmap(ImgFile.InputStream))
                    {
                        Bitmap saveImg = ImageWorker.CreateImage(img, 400, 400);
                        if (saveImg != null)
                        {
                            saveImg.Save(image, ImageFormat.Jpeg);
                            _ctx.TeacherAdditionalInfos.Add(new Models.EF.TeacherAdditionalInfo()
                            {
                                FullName = model.FullName,
                                Address = model.Address,
                                Image = fileName,
                                Id = user.Id,
                                Skills = model.Skills
                            });
                            _ctx.SaveChanges();
                        }
                    }
                    UserManager.AddToRole(user.Id, "Teacher");
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    return RedirectToAction("Index", "Home", new { area = "" });
                }
                AddErrors(result);
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult CreateGroup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateGroup(CreateGroupViewModel model)
        {
            _ctx.Groups.Add(new Models.EF.Group
            {
                Description = model.Description,
                Name = model.Name,
                EducationStartDate = model.EducationStartDate
            });

            _ctx.SaveChanges();
            return RedirectToAction("GroupList", "AdminPanel");
        }

        [HttpGet]
        public ActionResult CreateNews()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateNews(CreateNewsViewModel model)
        {
            _ctx.News.Add(new Models.EF.News
            {
                Description = model.Description,
                ImgUrl = model.ImgUrl,
                RealeseDate = model.RealeseDate,
                Title = model.Title
            });

            _ctx.SaveChanges();
            return RedirectToAction("Index", "Home", new { area="" });
        }

        public ActionResult GroupList()
        {
            var groups = _ctx.Groups.Select(s => new GroupViewModel
            {
                Description = s.Description,
                Name = s.Name,
                Id = s.Id
            });
            return View(groups);
        }

        private void AddErrors(Microsoft.AspNet.Identity.IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}