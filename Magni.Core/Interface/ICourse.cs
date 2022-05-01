using Magni.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magni.Core.Interface
{
    public interface ICourse
    {
        Task<Response> CreateCourse(CreateCourseDto courseDto);
        Task<Response> UpdateCourse(UpdateCourseDto courseDto);
        Task<Response> DeleteCourse(DeleteCourseDto courseDto);
        Task<GetCourseResponseDto> GetCourseId(GetCourseRequestDto subjectDto);
        Task<List<GetCourseResponseDto>> CourseList();
    }
}
