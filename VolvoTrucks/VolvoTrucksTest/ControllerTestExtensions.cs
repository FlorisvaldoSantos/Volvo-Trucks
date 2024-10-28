using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace VolvoTrucksTest
{
    public static class ControllerTestExtensions
    {
        public static T EnsureHttpContext<T>(this T controller, ControllerContext? controllerContext = null,
            HttpContext? httpContext = null) where T : ControllerBase
        {
            controller.ControllerContext ??= controllerContext ?? new ControllerContext();
            controller.ControllerContext.HttpContext ??= httpContext ?? new DefaultHttpContext();

            return controller;
        }

    }
}
