using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace Titan.Entity
{
    public class TitanDbContext:DbContext
    {
        
        public TitanDbContext(DbContextOptions options) : base(options)
        {

        }

        public TitanDbContext()
        {
           
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=DESKTOP-KK1QB16;Database=TitanDb;Trusted_Connection=True");
            base.OnConfiguring(builder);
        }

        public DbSet<TestEntity> TestEntitys { get; set; }
    }
}

