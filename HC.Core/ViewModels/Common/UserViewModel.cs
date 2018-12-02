using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Core.ViewModels.Common
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool? IsInternalUser { get; set; }
        //public UserViewModel()
        //{
        //    this.UserName = "shahid";
        //    this.Password = "shahid";
        //}
    }
}
