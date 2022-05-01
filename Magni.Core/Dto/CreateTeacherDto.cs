using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magni.Core.Dto
{
    public class CreateTeacherDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Birthday")]
        public DateTime Birthday { get; set; }
        [Required]
        public decimal Salary { get; set; }
    }


    public class UpdateTeacherDto
    {
        [Required]
        public long TeacherId { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Birthday")]
        public DateTime Birthday { get; set; }
        public decimal Salary { get; set; }
    }

    public class DeleteTeacherDto
    {
        [Required]
        public long TeacherId { get; set; }
    }


    public class GetTeacherResponseDto
    {
        public long TeacherId { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Birthday")]
        public DateTime Birthday { get; set; }
        public decimal Salary { get; set; }
    }


    public class GetTeacherRequestDto
    {
        [Required]
        public long TeacherId { get; set; }
    }

}
