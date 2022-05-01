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
    public class SubjectController : Controller
    {
        private readonly ISubject _subject;
        public SubjectController(ISubject _subject)
        {
            this._subject = _subject;
        }  
        
        public async Task<JsonResult> CreateSubject(CreateSubjectDto subject)
        {
            if (!ModelState.IsValid)
            {
                return Json(ModelState);
            }
            var createSubject = await _subject.CreateSubject(subject);
            return Json(createSubject, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> GetSubjectById(GetSubjectRequestDto subject)
        {
            var getSubject = await _subject.GetSubjectById(subject);
            return Json(getSubject, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> AllSubjects(GetSubjectRequestDto subject)
        {
            var getSubject = await _subject.AllSubjects();
            return Json(getSubject, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddSubject()
        {
            return View();
        }
        public async Task<JsonResult> UpdateSubject(UpdateSubjectDto subject)
        {
            if (!ModelState.IsValid)
            {
                return Json(ModelState);
            }
            var updateSubject = await _subject.UpdateSubject(subject);
            return Json(updateSubject, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> DeleteSubject(DeleteSubjectDto subject)
        {
            if (!ModelState.IsValid)
            {
                return Json(ModelState);
            }
            var createSubject = await _subject.DeleteSubject(subject);
            return Json(createSubject, JsonRequestBehavior.AllowGet);
        }
    }
}