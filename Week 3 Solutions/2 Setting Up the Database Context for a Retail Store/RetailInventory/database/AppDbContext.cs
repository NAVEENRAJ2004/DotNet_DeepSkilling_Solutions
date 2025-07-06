using Microsoft.EntityFrameworkCore;
using RetailInventory.models;

namespace RetailInventory.database
{
	public class AppDbContext : DbContext
	{
		public DbSet<product> Products => Set<product>();
		public DbSet<category> Categories => Set<category>();

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var connection = "Server=localhost;Database=RetailDb;Trusted_Connection=True;TrustServerCertificate=True;";
			optionsBuilder.UseSqlServer(connection);
		}
	}
}
