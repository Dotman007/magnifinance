using Magni.Core.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Magni.Core.ViewModels
{
    public class StudentGradeViewModel
    {
        public StudentGrading StudentGrade { get; set; }
        public IEnumerable<SelectListItem>? StudentList { get; set; }
        public IEnumerable<SelectListItem>? SubjectList { get; set; }
        public IEnumerable<SelectListItem>? GradeList { get; set; }
    }
}
