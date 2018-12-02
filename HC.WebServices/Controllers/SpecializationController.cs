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
    public class SpecializationController : ApiController
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        //ResponseModel<SpecializationViewModel> responseSpecialization = new ResponseModel<SpecializationViewModel>();
        ResponseModel responseSpecialization = new ResponseModel();
        string contentType = ConfigurationManager.AppSettings["ContentType"].ToString();
        [HttpPost]
        public HttpResponseMessage Add([FromBody] SpecializationViewModel specializationViewModel)
        {

            try
            {
                var user = UserMatching.IsUserMatch();
                if (user ==null)
                {
                    responseSpecialization.UnAuthorized();
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, responseSpecialization, contentType);
                }
                specializationViewModel.CreatedBy = user.Id;
                specializationViewModel.IsInternalCreated = user.IsInternalUser;
                SqlParameter[] sqlParameters;
                string parameter = SQLParameters.GetParameters<SpecializationViewModel>(specializationViewModel);
                sqlParameters = SQLParameters.GetSQLParameters<SpecializationViewModel>(specializationViewModel, "GetByName").ToArray();
                var specialization = unitOfWork.GetRepositoryInstance<SpecializationViewModel>().ReadStoredProcedure("Specialization_Detail " + parameter, sqlParameters).ToList();
                if (specialization.Count > 0)
                {
                    sqlParameters = SQLParameters.GetSQLParameters<SpecializationViewModel>(specializationViewModel, "GetByName").ToArray();
                    responseSpecialization.Failed((new JavaScriptSerializer()).Serialize(specializationViewModel), "Specialization already exist");
                    return Request.CreateResponse(HttpStatusCode.ExpectationFailed, responseSpecialization, contentType);
                }
                else
                {
                    sqlParameters = SQLParameters.GetSQLParameters<SpecializationViewModel>(specializationViewModel, "Add").ToArray();
                    var result = unitOfWork.GetRepositoryInstance<object>().WriteStoredProcedure("Specialization_Detail " + parameter, sqlParameters);
                    if (result >= 1)
                    {
                        responseSpecialization.Success((new JavaScriptSerializer()).Serialize(specializationViewModel));
                        return Request.CreateResponse(HttpStatusCode.Created, responseSpecialization, contentType);
                    }
                    else
                    {
                        responseSpecialization.Failed((new JavaScriptSerializer()).Serialize(specializationViewModel), "Failed to create new specialization, try again");
                        return Request.CreateResponse(HttpStatusCode.ExpectationFailed, responseSpecialization, contentType);
                    }
                }
            }
            catch (Exception exception)
            {
                responseSpecialization.Exception(exception.Message);
                return Request.CreateResponse(HttpStatusCode.Conflict, responseSpecialization, contentType);
            }
        }
        [HttpPost]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var specializationViewModel = new SpecializationViewModel();
                if (UserMatching.IsUserMatch() ==null)//specializationViewModel.UserName, specializationViewModel.Password))
                {
                    responseSpecialization.UnAuthorized();
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, responseSpecialization, contentType);
                }

                SqlParameter[] sqlParameters;
                string parameter = SQLParameters.GetParameters<SpecializationViewModel>(specializationViewModel);
                sqlParameters = SQLParameters.GetSQLParameters<SpecializationViewModel>(specializationViewModel, "GetAll").ToArray();
                var specialization = unitOfWork.GetRepositoryInstance<SpecializationViewModel>().ReadStoredProcedure("Specialization_Detail " + parameter, sqlParameters).ToList();
                responseSpecialization.Success((new JavaScriptSerializer()).Serialize(specialization));
                return Request.CreateResponse(HttpStatusCode.Accepted, responseSpecialization, contentType);
            }
            catch (Exception exception)
            {
                responseSpecialization.Exception(exception.Message);
                return Request.CreateResponse(HttpStatusCode.Conflict, responseSpecialization, contentType);
            }
        }
        [HttpPost]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var specializationViewModel = new SpecializationViewModel();
                specializationViewModel.Id = id;
                if (UserMatching.IsUserMatch() == null)//specializationViewModel.UserName, specializationViewModel.Password))
                {
                    responseSpecialization.UnAuthorized();
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, responseSpecialization, contentType);
                }

                SqlParameter[] sqlParameters;
                string parameter = SQLParameters.GetParameters<SpecializationViewModel>(specializationViewModel);
                sqlParameters = SQLParameters.GetSQLParameters<SpecializationViewModel>(specializationViewModel, "GetById").ToArray();
                var specialization = unitOfWork.GetRepositoryInstance<SpecializationViewModel>().ReadStoredProcedure("Specialization_Detail " + parameter, sqlParameters).ToList();
                responseSpecialization.Success((new JavaScriptSerializer()).Serialize(specialization));
                return Request.CreateResponse(HttpStatusCode.Accepted, responseSpecialization, contentType);
            }
            catch (Exception exception)
            {
                responseSpecialization.Exception(exception.Message);
                return Request.CreateResponse(HttpStatusCode.Conflict, responseSpecialization, contentType);
            }
        }
        [HttpPost]
        public HttpResponseMessage Update(SpecializationViewModel specializationViewModel)
        {
            try
            {
                var user = UserMatching.IsUserMatch();
                if (user == null)
                {
                    responseSpecialization.UnAuthorized();
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, responseSpecialization, contentType);
                }
                specializationViewModel.UpdatedBy = user.Id;
                specializationViewModel.IsInternalCreated = user.IsInternalUser;
                SqlParameter[] sqlParameters;
                string parameter = SQLParameters.GetParameters<SpecializationViewModel>(specializationViewModel);
                sqlParameters = SQLParameters.GetSQLParameters<SpecializationViewModel>(specializationViewModel, "Update").ToArray();
                var specialization = unitOfWork.GetRepositoryInstance<object>().WriteStoredProcedure("Specialization_Detail " + parameter, sqlParameters);
                responseSpecialization.Success((new JavaScriptSerializer()).Serialize(specializationViewModel));
                return Request.CreateResponse(HttpStatusCode.Accepted, responseSpecialization, contentType);
            }
            catch (Exception exception)
            {
                responseSpecialization.Exception(exception.Message);
                return Request.CreateResponse(HttpStatusCode.Conflict, responseSpecialization, contentType);
            }
        }
    }
}
