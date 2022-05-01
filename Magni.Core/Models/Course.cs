using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magni.Core.Models
{
    public class Course : Audit
    {
        public string Name { get; set; }
        public int Unit{ get; set; }


    }
}
