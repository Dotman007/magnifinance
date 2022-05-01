using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magni.Core.Dto
{
    public class UpdateSubjectDto
    {
        [Required]
        public long SubjectId { get; set; }
        public string Name { get; set; }
        public long? CourseId { get; set; }
        public long? TeacherId { get; set; }
    }
    public class CreateSubjectDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public long? CourseId { get; set; }
        [Required]
        public long? TeacherId { get; set; }
        [Required]
        [Range(0,10)]
        public int Unit { get; set; }

    }

    public class DeleteSubjectDto
    {
        [Required]
        public long SubjectId { get; set; }
    }

    public class GetSubjectRequestDto
    {
        public long SubjectId { get; set; }
    }

    public class GetSubjectResponseDto
    {
        public long SubjectId { get; set; }
        public string Name { get; set; }

        public long? CourseId { get; set; }

        public long? TeacherId { get; set; }

    }
}
