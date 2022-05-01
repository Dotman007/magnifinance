using System;
using System.Threading.Tasks;

namespace Magni.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        ICourseRepository CourseRepository { get; }
        ISubjectRepository SubjectRepository { get; }
        ITeacherRepository TeacherRepository { get; }
        IStudentRepository StudentRepository { get; }
        IStudentGradeRepository StudentGradeRepository { get; }
        IGradeRepository GradeRepository { get; }
        Task Save();
    }
}
