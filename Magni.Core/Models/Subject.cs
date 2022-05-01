using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magni.Core.Models
{
    public class Subject:Audit
    {
            [Required]
            public string Name { get; set; }

            [Required]
            public long? CourseId { get; set; }

            [ForeignKey("CourseId")]
            public Course Course { get; set; }
            public long? TeacherId { get; set; }

            [ForeignKey("TeacherId")]
            public Teacher Teacher { get; set; }
            [Required]
            [Range(0, 10)]
            public int Unit { get; set; }
    }
}
