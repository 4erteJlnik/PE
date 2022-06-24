using Web1.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Web1.Infrastructure
{
    /// <summary>
    /// Конфигурация таблицы БД Post.
    /// </summary>
    public class PostConfiguration : IEntityTypeConfiguration<Postdto>
    {
        /// <inheritdoc />
        public void Configure(EntityTypeBuilder<Postdto> builder)
        {
            
            builder.ToTable(nameof(Postdto));
            builder.HasKey(p => p.ID);
            builder.Property(p => p.ID).ValueGeneratedOnAdd();
            builder.Property(p => p.DateOfCreate).HasConversion<DateTime>();
            builder.Property(p => p.Description).HasConversion<String>();
            builder.Property(p => p.Cost).HasConversion<int>();
            builder.Property(p => p.City).HasConversion<string>();
            builder.HasMany<PostCommentdto>(p => p.Comments)
                .WithOne(p => p.Post)
                .HasForeignKey(p => p.PostId)
                .OnDelete(DeleteBehavior.Cascade).IsRequired(false);
            
            builder.HasOne<Peopledto>(p => p.Creator)
                .WithMany(p => p.Posts)
                .HasForeignKey(p => p.CreatorId)
                .OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(x=>x.Category).WithMany(x=>x.Post).HasForeignKey(x=>x.CategoryId).IsRequired(false);
            
        }
    }
}