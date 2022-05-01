using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magni.Core.Utility
{

    public class Grades
    {
        public  string GradeName { get; set; }
        public  int GradePoint { get; set; }
    }
    public class GetGradePoints
    {
        public List<Grades> grades = new List<Grades>()
        {
            new Grades
            {
               GradeName =  "A",
               GradePoint = 5
            },
            new Grades
            {
               GradeName =  "B",
               GradePoint = 4
            },
            new Grades
            {
               GradeName =  "C",
               GradePoint = 3
            },
            new Grades
            {
               GradeName =  "D",
               GradePoint = 2
            },
            new Grades
            {
               GradeName =  "E",
               GradePoint = 1
            },
            new Grades
            {
               GradeName =  "F",
               GradePoint = 0
            }
        };

        public List<Grades> AllGradePoints()
        {
            return grades;
        }
    }
}
