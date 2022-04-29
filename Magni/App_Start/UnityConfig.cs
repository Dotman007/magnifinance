using Magni.Core.Interface;
using Magni.Core.Services;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace Magni
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ICourse, CourseService>();
            container.RegisterType<ITeacher, TeacherService>();
            container.RegisterType<IStudent, StudentService>();
            container.RegisterType<ISubject, SubjectService>();
            container.RegisterType<IEnrollment, EnrollmentService>();
            container.RegisterType<IStudentGrading, StudentGradingService>();
            container.RegisterType<IGrade, GradeService>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}