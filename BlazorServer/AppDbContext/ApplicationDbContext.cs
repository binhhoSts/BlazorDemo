using BlazorServer.Entity;
using BlazorServer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServer.AppDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<AppPasswordEntity> AppPasswords { get; set; }
        public DbSet<BrowserEntity> Browsers { get; set; }
    }
}
