using Magni.Core.Models;
using Magni.Core.Views;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Magni.Core.ViewModels
{
    public class RecordStudentGradeVm
    {
        public Student? Student { get; set; }
        public StudentGrading? StudentGrade { get; set; }
        public StudentGradeVw? StudentGradeVw { get; set; }
        public IEnumerable<SelectListItem>? SubjectList { get; set; }
        public IEnumerable<SelectListItem>? GradeList { get; set; }
    }
}
