using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SuZhouSubway.Model.Data;
using SuZhouSubway.Web.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SuZhouSubway.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly SubwayDbContext _context;

        /// <summary>
        /// constructor
        /// </summary>
        public HomeController(SubwayDbContext context)
        {
            _context = context;
        }


        /// <summary>
        /// 主页
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _context.Categories.OrderBy(x => x.Order).ToListAsync();
            return View(categories);
        }

        public async Task<IActionResult> DetailList([FromRoute(Name = "id")]int categoryId)
        {
            /*var category = await _context.Categories.Include(x => x.Details)
                .FirstOrDefaultAsync(x => x.Id == categoryId);
            var details = category.Details;*/
            var details = await _context.Details.Where(x => x.CategoryId == categoryId).ToListAsync();
            return View(details);
        }


        /// <summary>
        /// 详情 列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Detail()
        {
            var details = await _context.Details.OrderBy(x => x.Order).ToListAsync();
            return View(details);
        }

        /// <summary>
        /// 栏目列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Category()
        {
            var categories = await _context.Categories.OrderBy(x => x.Order).ToListAsync();
            return View(categories);
        }

        /// <summary>
        /// 添加，更新栏目
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ModifyCategory(int? id)
        {
            if (id != null && id != 0)
            {
                var category = await _context.Categories.SingleOrDefaultAsync(x => x.Id == id);
                return View(category);
            }

            return View();
        }


        /// <summary>
        /// 添加更新详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ModifyDetail(int? id)
        {
            var categories = await _context.Categories.ToListAsync();
            //生成select
            List<SelectListItem> items;
            if (id != null && id != 0)
            {
                var details = await _context.Details.SingleOrDefaultAsync(x => x.Id == id);
                if (details == null)
                {
                    return View();
                }

                items = categories.Select(x => new SelectListItem(x.Name, x.Id.ToString(), x.Id == details.CategoryId))
                    .ToList();
                ViewBag.Categories = items;
                return View(details);
            }

            items = categories.Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();
            ViewBag.Categories = items;
            return View();
        }


        /// <summary>
        /// 获取详情的详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> DetailDetails(int id)
        {
            var detail = await _context.Details.SingleOrDefaultAsync(x => x.Id == id);
            if (detail == null)
            {
                return NotFound();
            }

            return View(detail);
        }

        /*/// <summary>
        /// 获取栏目详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> CategoryDetails(int id)
        {
            var category = await _context.Categories.SingleOrDefaultAsync(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }*/

        /// <summary>
        /// 错误页面
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}