using Magni.Core.Models;
using Magni.Core.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Magni.Core.Interface
{
    public interface ITeacherService
    {
        Task<Teacher> AddTeacher(TeacherViewModel teacherVm);
        Task<IEnumerable<Teacher>> GetAllTeacher();
        Task<Teacher> UpdateTeacher(TeacherViewModel teacherVm);
        Task<Teacher> GetTeacherById(int teacherId);
        Task<IEnumerable<Teacher>> GetAvailableTeachers(int courseId);
        Task DeleteTeacher(int teacherId);
    }
}
