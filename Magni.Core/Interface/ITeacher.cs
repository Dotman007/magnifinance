using Magni.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magni.Core.Interface
{
    public interface ITeacher
    {
        Task<Response> CreateTeacher(CreateTeacherDto teacherDto);
        Task<Response> UpdateTeacher(UpdateTeacherDto teacherDto);
        Task<Response> DeleteTeacher(long Id);
        Task<GetTeacherResponseDto> GetTeacherById(long Id);
        Task<List<GetTeacherResponseDto>> AllTeachers();
    }
}
