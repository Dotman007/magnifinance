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
    public class SubjectRepository : GenericRepository<Subject>, ISubjectRepository
    {
        private readonly MagniContext _context = new MagniContext();
       
        public Subject UpdateSubject(SubjectViewModel subjectVm)
        {
            var subjectFromDb = _context.Subjects.FirstOrDefault(c => c.Id == subjectVm.Subject.Id);

            if (subjectFromDb != null)
            {
                subjectFromDb.Name = subjectVm.Subject.Name;
                subjectFromDb.CourseId = subjectVm.Subject.CourseId;
                subjectFromDb.TeacherId = subjectVm.Subject.TeacherId;
            }
            return subjectFromDb;
        }
        public Subject GetCourseIdBySubjectId(int? subjectId)
        {
            var subjectFromDb = _context.Subjects.FirstOrDefault(c => c.Id == subjectId);
            return subjectFromDb;
        }
    }
}
