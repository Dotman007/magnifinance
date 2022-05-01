using Magni.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magni.Core.Dtos
{
    public class CourseDto:Audit
    {
        public string CourseName { get; set; }
    }
}
