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
    public class ShopDbContext:DbContext
    {
        public readonly IConfiguration iconfiguration;

        public ShopDbContext(IConfiguration configuration)
        {
            iconfiguration=configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder option)
        {
            option.UseSqlServer(iconfiguration.GetConnectionString("CommandDBConnection"));
        }
        public DbSet<User> Users { get; set; }
    }
}
