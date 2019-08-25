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

    /// <summary>
    /// Front And BackEnd
    /// </summary>
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
        /// front-主页
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _context.Categories
                .Where(x => x.Enabled)
                .OrderBy(x => x.Order).ToListAsync();
            return View(categories);
        }


        /// <summary>
        /// front-文章列表
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public async Task<IActionResult> DetailList([FromRoute(Name = "id")] int categoryId)
        {
            var details = await _context.Details
                .Where(x => x.CategoryId == categoryId && x.Enabled)
                .OrderBy(x => x.Order)
                .ToListAsync();
            return View(details);
        }

        /// <summary>
        /// front-人员列表（人员风采）
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> PersonList()
        {
            var persons = await _context.Persons.Where(x => x.Enabled).OrderBy(x => x.Order).ToListAsync();
            return View(persons);
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

        public async Task<IActionResult> Person()
        {
            var persons = await _context.Persons.OrderBy(x => x.Order).ToListAsync();
            return View(persons);
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


        public async Task<IActionResult> ModifyPerson(int? id)
        {
            if (id == null || id == 0)
                return View();
            var person = await _context.Persons.SingleOrDefaultAsync(x => x.Id == id);
            return View(person);
        }


        /// <summary>
        /// front-获取详情的详情
        /// 预览
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


        /// <summary>
        /// front-人员详情（员工风采详情）
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> PersonDetails(int id)
        {
            var person = await _context.Persons.SingleOrDefaultAsync(x => x.Id == id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

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