using Magni.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magni.Core.Interface
{
    public interface IStudentGrading
    {
        Task<Response> CreateStudentGrading(CreateStudentGradingDto studentGradingDto);

        Task<Response> UpdateGrade(UpdateStudentGradingDto courseDto);
        Task<Response> DeleteGrade(DeleteStudentGradingDto courseDto);
        Task<GetStudentGradingResponseDto> GetGradeId(GetStudentGradingRequestDto subjectDto);
        Task<GetStudentGradingResponseListDto> GetStudentGradingInfoById(GetStudentGradingRequestDto subjectDto);
        Task<GetStudentGradingResponseListDto> GetStudentGradingInfoByStudentId(StudentGradingRequestDto subjectDto);
        Task<List<SubjectTeacherGradeDto>> GetStudentGradingListInfoByStudent();
        Task<IEnumerable<CourseListDto>> GetStudentCourseAverage();
        Task<List<GetGradeResponseDto>> GradeList();
        Task<IEnumerable<StudentSubjectGradeDto>> GetStudentSubjectGrade();
    }
}
