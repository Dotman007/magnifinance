using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magni.Core.Models
{
    public class StudentGrading:Audit
    {


        [ForeignKey("StudentId")]
        public Student Student { get; set; }
        public long? StudentId { get; set; }

        [ForeignKey("SubjectId")]
        public Subject Subject { get; set; }
        public long? SubjectId { get; set; }


        [ForeignKey("GradeId")]
        public Grade Grade { get; set; }
        public long? GradeId { get; set; }
    }
}
