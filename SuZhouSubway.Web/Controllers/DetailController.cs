using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuZhouSubway.Model;
using SuZhouSubway.Model.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuZhouSubway.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings]
    public class DetailController : ControllerBase
    {
        private readonly SubwayDbContext _context;

        /// <summary>
        /// constructor
        /// </summary>
        public DetailController(SubwayDbContext context)
        {
            _context = context;
        }


        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        public async Task<IEnumerable<Detail>> Get()
        {
            return await _context.Details.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// 通过id 获取单个模型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<Detail> Get(int id)
        {
            return await _context.Details.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }

        // POST: api/Detail
        [HttpPost]
        public async Task Post([FromBody] Detail value)
        {
            await _context.Details.AddAsync(value);
            await _context.SaveChangesAsync();
        }

        // PUT: api/Detail/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Detail value)
        {
            var data = await Get(id);
            if (data == null)
            {
                return;
            }
            else
            {
                data.Title = value.Title;
                data.CategoryId = value.CategoryId;
                data.Contents = value.Contents;
                data.CoverImage = value.CoverImage;
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

            _context.Details.Remove(data);
            await _context.SaveChangesAsync();
        }
    }
}