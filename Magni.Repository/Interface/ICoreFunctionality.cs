using CollegeMGT.Core.Views;
using Magni.Core.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magni.Core.Interface
{
    public interface ICoreFunctionality
    {
        Task<IEnumerable<SubjectTeacherStudentGrade>> GetSubjectsAndTeacherInformation();
        Task<IEnumerable<StudentSubjectGrade>> GetStudentsAndRespectiveGrades();
        Task<IEnumerable<CourseTeacherStudentAverageGrade>> GetCoursesAndNoOfTeachersAnStudents();
    }
}
