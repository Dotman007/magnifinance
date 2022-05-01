using Magni.Core.Dto;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Collections.Generic;

namespace Magni.Hubs
{
    [HubName("courseHub")]
    public class CourseHub:Hub
    {
        public static void ListCourse(List<GetCourseResponseDto> courseDt)
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<CourseHub>();
            context.Clients.All.allCourses(courseDt);
        }
    }
}