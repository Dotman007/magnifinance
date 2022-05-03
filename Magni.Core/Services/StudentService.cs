using Magni.Core.DAL;
using Magni.Core.Dto;
using Magni.Core.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magni.Core.Services
{
    public class StudentService : IStudent
    {
        public readonly MagniContext _context = new MagniContext();
        public async Task<List<GetStudentResponseDto>> AllStudents()
        {
            return await _context.Students.Where(a => a.IsDeleted != true).Select(g => new
              GetStudentResponseDto
            {
                StudentId = g.Id,
                CourseId = g.CourseId,
                Name = g.Name,
                Birthday =  g.Birthday,
                RegistrationNumber = g.RegistrationNumber,
            }).ToListAsync();
        }
        private static Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public async Task<Response> CreateStudent(CreateStudentDto subjectDto)
        {
            try
            {
                _context.Students.Add(new Models.Student
                {
                    CourseId = subjectDto.CourseId,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    Name = subjectDto.Name,
                    Birthday = subjectDto.Birthday.ToString("yyyy-MM-dd"),
                    RegistrationNumber = RandomString(10) 
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

        public async Task<Response> DeleteStudent(long Id)
        {
            try
            {
                var getSubject = _context.Students.Where(s => s.Id == Id).FirstOrDefault();
                if (getSubject == null)
                {
                    return new Response
                    {
                        ResponseMessage = "Student not found"
                    };
                }

                getSubject.DateModified = DateTime.Now;
                getSubject.IsDeleted = true;
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

        public async Task<GetStudentResponseDto> GetStudentById(long Id)
        {
            var getSubject = await _context.Students.Where(z => z.Id == Id).Select(g => new
               GetStudentResponseDto
            {
                CourseId = g.CourseId,
                Name = g.Name,
                Birthday = g.Birthday,
                RegistrationNumber = g.RegistrationNumber,
                StudentId = g.Id
            }).FirstOrDefaultAsync();
            return getSubject;
        }

        public async Task<Response> UpdateStudent(UpdateStudentDto subjectDto)
        {
            try
            {
                var getSubject = _context.Students.FirstOrDefault(x => x.Id == subjectDto.StudentId);
                if (getSubject == null)
                {
                    return new Response
                    {
                        ResponseMessage = "Student not found"
                    };
                }
                if (!string.IsNullOrEmpty(subjectDto.Name))
                {
                    getSubject.Name = subjectDto.Name;
                }
                if (subjectDto.Birthday != null)
                {
                    getSubject.Birthday = subjectDto.Birthday.ToString("yyyy-MM-dd");
                }
                if (subjectDto.CourseId != 0)
                {
                    getSubject.CourseId = subjectDto.CourseId;
                }
                getSubject.DateModified = DateTime.Now;
                getSubject.IsUpdated = true;
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
    }
}
