using Magni.Core.Dto;
using Magni.Core.Interface;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Magni.Controllers
{
    public class GradeController : Controller
    {
        private readonly IGrade _course;
        public GradeController(IGrade _course)
        {
            this._course = _course;
        }  
        
        public async Task<JsonResult> CreateGrade(CreateGradeDto subject)
        {
            if (!ModelState.IsValid)
            {
                return Json(ModelState);
            }
            var createCourse = await _course.CreateGrade(subject);
            return Json(createCourse, JsonRequestBehavior.AllowGet);
        }


        public ActionResult AddGrade()
        {
            return View();
        }
        public ActionResult AddTeacher()
        {
            return View();
        }
        public async Task<JsonResult> GetGradeById(GetGradeRequestDto subject)
        {
            var getSubject = await _course.GetGradeId(subject);
            return Json(getSubject, JsonRequestBehavior.AllowGet);
        }


        public async Task<JsonResult> AllGrades()
        {
            var getSubject = await _course.GradeList();
            return Json(getSubject, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> UpdateGrade(UpdateGradeDto courseDto)
        {
            if (!ModelState.IsValid)
            {
                return Json(ModelState);
            }
            var updateCourse = await _course.UpdateGrade(courseDto);
            return Json(updateCourse, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> DeleteTeacher(DeleteGradeDto courseDto)
        {
            if (!ModelState.IsValid)
            {
                return Json(ModelState);
            }
            var deleteCourse = await _course.DeleteGrade(courseDto);
            return Json(deleteCourse, JsonRequestBehavior.AllowGet);
        }
    }
}