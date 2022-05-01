using Magni.Core.Dtos;
using Magni.Core.Models;
using Magni.Repository.DAL;
using System.Linq;
using System.Threading.Tasks;

namespace Magni.Repository.Services
{
    public class GradeRepository : GenericRepository<Grade>, IGradeRepository
    {
        private readonly MagniContext _context = new MagniContext();

        public Grade UpdateGrade(GradeDto grade)
        {
            var gradeFromDb =  _context.Grades.FirstOrDefault(c => c.Id == grade.Id);

            if (gradeFromDb != null)
            {
                gradeFromDb.Name = grade.GradeName;
                gradeFromDb.Score = grade.Score;
            }
            return gradeFromDb;
        }
    }
}
