using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManager.Models;

namespace UniversityManager.Controllers
{
    public class GroupRequestController : Controller
    {
        // GET: GroupRequest
        private ApplicationDbContext _ctx;

        public GroupRequestController()
        {
            _ctx = new ApplicationDbContext();
        }
        public ActionResult Index()
        {

            var groupRequests = _ctx.GroupRequests.Select(s => new GroupRequestViewModel
            {
                Description = s.Description,
                FirstName = s.FirstName,
                GroupId = s.GroupId,
                LastName = s.LastName,
                Id = s.Id
            }).ToList();
            foreach (var item in groupRequests)
            {
                var g = _ctx.Groups.FirstOrDefault(s => s.Id == item.GroupId);
                if(g!=null)
                {
                    item.GroupName = g.Name;
                }
            }
            return View(groupRequests);
        }

        [HttpGet]
        public ActionResult Create()
        {
            CreateGroupRequestViewModel model = new CreateGroupRequestViewModel();
            model.Groups = _ctx.Groups.Select(g => new SelectListItem() { Text = g.Name, Value = g.Id.ToString() }).ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CreateGroupRequestViewModel model)
        {
            _ctx.GroupRequests.Add(new Models.EF.GroupRequest
            {
                Description = model.Description,
                FirstName = model.FirstName,
                LastName = model.LastName,
                GroupId = int.Parse(model.GroupId),
            });

            _ctx.SaveChanges();
            return RedirectToAction("Index", "GroupRequest");
        }
    }
}