using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdminApprovalBack.Controllers.Business
{
    public class ImageController : ControllerBase
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public ImageController(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        public IActionResult Upload(IFormFile file)
        {
            while (true)
            {
                var filename = Path.GetRandomFileName();
                var filepath = Path.Combine(webHostEnvironment.ContentRootPath, "user_upload", filename);
                if (System.IO.File.Exists(filepath)) continue;
                using var fs = System.IO.File.OpenWrite(filepath);
                using var readStream = file.OpenReadStream();
                readStream.CopyTo(fs);
                return Success(filepath);
            }
        }

        [HttpGet("{filename}")]
        public IActionResult Read(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename)) return StatusCode(404);
            var filepath = Path.Combine(webHostEnvironment.ContentRootPath, "user_upload", filename);
            if (!System.IO.File.Exists(filepath)) return StatusCode(404);
            using var fs = System.IO.File.OpenRead(filepath);
            return File(fs, "application/octet-stream", filename);
        }
    }
}