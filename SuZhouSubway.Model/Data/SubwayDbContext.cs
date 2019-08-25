using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SuZhouSubway.Model.Data
{
    /// <summary>
    /// 数据库连接对象
    /// </summary>
    public class SubwayDbContext : DbContext
    {
        public SubwayDbContext(DbContextOptions<SubwayDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// 分类表
        /// </summary>
        public DbSet<Category> Categories { get; set; }

        /// <summary>
        /// 详情表
        /// </summary>
        public DbSet<Detail> Details { get; set; }

        /// <summary>
        /// 人员表
        /// </summary>
        public DbSet<Person> Persons { get; set; }


    }
}