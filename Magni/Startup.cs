using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Owin;
using Microsoft.Owin;
[assembly: OwinStartup(typeof(Magni.Startup))]
namespace Magni
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Any connection or hub wire up and configuration should go here
            app.MapSignalR();
        }
    }
}