using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManager.Models;

namespace UniversityManager.Controllers
{
    public class UniversityController : Controller
    {
       
     

        [Authorize(Roles = "Student")]
        public ActionResult StudentPanel()
        {
           
            return View();
        }

        [Authorize(Roles = "Teacher")]
        public ActionResult TeacherPanel()
        {

            return View();
        }
    }
}