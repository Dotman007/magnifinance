using Magni.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magni.Core.Interface
{
    public interface ISubject
    {
        Task<Response> CreateSubject(CreateSubjectDto subjectDto);
        Task<Response> UpdateSubject(UpdateSubjectDto subjectDto);
        Task<Response> DeleteSubject(DeleteSubjectDto subjectDto);
        Task<GetSubjectResponseDto> GetSubjectById(GetSubjectRequestDto subjectDto);
        Task<List<GetSubjectResponseDto>> AllSubjects();
    }
}
