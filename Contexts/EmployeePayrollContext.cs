using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//added libraries
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using IdentityAndEntityFramework.Models;

namespace IdentityAndEntityFramework.Contexts
{
	public class EmployeePayrollContext : DbContext
	{
		// Database Context
		public EmployeePayrollContext(DbContextOptions<EmployeePayrollContext> options) : base(options)
		{

		}

		// Database Table
		public DbSet<EmployeePayrollModel> tblEmployeePayroll { get; set; }
	}

	

}
