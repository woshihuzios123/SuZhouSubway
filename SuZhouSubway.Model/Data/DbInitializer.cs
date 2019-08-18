using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;

namespace SuZhouSubway.Model.Data
{
    public static class DbInitializer
    {
        public static async Task Initialize(SubwayDbContext context)
        {
            if (!context.Database.GetService<IRelationalDatabaseCreator>().Exists())
            {
                await context.Database.MigrateAsync(); // 迁移数据库
            }
            else
            {
                await context.Database.EnsureCreatedAsync();// 初始化数据库
            }
        }
    }
}