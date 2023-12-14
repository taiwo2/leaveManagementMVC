using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace LeaveManagement.Data
{
	public class ApplicationDbContext : IdentityDbContext<Employee>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
		public DbSet<LeaveType> LeaveTypes { get; set; }
		public DbSet<LeaveAllocation> LeaveAllLocations { get; set; }

	}
}

// dotnet aspnet-codegenerator controller -name ExampleController -outDir Controllers --no-build
// then install 
// Add Microsoft.VisualStudio.Web.CodeGeneration.Design 