using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace FCG.Infra.Repository
{
	public class ApplicationDbContext : DbContext
	{
		private readonly IConfiguration _configuration;

		//public DbSet<Game> Game { get; set; }

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
