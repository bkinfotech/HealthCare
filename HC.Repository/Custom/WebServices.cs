using HC.Core.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace HC.Repository.Custom
{
    public class WebServices
    {
        HttpClient httpClient;
        string baseURL = "http://localhost:51137/api/"; //ConfigurationManager.AppSettings["BaseURL"].ToString();
        ResponseModel responseModel;
        public WebServices()
        {
            if (httpClient == null)
            {
                httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("UserName", "shahid");
                httpClient.DefaultRequestHeaders.Add("Password", "shahid");
            }
            responseModel = new ResponseModel();
        }
        public ResponseModel Post(object input,string service)
        {            
            string inputJson = (new JavaScriptSerializer()).Serialize(input);


            HttpContent inputContent = new StringContent(inputJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = httpClient.PostAsync(baseURL + service, inputContent).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                responseModel = (new JavaScriptSerializer()).Deserialize<ResponseModel>(result);
            }
            return responseModel;
        }
    }
}
