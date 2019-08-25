using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuZhouSubway.Model;
using SuZhouSubway.Model.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuZhouSubway.Web.Controllers
{
    /// <summary>
    /// Detail Api
    /// </summary>
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
        [HttpGet]
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

        /// <summary>
        /// 添加 详情
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Post([FromBody] Detail value)
        {
            await _context.Details.AddAsync(value);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// 更新详情
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns></returns>
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
                data.CategoryId = value.CategoryId;
                data.Title = value.Title;
                data.Order = value.Order;
                data.Enabled = value.Enabled;
                data.Contents = value.Contents;
                /*data.CoverImage = value.CoverImage;*/
            }

            _context.Update(data);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// 删除 详情
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

            _context.Details.Remove(data);
            await _context.SaveChangesAsync();
        }
    }
}