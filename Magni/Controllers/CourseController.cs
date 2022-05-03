using Magni.Core.Dto;
using Magni.Core.Interface;
using Magni.Hubs;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Magni.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourse _course;
        private readonly IBroadcaster _broadcaster;
        public CourseController(ICourse _course, IBroadcaster broadcaster)
        {
            this._course = _course;
            _broadcaster = broadcaster;
        }  
        
        public ActionResult AddCourse()
        {
            return View();
        }
        public async Task<JsonResult> CreateCourse(CreateCourseDto subject)
        {
            if (!ModelState.IsValid)
            {
                return Json(ModelState);
            }
            var createCourse = await _course.CreateCourse(subject);
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<CourseHub>();
            context.Clients.All.allCourses(subject);
            return Json(createCourse, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> GetCourseId(long Id)
        {
            var getSubject = await _course.GetCourseId(Id);
            return Json(getSubject, JsonRequestBehavior.AllowGet);
        }


        public async Task<JsonResult> AllCourses()
        {
            var getSubject = await _course.CourseList();
            return Json(getSubject, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<JsonResult> UpdateCourse(UpdateCourseDto courseDto)
        {
            if (!ModelState.IsValid)
            {
                return Json(ModelState);
            }
            var updateCourse = await _course.UpdateCourse(courseDto);
            return Json(updateCourse, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> DeleteCourse(long Id)
        {
            if (!ModelState.IsValid)
            {
                return Json(ModelState);
            }
            var deleteCourse = await _course.DeleteCourse(Id);
            return Json(deleteCourse, JsonRequestBehavior.AllowGet);
        }
    }
}