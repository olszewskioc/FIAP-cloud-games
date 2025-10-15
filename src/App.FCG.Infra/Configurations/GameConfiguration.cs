//using App.FCG.Core.Entities;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace App.FCG.Infra.Configurations
//{
//	public class GameConfiguration : IEntityTypeConfiguration<Game>
//	{
//		public void Configure(EntityTypeBuilder<Game> builder)
//		{
//			builder.ToTable("Game");
//			builder.HasKey(g => g.Id);
//			builder.Property(u => u.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWSEQUENTIALID()");
//			builder.Property(u => u.Name).HasColumnType("VARCHAR(100)").IsRequired();
//			builder.Property(u => u.Description).HasColumnType("VARCHAR(1000)").IsRequired();
//			builder.Property(u => u.PublisherName).HasColumnType("VARCHAR(50)").IsRequired();
//			builder.Property(u => u.ReleaseDate).HasColumnType("DATE").IsRequired();
//			builder.Property(u => u.Price).HasColumnType("DECIMAL").IsRequired();
//		}
//	}
//}
