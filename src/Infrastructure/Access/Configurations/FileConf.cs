using Web1.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Web1.Infrastructure
{
    /// <summary>
    /// Конфигурация таблицы БД Post.
    /// </summary>
    public class FileConfiguration : IEntityTypeConfiguration<Filedto>
    {
        /// <inheritdoc />
        public void Configure(EntityTypeBuilder<Filedto> builder)
        {
            
            builder.ToTable(nameof(Filedto));
            builder.HasKey(x=>x.ID);
            builder.Property(x=>x.ID).ValueGeneratedOnAdd();
            builder.HasOne(x=>x.Author).WithMany(x=>x.Files).HasForeignKey(x=>x.Autorid);
            builder.HasOne(x=>x.post).WithMany(x=>x.Files).HasForeignKey(x=>x.postid);
            builder.Property(x=>x.Lenght);
            
        }
    }
}