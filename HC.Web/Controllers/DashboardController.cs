using HC.Core.ViewModels;
using HC.Core.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace HC.Web.Controllers
{
    public class DashboardController : Controller
    {
        DoctorViewModel doctorViewModel;
        List<DoctorViewModel> doctorViewModelList = new List<DoctorViewModel>();
        SpecializationViewModel specializationViewModel;
        List<SpecializationViewModel> specializationViewModelList = new List<SpecializationViewModel>();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Test()
        {
            doctorViewModel = new DoctorViewModel();
            string apiUrl = "http://localhost:51137/api/Doctor";
            string inputJson = (new JavaScriptSerializer()).Serialize(null);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("UserName", "shahid");
            client.DefaultRequestHeaders.Add("Password", "shahid");
            HttpContent inputContent = new StringContent(inputJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(apiUrl + "/GetAll", null).Result;
            if (response.IsSuccessStatusCode)
            {
                ResponseModel responseDoctor = new ResponseModel();
                var result = response.Content.ReadAsStringAsync().Result;
                var re = (new JavaScriptSerializer()).Deserialize<ResponseModel>(result);
                //List<DoctorViewModel> customers = (new JavaScriptSerializer()).Deserialize<List<DoctorViewModel>>(response.Content.ReadAsStringAsync().Result);
                //gvCustomers.DataSource = customers;
                //gvCustomers.DataBind();
                //var customer = customers;
                doctorViewModelList = (new JavaScriptSerializer()).Deserialize<List<DoctorViewModel>>(re.Data.ToString());
            }


            //doctorViewModel = new DoctorViewModel();
            //doctorViewModel.Id = 1;
            //doctorViewModel.Name = "Samar Gul";
            //doctorViewModel.Degree = "MBBC, MCP";
            //doctorViewModel.Address = "Budhni";
            //doctorViewModel.Contact = "0912345678, 0312987458";
            //doctorViewModel.SpecializationName = "Allergist or Immunologist";
            //doctorViewModelList.Add(doctorViewModel);
            //doctorViewModel = new DoctorViewModel();
            //doctorViewModel.Id = 1;
            //doctorViewModel.Name = "Rkhsar";
            //doctorViewModel.Degree = "MBBC, MCP";
            //doctorViewModel.Address = "Daman";
            //doctorViewModel.Contact = "0912345678, 0312987458";
            //doctorViewModel.SpecializationName = "Cardiologist";
            //doctorViewModelList.Add(doctorViewModel);
            return PartialView("/Views/Shared/PartialViews/_DoctorsList.cshtml", doctorViewModelList);
        }
        public ActionResult Specializations()
        {
            specializationViewModel = new SpecializationViewModel();
            specializationViewModel.Id = 1;
            specializationViewModel.Name = "Anesthesiologist";
            specializationViewModelList.Add(specializationViewModel);
            specializationViewModel = new SpecializationViewModel();
            specializationViewModel.Id = 1;
            specializationViewModel.Name = "Cardiologist";
            specializationViewModelList.Add(specializationViewModel);
            return PartialView("/Views/Shared/PartialViews/_SpecializationList.cshtml", specializationViewModelList);
        }
    }
}