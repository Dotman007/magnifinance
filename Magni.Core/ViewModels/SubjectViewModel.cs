using System.Collections.Generic;
using System.Web.Mvc;
using Magni.Core.Models;

namespace Magni.Core.ViewModels
{
    public class SubjectViewModel
    {
        public Subject Subject { get; set; }
        public IEnumerable<SelectListItem>? CourseList { get; set; }
        public IEnumerable<SelectListItem>? TeacherList { get; set; }
    }
}
