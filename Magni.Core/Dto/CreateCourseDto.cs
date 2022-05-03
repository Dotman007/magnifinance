using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magni.Core.Dto
{
    public class CreateCourseDto
    {
        [Required]
        public string Name { get; set; }
        
    }

    public class UpdateCourseDto
    {
        public long CourseId { get; set; }
        [Required]
        public string Name { get; set; }
    }

    public class GetCourseResponseDto
    {
        public long CourseId { get; set; }
        public string Name { get; set; }

    }

    public class GetCourseRequestDto
    {
        public long CourseId { get; set;}
    }

    public class DeleteCourseDto
    {
        [Required]
        public long CourseId { get; set; }
    }
}
