using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.CommonObjects.DomainModel
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100),Required]
        public string Name { get; set; }
        [MaxLength(100),Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public int CreatedBy { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }
        public bool? IsInternalUser { get; set; }
        public bool IsActive { get; set; }
    }
}
