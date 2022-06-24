using Web1.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Web1.Infrastructure
{
    /// <summary>
    /// Конфигурация таблицы БД Post.
    /// </summary>
    public class CategoryConfiguration : IEntityTypeConfiguration<Categorydto>
    {
        /// <inheritdoc />
        public void Configure(EntityTypeBuilder<Categorydto> builder)
        {
            
            builder.ToTable(nameof(Categorydto));
            builder.HasKey(x=>x.ID);
            builder.Property(x=>x.ID).ValueGeneratedOnAdd();
            builder.Property(x=>x.Name).HasConversion<string>();
            //builder.HasMany(x=>x.Post).WithOne(x=>x.Category).HasForeignKey(x=>x.CategoryId);
            
        }
    }
}