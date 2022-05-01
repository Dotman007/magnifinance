using Magni.Core.Models;
using System.Threading.Tasks;

namespace Magni.Repository
{
    public interface IStudentGradeRepository : IGenericRepository<StudentGrading>
    {
        Task<StudentGrading> UpdateStudentGrade(RecordStudentGradeVm studentVm);
    }
}
