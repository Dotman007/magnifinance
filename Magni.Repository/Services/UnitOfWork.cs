using Magni.Repository.Services;
using Magni.Repository;
using Magni.Repository.DAL;
using System.Threading.Tasks;


namespace CollegeMGT.Repo.Data.GenericRepository.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MagniContext _context = new MagniContext();

        public UnitOfWork()
        {
            CourseRepository = new CourseRepository();
            SubjectRepository = new SubjectRepository();
            TeacherRepository = new TeacherRepository();
            StudentRepository = new StudentRepository();
            StudentGradeRepository = new StudentGradeRepository();
            GradeRepository = new GradeRepository();
        }
        public ICourseRepository CourseRepository { get; private set; }
        public ISubjectRepository SubjectRepository { get; private set; }
        public ITeacherRepository TeacherRepository { get; private set; }
        public IStudentRepository StudentRepository { get; private set; }
        public IStudentGradeRepository StudentGradeRepository { get; private set; }
        public IGradeRepository GradeRepository { get; private set;}
        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
