using Web1.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Web1.Infrastructure
{
    /// <summary>
    /// Конфигурация таблицы БД Рейтинг.
    /// </summary>
    public class RatingConfiguration : IEntityTypeConfiguration<RatingDB>
    {
        /// <inheritdoc />
        public void Configure(EntityTypeBuilder<RatingDB> builder)
        {
            
            builder.ToTable(nameof(RatingDB));
            builder.HasKey(x=>x.Senderid);
            builder.HasKey(x=>x.Recipientid);
            builder.HasOne(x=>x.Sender).WithMany(x=>x.Ratingobj).HasForeignKey();
            builder.HasOne(x=>x.Recipient).WithMany(x=>x.Ratingobj).HasForeignKey();
        }
    }
}