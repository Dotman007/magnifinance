using CollegeMGT.Core.Models;
using CollegeMGT.Core.View_Models;
using CollegeMGT.Repo.Data.GenericRepository.Implementations;
using CollegeMGT.Repo.Data.Repository.Interface;
using Magni.Core.Models;
using Magni.Core.ViewModels;
using Magni.Repository.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magni.Repository.Services
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        private readonly MagniContext _context = new MagniContext();
     
        public Student UpdateStudent(StudentViewModel studentVm)
        {
            var studentFromDb = _context.Students.FirstOrDefault(c => c.Id == studentVm.Student.Id);

            if (studentFromDb != null)
            {
                studentFromDb.Name = studentVm.Student.Name;
                studentFromDb.CourseId = studentVm.Student.CourseId;
                studentFromDb.Birthday = studentVm.Student.Birthday;
            }
            return studentFromDb;
        }

        public Student GetCourseIdByStudentId(int? studentId)
        {
            var courseFromDb = _context.Students.FirstOrDefault(c => c.Id == studentId);
            return courseFromDb;
        }
    }
}
