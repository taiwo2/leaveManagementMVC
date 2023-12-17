using LeaveManagement.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagement.RolesEntities
{
	public class UserSeedConfiguration : IEntityTypeConfiguration<Employee>
	{
		public void Configure(EntityTypeBuilder<Employee> builder)
		{
			var hasher= new PasswordHasher<Employee>();
			builder.HasData(
				new Employee
				{
					Id = "6d77d78b9d7d-1c3e-449d-f66e1234",
					Email = "adminsson@hotmail.com",
					NormalizedEmail = "ADMINSSON@HOTMAIL.COM",
					NormalizedUserName = "ADMINSSON@HOTMAIL.COM",
					UserName = "adminsson@hotmail.com",
					FirstName = "Admin",
					LastName = "Adminsson",
					PasswordHash=hasher.HashPassword(null, "P@ssword1"),
					EmailConfirmed=true
				},
				new Employee
				{
					Id = "f66e1234-1c3e-449d-80c7-6d77d7",
					Email = "usersson@hotmail.com",
					NormalizedEmail = "USERSSON@HOTMAIL.COM",
					NormalizedUserName = "USERSSON@HOTMAIL.COM",
					UserName = "usersson@hotmail.com",
					FirstName = "User",
					LastName = "Usersson",
					PasswordHash = hasher.HashPassword(null, "P@ssword1"),
					EmailConfirmed = true
				}
				);

		}
	}
}

		