using App.FCG.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace App.FCG.Infra.Repository
{
	public class ApplicationDbContext(IConfiguration configuration) : DbContext
	{
		public DbSet<Game> Game { get; set; }
		public DbSet<Admin> Admin { get; set; }
		public DbSet<Client> Client { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(configuration.GetConnectionString(""));
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
		}
	}
}
