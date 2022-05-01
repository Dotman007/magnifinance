using Magni.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magni.Core.Interface
{
    public interface IGrade
    {
        Task<Response> CreateGrade(CreateGradeDto courseDto);
        Task<Response> UpdateGrade(UpdateGradeDto courseDto);
        Task<Response> DeleteGrade(DeleteGradeDto courseDto);
        Task<GetGradeResponseDto> GetGradeId(GetGradeRequestDto subjectDto);
        Task<List<GetGradeResponseDto>> GradeList();
    }
}
