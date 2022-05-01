using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magni.Core.Dto
{
    public class CreateStudentDto
    {
        public string Name { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Birthday")]
        public DateTime Birthday { get; set; }
        public long? CourseId { get; set; }
    }

    public class UpdateStudentDto
    {
        public long StudentId { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Birthday")]
        public DateTime Birthday { get; set; }
        public string? RegistrationNumber { get; set; }
        public long? CourseId { get; set; }
    }



    public class DeleteStudentDto
    {
        public long StudentId { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Birthday")]
        public DateTime Birthday { get; set; }
        public string? RegistrationNumber { get; set; }
        public long? CourseId { get; set; }
    }


    public class GetStudentResponseDto
    {
        public long StudentId { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Birthday")]
        public DateTime Birthday { get; set; }
        public string? RegistrationNumber { get; set; }
        public long? CourseId { get; set; }
    }

    public class GetStudentRequestDto
    {
        public long StudentId { get; set; }
    }
}
