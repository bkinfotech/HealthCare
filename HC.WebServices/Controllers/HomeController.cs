using HC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HC.WebServices.Controllers
{
    public class HomeController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        public ActionResult Index()
        {
            //unitOfWork.GetRepositoryInstance<object>().GetAll().ToList();
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
