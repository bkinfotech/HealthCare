using HC.Core.ViewModels;
using HC.Repository.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace HC.Web.Controllers
{
    public class SpecializationController : Controller
    {
        SpecializationViewModel specializationViewModel;
        List<SpecializationViewModel> specializationViewModelList = new List<SpecializationViewModel>();
        WebServices webServices = new WebServices();
        public ActionResult GetSpecializations()
        {
            var result = webServices.Post(new SpecializationViewModel(), "Specialization/GetAll");
            specializationViewModelList = (new JavaScriptSerializer()).Deserialize<List<SpecializationViewModel>>(result.Data.ToString());
            
            return PartialView("/Views/Shared/PartialViews/_SpecializationList.cshtml", specializationViewModelList);
        }
    }
}