using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using UsersAndDepartments.Entities;

namespace UsersAndDepartments.Contexts
{
	public sealed class UserContext : DbContext
	{
		public UserContext() { }

		public UserContext(DbContextOptions<UserContext> options)
			: base(options)
		{ }

		public DbSet<User> Users { get; set; }

		public DbSet<Department> Departments { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				IConfigurationRoot configuration = new ConfigurationBuilder()
					.SetBasePath(Directory.GetCurrentDirectory())
					.AddJsonFile("appsettings.json")
					.Build();
				optionsBuilder.UseSqlServer(configuration.GetConnectionString("DbConnection"));
			}
		}
	}
}
