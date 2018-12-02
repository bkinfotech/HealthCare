using HC.Core.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Core.ViewModels
{
    public class SpecializationViewModel//: UserCredential
    {
        //[Key]
        //public new int Id { get; set; }
        //[MaxLength(100), Required]
        //public string Name { get; set; }
        //[MaxLength(500)]
        //public string Description { get; set; }
        //[Required]
        //public DateTimeOffset CreatedDate { get; set; }
        //public DateTimeOffset UpdatedDate { get; set; }
        //public bool IsInternalCreated { get; set; }
        [Key]
        public int Id { get; set; }
        [MaxLength(100), Required]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public int? CreatedBy { get; set; }
        [Required]
        public DateTimeOffset? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }

        public bool? IsInternalCreated { get; set; }
    }
}
