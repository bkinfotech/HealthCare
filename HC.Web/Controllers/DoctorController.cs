using HC.Core.ViewModels;
using HC.Core.ViewModels.Common;
using HC.Repository.Custom;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace HC.Web.Controllers
{
    public class DoctorController : Controller
    {
        DoctorViewModel doctorViewModel;
        List<DoctorViewModel> doctorViewModelList = new List<DoctorViewModel>();
        //string baseURL = ConfigurationManager.AppSettings["BaseURL"].ToString();
        WebServices webServices = new WebServices();
        public PartialViewResult GetDoctorsList()
        {
            var result = webServices.Post(new DoctorViewModel(),"Doctor/GetAll");
            doctorViewModelList = (new JavaScriptSerializer()).Deserialize<List<DoctorViewModel>>(result.Data.ToString());
            return PartialView("/Views/Shared/PartialViews/_DoctorsList.cshtml", doctorViewModelList);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(DoctorViewModel doctorViewModel)
        {
            return View();
        }
    }
}