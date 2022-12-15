using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdvApp.Application.Interfaces;
using UdvApp.Domain;
using UdvApp.Persistence.EntityTypeConfigurations;

namespace UdvApp.Persistence
{
    public class UdvAppDbContext : DbContext, IUdvAppDbContext
    {
        public DbSet<UserTask> UserTasks { get; set; }
        public DbSet<Faculty> Faculties { get; set; }

        public UdvAppDbContext(DbContextOptions<UdvAppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserTaskConfiguration());
            modelBuilder.ApplyConfiguration(new FacultyConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
