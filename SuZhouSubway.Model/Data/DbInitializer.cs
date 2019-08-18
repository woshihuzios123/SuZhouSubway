using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace SuZhouSubway.Model.Data
{
    public static class DbInitializer
    {
        public static async Task Initialize(SubwayDbContext context)
        {
            if ((await context.Database.GetPendingMigrationsAsync()).Any())
            {
                await context.Database.MigrateAsync();
            }
        }
    }
}