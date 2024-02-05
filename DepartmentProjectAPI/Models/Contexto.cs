using Microsoft.EntityFrameworkCore;

namespace DepartmentProjectAPI.Models
{
    public class Contexto : DbContext
    {
        public DbSet<Department> Departments { get; set; }

        public DbSet<Employee> Employees { get; set; }


        public Contexto(DbContextOptions<Contexto> opcoes) : base(opcoes)
        {

        }

    }
}
