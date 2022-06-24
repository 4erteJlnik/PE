using Web1.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Web1.Infrastructure
{
    /// <summary>
    /// Конфигурация таблицы БД Post.
    /// </summary>
    public class PostCommentConfiguration : IEntityTypeConfiguration<PostCommentdto>
    {
        /// <inheritdoc />
        public void Configure(EntityTypeBuilder<PostCommentdto> builder)
        {
            builder.ToTable(nameof(PostCommentdto));
            builder.HasKey(p => p.ID);
            builder.Property(p => p.ID).ValueGeneratedOnAdd();
            builder.Property(p => p.DateOfCreate).HasConversion<DateTime>();
            builder.Property(p => p.Description).HasConversion<String>();
            /// <summary>
            /// 1 ко многим, с внешним ключом User , при удалении которого удалить все PostComment
            /// </summary>
            builder.HasOne<Peopledto>(p => p.User)
                .WithMany(p => p.Comments)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.SetNull);
            /// <summary>
            /// 1 ко многим, с внешним ключом Post , при удалении которого удалить все PostComment
            /// </summary>
            builder.HasOne<Postdto>(p => p.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(p => p.PostId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}