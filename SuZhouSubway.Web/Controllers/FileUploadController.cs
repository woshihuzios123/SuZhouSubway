using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuZhouSubway.Web.Models.ViewModels;
using System;
using System.IO;
using System.Linq;

namespace SuZhouSubway.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public FileUploadController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// 文件上传
        /// </summary>
        /// <param name="forms"></param>
        /// <returns></returns>
        public FileUploadDto Upload([FromForm] IFormCollection forms)
        {
            if (forms?.Files == null || !forms.Files.Any())
            {
                return new FileUploadDto()
                {
                    Errno = 1,
                    Data = new string[] { }
                };
            }

            var webRootPath = _hostingEnvironment.WebRootPath;
            // 添加文件夹
            webRootPath = Path.Combine(webRootPath, "file");
            if (System.IO.File.Exists(webRootPath))
            {
                Directory.CreateDirectory(webRootPath);
            }

            var file = forms.Files.First();
            if (file.Length == 0)
                return new FileUploadDto()
                {
                    Errno = 1,
                    Data = new string[] { }
                };
            //生成随机名称
            string fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            FileInfo fileInfo = new FileInfo(Path.Combine(webRootPath, fileName));
            using (FileStream fs = new FileStream(fileInfo.ToString(), FileMode.Create))
            {
                // 保存到本地
                file.CopyTo(fs);
            }

            // 返回路径
            return new FileUploadDto()
            {
                Errno = 0,
                Data = new[] {"/file/" + fileName}
            };
        }
    }
}