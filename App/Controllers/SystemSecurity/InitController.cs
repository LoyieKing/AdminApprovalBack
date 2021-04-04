using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApprovalBack.Controllers.SystemSecurity
{
    public class InitController : ControllerBase
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public InitController(IWebHostEnvironment webHostEnvironment,
            )
        {
            if (!webHostEnvironment.IsDevelopment())
            {
                HttpContext.Response.StatusCode = 404;
                throw new Exception("Unknown page");
            }

            this.webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Init()
        {

        }
    }
}
