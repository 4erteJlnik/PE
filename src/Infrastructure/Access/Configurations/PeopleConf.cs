using Web1.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;

namespace Web1.Infrastructure
{
    /// <summary>
    /// Конфигурация таблицы БД Post.
    /// </summary>
    public class PeopleConfiguration : IEntityTypeConfiguration<Peopledto>
    {
        /// <inheritdoc />
        public void Configure(EntityTypeBuilder<Peopledto> builder)
        {
            builder.ToTable(nameof(Peopledto));
            builder.HasKey(p => p.ID);
            builder.Property(p => p.ID).ValueGeneratedOnAdd();
            builder.Property(p => p.DateOfCreate).HasConversion<DateTime>();
            builder.Property(p => p.Rating).HasConversion<short>();
            builder.Property(p => p.Avatar).HasConversion<String>();
            builder.HasMany<Postdto>(p => p.Posts)
                .WithOne(p => p.Creator)
                .HasForeignKey(p => p.CreatorId)
                .OnDelete(DeleteBehavior.Cascade).IsRequired(false);
            builder.HasMany<PostCommentdto>(p => p.Comments)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade).IsRequired(false);
            builder.HasOne<Peoplelogin>(e=>e.Peoplelogin).WithOne(e=>e.orig).HasForeignKey<Peoplelogin>(p=>p.Id);
        }
    }
}