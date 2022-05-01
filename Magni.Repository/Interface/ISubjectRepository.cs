using Magni.Core.Models;
using Magni.Core.ViewModels;
using System.Threading.Tasks;

namespace Magni.Repository
{
    public interface ISubjectRepository : IGenericRepository<Subject>
    {
        Subject UpdateSubject(SubjectViewModel subjectVm);
        Subject GetCourseIdBySubjectId(int? subjectId);
    }
}
