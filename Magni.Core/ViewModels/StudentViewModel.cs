using Magni.Core.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Magni.Core.ViewModels
{
    public class StudentViewModel
    {
        public Student? Student { get; set; }
        public IEnumerable<SelectListItem>? CourseList { get; set; }
        public IEnumerable<SelectListItem>? SubjectList { get; set; }
        public IEnumerable<SelectListItem>? GradeList { get; set; }

    }
}
