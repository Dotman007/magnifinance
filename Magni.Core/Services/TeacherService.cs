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
    public class TeacherService : ITeacher
    {
        public readonly MagniContext _context = new MagniContext();
        public async Task<List<GetTeacherResponseDto>> AllTeachers()
        {
            return await _context.Teachers.Where(x=>x.IsDeleted != true).Select(s => new GetTeacherResponseDto
            {
                TeacherId =  s.Id,
                Birthday = s.Birthday,
                Name = s.Name,
                Salary = s.Salary,

            }).ToListAsync();
        }

        public async Task<Response> CreateTeacher(CreateTeacherDto teacherDto)
        {
            try
            {
                _context.Teachers.Add(new Models.Teacher
                {
                    Name = teacherDto.Name,
                    Birthday = teacherDto.Birthday.ToString("yyyy-MM-dd"),
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    IsDeleted = false,
                    IsUpdated = false,
                    Salary = teacherDto.Salary,
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

        public async Task<Response> DeleteTeacher(long Id)
        {
            try
            {
                var delete = _context.Teachers.FirstOrDefault(s => s.Id == Id);
                if (delete == null)
                {
                    return new Response
                    {
                        ResponseMessage = "Teacher not found"
                    };
                }

                delete.DateModified = DateTime.Now;
                delete.IsDeleted = true;
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

        public async Task<GetTeacherResponseDto> GetTeacherById(long Id)
        {
            var teacher =  _context.Teachers.Where(s => s.Id == Id).Select(x => new GetTeacherResponseDto
            {
                TeacherId =  x.Id,
                Birthday = x.Birthday,
                Name = x.Name,
                Salary = x.Salary
            }).FirstOrDefault();

            return teacher;
        }

        public async Task<Response> UpdateTeacher(UpdateTeacherDto teacherDto)
        {
            try
            {
                var getCourse = _context.Teachers.FirstOrDefault(x => x.Id == teacherDto.TeacherId);
                if (getCourse == null)
                {
                    return new Response
                    {
                        ResponseMessage = "Teacher not found"
                    };
                }
                if (!string.IsNullOrEmpty(teacherDto.Name))
                {
                    getCourse.Name = teacherDto.Name;
                }

                if (teacherDto.Salary > 0)
                {
                    getCourse.Salary = teacherDto.Salary;
                }

                if (teacherDto.Birthday != null)
                {
                    getCourse.Birthday = teacherDto.Birthday.ToString("yyyy-MM-dd");
                }
                getCourse.DateModified = DateTime.Now;
                getCourse.IsUpdated = true;
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
