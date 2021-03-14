using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManager.Models;

namespace UniversityManager.Controllers
{
    public class GroupController : Controller
    {
        private ApplicationDbContext _ctx;

        public GroupController()
        {
            _ctx = new ApplicationDbContext();
        }
        
        public ActionResult InfoUser()
        {
            return View();
        }
    }
}