using HC.Core.Common;
using HC.Core.ViewModels;
using HC.Core.ViewModels.Common;
using HC.Repository;
using HC.Repository.Custom;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace HC.WebServices.Controllers
{
    public class DoctorController : ApiController
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        ResponseModel responseDoctor = new ResponseModel();
        SpecializationController specializationController = new SpecializationController();
        UserViewModel userViewModel = new UserViewModel();
        string contentType = ConfigurationManager.AppSettings["ContentType"].ToString();

        [HttpPost]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var doctorViewModel = new DoctorViewModel();
                var user = UserMatching.IsUserMatch();
                if (user == null)
                {
                    responseDoctor.UnAuthorized();
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, responseDoctor, contentType);
                }

                SqlParameter[] sqlParameters;
                string parameter = SQLParameters.GetParameters<DoctorViewModel>(doctorViewModel);
                sqlParameters = SQLParameters.GetSQLParameters<DoctorViewModel>(doctorViewModel, "GetAll").ToArray();
                var doctorsList = unitOfWork.GetRepositoryInstance<DoctorViewModel>().ReadStoredProcedure("Doctor_Detail " + parameter, sqlParameters).ToList();
                responseDoctor.Success((new JavaScriptSerializer()).Serialize(doctorsList));
                return Request.CreateResponse(HttpStatusCode.Accepted, responseDoctor, contentType);
            }
            catch (Exception exception)
            {
                responseDoctor.Exception(exception.Message);
                return Request.CreateResponse(HttpStatusCode.Conflict, responseDoctor, contentType);
            }
        }
        [HttpPost]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var doctorViewModel = new DoctorViewModel();
                doctorViewModel.Id = id;
                if (UserMatching.IsUserMatch() == null)
                {
                    responseDoctor.UnAuthorized();
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, responseDoctor, contentType);
                }

                SqlParameter[] sqlParameters;
                string parameter = SQLParameters.GetParameters<DoctorViewModel>(doctorViewModel);
                sqlParameters = SQLParameters.GetSQLParameters<DoctorViewModel>(doctorViewModel, "GetById").ToArray();
                var doctor = unitOfWork.GetRepositoryInstance<DoctorViewModel>().ReadStoredProcedure("Doctor_Detail " + parameter, sqlParameters).ToList();
                responseDoctor.Success((new JavaScriptSerializer()).Serialize(doctor));
                return Request.CreateResponse(HttpStatusCode.Accepted, responseDoctor, contentType);
            }
            catch (Exception exception)
            {
                responseDoctor.Exception(exception.Message);
                return Request.CreateResponse(HttpStatusCode.Conflict, responseDoctor, contentType);
            }
        }
        [HttpPost]
        public HttpResponseMessage Add(DoctorViewModel doctorViewModel)
        {
            try
            {
                var user = UserMatching.IsUserMatch();
                if (user == null)
                {
                    responseDoctor.UnAuthorized();
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, responseDoctor, contentType);
                }
                doctorViewModel.IsInternalCreated = user.IsInternalUser;
                doctorViewModel.CreatedBy = user.Id;
                SqlParameter[] sqlParameters;
                string parameter = SQLParameters.GetParameters<DoctorViewModel>(doctorViewModel);                               
                sqlParameters = SQLParameters.GetSQLParameters<DoctorViewModel>(doctorViewModel, "Add").ToArray();
                var result = unitOfWork.GetRepositoryInstance<object>().WriteStoredProcedure("Doctor_Detail " + parameter, sqlParameters);
                if (result >= 1)
                    responseDoctor.Success((new JavaScriptSerializer()).Serialize(result));
                else
                    responseDoctor.Failed((new JavaScriptSerializer()).Serialize(doctorViewModel), "Failed to add doctor detail, please try again");

                return Request.CreateResponse(HttpStatusCode.Accepted, responseDoctor, contentType);
            }
            catch (Exception exception)
            {
                responseDoctor.Exception(exception.Message);
                return Request.CreateResponse(HttpStatusCode.Conflict, responseDoctor, contentType);
            }
        }
        [HttpPost]
        public HttpResponseMessage Update(DoctorViewModel doctorViewModel)
        {
            try
            {
                var user = UserMatching.IsUserMatch();
                if (user == null)
                {
                    responseDoctor.UnAuthorized();
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, responseDoctor, contentType);
                }
                doctorViewModel.IsInternalCreated = user.IsInternalUser;
                doctorViewModel.CreatedBy = user.Id;
                SqlParameter[] sqlParameters;
                string parameter = SQLParameters.GetParameters<DoctorViewModel>(doctorViewModel);
                sqlParameters = SQLParameters.GetSQLParameters<DoctorViewModel>(doctorViewModel, "Update").ToArray();
                var result = unitOfWork.GetRepositoryInstance<object>().WriteStoredProcedure("Doctor_Detail " + parameter, sqlParameters);
                if (result >= 1)
                    responseDoctor.Success((new JavaScriptSerializer()).Serialize(doctorViewModel));
                else
                    responseDoctor.Failed((new JavaScriptSerializer()).Serialize(doctorViewModel), "Failed to update doctor detail, please try again");

                return Request.CreateResponse(HttpStatusCode.Accepted, responseDoctor, contentType);
            }
            catch (Exception exception)
            {
                responseDoctor.Exception(exception.Message);
                return Request.CreateResponse(HttpStatusCode.Conflict, responseDoctor, contentType);
            }
        }
    }
}
