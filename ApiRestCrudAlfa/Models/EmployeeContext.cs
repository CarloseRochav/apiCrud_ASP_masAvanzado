using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// Dont forge install :
// Microsoft.EntityframeworkCore.Sql
// Microsodt.EntityframeworkCore.Tools

namespace ApiRestCrudAlfa.Models
{
    public class EmployeeContext:DbContext //Para decir que usaremos el Entity Framework y usar sus metodos
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; } //Creacion de tabla en nuestra base de datos
    }
}
