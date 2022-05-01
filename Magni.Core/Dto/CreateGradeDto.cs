using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magni.Core.Dto
{
    public class CreateGradeDto
    {
        [Required]
        public string Name { get; set; }

        [Range(0, 100)]
        public int Score { get; set; }
    }

    public class UpdateGradeDto
    {
        [Required]
        public long GradeId { get; set; }
        public string Name { get; set; }

        
        public int Score { get; set; }
    }

    public class DeleteGradeDto
    {
        [Required]
        public long GradeId { get; set; }

        
    }

    public class GetGradeRequestDto
    {
        [Required]
        public long GradeId { get; set; }
    }

    public class GetGradeResponseDto
    {
        public long GradeId { get; set; }

        public string Name { get; set; }


        public int Score { get; set; }
    }
}
