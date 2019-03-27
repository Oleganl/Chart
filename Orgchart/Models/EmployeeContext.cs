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
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Reporter> Reporters { get; set; }
        public EmployeeContext(DbContextOptions<EmployeeContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        
    }
}
