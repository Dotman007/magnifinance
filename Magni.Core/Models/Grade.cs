using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magni.Core.Models
{
    public class Grade:Audit
    {
        public string Name { get; set; }

        [Range(0,100)]
        public int Score { get; set; }

    }
}
