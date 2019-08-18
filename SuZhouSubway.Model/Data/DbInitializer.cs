using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Threading.Tasks;

namespace SuZhouSubway.Model.Data
{
    public static class DbInitializer
    {
        public static async Task Initialize(SubwayDbContext context)
        {
              
            await context.Database.EnsureCreatedAsync();

            if (await context.Details.AnyAsync() || await context.Categories.AnyAsync())
            {
                return;
            }


            // 初始化数据
            var details = new Detail[] { };

            if (details.Any())
            {
                await context.Details.AddRangeAsync(details);
                await context.SaveChangesAsync();
            }


            var category = new Category[] { };

            if (category.Any())
            {
                await context.Categories.AddRangeAsync(category);
                await context.SaveChangesAsync();
            }
        }
    }
}