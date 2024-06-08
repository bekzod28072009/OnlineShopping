using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using UzumMarket.DataAcces.AppDBContexts;
using UzumMarket.DataAcces.IRepository;
using UzumMarket.DataAcces.Repository;
using UzumMarket.Domain.Entity;
using UzumMarket.Service.IServices;
using UzumMarket.Service.Services;

namespace UzumMarketWepAPI.Extension
{
    public static class Middleware
    {
        public static void AddDBConTextes(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(option =>
            option.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        }

        public static void AddRepository(this IServiceCollection services)
        {
            services.AddTransient<IGenericRepository<Item>, GenericRepository<Item>>();
            services.AddTransient<IGenericRepository<Order>, GenericRepository<Order>>();
            services.AddTransient<IGenericRepository<Users>, GenericRepository<Users>>();
        }

        public static void AddService(this IServiceCollection services)
        {
            services.AddTransient<IItemService, ItemService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IUsersService, UsersService>();
        }
    }
}
