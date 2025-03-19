using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace IDP.Infra.Data
{
    public class ShopQueryDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public ShopQueryDbContext(IConfiguration configuration)
        {
            Configuration = configuration;

        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to postgres with connection string from app settings
            options.UseSqlServer(Configuration.GetConnectionString("QueryDBConnection"));
        }
        public DbSet<User> Users { get; set; }
    }
}
