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
        Task<Response> DeleteCourse(long Id);
        Task<GetCourseResponseDto> GetCourseId(long Id);
        Task<List<GetCourseResponseDto>> CourseList();
    }
}
