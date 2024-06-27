using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using xyzR_Employee_API.Model;

namespace xyzR_Employee_API.Data
{
    public class xyzR_Employee_APIContext : DbContext
    {
        public xyzR_Employee_APIContext (DbContextOptions<xyzR_Employee_APIContext> options)
            : base(options)
        {
        }

        public DbSet<xyzR_Employee_API.Model.Salary> Salary { get; set; } = default!;

        public DbSet<xyzR_Employee_API.Model.Employee>? Employee { get; set; }
    }
}
