using Magni.Core.DAL;
using Magni.Core.Dto;
using Magni.Core.Interface;
using Magni.Core.Utility;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magni.Core.Services
{
    public class StudentGradingService : IStudentGrading
    {
        public readonly MagniContext _context = new MagniContext();
        public async Task<Response> CreateStudentGrading(CreateStudentGradingDto studentGradingDto)
        {
            try
            {
                var student = _context.StudentGradings.Any(s => s.GradeId == studentGradingDto.GradeId && s.StudentId == studentGradingDto.StudentId && s.SubjectId == studentGradingDto.SubjectId);
                if (student)
                {
                    return new Response
                    {
                        ResponseMessage = "Duplicate Grading is not allowed"
                    };
                }
                var gradersPoint = new Utility.GetGradePoints();
                _context.StudentGradings.Add(new Models.StudentGrading
                {
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    GradeId = studentGradingDto.GradeId,
                    IsDeleted = false,
                    IsUpdated = false,
                    StudentId = studentGradingDto.StudentId,
                    SubjectId = studentGradingDto.SubjectId,
                    Unit =  _context.Subjects.FirstOrDefault(s=>s.Id == studentGradingDto.SubjectId).Unit,
                    Point =  gradersPoint.grades
                    .Where(s=>s.GradeName == _context.Grades
                    .Where(h=>h.Id == studentGradingDto.GradeId).Select(s=>s.Name)
                    .FirstOrDefault()).Select(f=>f.GradePoint).FirstOrDefault()
                });

                await _context.SaveChangesAsync();
                return new Response
                {
                    ResponseMessage = "Success"
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    ResponseMessage = "An Error Occurred"
                };
            }
        }

        public Task<Response> DeleteGrade(DeleteStudentGradingDto courseDto)
        {
            throw new NotImplementedException();
        }

        public async Task<GetStudentGradingResponseDto> GetGradeId(GetStudentGradingRequestDto subjectDto)
        {
            var getInfo = await _context.StudentGradings.Where(s => s.Id == subjectDto.StudentGradingId).Select(d => new GetStudentGradingResponseDto
            {
                Grade =  d.Grade.Name,
                Score =  d.Grade.Score,
                StudentCourse=  d.Student.Course.Name,
                StudentName= d.Student.Name,
                Subject = d.Subject.Name,
                StudentGradingId =  d.Id
            }).FirstOrDefaultAsync();
            return getInfo;
        }

        

        public async Task<IEnumerable<CourseListDto>> GetStudentCourseAverage()
        {


            var res = _context.Database.SqlQuery<CourseListDto>(@"select a.Id, a.Name, Count(distinct(d.Id))TeacherCount, Count(distinct(b.Id))StudentCount,
                                            isnull(Avg(f.Score), 0)AvgGrade
                                            from Courses a
                                            left outer join Students b on a.Id = b.CourseId
                                            left outer join Subjects c on c.CourseId = a.Id
                                            left outer join Teachers d on c.TeacherId = d.Id
                                            left outer join StudentGradings e on e.StudentId = b.Id
                                            left outer join Grades f on f.Id = e.GradeId
                                            group by a.Id, a.Name
                                            order by a.Id
                                            ").ToList();

            return res;
        }

        public async Task<GetStudentGradingResponseListDto> GetStudentGradingInfoById(GetStudentGradingRequestDto subjectDto)
        {
            var getInfo = await _context.StudentGradings.Where(s => s.Id == subjectDto.StudentGradingId).Select(d => new GetStudentGradingResponseListDto
            {
                StudentCourse = d.Student.Course.Name,
                StudentName = d.Student.Name,
                StudentGradingInfoDtos = _context.StudentGradings.
                Where(h=>h.Id == subjectDto.StudentGradingId && h.StudentId == d.StudentId)
                .Select(g=> new StudentGradingInfoDto
                {
                    Grade = d.Grade.Name,
                    Score = d.Grade.Score,
                    StudentGradingId =  d.Id,
                    Subject =  d.Subject.Name
                }).ToList()
                
            }).FirstOrDefaultAsync();
            return getInfo;
        }

        public async Task<GetStudentGradingResponseListDto> GetStudentGradingInfoByStudentId(StudentGradingRequestDto subjectDto)
        {

            var getInfo = await _context.StudentGradings.Where(s => s.StudentId== subjectDto.StudentId).Select(d => new GetStudentGradingResponseListDto
            {
                StudentCourse = d.Student.Course.Name,
                StudentName = d.Student.Name,
                StudentGradingInfoDtos = _context.StudentGradings.
                Where(h => h.StudentId == subjectDto.StudentId)
                .Select(g => new StudentGradingInfoDto
                {
                    Grade = g.Grade.Name,
                    Score = g.Grade.Score,
                    StudentGradingId = g.Id,
                    Subject = g.Subject.Name
                }).ToList()

            }).FirstOrDefaultAsync();
            return getInfo;
        }

        public async Task<List<SubjectTeacherGradeDto>> GetStudentGradingListInfoByStudent()
        {
            var getAllSubjects = _context.Subjects.Select(e => new SubjectTeacherGradeDto
            {
                SubjectName = e.Name,
                TeacherCourse = e.Course.Name,
                TeacherName = e.Teacher.Name,
                TotalStudents =  _context.StudentGradings.Where(s=>s.SubjectId == e.Id).ToList().Count(),
                StudentGradingInfoDtos =  _context.StudentGradings.Where(s=>s.Subject.Name == e.Name).Select(r=> new StudentGradingInfoDto
                {
                    StudentGradingId = r.Id,
                    Grade = r.Grade.Name,
                    Score = r.Grade.Score,
                    StudentRegNo = r.Student.RegistrationNumber,
                    Subject = r.Subject.Name
                }).ToList()
            }).ToList();
            return getAllSubjects;
        }



        public async Task<IEnumerable<StudentSubjectGradeDto>> GetStudentSubjectGrade()
        {
            var getAllSubjects = _context.StudentGradings.Select(e => new StudentSubjectGradeDto
            {
                StudentName = e.Student.Name,
                StudentGradingInfoDtos = _context.StudentGradings.Where(s=>s.StudentId == e.StudentId).Select(r => new StudentGradingInfoDto
                {
                    StudentGradingId = r.Id,
                    Grade = r.Grade.Name,
                    Score = r.Grade.Score,
                    StudentRegNo = r.Student.RegistrationNumber,
                    Subject = r.Subject.Name
                }).ToList()
            }).ToList();

            var get =  FilterHelper.DistinctBy(getAllSubjects,s=>s.StudentName);
            return get;
        }

        public Task<List<GetGradeResponseDto>> GradeList()
        {
            throw new NotImplementedException();
        }

        public Task<Response> UpdateGrade(UpdateStudentGradingDto courseDto)
        {
            throw new NotImplementedException();
        }
    }
}
