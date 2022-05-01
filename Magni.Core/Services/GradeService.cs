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
    public class GradeService : IGrade
    {
        public readonly MagniContext _context = new MagniContext();
        public async Task<List<GetGradeResponseDto>> GradeList()
        {
            return await _context.Grades.Where(a => a.IsDeleted != true).Select(g => new
              GetGradeResponseDto
            {
                Name = g.Name,
                Score = g.Score,
                GradeId = g.Id
            }).ToListAsync();
        }

        public async Task<Response> CreateGrade(CreateGradeDto courseDto)
        {
            try
            {
                _context.Grades.Add(new Models.Grade
                {
                    Score =  courseDto.Score,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
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

        public async Task<Response> DeleteGrade(DeleteGradeDto courseDto)
        {
            try
            {
                var getSubject = _context.Grades.Where(s => s.Id == courseDto.GradeId).FirstOrDefault();
                if (getSubject == null)
                {
                    return new Response
                    {
                        ResponseMessage = "Grade not found"
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

        public async Task<GetGradeResponseDto> GetGradeId(GetGradeRequestDto subjectDto)
        {
            var getSubject = await _context.Grades.Where(z => z.Id == subjectDto.GradeId).Select(g => new
              GetGradeResponseDto
            {
                Name = g.Name,
                Score =  g.Score,
                GradeId = g.Id,
            }).FirstOrDefaultAsync();
            return getSubject;
        }

        public async Task<Response> UpdateGrade(UpdateGradeDto courseDto)
        {
            try
            {
                var getSubject = _context.Grades.FirstOrDefault(x => x.Id == courseDto.GradeId);
                if (getSubject != null)
                {
                    return new Response
                    {
                        ResponseMessage = "Grade not found"
                    };
                }
                if (!string.IsNullOrEmpty(courseDto.Name))
                {
                    getSubject.Name = courseDto.Name;
                }
                if (courseDto.Score  > 0)
                {
                    courseDto.Score = courseDto.Score;
                }
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
