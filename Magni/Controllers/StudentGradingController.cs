using Magni.Core.Dto;
using Magni.Core.Interface;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Magni.Controllers
{
    public class StudentGradingController : Controller
    {
        private readonly IStudentGrading _course;
        public StudentGradingController(IStudentGrading _course)
        {
            this._course = _course;
        }  
        
        public async Task<JsonResult> CreateStudentGrading(CreateStudentGradingDto subject)
        {
            if (!ModelState.IsValid)
            {
                return Json(ModelState);
            }
            var createCourse = await _course.CreateStudentGrading(subject);
            return Json(createCourse, JsonRequestBehavior.AllowGet);
        }


        public ActionResult AddStudentGrading()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult SubjectInfo()
        {
            return View();
        }

        public ActionResult CourseInfo()
        {
            return View();
        }


        public async Task<JsonResult> GetGradeById(GetStudentGradingRequestDto subject)
        {
            var getSubject = await _course.GetGradeId(subject);
            return Json(getSubject, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> GetStudentGradingInfoById(GetStudentGradingRequestDto subjectDto)
        {
            var getSubject = await _course.GetStudentGradingInfoById(subjectDto);
            return Json(getSubject, JsonRequestBehavior.AllowGet);
        }


        public async Task<JsonResult>  GetStudentCourseAverage()
        {
            var getSubject = await _course.GetStudentCourseAverage();
            return Json(getSubject, JsonRequestBehavior.AllowGet);
        }


        public async Task<JsonResult> GetStudentSubjectGrade()
        {
            var getSubject = await _course.GetStudentSubjectGrade();
            return Json(getSubject, JsonRequestBehavior.AllowGet);
        }


        public async Task<JsonResult> GetStudentGradingList()
        {
            var getSubject = await _course.GetStudentGradingListInfoByStudent();
            return Json(getSubject, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> GetStudentGradingInfoByStudentId(StudentGradingRequestDto subjectDto)
        {
            var getSubject = await _course.GetStudentGradingInfoByStudentId(subjectDto);
            return Json(getSubject, JsonRequestBehavior.AllowGet);
        }

    }
}