using Magni.Core.Dtos;
using Magni.Core.Models;
using System.Threading.Tasks;

namespace Magni.Repository
{
    public interface IGradeRepository : IGenericRepository<Grade>
    {
        Grade UpdateGrade(GradeDto grade);
    }
}
