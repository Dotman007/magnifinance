using Magni.Core.Dtos;
using Magni.Core.Models;
using System.Threading.Tasks;

namespace Magni.Repository
{
    public interface ICourseRepository : IGenericRepository<Course>
    {
        Course UpdateCourse(CourseDto course);
    }
}
