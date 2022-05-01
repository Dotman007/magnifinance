using Magni.Core.Models;
using Magni.Core.ViewModels;
using System.Threading.Tasks;

namespace Magni.Repository
{
    public interface ITeacherRepository : IGenericRepository<Teacher>
    {
        Teacher UpdateTeacher(TeacherViewModel teacher);
    }
}
