using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UzumMarket.Domain.Entity;

namespace UzumMarket.DataAcces.AppDBContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        public virtual DbSet<Item> Items { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<Users> Users { get; set; }
    }
}
