using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magni.Core.Dto
{
    public class CreateStudentGradingDto
    {
        public long? StudentId { get; set; }

        public long? SubjectId { get; set; }

        public long? GradeId { get; set; }
    }

    public class UpdateStudentGradingDto
    {
        [Required]
        public long StudentGradingId { get; set; }
        public long? StudentId { get; set; }

        public long? SubjectId { get; set; }

        public long? GradeId { get; set; }
    }

    public class DeleteStudentGradingDto
    {
        [Required]
        public long StudentGradingId { get; set; }
    }


    public class GetStudentGradingRequestDto
    {
        [Required]
        public long StudentGradingId { get; set; }
    }


    public class StudentGradingRequestDto
    {
        [Required]
        public long StudentId { get; set; }
    }

    public class GetStudentGradingResponseDto
    {
        [Required]
        public long StudentGradingId { get; set; }
        public  string StudentName { get; set; }
        public  string Subject { get; set; }
        public  string StudentCourse { get; set; }
        public  string Grade { get; set; }
        public  int Score { get; set; }
    }


    public class GetStudentGradingResponseListDto
    {
        public string StudentName { get; set; }
        public string StudentCourse { get; set; }
        public List<StudentGradingInfoDto> StudentGradingInfoDtos { get; set; }
    }


    public class CourseListDto
    {
        public string Name { get; set; }
        public int TeacherCount { get; set; }
        public int StudentCount { get; set; }
        public int AvgGrade { get; set; }
    }
    public class CourseTeacherStudentDto
    {
        public int TotalTeachers { get; set; }
        public int TotalStudents { get; set; }
        public string CourseName { get; set; }
        public float AverageGrade { get; set; }
        public long? TotalUnit { get; set; }
        public List<StudentGradingInfoDto> StudentGradingInfoDtos { get; set; }
    }
    public class SubjectTeacherGradeDto
    {
        public int TotalStudents { get; set; }
        public string TeacherName { get; set; }
        public string TeacherCourse { get; set; }
        public string SubjectName { get; set; }
        public List<StudentGradingInfoDto> StudentGradingInfoDtos { get; set; }
    }



    public class StudentSubjectGradeDto
    {
        public string StudentName { get; set; }
        public List<StudentGradingInfoDto> StudentGradingInfoDtos { get; set; }
    }

    public class StudentGradingInfoDto
    {
        public long StudentGradingId { get; set; }
        public string StudentRegNo { get; set; }
        public string Subject { get; set; }
        public string Grade { get; set; }
        public int Score { get; set; }
    }

    public class SubjectCourse
    {
        public string SubjectName { get; set; }

        public long TotalStudents { get; set; }
    }

    public class StudentCourseGradingInfoDto
    {
        public long StudentGradingId { get; set; }
        public string StudentRegNo { get; set; }
        public string Subject { get; set; }
        public string Grade { get; set; }
        public int Score { get; set; }
    }
}
