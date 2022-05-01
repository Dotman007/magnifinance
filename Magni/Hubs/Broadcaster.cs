using Magni.Core.Interface;
using Magni.Core.Services;

namespace Magni.Hubs
{
    public class Broadcaster:IBroadcaster
    {
        private readonly ICourse _course;
        public Broadcaster(ICourse _course)
        {
            this._course = _course;
        }
        public void BroadcastCourses()
        {
            var courses = _course.CourseList().Result;
            CourseHub.ListCourse(courses);
        }
    }
}