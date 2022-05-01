using Magni.Core.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Magni.Core.ViewModels
{
    public class TeacherViewModel
    {
        public Teacher Teacher { get; set; }
        public IEnumerable<SelectListItem>? CourseList { get; set; }
    }
}
