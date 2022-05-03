using Magni.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magni.Core.Interface
{
    public interface IStudent
    {
        Task<Response> CreateStudent(CreateStudentDto subjectDto);
        Task<Response> UpdateStudent(UpdateStudentDto subjectDto);
        Task<Response> DeleteStudent(long Id);
        Task<GetStudentResponseDto> GetStudentById(long Id);
        Task<List<GetStudentResponseDto>> AllStudents();
    }
}
