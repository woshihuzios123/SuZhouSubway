using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuZhouSubway.Model;
using SuZhouSubway.Model.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuZhouSubway.Web.Controllers
{
    /// <summary>
    /// Category Api
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings]
    public class CategoryController : ControllerBase
    {
        private readonly SubwayDbContext _context;

        /// <summary>
        /// constructor
        /// </summary>
        public CategoryController(SubwayDbContext context)
        {
            _context = context;
        }


        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Category>> Get()
        {
            return await _context.Categories.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// 通过id 获取单个模型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<Category> Get(int id)
        {
            return await _context.Categories.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }


        /// <summary>
        /// 保存category
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Post([FromBody] Category value)
        {
            await _context.Categories.AddAsync(value);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// 更新category
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Category value)
        {
            var data = await Get(id);
            if (data == null)
            {
                return;
            }
            else
            {
                data.Name = value.Name;
                data.Enabled = value.Enabled;
                data.Order = value.Order;
                data.Description = value.Description;
            }

            _context.Update(data);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// 删除category
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var data = await Get(id);
            if (data == null)
            {
                return;
            }

            _context.Categories.Remove(data);
            await _context.SaveChangesAsync();
        }
    }
}