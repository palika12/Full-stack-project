using EmployeeDetailsWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace EmployeeDetailsWebAPI.Data
{
    public class EmployeeCRUDappDbContext : DbContext
    {
        public EmployeeCRUDappDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
