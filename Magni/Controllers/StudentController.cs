using Magni.Core.Dto;
using Magni.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Magni.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudent _course;
        public StudentController(IStudent _course)
        {
            this._course = _course;
        }  
        
        public async Task<JsonResult> CreateStudent(CreateStudentDto subject)
        {
            if (!ModelState.IsValid)
            {
                return Json(ModelState);
            }
            var createCourse = await _course.CreateStudent(subject);
            return Json(createCourse, JsonRequestBehavior.AllowGet);
        }


        public ActionResult AddStudent()
        {
            return View();
        }
        public async Task<JsonResult> GetStudentById(GetStudentRequestDto subject)
        {
            var getSubject = await _course.GetStudentById(subject);
            return Json(getSubject, JsonRequestBehavior.AllowGet);
        }


        public async Task<JsonResult> AllStudents()
        {
            var getSubject = await _course.AllStudents();
            return Json(getSubject, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> UpdateTeacher(UpdateStudentDto courseDto)
        {
            if (!ModelState.IsValid)
            {
                return Json(ModelState);
            }
            var updateCourse = await _course.UpdateStudent(courseDto);
            return Json(updateCourse, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> DeleteStudent(DeleteStudentDto courseDto)
        {
            if (!ModelState.IsValid)
            {
                return Json(ModelState);
            }
            var deleteCourse = await _course.DeleteStudent(courseDto);
            return Json(deleteCourse, JsonRequestBehavior.AllowGet);
        }
    }
}