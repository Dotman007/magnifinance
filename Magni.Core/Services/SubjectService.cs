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
    public class SubjectService : ISubject
    {
        public readonly MagniContext _context = new MagniContext();

        public async Task<List<GetSubjectResponseDto>> AllSubjects()
        {
            return await _context.Subjects.Where(a=>a.IsDeleted != true).Select(g => new
            GetSubjectResponseDto
            {
                SubjectId =  g.Id,
                CourseId = g.CourseId,
                Name = g.Name,
                TeacherId = g.TeacherId,
            }).ToListAsync(); 
        }

        public async Task<Response> CreateSubject(CreateSubjectDto subjectDto)
        {
            try
            {
                _context.Subjects.Add(new Models.Subject
                {
                    CourseId = subjectDto.CourseId,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    Name = subjectDto.Name,
                    TeacherId = subjectDto.TeacherId,
                    Unit = subjectDto.Unit,
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

        public async Task<Response> DeleteSubject(DeleteSubjectDto subjectDto)
        {
            try
            {
                var getSubject = _context.Subjects.Where(s => s.Id == subjectDto.SubjectId).FirstOrDefault();
                if (getSubject == null)
                {
                    return new Response
                    {
                        ResponseMessage = "Subject not found"
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

        public async Task<GetSubjectResponseDto> GetSubjectById(GetSubjectRequestDto subjectDto)
        {
            var getSubject = await _context.Subjects.Where(z=>z.Id == subjectDto.SubjectId).Select(g=> new
            GetSubjectResponseDto
            {
                CourseId =  g.CourseId,
                Name = g.Name,
                TeacherId = g.TeacherId,
            }).FirstOrDefaultAsync();
            return getSubject;
        }

        public async Task<Response> UpdateSubject(UpdateSubjectDto subjectDto)
        {
            try
            {
                var getSubject = _context.Subjects.FirstOrDefault(x => x.Id == subjectDto.SubjectId);
                if (getSubject != null)
                {
                    return new Response
                    {
                        ResponseMessage = "Subject not found"
                    };
                }
                if (!string.IsNullOrEmpty(subjectDto.Name))
                {
                    getSubject.Name = subjectDto.Name;
                }
                if (subjectDto.TeacherId != 0)
                {
                    getSubject.TeacherId = subjectDto.TeacherId;
                }
                if (subjectDto.CourseId != 0)
                {
                    getSubject.CourseId = subjectDto.CourseId;
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
