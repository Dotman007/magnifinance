using CollegeMGT.Core.Dtos;
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
    public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository
    {
        private readonly MagniContext _context = new MagniContext();

        public  Teacher UpdateTeacher(TeacherViewModel teacher)
        {
            var teacherFromDb = _context.Teachers.FirstOrDefault(c => c.Id == teacher.Teacher.Id);


            if (teacherFromDb != null)
            {
                teacherFromDb.Name = teacher.Teacher.Name;
                teacherFromDb.Birthday = teacher.Teacher.Birthday;
                teacherFromDb.Salary = teacher.Teacher.Salary;
            }
            return teacherFromDb;
        }
    }
}
