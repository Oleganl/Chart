using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Orgchart.Models;

namespace Orgchart.Models
{
    public class EmployeeContext : DbContext
    {
        public DbSet<EmployeeTree> Employees { get; set; }
        public EmployeeContext(DbContextOptions<EmployeeContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeTree>(entity =>
            {
                entity
                .HasMany(e => e.Reporters)
                .WithOne(e => e.Manager)
                .HasForeignKey(e => e.ManagerId);
            });
        }
    }
}
