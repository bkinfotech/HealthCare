using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Core.ViewModels.Common
{
    public class UserCredential
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public UserCredential()
        {
            this.UserName = "shahid";
            this.Password = "shahid";
        }
    }
}
