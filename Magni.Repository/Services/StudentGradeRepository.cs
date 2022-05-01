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
    public class StudentGradeRepository : GenericRepository<StudentGrading>, IStudentGradeRepository
    {
        private readonly MagniContext _context = new MagniContext();


        public StudentGrading UpdateStudentGrade(RecordStudentGradeVm studentVm)
        {
            var studentGradeFromDb = _context.StudentGradings.FirstOrDefault(c => c.Id == studentVm.StudentGradeVw.StudentGradeId);

            if (studentGradeFromDb != null)
            {
                studentGradeFromDb.GradeId = studentVm.StudentGradeVw.GradeId;
                studentGradeFromDb.SubjectId = studentVm.StudentGradeVw.SubjectId;
            }
            return studentGradeFromDb;
        }
    }
}
