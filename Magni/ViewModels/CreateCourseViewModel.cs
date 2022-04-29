
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;

namespace Magni.ViewModels
{
    public class CreateCourseViewModel
    {
        [Required(ErrorMessage ="Course Name is Required")]
        public string Name { get; set; }
    }
}