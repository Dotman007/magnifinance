using Magni.Core.Models;
using Magni.Core.ViewModels;
using System.Threading.Tasks;

namespace Magni.Repository
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        Student UpdateStudent(StudentViewModel studentVm);
        Student GetCourseIdByStudentId(int? studentId);

    }
}
