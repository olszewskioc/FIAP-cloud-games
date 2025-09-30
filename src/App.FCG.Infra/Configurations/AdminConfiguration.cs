using App.FCG.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.FCG.Infra.Configurations
{
	public class AdminConfiguration : IEntityTypeConfiguration<Admin>
	{
		public void Configure(EntityTypeBuilder<Admin> builder)
		{
			builder.ToTable("Admin");
			builder.Property(u => u.Name).HasColumnType("VARCHAR(50)").IsRequired();
			builder.Property(u => u.LastName).HasColumnType("VARCHAR(50)").IsRequired();
			builder.Property(u => u.CreatedAt).HasColumnType("DATETIME").IsRequired().HasDefaultValueSql("GETDATE()");
			builder.Property(u => u.UpdatedAt).HasColumnType("DATETIME");
		}
	}
}
