using HC.Core.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Core.ViewModels
{
    public class DoctorViewModel
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50), Required]
        public string Name { get; set; }
        public string Degree { get; set; }
        [MaxLength(100)]
        public string Address { get; set; }
        [MaxLength(44)]
        public string Contact { get; set; }
        [MaxLength(10)]
        public string Latitude { get; set; }
        [MaxLength(10)]
        public string Longitude { get; set; }
        public int? CityId { get; set; }
        public int? SpecializationId { get; set; }
        [MaxLength(100)]
        public string SpecializationName { get; set; }
        public int? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
        public bool? IsInternalCreated { get; set; }
        public bool? IsActive { get; set; }
    }
}
