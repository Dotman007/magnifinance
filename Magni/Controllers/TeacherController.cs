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
    public class TeacherController : Controller
    {
        private readonly ITeacher _course;
        public TeacherController(ITeacher _course)
        {
            this._course = _course;
        }  
        
        public async Task<JsonResult> CreateTeacher(CreateTeacherDto subject)
        {
            if (!ModelState.IsValid)
            {
                return Json(ModelState);
            }
            var createCourse = await _course.CreateTeacher(subject);
            return Json(createCourse, JsonRequestBehavior.AllowGet);
        }


        public ActionResult AddTeacher()
        {
            return View();
        }
        public async Task<JsonResult> GetTeacherById(GetTeacherRequestDto subject)
        {
            var getSubject = await _course.GetTeacherById(subject);
            return Json(getSubject, JsonRequestBehavior.AllowGet);
        }


        public async Task<JsonResult> AllTeachers()
        {
            var getSubject = await _course.AllTeachers();
            return Json(getSubject, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> UpdateTeacher(UpdateTeacherDto courseDto)
        {
            if (!ModelState.IsValid)
            {
                return Json(ModelState);
            }
            var updateCourse = await _course.UpdateTeacher(courseDto);
            return Json(updateCourse, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> DeleteTeacher(DeleteTeacherDto courseDto)
        {
            if (!ModelState.IsValid)
            {
                return Json(ModelState);
            }
            var deleteCourse = await _course.DeleteTeacher(courseDto);
            return Json(deleteCourse, JsonRequestBehavior.AllowGet);
        }
    }
}