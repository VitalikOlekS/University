using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManager.Models;

namespace UniversityManager.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _ctx;

        public HomeController()
        {
            _ctx = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var news = _ctx.News.Select(s => new NewsViewModel
            {
                Description = s.Description,
                RealeseDate = s.RealeseDate,
                ImgUrl = s.ImgUrl,
                Title = s.Title
            });
            return View(news);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}