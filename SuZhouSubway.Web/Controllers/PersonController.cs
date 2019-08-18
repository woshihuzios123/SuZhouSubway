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
    public class PersonController : ControllerBase
    {
        private readonly SubwayDbContext _context;

        /// <summary>
        /// constructor
        /// </summary>
        public PersonController(SubwayDbContext context)
        {
            _context = context;
        }


        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Person>> Get()
        {
            return await _context.Persons.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// 通过id 获取单个模型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<Person> Get(int id)
        {
            return await _context.Persons.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }

        // POST: api/Person
        [HttpPost]
        public async Task Post([FromBody] Person value)
        {
            await _context.Persons.AddAsync(value);
            await _context.SaveChangesAsync();
        }

        // PUT: api/Person/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Person value)
        {
            var data = await Get(id);
            if (data == null)
            {
                return;
            }
            else
            {
                data.Duties = value.Duties;
                data.Description = value.Description;
                data.HeadPhoto = value.HeadPhoto;
                data.JobNumber = value.JobNumber;
                data.Name = value.Name;
                data.Enabled = value.Enabled;
                data.Order = value.Order;
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

            _context.Persons.Remove(data);
            await _context.SaveChangesAsync();
        }
    }
}