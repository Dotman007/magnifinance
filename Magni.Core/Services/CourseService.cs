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
    public class CourseService : ICourse
    {
        public readonly MagniContext _context = new MagniContext();

        public async Task<List<GetCourseResponseDto>> CourseList()
        {
            return await _context.Courses.Where(q=>q.IsDeleted!= true).Select(s=> new GetCourseResponseDto
            {
                CourseId =  s.Id,
                Name =  s.Name,

            }).ToListAsync();
        }

        public  async Task<Response> CreateCourse(CreateCourseDto courseDto)
        {
            try
            {
                _context.Courses.Add(new Models.Course
                {
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    IsDeleted = false,
                    IsUpdated = false,
                    Name = courseDto.Name,
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

        public async Task<Response> DeleteCourse(DeleteCourseDto courseDto)
        {
            try
            {
                var getCourse = await _context.Courses.Where(s => s.Id == courseDto.CourseId).FirstOrDefaultAsync();
                if (getCourse == null)
                {
                    return new Response
                    {
                        ResponseMessage = "Course not found"
                    };
                }
                getCourse.IsDeleted = true;
                getCourse.DateModified = DateTime.Now;
                await _context.SaveChangesAsync();
                return new Response
                {
                    ResponseMessage = "Success"
                };
            }
            catch ( Exception ex)
            {
                return new Response
                {
                    ResponseMessage = "An Error Occurred"
                };
            }

        }

        public async Task<GetCourseResponseDto> GetCourseId(GetCourseRequestDto courseDto)
        {
            var  getCourse = await _context.Courses.Where(z => z.Id == courseDto.CourseId).Select(g => new
              GetCourseResponseDto
            {
                CourseId = g.Id,
                Name = g.Name,
            }).FirstOrDefaultAsync();

            return getCourse;
        }

        public async Task<Response> UpdateCourse(UpdateCourseDto courseDto)
        {
            try
            {
                var getCourse = _context.Courses.FirstOrDefault(x => x.Id == courseDto.CourseId);
                if (getCourse != null)
                {
                    return new Response
                    {
                        ResponseMessage = "Course not found"
                    };
                }
                if (!string.IsNullOrEmpty(courseDto.Name))
                {
                    getCourse.Name = courseDto.Name;
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
