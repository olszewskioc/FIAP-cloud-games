using App.FCG.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace App.FCG.Infra.Repository
{
	public class ApplicationDbContext : DbContext
	{
		private readonly IConfiguration _configuration;

		public DbSet<Game> Game { get; set; }
		public DbSet<Admin> Admin { get; set; }
		public DbSet<Client> Client { get; set; }

		public ApplicationDbContext()
		{

		}

		public ApplicationDbContext(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Core"));
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
		}
	}
}
