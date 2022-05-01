using Magni.Core.Dtos;
using Magni.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Magni.Core.Interface
{
    public interface IGradeService
    {
        Task<Grade> AddGrade(GradeDto gradeDto);
        Task<IEnumerable<Grade>> GetAllGrades();

        Task<Grade> UpdateGrade(GradeDto gradeDto);
        Task<Grade> GetGradeById(int gradeId);
        Task DeleteGrade(int gradeId);
    }
}
