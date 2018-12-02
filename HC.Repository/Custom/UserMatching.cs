using HC.Core.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HC.Repository.Custom
{
    public class UserMatching
    {
        
        public static UserViewModel IsUserMatch()//string userName, string password)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            //var headers = re.Headers;
            HttpRequestMessage httpRequestMessage = HttpContext.Current.Items["MS_HttpRequestMessage"] as HttpRequestMessage;
            var headers = httpRequestMessage.Headers;
            bool result;
            string userName = string.Empty, password = string.Empty;
            if (headers.Contains("UserName"))
            {
                userName = headers.GetValues("UserName").First();
            }
            if (headers.Contains("Password"))
            {
                password = headers.GetValues("Password").First();
            }
            var user = unitOfWork.GetRepositoryInstance<UserViewModel>().ReadStoredProcedure("SELECT * FROM Users WHERE UserName = '" + userName + "' AND Password = '" + password + "'").FirstOrDefault();
            return user;
            //if (!string.IsNullOrEmpty(userName) && !string.IsNullOrWhiteSpace(userName) && userName.Equals("shahid"))
            //    result = true;
            //else
            //{
            //    result = false;
            //    return result;
            //}
            //if (!string.IsNullOrEmpty(password) && !string.IsNullOrWhiteSpace(password) && password.Equals("shahid"))
            //    result = true;
            //else
            //    result = false;
            //return result;
        }
    }
}
