using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuZhouSubway.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using SuZhouSubway.Model.Data;

namespace SuZhouSubway.Web.Controllers
{
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

        // POST: api/Category
        [HttpPost]
        public async Task Post([FromBody] Category value)
        {
            await _context.Categories.AddAsync(value);
            await _context.SaveChangesAsync();
        }

        // PUT: api/Category/5
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
            }

            _context.Update(data);
            await _context.SaveChangesAsync();
        }

        // DELETE: api/ApiWithActions/5
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