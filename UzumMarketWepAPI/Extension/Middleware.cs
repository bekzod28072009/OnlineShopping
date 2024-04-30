using Microsoft.EntityFrameworkCore;
using UzumMarket.DataAcces.AppDBContexts;

namespace UzumMarketWepAPI.Extension
{
    public static class Middleware
    {
        public static void AddDBConTextes(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(option =>
            option.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
